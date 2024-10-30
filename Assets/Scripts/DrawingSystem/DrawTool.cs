using System.Collections.Generic;
using UnityEngine;

namespace DrawingSystem
{
    public class DrawTool : MonoBehaviour, IDrawingTool
    {
        [SerializeField] private int brushSize;
        [SerializeField, Range(0, 1)] private float fallOff = 0.5f;
        private Color color;
        private Vector2 point;
        private List<Vector2Int> drawnPoints = new List<Vector2Int>();
        private Color[] initialSnapshot;

        public void OnLeftClickBegin(Vector2 location)
        {
            color = CanvasController.Instance.color;
            drawnPoints.Clear();
            initialSnapshot = CanvasController.Instance.Snapshot();
        }

        public void OnLeftClickUpdated(Vector2 location)
        {
            if ((point - location).sqrMagnitude > 1)
            {
                point = location;
                int radius = brushSize / 2;
                int count = brushSize * brushSize + radius * 4 + 1;
                int[] locations = new int[count];
                Color[] colors = new Color[count];
                Vector2Int textureSpace = CanvasController.Instance.GetPixelFromScreenSpace(point);
                int iterator = 0;

                for (int y = -radius; y <= radius; y++)
                {
                    for (int x = -radius; x <= radius; x++)
                    {
                        int pixelX = textureSpace.x + x;
                        int pixelY = textureSpace.y + y;
                        if (pixelX >= 0 && pixelX < 512 && pixelY >= 0 && pixelY < 256)
                        {
                            float distance = Mathf.Sqrt(x * x + y * y);
                            Color c = color;
                            c.a *= Mathf.Clamp01(1 - (distance / radius) * (fallOff + 0.5f));
                            locations[iterator] = pixelY * 512 + pixelX;
                            colors[iterator] = c;
                            drawnPoints.Add(new Vector2Int(pixelX, pixelY)); // Store drawn points
                        }
                        iterator += 1;
                    }
                }

                CanvasController.Instance.DrawPixels(locations, colors);
            }
        }

        public void OnLeftClickEnd(Vector2 location)
        {
            if (drawnPoints.Count > 0)
            {
                var transaction = new DrawingCommand(drawnPoints.ToArray(), initialSnapshot, CanvasController.Instance.Snapshot());
                CanvasController.Instance.AddUndoCommand(transaction);
            }
        }
    }
}