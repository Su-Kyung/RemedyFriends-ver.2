using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameScore : MonoBehaviour
{
    private GameObject btnScore;    // 다시하기 혹은 나가기 버튼

    // 화면 전환 위한(게임리스트로 나가기 위한) 선언
    public UnityEvent OnClick = new UnityEvent();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CastRay();

            // 다시하기 버튼 클릭했을 때
            if (btnScore.name == "game_score_popup_replay")
            {
                // 게임 다시 시작하기 (맞나 확인)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            // 나가기 버튼 클릭했을 때
            else if (btnScore.name == "game_score_popup_exit")
            {
                // 게임 리스트 화면으로 넘어가기
                //OnClick.Invoke();
                SceneManager.LoadScene("gameList");
            }
        }
    }

    void CastRay() // 유닛 히트처리 부분.  레이를 쏴서 처리합니다. 
    {
        btnScore = null;
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

        if (hit.collider != null)
        { //히트되었다면 여기서 실행
            Debug.Log(hit.collider.name);  //이 부분을 활성화 하면, 선택된 오브젝트의 이름이 찍혀 나옵니다. 
            btnScore = hit.collider.gameObject;  //히트 된 게임 오브젝트를 타겟으로 지정
        }
    }
    /*
    // 게임리스트 화면으로 나가기
    public void ButtonClick_Exit()
    {
        SceneManager.LoadScene("gameList");
    }
    */
}
