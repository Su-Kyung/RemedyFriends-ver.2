using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 점수도 여기~
public class game1_FishDirector : MonoBehaviour
{
    public Button btnRed, btnYellow, btnGreen, btnPurple;   // 버튼들
    public int indexFish;   // 물고기 색 판별 위한 변수 (SpawnFish와 연결됨)

    public GameObject resultYes, resultNo;  // 맞았을 때 혹은 틀렸을 때 팝업 이미지

    //--------------------------- DB에 넘길 변수 ---------------------------
    // 맞은 물고기 수 세기 위한 변수
    int countFish = 0;

    // 점수 위한 변수
    private int scoreShark = 0;    // 점수
    public Text txtScore;
    //--------------------------- DB에 넘길 점수 변수 ---------------------------


    // Start is called before the first frame update
    void Start()
    {
        // 팝업 이미지 게임 시작시에는 안보이게
        HideResult();

        // 버튼마다 리스너 추가
        btnRed.onClick.AddListener(CheckRed);
        btnYellow.onClick.AddListener(CheckYellow);
        btnGreen.onClick.AddListener(CheckGreen);
        btnPurple.onClick.AddListener(CheckPurple);
    }

    void CheckBonus()
    {
        GameCountdown Countdown = GameObject.Find("countdown_PanelUI").GetComponent<GameCountdown>();  // GameCountdown 스크립트의 객체 받아옴
    
            // 물고기 10의 배수만큼 찾을 때마다
            if (countFish % 10 == 0 && countFish != 0)
            {
                // 시간 5초 증가
                GameTimeSlider gameTimeSlider = GameObject.Find("TimeSlider").GetComponent<GameTimeSlider>();  // GameTimeSlider 스크립트의 객체 받아옴
                gameTimeSlider.remainTime += 5;   // remainTime멤버변수 가져옴

                // 점수 200 추가
                scoreShark += 200;
                txtScore.text = scoreShark.ToString();
            }
        
    }
    
    // 빨간 버튼 클릭했을 때
    void CheckRed()
    {
        if (indexFish == 0)
        {
            countFish += 1; // 찾은 물고기 수에 1 추가

            // 점수 더하기
            scoreShark += 13;
            txtScore.text = scoreShark.ToString();
            CheckBonus();

            resultYes.SetActive(true);
            Debug.Log("빨강 딩동댕");
        }
        else
        {
            resultNo.SetActive(true);
            Debug.Log("빨강 땡");
        }

        // 1.5초 뒤 팝업 없애기
        Invoke("HideResult", 1.5f);
    }

    // 노랑 버튼 클릭했을 때
    void CheckYellow()
    {
        if (indexFish == 1)
        {
            countFish += 1; // 찾은 물고기 수에 1 추가

            // 점수 더하기
            scoreShark += 13;
            txtScore.text = scoreShark.ToString();
            CheckBonus();

            resultYes.SetActive(true);
            Debug.Log("노랑 딩동댕");
        }
        else
        {
            resultNo.SetActive(true);
            Debug.Log("노랑 땡");
        }

        // 1.5초 뒤 팝업 없애기
        Invoke("HideResult", 1.5f);
    }

    // 초록 버튼 클릭했을 때
    void CheckGreen()
    {
        if (indexFish == 2)
        {
            countFish += 1; // 찾은 물고기 수에 1 추가

            // 점수 더하기
            scoreShark += 13;
            txtScore.text = scoreShark.ToString();
            CheckBonus();

            resultYes.SetActive(true);
            Debug.Log("초록 딩동댕");
        }
        else
        {
            resultNo.SetActive(true);
            Debug.Log("초록 땡");
        }

        // 1.5초 뒤 팝업 없애기
        Invoke("HideResult", 1.5f);
    }

    // 보라 버튼 클릭했을 때
    void CheckPurple()
    {
        if (indexFish == 3)
        {
            countFish += 1; // 찾은 물고기 수에 1 추가

            // 점수 더하기
            scoreShark += 13;
            txtScore.text = scoreShark.ToString();
            CheckBonus();

            resultYes.SetActive(true);
            Debug.Log("보라 딩동댕");
        }
        else
        {
            resultNo.SetActive(true);
            Debug.Log("보라 땡");
        }

        // 1.5초 뒤 팝업 없애기
        Invoke("HideResult", 1.5f);
    }

    // 맞은 경우, 틀린 경우 이미지 팝업 없애기
    void HideResult()
    {
        resultYes.SetActive(false);
        resultNo.SetActive(false);

        // 0.5초 뒤 새로운 물고기 호출
        Invoke("NewFish", 0.5f);
    }

    void NewFish()
    {
        SpawnFish Fish = GameObject.Find("Fishes").GetComponent<SpawnFish>();  // SpawnFish 스크립트의 객체 받아옴

        Fish.ShowFish();    // 새롭게 호출
    }
}
