using System.Collections.Generic;
using UnityEngine;

namespace DrawingSystem
{
    public class DrawTool : MonoBehaviour, IDrawingTool
    {
        [SerializeField] private int brushSize;
        [SerializeField, Range(0,1)] private float fallOff = 0.5f; private Color color;
        //private List<Vector2> points;
        Vector2 point;
        
        
        //When we begin our press, we must begin transacting / recording
        public void OnLeftClickBegin(Vector2 location)
        {
            //We can assume once we begin drawing, that the colour will remain constant.
            color = CanvasController.Instance.color;
        }
        
        //while the mouse is updating, draw over each tile
        public void OnLeftClickUpdated(Vector2 location)
        {
            //We don't want to add tiny changes.
            //Better to use a list vs a hashset if adding "Transparency" in the future.
            Debug.Log(location);
            if ((point - location).sqrMagnitude > 1)
            {
              point = location;
              CanvasController.Instance.DrawPixel(location, color, brushSize, fallOff);
            }
            
            
            
        }

        //When we end our press, we should send our transaction as a command
        public void OnLeftClickEnd(Vector2 location)
        {
            
            
        }
    }
}
