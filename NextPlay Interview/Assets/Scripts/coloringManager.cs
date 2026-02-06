using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class coloringManager : MonoBehaviour
{
    public static coloringManager Instance { get; private set; }
    public Color currentColor;
    [SerializeField] Color[] allColors;//the index and order is very important(red blue green gray white black)
    UIDocument doc;
    [SerializeField] brushColoring brush;//this
    [SerializeField] fillBucket fill;//and this are just here so we can enable adn disable them

    void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);//we wont do this because it breaks the logic behind the game and there is never another instance of this class either way
        }
        else
        {
            Destroy(gameObject);
        }
        doc = GetComponent<UIDocument>();
    }

    void Start()
    {
        //UI
        //setting the click events for all the buttons
        for (int i = 0; i < 6; i++)
        {
            Button button = doc.rootVisualElement.Q<Button>("color_"+i);
            int currentIndex = i; // Local copy because if we used i, the program takes too long to run and the next loop wouldve started and would have caused symantic erros
            button.RegisterCallback<ClickEvent>(evt => changeColor(evt, currentIndex));
        }
        Button buttonToggle = doc.rootVisualElement.Q<Button>("toggleColoringMode");
        buttonToggle.RegisterCallback<ClickEvent>(evt => toggleColoringMode(evt));

        Button buttonBack = doc.rootVisualElement.Q<Button>("backToMainMenu");//Go back to main menu
        buttonBack.RegisterCallback<ClickEvent>(evt => backToMainMenu(evt));
    }
    void backToMainMenu(ClickEvent evt)
    {
        SceneManager.LoadScene("MainMenu");
    }

    void changeColor(ClickEvent evt, int index)
    {
        currentColor = allColors[index];//used for fill color
    }

    void toggleColoringMode(ClickEvent evt)
    {
        if(brush.enabled)
        {
            brush.enabled = false;
            fill.enabled = true;
        }
        else
        {
            brush.enabled = true;
            fill.enabled = false;
        }
    }
}
