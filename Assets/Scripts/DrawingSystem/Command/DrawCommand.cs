using UnityEngine;
using DrawingSystem;

public class DrawCommand : ICommand
{
    private readonly Vector2[] positions;
    private readonly Color[] colors;

    public DrawCommand(Vector2[] positions, Color[] colors)
    {
        this.positions = positions;
        this.colors = colors;
    }

    public void Execute()
    {
        int[] locations = new int[positions.Length];
        for (int i = 0; i < positions.Length; i++)
        {
            Vector2Int textureSpace = CanvasController.Instance.GetPixelFromScreenSpace(positions[i]);
            locations[i] = textureSpace.y * 512 + textureSpace.x;
        }
        CanvasController.Instance.DrawPixels(locations, colors);
    }

    public void Undo()
    {
        // Create an array with the same positions but transparent color for undoing the draw
        Color[] undoColors = new Color[colors.Length];
        for (int i = 0; i < undoColors.Length; i++)
        {
            undoColors[i] = new Color(colors[i].r, colors[i].g, colors[i].b, 0); // Set alpha to 0 to "erase"
        }
        ExecuteUndo(undoColors);
    }

    private void ExecuteUndo(Color[] undoColors)
    {
        int[] locations = new int[positions.Length];
        for (int i = 0; i < positions.Length; i++)
        {
            Vector2Int textureSpace = CanvasController.Instance.GetPixelFromScreenSpace(positions[i]);
            locations[i] = textureSpace.y * 512 + textureSpace.x;
        }
        CanvasController.Instance.DrawPixels(locations, undoColors);
    }
}
