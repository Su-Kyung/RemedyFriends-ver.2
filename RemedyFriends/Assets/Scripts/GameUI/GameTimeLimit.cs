using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimeLimit : MonoBehaviour
{
    public GameObject txtRemainTime; // 남은 시간 표시 게임 오브젝트
    public GameObject timeover;  // 시간 종료 이미지 위한 오브젝트
    public GameObject Score;    // 결과 창 위한 캔버스(점수) -> 게임마다 다르다

    // timeSlider
    //public Slider TimeSlider;
    //private int currentTime, fullTime;

    private Text t; // 텍스트 개체 ( 위 게임 오브젝트 txtRemainTime와 연결)
    //private float fTime;
    // 다른 클래스에서 접근 위한 실험
    public float fTime;

    // Start is called before the first frame update
    void Start()
    {
        // TimeLimit 객체 동적 할당
        t = GameObject.Find("TimeLimit").GetComponent<Text>();
        Debug.Log(t);
        t.text = "10";

        // 제한시간을 60초 (1분)으로 설정
        fTime = 60;
        //
        //currentTime = 100;
        //fullTime = 100;

        // 시간 종료 이미지 비활성화
        timeover.SetActive(false);
        // 결과 캔버스 비활성화
        Score.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // 매 프레임마다 1초씩 감소
        fTime -= Time.deltaTime;
        t.text = fTime.ToString("00");

        //
        //TimeSlider.value = (float)fTime*100/60; //default 시간 60

        // 0초 남았을 때(시간 끝나면) 시간 종료 화면 띄우기
        if (fTime <= 0)
        {
            timeover.SetActive(true);
            Invoke("score", 3);

            // 게임 오브젝트 생성 (예를 들면 진주) 금지시키기 위해
            // 각 게임에 대한 스크립트에서 enableSpawn을 다시 false로 만든다.
            // 추후에는 각 게임에서 여기 변수 받아오는 걸로 바꾸기
            game1_SpawnShells gameSpawn = GameObject.Find("game1_shell_GameObject").GetComponent<game1_SpawnShells>();  // game1_SpawnShells 스크립트의 객체 받아옴
            gameSpawn.enableSpawn = false;   
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
