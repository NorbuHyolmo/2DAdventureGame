using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    private AudioSource ButtonPressedAudio;

    private void Start()
    {
        ButtonPressedAudio = GetComponent<AudioSource>();
    }
    // it should be accessible to the user 
    // that's why the method is created as public


    public void StartGame()
    {
        ButtonPressedAudio.Play();
        Invoke("Delay", 1f);
        //ButtonPressedAudio.Play();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void Delay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        ButtonPressedAudio.Play();
        Application.Quit();
    }

    //public void EndGame()
    //{
    //    Application.Quit();
    //}
}
