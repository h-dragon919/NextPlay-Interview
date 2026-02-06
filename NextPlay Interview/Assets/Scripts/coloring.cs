// For touch painting - put this on a UI Image
using UnityEngine;
using UnityEngine.UI;

public class coloring : MonoBehaviour
{
    public Color paintColor = Color.red;
    public float brushWidth = 20f;
    
    private Texture2D texture;
    
    void Start()
    {
        texture = new Texture2D(Screen.width, Screen.height);
        GetComponent<Image>().sprite = Sprite.Create(texture, 
            new Rect(0, 0, Screen.width, Screen.height), Vector2.one * 0.5f);
    }
    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 pixelUV = Input.mousePosition;
            
            // Draw a circle at mouse position
            for (int x = -Mathf.RoundToInt(brushWidth); x < brushWidth; x++)
            {
                for (int y = -Mathf.RoundToInt(brushWidth); y < brushWidth; y++)
                {
                    if (x * x + y * y < brushWidth * brushWidth)
                    {
                        int texX = Mathf.RoundToInt(pixelUV.x + x);
                        int texY = Mathf.RoundToInt(pixelUV.y + y);
                        
                        if (texX >= 0 && texX < texture.width && 
                            texY >= 0 && texY < texture.height)
                        {
                            texture.SetPixel(texX, texY, paintColor);
                        }
                    }
                }
            }
            texture.Apply();
        }
    }
}