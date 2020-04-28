using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 한 판당 점수 제어
public class game2_StuffDirector : MonoBehaviour
{
    // 맞춘 짐 수 세기 위한 변수
    public Text numYesStuff;
    private int countYesStuff = 0;

    // 틀린 짐 수 세기 위한 변수
    public Text numNoStuff;
    private int countNoStuff = 0;

    // 점수 위한 변수
    private int scoreStuff = 0;    // 점수
    public Text txtScore;

    private GameObject target;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CastRay();

            /*
            // 클릭한 객체가 맞았을 때
            if (target.name == "game1_blup_bubble1(Clone)" || target.name == "game1_blup_bubble2(Clone)" ||
                target.name == "game1_blup_bubble3(Clone)" || target.name == "game1_blup_bubble4(Clone)" || target.name == "game1_blup_bubble5(Clone)")
            {
                
                Destroy(target);

                // 터뜨린 버블 수에 1 더하기 (추후에 점수로 변경)
                countBubble += 1;
                scoreBubble += 23;  // Bubble 하나 찾을 때 마다 점수 23 더하기
                numBubble.text = countBubble.ToString();

                // 진주조개 7의 배수만큼 찾을 때마다
                if (countBubble % 7 == 0)
                {
                    // 시간 5초 증가
                    GameTimeSlider gameTimeSlider = GameObject.Find("TimeSlider").GetComponent<GameTimeSlider>();  // GameTimeSlider 스크립트의 객체 받아옴
                    gameTimeSlider.remainTime += 5;   // remainTime멤버변수 가져옴

                    // 점수 300 추가
                    scoreBubble += 300;
                }
                txtScore.text = scoreBubble.ToString();
            }

            else if (target.name == "game1_blup_bg") // 배경 터치했을 때 시간 감소
            {
                Debug.Log("You did not touch bubbles");
                // 시간 1초 감소
                GameTimeSlider gameTimeSlider = GameObject.Find("TimeSlider").GetComponent<GameTimeSlider>();  // GameTimeSlider 스크립트의 객체 받아옴
                gameTimeSlider.remainTime -= 1;   // remainTime멤버변수 가져옴
            }
            */

        }
    }


    void CastRay() // 유닛 히트처리 부분.  레이를 쏴서 처리합니다. 
    {
        target = null;
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

        if (hit.collider != null)
        { //히트되었다면 여기서 실행
            if (hit.collider.tag == "GameObject_Sea_Bubble")
            {
                Debug.Log(hit.collider.name);  //이 부분을 활성화 하면, 선택된 오브젝트의 이름이 찍혀 나옵니다.
                target = hit.collider.gameObject;  //히트 된 게임 오브젝트를 타겟으로 지정
            }
        }
    }
}
