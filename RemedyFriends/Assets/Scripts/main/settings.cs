using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settings : MonoBehaviour
{
    public Button btnSettings;      // 설정 버튼
    public GameObject canvasSettings;
    public bool sound;  // 소리 변수
    public bool soundeffect;    // 효과음 변수


    // 설정 창 위의 버튼들
    public Button btnClose;
    /*
    public Button btnSound;
    public Button btnEffect;

    public GameObject checkSound;
    public GameObject checkEffect;
    */

    // Start is called before the first frame update
    void Start()
    {
        //canvasSettings.SetActive(false);
        canvasSettings.gameObject.SetActive(false);

        btnSettings.onClick.AddListener(showSettings);
        btnClose.onClick.AddListener(HideSettings);
    }
    
    void showSettings()
    {
        canvasSettings.SetActive(true);
    }

    void HideSettings()
    {
        canvasSettings.SetActive(false);
    }
}
