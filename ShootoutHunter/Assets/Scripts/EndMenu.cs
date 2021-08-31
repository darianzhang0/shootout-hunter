using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT GAME");
        Application.Quit();
    }


    public GameObject playButton;
    public GameObject quitButton;

    void Start()
    {
        playButton.SetActive(false);
        StartCoroutine(HidePlayButton());

        quitButton.SetActive(false);
        StartCoroutine(HideQuitButton());

    }

    IEnumerator HidePlayButton()
    {
        yield return new WaitForSeconds(2.0f);
        playButton.SetActive(true);
    }

    IEnumerator HideQuitButton()
    {
        yield return new WaitForSeconds(2.0f);
        quitButton.SetActive(true);
    }
}
