using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class game1_shell : MonoBehaviour
{
    // 선택한 진주조개 수 세기 위한 변수
    public Text numPearlShell;
    private int countPearlShell;
    // 점수 위한 변수
    private int scorePearlShell;    // 점수
    public Text txtScore;

    // 선택한 진주없는 조개 수 세기 위한 변수
    public Text numNonPearlShell;
    private int countNonPearlShell;

    private GameObject target;
 

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CastRay();

            // 진주 조개 클릭했을 때
            if (target.name == "game1_shell_pearl(Clone)")
            {
                // 찾은 진주 조개 수에 1 더하기 (추후에 점수로 변경)
                countPearlShell += 1;
                scorePearlShell += 23;  // 진주조개 하나 찾을 때 마다 점수 23 더하기
                numPearlShell.text = countPearlShell.ToString();

                // 진주조개 10의 배수만큼 찾을 때마다
                if (countPearlShell %10 == 0)
                {
                    // 시간 5초 증가
                    GameTimeSlider gameTimeSlider = GameObject.Find("TimeSlider").GetComponent<GameTimeSlider>();  // GameTimeSlider 스크립트의 객체 받아옴
                    gameTimeSlider.remainTime += 5;   // remainTime멤버변수 가져옴

                    // 점수 500 추가
                    scorePearlShell += 500;
                }
                txtScore.text = scorePearlShell.ToString();
            }
            else if (target.name == "game1_shell_nonPearl(Clone)")
            {
                // 그냥 조개 수에 1 마이너스
                countNonPearlShell -= 1;
                numNonPearlShell.text = countNonPearlShell.ToString();
                // 시간 3초 감소
                GameTimeSlider gameTimeSlider = GameObject.Find("TimeSlider").GetComponent<GameTimeSlider>();  // GameTimeSlider 스크립트의 객체 받아옴
                gameTimeSlider.remainTime -= 3;   // remainTime멤버변수 가져옴
            }
            
            Destroy(target);
        }
    }

    void CastRay() // 유닛 히트처리 부분.  레이를 쏴서 처리합니다. 
    {
        target = null;
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
        
        if (hit.collider != null)
        { //히트되었다면 여기서 실행
            if (hit.collider.tag == "GameObject_Sea_Shell")
            {
                Debug.Log(hit.collider.name);  //이 부분을 활성화 하면, 선택된 오브젝트의 이름이 찍혀 나옵니다. 
                target = hit.collider.gameObject;  //히트 된 게임 오브젝트를 타겟으로 지정
            }
        }

    }
    
}
