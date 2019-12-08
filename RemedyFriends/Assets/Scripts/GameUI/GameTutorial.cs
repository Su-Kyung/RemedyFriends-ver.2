using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.EventSystems;

public class GameTutorial : MonoBehaviour
{
    public GameObject panel;    // GameObject로 받아온다(선언)

    //private bool state;     // 상태(튜토리얼 패널을 보일 것인가)
    private float fTime;    // 시간

    // Start is called before the first frame update
    void Start()
    {
        //tutorial = GameObject.Find("tutorial").GetComponent<GameObject>();
        panel.SetActive(true);  
    }

    // Update is called once per frame
    void Update()
    {
        fTime += Time.deltaTime;    //매 프레임마다 Time 더해준다
        if (fTime > 3)  // 3초 이상 되면
        {
            panel.SetActive(false); // 튜토리얼 안보이게 함
        }

        // 터치 안되게 하기?
        //if (EventSystem.current.IsPointerOverGameobject(0) == true) return;
    }
}
