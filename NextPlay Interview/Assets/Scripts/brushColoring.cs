using UnityEngine;
using UnityEngine.UIElements;
public class brushColoring : MonoBehaviour
{
    [SerializeField] GameObject stroke, strokeStyle_1, strokeStyle_2;//stroke is the used one and strokeStyle_1 and strokeStyle_2 are the avalible styles

    LineRenderer currentLineRenderer;
    Vector2 lastPos;
    UIDocument doc;

    void Start()
    {
        doc = FindObjectOfType<UIDocument>().GetComponent<UIDocument>();

        Button button = doc.rootVisualElement.Q<Button>("toggleDrawingStyle");//extra feature as it looked cool
        button.RegisterCallback<ClickEvent>(evt => toggleStyle(evt));
    }
    void toggleStyle(ClickEvent evt)
    {
        if(stroke == strokeStyle_1)
        {
            stroke = strokeStyle_2;
        }
        else
        {
            stroke = strokeStyle_1;
        }
    }

    void Update()
    {
        DrawStroke();
    }
    void DrawStroke()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            CreateStroke();
        }
        if(Input.GetButton("Fire1"))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(mousePos != lastPos)
            {
                AddPoint(mousePos);
                lastPos = mousePos;
            }
        }
        else
        {
            currentLineRenderer = null;
        }
    }

    void CreateStroke()
    {
        GameObject tempStroke = Instantiate(stroke);
        currentLineRenderer = tempStroke.GetComponent<LineRenderer>();

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        currentLineRenderer.SetPosition(0, mousePos);
        currentLineRenderer.SetPosition(1, mousePos);
        //Color

        // Create a new MaterialPropertyBlock
        MaterialPropertyBlock propertyBlock = new MaterialPropertyBlock();

        currentLineRenderer.GetPropertyBlock(propertyBlock);
        // Set a random color in the MaterialPropertyBlock
        propertyBlock.SetColor("_TintColor", coloringManager.Instance.currentColor);
        propertyBlock.SetColor("_BaseColor", coloringManager.Instance.currentColor);

        // Apply the MaterialPropertyBlock to the GameObject
        currentLineRenderer.GetComponent<LineRenderer>().SetPropertyBlock(propertyBlock);
    }

    void AddPoint(Vector2 pointPos)
    {
        currentLineRenderer.positionCount++;
        int positionIndex = currentLineRenderer.positionCount - 1;
        currentLineRenderer.SetPosition(positionIndex, pointPos);
    }
}
