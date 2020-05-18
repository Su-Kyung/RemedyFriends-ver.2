using System.Collections;
using System.Collections.Generic;
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
    // gameobject list 참고링크: https://m.blog.naver.com/PostView.nhn?blogId=hst322&logNo=220960510868&proxyReferer=https:%2F%2Fwww.google.co.kr%2F
    List<Button> BubbleList = new List<Button>();


    //Button[] btnBubble;

    // Start is called before the first frame update
    void Start()
    {
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

        //Shuffle(BubbleList);
        //InvokeRepeating("SpawnBubble1", 0, 2.2f);
        //InvokeRepeating("SpawnBubble2", 0, 2.1f);
        //InvokeRepeating("SpawnBubble3", 0, 2.4f);
        //InvokeRepeating("SpawnBubble4", 0, 2.3f);
        //InvokeRepeating("SpawnBubble5", 0, 2.35f);





        for (int i = 0; i < 5; i++)
        {
            int rand = Random.Range(0, BubbleList.Count);
            print(BubbleList[rand].name);
            BubbleList.RemoveAt(rand);
        }
    }
/*
    void update()
    {
        GameCountdown Countdown = GameObject.Find("countdown_PanelUI").GetComponent<GameCountdown>();  // GameCountdown 스크립트의 객체 받아옴

        if (Countdown.enableSpawn)   // +발생해야 할 때에
        {
            for (int i = 0; i < 5; )
            {

            }
        }
    }
*/
    //for shuffle number from array
    void Shuffle(List<Button> list)
    {
        int random;

        Button tmp;

        for (int index = 0; index < 5; ++index)
        {
            random = Random.Range(0, 5);

            tmp = list[index];
            list[index] = list[random];
            list[random] = tmp;
            Debug.Log(index+1 + "번 버블은 " + random + "번째로 생성");
        }
        //https://minhyeokism.tistory.com/16 [programmer-dominic.kim]
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
