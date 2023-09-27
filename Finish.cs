using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : ItemCollector
{
    private AudioSource FinishAudio;
    private Animator anim;

    private bool levelCompleted = false;

    private void Start()
    {
        FinishAudio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && !levelCompleted && PlayerPrefs.GetInt("CoinCollection") >= 4)
        {
                FinishAudio.Play();
                levelCompleted = true;
                Invoke("CompleteLevel", 2f);
        }else
        {
            PopUp();
            print("All items not collected");
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void PopUp()
    {
        anim.SetTrigger("PopUp");
    }


}
