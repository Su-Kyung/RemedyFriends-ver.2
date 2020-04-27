using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game1_gameover : MonoBehaviour
{
    private GameObject target;

    // Update is called once per frame
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
                //SceneManager.LoadScene("game1_Find the Pearl Shell");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
