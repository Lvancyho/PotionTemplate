using System;
using System.Threading.Tasks;
using Managers;
using UnityEngine;

namespace DrawingSystem
{
    public class CanvasController : MonoBehaviour
    {
        //Singleton
        public static CanvasController Instance { get; private set; }

        //Liskov Substitution Principle, use an interface instead of a direct object.
        private IDrawingTool currentTool;
        
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

        public void SetCurrentTool(MonoBehaviour tool)
        {
            currentTool?.OnDeselected();
            currentTool = tool as IDrawingTool;
            currentTool?.OnSelected();
            
            if(currentTool == null) Debug.LogWarning("No IDrawingTool attached");
            else Debug.Log("Selected: " + currentTool.GetType());
        }


        //Truthfully, we should check if we're in range before doing this.
        public void BeginPrimary(Vector2 readValue) => currentTool?.OnLeftClickBegin(readValue); 
        public void UpdatePrimary(Vector2 readValue) => currentTool?.OnLeftClickUpdated(readValue);
        public void EndPrimary(Vector2 readValue) => currentTool?.OnLeftClickEnd(readValue);
        public void BeginSecondary(Vector2 readValue) => currentTool?.OnRightClickBegin(readValue);
        public void UpdateSecondary(Vector2 readValue) => currentTool?.OnRightClickUpdated(readValue);
        public void EndSecondary(Vector2 readValue) => currentTool?.OnRightClickEnd(readValue);
        
        public void Undo()
        {
            
        }

        public void Redo()
        {
            
        }

        public async void Save()
        {
            if (fileLocation != null) canvas.SaveCanvasToTexture(fileLocation);
            else await DeclareFileName();
        }

        public Task DeclareFileName()
        {
            //Do whatever we need to do to save...
            return Task.CompletedTask;
        }

        public void Load(string fileLocation)
        {
            canvas.Load(fileLocation);
        }

        public void DrawPixel(Vector2 location, Color color1, int brushSize, float fallOff)
        {
            canvas.UpdateImage(location, color1, brushSize, fallOff);
        }
    }
}