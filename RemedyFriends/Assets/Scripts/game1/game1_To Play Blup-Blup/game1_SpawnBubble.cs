using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


// 게임 진행 + 점수 계산 한번에
// 위에말고 랜덤생성, 움직임
public class game1_SpawnBubble : MonoBehaviour
{

    // 진주조개 방법으로 도전
    // 그러나 진주조개는 Clone으로 복제해서 랜덤생성하고 이 경우는 각각의 객체에
    // 랜덤 시간값을 줘서 각각이 랜덤생성 되도록 한다.(그래서 랜덤생성 및 삭제함수에서 각각 위치 지정함)
    
    public Button Bubble1, Bubble2, Bubble3, Bubble4, Bubble5;

    // 랜덤으로 순서 맞출 배열
    List<Button> BubbleList = new List<Button>();
    // 순서 저장할 배열
    public int[] BubbleOrder = new int[5];

    // 시간 지연
    float timer = 0;
    float waitingTime = 1;

    bool blup;

    // Start is called before the first frame update
    void Start()
    {
        blup = false;
        // 리스트에 버블 오브젝트들 추가
        BubbleList.Add(Bubble1);
        BubbleList.Add(Bubble2);
        BubbleList.Add(Bubble3);
        BubbleList.Add(Bubble4);
        BubbleList.Add(Bubble5);

        // 게임 시작 시 안보이게
        Bubble1.gameObject.SetActive(false);
        Bubble2.gameObject.SetActive(false);
        Bubble3.gameObject.SetActive(false);
        Bubble4.gameObject.SetActive(false);
        Bubble5.gameObject.SetActive(false);
        
        InvokeRepeating("Bubble", 5.0f, 12.0f);
       
    }

    void Bubble()
    {
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

        blup = true;
    }

    void Update()
    {
        if(blup)
        {
            timer += Time.deltaTime;

            if(timer > 0 && timer < waitingTime)
            {
                BubbleList[BubbleOrder[0]].gameObject.SetActive(true);
            }
            else if(timer > waitingTime && timer < waitingTime*2)
            {
                BubbleList[BubbleOrder[0]].gameObject.SetActive(false);
                BubbleList[BubbleOrder[1]].gameObject.SetActive(true);
            }
            else if (timer > waitingTime*2 && timer < waitingTime*3)
            {
                BubbleList[BubbleOrder[1]].gameObject.SetActive(false);
                BubbleList[BubbleOrder[2]].gameObject.SetActive(true);
            }
            else if (timer > waitingTime*3 && timer < waitingTime*4)
            {
                BubbleList[BubbleOrder[2]].gameObject.SetActive(false);
                BubbleList[BubbleOrder[3]].gameObject.SetActive(true);
            }
            else if (timer > waitingTime*4 && timer < waitingTime*5)
            {
                BubbleList[BubbleOrder[3]].gameObject.SetActive(false);
                BubbleList[BubbleOrder[4]].gameObject.SetActive(true);
            }
            else if (timer > waitingTime*5)
            {
                BubbleList[BubbleOrder[4]].gameObject.SetActive(false);
            }
        }
    }


    /*


    // Bubble 랜덤생성 및 삭제 함수
    void SpawnBubble1()
    {
        GameCountdown Countdown = GameObject.Find("countdown_PanelUI").GetComponent<GameCountdown>();  // GameCountdown 스크립트의 객체 받아옴
        
        if (Countdown.enableSpawn)
        {
            GameObject game1_blup_bubble1 = Instantiate(Bubble1, new Vector3(-0.3f, 1.18f, 0), Quaternion.identity);

            // 일정 시간 뒤에 Bubble Clone 삭제
            Destroy(game1_blup_bubble1, 2f);
        }
    }

    void SpawnBubble2()
    {
        GameCountdown Countdown = GameObject.Find("countdown_PanelUI").GetComponent<GameCountdown>();  // GameCountdown 스크립트의 객체 받아옴

        if (Countdown.enableSpawn)
        {
            GameObject game1_blup_bubble2 = Instantiate(Bubble2, new Vector3(4.67f, -2.95f, 0), Quaternion.identity);

            // 일정 시간 뒤에 Bubble Clone 삭제
            Destroy(game1_blup_bubble2, 2f);
        }
    }

    void SpawnBubble3()
    {
        GameCountdown Countdown = GameObject.Find("countdown_PanelUI").GetComponent<GameCountdown>();  // GameCountdown 스크립트의 객체 받아옴

        if (Countdown.enableSpawn)
        {
            GameObject game1_blup_bubble3 = Instantiate(Bubble3, new Vector3(-8.83f, 0.1899997f, 0), Quaternion.identity);

            // 일정 시간 뒤에 Bubble Clone 삭제
            Destroy(game1_blup_bubble3, 2f);
        }
    }

    void SpawnBubble4()
    {
        GameCountdown Countdown = GameObject.Find("countdown_PanelUI").GetComponent<GameCountdown>();  // GameCountdown 스크립트의 객체 받아옴

        if (Countdown.enableSpawn)
        {
            GameObject game1_blup_bubble4 = Instantiate(Bubble4, new Vector2(-5.08f, -3.97f), Quaternion.identity);

            // 일정 시간 뒤에 Bubble Clone 삭제
            Destroy(game1_blup_bubble4, 2f);
        }
    }

    void SpawnBubble5()
    {
        GameCountdown Countdown = GameObject.Find("countdown_PanelUI").GetComponent<GameCountdown>();  // GameCountdown 스크립트의 객체 받아옴

        if (Countdown.enableSpawn)
        {
            GameObject game1_blup_bubble5 = Instantiate(Bubble5, new Vector2(9, -0.5800003f), Quaternion.identity);

            // 일정 시간 뒤에 Bubble Clone 삭제
            Destroy(game1_blup_bubble5, 2f);
        }
    }

    */

}
