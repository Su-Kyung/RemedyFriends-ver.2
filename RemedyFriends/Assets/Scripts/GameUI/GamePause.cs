using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePause : MonoBehaviour
{
    public GameObject Pause; // 일시정지 캔버스
    public Button btnPause;  // 일시정지 보기 버튼

    // 일시정지 캔버스 내의 버튼들 
    public Button pBtnClose;   // 일시정지 캔버스 닫기
    public Button pBtnPlay;    // 계속하기
    public Button pBtnReplay;  // 다시하기
    public Button pBtnExit;    // 나가기
    public Button pBtnSound;   // 소리 켜고 끄기

    // 소리 상태
    public bool sound = true;
    public GameObject soundCheck;

    // 씬 전환 위한 변수
    public Scene replayScene;   // 현재 게임중이던 씬
    public Scene exitScene;     // 어디로 나갈지

    // Start is called before the first frame update
    void Start()
    {
        // 시작할 때에는 힌트 보이지 않게 설정
        Pause.SetActive(false);

        // 소리 켜진 상태로 시작
        soundCheck.SetActive(true);

        // 힌트 버튼 클릭했을 때 ShowHint 함수 실행
        btnPause.onClick.AddListener(ShowPause);

        // 닫기 버튼 클릭했을 때 캔버스 닫기
        pBtnClose.onClick.AddListener(HidePause);

        // 일시정지 캔버스의 버튼마다 하나씩 함수 구현
        pBtnPlay.onClick.AddListener(HidePause);
        pBtnReplay.onClick.AddListener(ReplayGame);
        pBtnExit.onClick.AddListener(ExitGame);
        //pBtnSound.onClick.AddListener(SoundControl);
    }

    void ShowPause()
    {
        // 일시정지 화면이 보이게 한다
        Pause.SetActive(true);

        // 게임 잠시 멈춤 (이어할 수 있도록 해야 함)
    }

    // 함수명이 필요하기 때문에 HideHint라는 함수를 하나 만들어둔다.
    void HidePause()
    {
        Pause.SetActive(false);
        
        // 게임 다시 시작 (이어하기해야함)

    }

    void ReplayGame()
    {
        Pause.SetActive(false);

        // 게임 다시 시작 (새로 해야함)
        SceneManager.LoadScene(replayScene.handle);
        Debug.Log("게임 다시 시작");
    }

    void ExitGame()
    {
        Pause.SetActive(false);

        // 게임 나가기
        SceneManager.LoadScene(exitScene.handle);
        Debug.Log("게임 나가기");
    }


    /* 나중에 구현 (아래는 임시 코드로 테스트 했을때에는 그닥 잘 되지는 않았음)
    void SoundControl()
    {
        if(sound)
        {
            Debug.Log("소리 끔");
            soundCheck.SetActive(false);
            // 소리 끄는 코드 넣기

        }
        else
        {
            Debug.Log("소리 켬");
            soundCheck.SetActive(true);
            // 소리 켜는 코드 넣기
        }
    }
    */
}
