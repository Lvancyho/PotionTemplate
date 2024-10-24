using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DrawingSystem
{
    public class DrawingCanvas : MonoBehaviour
    {
        private static readonly int Label = Shader.PropertyToID("_Label");
        private RawImage drawingArea;    // The UI RawImage where the texture will be displayed
        [SerializeField] private Texture2D inputImage;    // The MxN image we want to compress
        [SerializeField] private MeshRenderer mesh;    // The MxN image we want to compress
    
        private Texture2D texture;
        private float aspectRatio;
        private Material m;

        private void Awake()
        {
            drawingArea = transform.GetChild(0).GetComponent<RawImage>();
            texture = new Texture2D(512, 512);
            texture.SetPixels(inputImage.GetPixels());
            texture.Apply();
            drawingArea.texture = texture;
            drawingArea.uvRect = new Rect(0f, 0.5f, 1f, 0.5f);
            m = mesh.material;
            m.SetTexture(Label, texture);
        }

        private void Start()
        {
            aspectRatio = drawingArea.rectTransform.rect.width / drawingArea.rectTransform.rect.height;
        }
        
        //When falloff is a percentage from the center, 1 means there will be no fall off
        public void UpdateImage(Vector2 point, Color c, int size = 1, float fallOff = 1)
        {
            // Get the current texture colors
            Color[] colors = texture.GetPixels(0, 256, 512, 256);

            // Convert the screen space point to texture space (adjusted for anchored position)
            Vector2Int textureSpace = GetPixelFromScreenSpace(point - drawingArea.rectTransform.anchoredPosition / 2);
            Debug.Log(textureSpace);

            // Iterate over a square bounding box around the circle
            int radius = size / 2;
            for (int y = -radius; y <= radius; y++)
            {
                for (int x = -radius; x <= radius; x++)
                {
                    int pixelX = textureSpace.x + x;
                    int pixelY = textureSpace.y + y;

                    // Check if the current pixel is within the bounds of the texture
                    if (pixelX >= 0 && pixelX < 512 && pixelY >= 0 && pixelY < 256)
                    {
                        // Calculate the distance from the center point
                        float distance = Mathf.Sqrt(x * x + y * y);

                        // If the distance is within the radius, apply the color with falloff
                        if (distance <= radius)
                        {
                            // Calculate the falloff (1.0 means no falloff, smaller values create more falloff)
                            float falloffFactor = Mathf.Clamp01(1 - (distance / radius) * fallOff);

                            // Get the current pixel color
                            int index = pixelY * 512 + pixelX;
                            Color currentColor = colors[index];

                            // Blend the color with the current texture color based on falloff
                            Color blendedColor = Color.Lerp(currentColor, c, falloffFactor);

                            // Update the pixel color in the array
                            colors[index] = blendedColor;
                        }
                    }
                }
            }

            // Apply the updated colors to the texture
            texture.SetPixels(0, 256, 512, 256, colors);
            texture.Apply();
        }

        private Vector2Int GetPixelFromScreenSpace(Vector2 screenPoint)
        {
            // Convert screen coordinates to texture coordinates
            int x = Mathf.RoundToInt(screenPoint.x * 512 / drawingArea.rectTransform.rect.width);
            int y = Mathf.RoundToInt(screenPoint.y * 256 / drawingArea.rectTransform.rect.height);

            return new Vector2Int(x, y);
        }


        /*
         * In order to save or update the image, consider that we have a UI image of dimensions M and N
         * We want to compress that image to fit into the texture which is 512x512. However, the texture will only draw to the top 512x256,
         * the pixels on the Y axis after 256 should be pure black.
         * After every change, we need to update the texture
         */
        //Generate Canvas
        public void GenerateCanvas()
        {
            
        }
        
        /*
         * In order to save or update the image, consider that we have a UI image of dimensions M and N
         * We want to compress that image to fit into the texture which is 512x512. However, the texture will only draw to the top 512x256,
         * the pixels on the Y axis after 256 should be pure black.
         * After every change, we need to update the texture
         */

        public void SaveCanvasToTexture(string fileName)
        {
            
        }


        public void Load(string fileLocation)
        {
            throw new System.NotImplementedException();
        }
    }
}
