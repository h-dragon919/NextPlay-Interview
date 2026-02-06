using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class mainMenu : MonoBehaviour
{

    UIDocument doc;

    Button firstLevelButton, secondLevelButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        doc = GetComponent<UIDocument>();
        firstLevelButton = doc.rootVisualElement.Q<Button>("firstLevel");
        firstLevelButton.RegisterCallback<ClickEvent>(evt => LoadLevel(evt, 1));
        secondLevelButton = doc.rootVisualElement.Q<Button>("secondLevel");
        secondLevelButton.RegisterCallback<ClickEvent>(evt => LoadLevel(evt, 2));
        secondLevelButton = doc.rootVisualElement.Q<Button>("thirdLevel");
        secondLevelButton.RegisterCallback<ClickEvent>(evt => LoadLevel(evt, 3));
    }

    // Update is called once per frame
    void LoadLevel(ClickEvent evt, int index)
    {
        SceneManager.LoadScene("Level"+index);
    }

    void OnDisable()//just some good practice
    {
        firstLevelButton.UnregisterCallback<ClickEvent>(evt => LoadLevel(evt, 1));
        secondLevelButton.UnregisterCallback<ClickEvent>(evt => LoadLevel(evt, 2));
    }
}
