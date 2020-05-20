using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


// 게임 진행 + 점수 계산 한번에
// 위에말고 랜덤생성, 움직임
public class game1_SpawnBubble : MonoBehaviour
{
    public Button Bubble1, Bubble2, Bubble3, Bubble4, Bubble5;  // 버블
    public Button btnHole1, btnHole2, btnHole3, btnHole4, btnHole5; // 분화구 버튼

    // 랜덤으로 순서 맞출 리스트
    List<Button> BubbleList = new List<Button>();
    // 분화구 리스트
    List<Button> HoleList = new List<Button>();
    // 순서 저장할 배열
    public int[] BubbleOrder = new int[5];

    // 시간 지연
    float timer = 0;
    float waitingTime = 1;

    bool blup;

    // 비교 위한 변수
    int order = 0; int clicked = 0;

    // 위치 저장
    private UnityEngine.Vector3 pos1;
    private UnityEngine.Vector3 pos2;
    private UnityEngine.Vector3 pos3;
    private UnityEngine.Vector3 pos4;
    private UnityEngine.Vector3 pos5;

    // 점수 텍스트
    public Text txtScore;   // 스코어 팝업에 나타낼 텍스트
    // 점수 위한 변수
    private int scoreBubble = 0;    // 점수

    // 분화구 텍스트
    public Text txtHole1, txtHole2;

    // Start is called before the first frame update
    void Start()
    {
        blup = false;

        // 버블 위치 저장
        pos1 = Bubble1.transform.position;
        pos2 = Bubble2.transform.position;
        pos3 = Bubble3.transform.position;
        pos4 = Bubble4.transform.position;
        pos5 = Bubble5.transform.position;

        // 리스트에 버블 오브젝트들 추가
        BubbleList.Add(Bubble1);
        BubbleList.Add(Bubble2);
        BubbleList.Add(Bubble3);
        BubbleList.Add(Bubble4);
        BubbleList.Add(Bubble5);

        // 분화구 리스트 초기화
        HoleList.Add(btnHole1);
        HoleList.Add(btnHole2);
        HoleList.Add(btnHole3);
        HoleList.Add(btnHole4);
        HoleList.Add(btnHole5);

        // 게임 시작 시 안보이게
        Bubble1.gameObject.SetActive(false);
        Bubble2.gameObject.SetActive(false);
        Bubble3.gameObject.SetActive(false);
        Bubble4.gameObject.SetActive(false);
        Bubble5.gameObject.SetActive(false);

        // 분화구 버튼 비활성화
        btnHole1.gameObject.SetActive(false);
        btnHole2.gameObject.SetActive(false);
        btnHole3.gameObject.SetActive(false);
        btnHole4.gameObject.SetActive(false);
        btnHole5.gameObject.SetActive(false);

        // 분화구 버튼 클릭 이벤트 리스너
        btnHole1.onClick.AddListener(CompareOrder1);
        btnHole2.onClick.AddListener(CompareOrder2);
        btnHole3.onClick.AddListener(CompareOrder3);
        btnHole4.onClick.AddListener(CompareOrder4);
        btnHole5.onClick.AddListener(CompareOrder5);
    }
    
    // bubble 섞는 함수
    public void ShuffleBubble()
    {
        // 사전 설정: Bubble 위치 지정
        Bubble1.transform.position = pos1;
        Bubble2.transform.position = pos2;
        Bubble3.transform.position = pos3;
        Bubble4.transform.position = pos4;
        Bubble5.transform.position = pos5;

        // 분화구 버튼 비활성화
        btnHole1.gameObject.SetActive(false);
        btnHole2.gameObject.SetActive(false);
        btnHole3.gameObject.SetActive(false);
        btnHole4.gameObject.SetActive(false);
        btnHole5.gameObject.SetActive(false);

        // 순서 정할때만 잠깐 쓰일 배열
        int[] nTemp = { 0, 1, 2, 3, 4 };
        var nTempList = nTemp.ToList(); // 리스트로 바꾸기

        // 순서 정하기
        for (int i = 0; i < 5; i++)
        {
            int temp = Random.Range(0, nTempList.Count);
            int rand = nTempList[temp];
            BubbleOrder.SetValue(rand, i);  // 순서를 배열에 저장
            print(BubbleList[rand].name);
            nTempList.Remove(rand);
        }

        timer = 0.0f;

        // 클릭 순서 비교
        order = 0; clicked = 0;
        blup = true;
        Debug.Log("SpawnBubble: ShowBubble");
        //ShowBubble();
    }
    
    void Update()
    {
        if (blup)
        {
            ShowBubble();
        }

        GameCountdown Countdown = GameObject.Find("countdown_PanelUI").GetComponent<GameCountdown>();  // GameCountdown 스크립트의 객체 받아옴
        if (!Countdown.enableSpawn)
        {
            if (scoreBubble < 0)
            {
                scoreBubble = 0;
                txtScore.text = scoreBubble.ToString();
            }
        }
    }
    // 순서에 맞게 버블 나타낸 뒤 버튼 활성화 함수
    void ShowBubble()
    {
        timer += Time.deltaTime;

        if (timer > 0 && timer < waitingTime)
        {
            BubbleList[BubbleOrder[0]].gameObject.SetActive(true);
            txtHole1.gameObject.SetActive(false);
            
        }
        else if (timer > waitingTime && timer < waitingTime * 2)
        {
            BubbleList[BubbleOrder[0]].gameObject.SetActive(false);
            BubbleList[BubbleOrder[1]].gameObject.SetActive(true);
        }
        else if (timer > waitingTime * 2 && timer < waitingTime * 3)
        {
            BubbleList[BubbleOrder[1]].gameObject.SetActive(false);
            BubbleList[BubbleOrder[2]].gameObject.SetActive(true);
        }
        else if (timer > waitingTime * 3 && timer < waitingTime * 4)
        {
            BubbleList[BubbleOrder[2]].gameObject.SetActive(false);
            BubbleList[BubbleOrder[3]].gameObject.SetActive(true);
        }
        else if (timer > waitingTime * 4 && timer < waitingTime * 5)
        {
            BubbleList[BubbleOrder[3]].gameObject.SetActive(false);
            BubbleList[BubbleOrder[4]].gameObject.SetActive(true);
        }
        else if (timer > waitingTime * 5)
        {
            BubbleList[BubbleOrder[4]].gameObject.SetActive(false);

            blup = false;

            // 분화구 버튼 활성화
            btnHole1.gameObject.SetActive(true);
            btnHole2.gameObject.SetActive(true);
            btnHole3.gameObject.SetActive(true);
            btnHole4.gameObject.SetActive(true);
            btnHole5.gameObject.SetActive(true);

            txtHole1.gameObject.SetActive(true);
            
        }
        

    }

    // 버블 순서와 클릭 순서 비교
    void CompareOrder1 ()
    {
        if (BubbleOrder[order] == 0)
        {
            Debug.Log(order + 1 + "번째 버블 클릭");
            order++;
            txtHole2.text = (order + 1).ToString();
            scoreBubble += 23;

            // 시간 3초 증가
            GameTimeSlider gameTimeSlider = GameObject.Find("TimeSlider").GetComponent<GameTimeSlider>();  // GameTimeSlider 스크립트의 객체 받아옴
            gameTimeSlider.remainTime += 0.5f;   // remainTime멤버변수 가져옴
        }
        else
        {
            Debug.Log(order + 1 + "번째 버블이 아닙니다!");
            order = 5;
            scoreBubble -= 300;
        }

        txtScore.text = scoreBubble.ToString();

        if (order == 5)
        {
            NewBubble();
        }
    }
    void CompareOrder2()
    {

        if (BubbleOrder[order] == 1)
        {
            Debug.Log(order + 1 + "번째 버블 클릭");
            order++;
            txtHole2.text = (order + 1).ToString();
            scoreBubble += 23;

            // 시간 3초 증가
            GameTimeSlider gameTimeSlider = GameObject.Find("TimeSlider").GetComponent<GameTimeSlider>();  // GameTimeSlider 스크립트의 객체 받아옴
            gameTimeSlider.remainTime += 0.5f;   // remainTime멤버변수 가져옴
        }
        else
        {
            Debug.Log(order + 1 + "번째 버블이 아닙니다!");
            order = 5;
            scoreBubble -= 300;
        }

        txtScore.text = scoreBubble.ToString();

        if (order == 5)
        {
            NewBubble();
        }
    }
    void CompareOrder3()
    {
       
        if (BubbleOrder[order] == 2)
        {
            Debug.Log(order + 1 + "번째 버블 클릭");
            order++;
            txtHole2.text = (order + 1).ToString();
            scoreBubble += 23;

            // 시간 3초 증가
            GameTimeSlider gameTimeSlider = GameObject.Find("TimeSlider").GetComponent<GameTimeSlider>();  // GameTimeSlider 스크립트의 객체 받아옴
            gameTimeSlider.remainTime += 0.5f;   // remainTime멤버변수 가져옴
        }
        else
        {
            Debug.Log(order + 1 + "번째 버블이 아닙니다!");
            order = 5;
            scoreBubble -= 300;
        }

        txtScore.text = scoreBubble.ToString();

        if (order == 5)
        {
            NewBubble();
        }
    }
    void CompareOrder4()
    {
        if (BubbleOrder[order] == 3)
        {
            Debug.Log(order + 1 + "번째 버블 클릭");
            order++;
            txtHole2.text = (order + 1).ToString();
            scoreBubble += 23;

            // 시간 3초 증가
            GameTimeSlider gameTimeSlider = GameObject.Find("TimeSlider").GetComponent<GameTimeSlider>();  // GameTimeSlider 스크립트의 객체 받아옴
            gameTimeSlider.remainTime += 0.5f;   // remainTime멤버변수 가져옴
        }
        else
        {
            Debug.Log(order + 1 + "번째 버블이 아닙니다!");
            order = 5;
            scoreBubble -= 300;
        }

        txtScore.text = scoreBubble.ToString();

        if (order == 5)
        {
            NewBubble();
        }
    }
    void CompareOrder5()
    {
        if (BubbleOrder[order] == 4)
        {
            Debug.Log(order + 1 + "번째 버블 클릭");
            order++;
            txtHole2.text = (order+1).ToString();
            scoreBubble += 23;

            // 시간 3초 증가
            GameTimeSlider gameTimeSlider = GameObject.Find("TimeSlider").GetComponent<GameTimeSlider>();  // GameTimeSlider 스크립트의 객체 받아옴
            gameTimeSlider.remainTime += 0.5f;   // remainTime멤버변수 가져옴
        }
        else
        {
            Debug.Log(order + 1 + "번째 버블이 아닙니다!");
            order = 5;
            scoreBubble -= 300;
        }

        txtScore.text = scoreBubble.ToString();

        if (order == 5)
        {
            NewBubble();
        }
    }



    void NewBubble()
    {
        game1_BubbleDirector Director = GameObject.Find("GameObject_bubble").GetComponent<game1_BubbleDirector>();
        Director.PlayBubble();
        Debug.Log("새로운 bubble 시작");

        txtHole1.gameObject.SetActive(false);
        txtHole2.text = "1";
        scoreBubble += 300;
        txtScore.text = scoreBubble.ToString();
    }

}
