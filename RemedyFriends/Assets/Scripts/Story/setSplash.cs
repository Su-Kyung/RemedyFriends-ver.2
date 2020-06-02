using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setSplash : MonoBehaviour
{
    public Button btnGameStart;
    public GameObject canvasSplash;

    
    void Awake()
    {
        btnGameStart.gameObject.SetActive(true);
        canvasSplash.SetActive(true);

        btnGameStart.onClick.AddListener(gogoGame);
    }

    void gogoGame()
    {
        btnGameStart.gameObject.SetActive(false);
        canvasSplash.SetActive(false);
    }
}
