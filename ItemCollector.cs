using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{

    //store items in the list
    private List<string> items;

    ////for displaying the collectables
    //[SerializeField] private Text coinText;

    //for audio
    [SerializeField] private AudioSource coinAudioSource;


    private void Start()
    {
        items = new List<string>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            coinAudioSource.Play();
            string itemType = collision.gameObject.GetComponent<CollectableScript>().itemType;
            items.Add(itemType);
            PlayerPrefs.SetInt("CoinCollection", (items.Count));
            print(items.Count);
        }
    }


    //public void CompleteLevel1()
    //{
    //    if (PlayerPrefs.GetInt("Testing") >= 4)
    //    {
    //        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //    }
    //    else
    //    {
    //        print("the number of coins is : " + PlayerPrefs.GetInt("Testing"));
    //    }
    //}

}
