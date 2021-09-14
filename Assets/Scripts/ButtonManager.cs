using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{

    public void onStart()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void back(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void instructions(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void onQuitPressed(GameObject panel)
    {
        panel.SetActive(true);
    }
}
