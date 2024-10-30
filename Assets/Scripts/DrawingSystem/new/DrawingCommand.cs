using UnityEngine;

namespace DrawingSystem
{
    public class DrawingCommand
    {
        public Vector2Int[] Points { get; }
        public Color[] Before { get; }
        public Color[] After { get; }

        public DrawingCommand(Vector2Int[] points, Color[] before, Color[] after)
        {
            Points = points;
            Before = before;
            After = after;
        }

        public void Undo() => CanvasController.Instance.DrawPixels(Before);
        public void Redo() => CanvasController.Instance.DrawPixels(After);
    }
}