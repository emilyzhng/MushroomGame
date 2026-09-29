using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public ScenePreloader scene;
    public void ClickStart()
    {
        scene.ActivatePreloadedScene();
    }

    public void Quit()
    {
        Application.Quit(); 
        Debug.Log("Exitting");  
    }
}
