using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Retry()
    {
        Debug.Log("LoadScene");
        SceneManager.LoadScene("Game");
    }
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
