﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimeSlider : MonoBehaviour
{
    public Slider TimeSlider;   // 시간 슬라이더(UI)
    public GameObject timeover; // 시간 종료 시 띄울 이미지
    public GameObject Score;    // 결과 창(캔버스). 점수표시하며 게임마다 다르다

    public float remainTime;   // 게임 플레이 시 남은 시간(다른 클래스에서 접근 위해 public)

    
    /* 위에 애들 안썼을때 되던 코드
    game1_SpawnShells SpawnShells = GameObject.Find("game1_shell_GameObject").GetComponent<game1_SpawnShells>();  // game1_SpawnShells 스크립트의 객체 받아옴
    SpawnShells.enableSpawn = false;

            game1_SpawnBubble SpawnBubble = GameObject.Find("game1_blup_GameObject").GetComponent<game1_SpawnBubble>(); // enableSpawn 받아옴
    SpawnBubble.enableSpawn = false;
    */

    // Start is called before the first frame update
    void Start()
    {
        // 기본 설정된 게임 시간을 60초로 설정
        remainTime = 60;

        // 시간 종료 이미지와 결과 캔버스를 비활성화
        timeover.SetActive(false);
        Score.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // 매 프레임마다 1초씩 감소
        remainTime -= Time.deltaTime;

        // 시간 슬라이더 값 변경 -> 이 값에 따라 슬라이더에 표시되는 길이 정해짐
        TimeSlider.value = (float)remainTime / 60;  //60: default 게임 시간(Start()에서 설정한 remainTime 값

        GameCountdown Countdown = GameObject.Find("countdown_PanelUI").GetComponent<GameCountdown>();  // GameCountdown 스크립트의 객체 받아옴

        // 0초 남았을 때(시간 끝나면) 시간 종료 화면 띄우기
        if (remainTime <= 0)
        {
            timeover.SetActive(true);
            Invoke("score", 3);

            Countdown.enableSpawn = false;
            Debug.Log("enableSpawn is false. - GameTimeSlider");
        }
    }

    void score()
    {
        Destroy(timeover);
        // SetActive(false) 하면 업데이트 때문에 자꾸 true가 되어 깜빡거린다.
        // 하지만 Destroy해도 여전히 위와 같은 문제 때문에 오류?가 뜨므로 더 좋은방법 있나 생각해볼 것

        Score.SetActive(true);
    }
}
