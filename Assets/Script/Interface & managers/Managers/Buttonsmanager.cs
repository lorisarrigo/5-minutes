using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttonsmanager : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("StartScreen");
    }
    public void MainLevel()
    {
        SceneManager.LoadScene("MainLevel");
    }
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
