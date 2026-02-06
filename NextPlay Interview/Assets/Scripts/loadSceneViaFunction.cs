using UnityEngine;
using UnityEngine.SceneManagement;
public class loadSceneViaFunction : MonoBehaviour
{
    public void loadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
