using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Awake()
    {
        Initiate.DoneFading();
    }
    public void StartGame()
    {
        Initiate.Fade("LoadingScreen", Color.black, 1f);
    }
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
    public void GoToMainMenu()
    {
        Initiate.Fade("Menu", Color.black, 1f);
    }
}
