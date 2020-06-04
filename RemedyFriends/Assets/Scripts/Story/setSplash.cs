using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setSplash : MonoBehaviour
{
    public Button btnGameStart;
    public GameObject canvasSplash;

    public AudioSource audioStartApp;

    
    void Awake()
    {
        btnGameStart.gameObject.SetActive(true);
        canvasSplash.SetActive(true);

        btnGameStart.onClick.AddListener(gogoGame);
    }

    void gogoGame()
    {
        audioStartApp.Play();

        btnGameStart.gameObject.SetActive(false);
        canvasSplash.SetActive(false);
    }
}
