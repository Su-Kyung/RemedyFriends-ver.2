﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePause : MonoBehaviour
{
    public GameObject Pause; // 일시정지 이미지
    public Button btnPause;  // 일시정지 보기 버튼

    // Start is called before the first frame update
    void Start()
    {
        // 시작할 때에는 힌트 보이지 않게 설정
        Pause.SetActive(false);

        // 힌트 버튼 클릭했을 때 ShowHint 함수 실행
        btnPause.onClick.AddListener(ShowHint);
    }

    void ShowHint()
    {
        // 일시정지 화면이 보이게 한다
        Pause.SetActive(true);
        // 2초 뒤에 일시정지 화면이 사라지게 한다. (Invoke의 첫 번째 인자는 함수명)
        Invoke("HidePause", 2);
    }

    // 함수명이 필요하기 때문에 HideHint라는 함수를 하나 만들어둔다.
    void HidePause()
    {
        Pause.SetActive(false);
    }


}
