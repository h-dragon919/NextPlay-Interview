using UnityEngine;

public class fillBucket : MonoBehaviour
{

    //SUMMARY
    //this script simply checks if the mouse is cliked then it calls Color_(it gets the curretn color through coloringManager as it's an instance) 
    // then it uses raycasthit2D to check if a collider is hit, then as the way the scene is created, this must be a fillable area
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Color_(coloringManager.Instance.currentColor);
        }
    }
    void Color_(Color color)
    {
        // Convert mouse position to world position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        
        // Cast ray from mouse position
        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
        
        if (hit.collider != null) //if any object has a collider then it muust mean it has a sprite renderer, if there is such a case where this is not the rule then add an extra check with tags or layers
            //fill color using SpriteRenderer
            hit.collider.GetComponent<SpriteRenderer>().color = color;
    }
}
