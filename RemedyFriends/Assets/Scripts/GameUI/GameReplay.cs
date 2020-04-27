using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// 게임 전체를 관장하고, 점수를 계산한다.
public class GameReplay : MonoBehaviour
{
    private GameObject target;
    public Scene currentScene;
    public Scene listScene;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CastRay();

            // 나가기 클릭했을 때
            if (target.name == "game_score_popup_exit")
            {
                //SceneManager.LoadScene("gameList_2nd");
                SceneManager.LoadScene(listScene.name);
            }
            // 다시하기 클릭했을 때
            else if (target.name == "game_score_popup_replay")
            {
                //SceneManager.LoadScene("game1_Find the Pearl Shell");
                SceneManager.LoadScene(currentScene.name);
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
