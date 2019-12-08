using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class game1_btnResult : MonoBehaviour    // 모든 게임에 적용 가능할듯
{
    /*
    public UnityEvent OnClick = new UnityEvent();

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
            if (hit.collider != null)
            {
                // 클릭한 콜라이더 객체가 Finish 태그일 때
                if (hit.collider.tag == "Finish")
                {
                    OnClick.Invoke();
                }
            }
        }
    }

    public void ButtonClick_Sea()
    {
        SceneManager.LoadScene("gameList");
    }

    public void ButtonClick_ReplayShell()   //Replay로 합치는거 되나 해보기
    {
         //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
         SceneManager.LoadScene("game1_Find the Pearl Shell");

    }
    */

    private GameObject target;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CastRay();

            // 나가기 클릭했을 때
            if (target.name == "game_score_popup_exit")
            {
                SceneManager.LoadScene("gameList");
            }
            // 다시하기 클릭했을 때
            else if (target.name == "game_score_popup_replay")
            {
                SceneManager.LoadScene("game1_Find the Pearl Shell");
            }
        }
    }

    void CastRay() // 유닛 히트처리 부분.  레이를 쏴서 처리합니다. 
    {
        target = null;
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

        if (hit.collider != null)
        { //히트되었다면 여기서 실행
            if (hit.collider.tag == "Finish")
            {
                Debug.Log(hit.collider.name);  //이 부분을 활성화 하면, 선택된 오브젝트의 이름이 찍혀 나옵니다. 
                target = hit.collider.gameObject;  //히트 된 게임 오브젝트를 타겟으로 지정
            }
        }

    }
}
