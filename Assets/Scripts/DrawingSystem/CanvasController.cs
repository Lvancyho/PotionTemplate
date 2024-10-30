using Managers;
using System.Collections.Generic;
using UnityEngine;

namespace DrawingSystem
{
    public class CanvasController : MonoBehaviour
    {
        public static CanvasController Instance { get; private set; }
        private IDrawingTool currentTool;
        private Stack<DrawingCommand> undoStack = new Stack<DrawingCommand>();
        private Stack<DrawingCommand> redoStack = new Stack<DrawingCommand>();

        [SerializeField] private DrawingCanvas canvas;
        private string fileLocation;
        public Color color;

        private void Awake()
        {
            if (Instance && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            PlayerControls.DrawingScreen(this);
            PlayerControls.EnterDrawing();
        }

        public void ClearCanvas()
        {
            // Save the current state of the canvas for undo
            Color[] currentSnapshot = canvas.GetSnapshot();
            int canvasPixelCount = 512 * 256;

            // Create a new color array filled with a blank color (e.g., white)
            Color[] clearColor = new Color[canvasPixelCount];
            for (int i = 0; i < clearColor.Length; i++)
            {
                clearColor[i] = Color.white; // or any default color you want for clearing
            }

            // Update the canvas with the clear color
            canvas.UpdateImage(clearColor);

            // Push the clear command to the undo stack
            var clearCommand = new DrawingCommand(new Vector2Int[0], currentSnapshot, clearColor);
            AddUndoCommand(clearCommand);
        }

        public void SetCurrentTool(MonoBehaviour tool)
        {
            currentTool?.OnDeselected();
            currentTool = tool as IDrawingTool;
            currentTool?.OnSelected();

            if (currentTool == null) Debug.LogWarning("No IDrawingTool attached");
            else Debug.Log("Selected: " + currentTool.GetType());
        }

        public void AddUndoCommand(DrawingCommand command)
        {
            undoStack.Push(command);
            redoStack.Clear();
        }

        public void Undo()
        {
            if (undoStack.Count > 0)
            {
                var command = undoStack.Pop();
                command.Undo();
                redoStack.Push(command);
            }
        }

        public void Redo()
        {
            if (redoStack.Count > 0)
            {
                var command = redoStack.Pop();
                command.Redo();
                undoStack.Push(command);
            }
        }

        public void BeginPrimary(Vector2 readValue) => currentTool?.OnLeftClickBegin(readValue);
        public void UpdatePrimary(Vector2 readValue) => currentTool?.OnLeftClickUpdated(readValue);
        public void EndPrimary(Vector2 readValue) => currentTool?.OnLeftClickEnd(readValue);
        public void DrawPixels(int[] locations, Color[] colors) => canvas.UpdateImage(locations, colors);
        public void DrawPixels(Color[] colors) => canvas.UpdateImage(colors);
        public Color[] Snapshot() => canvas.GetSnapshot();
        public Vector2Int GetPixelFromScreenSpace(Vector2 point) => canvas.GetPixelFromScreenSpace(point);
    }
}