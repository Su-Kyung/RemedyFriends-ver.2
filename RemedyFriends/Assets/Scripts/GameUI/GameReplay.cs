using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 스크립트를 적용: Score
// 다시하기 혹은 나가기를 선택하면, 설정한 index의 Scene으로 이동(점수 저장 위해 게임에만 적용)
public class GameReplay : MonoBehaviour
{
    private GameObject target;  // ray로 계산된 타겟
    public GameObject btnReplay;    // 리플레이 버튼
    public GameObject btnExit;    // 나가기 버튼
    public Scene currentScene;  // 현재 씬(다시하기)
    public Scene listScene;     // 리스트로 나가기

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CastRay();

            // 나가기 클릭했을 때
            if (target == btnExit)
            {
                //SceneManager.LoadScene("gameList_2nd");
                SceneManager.LoadScene(listScene.name);
            }
            // 다시하기 클릭했을 때
            else if (target == btnReplay)
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
            if (hit.collider.tag == currentScene.name)
            {
                Debug.Log(hit.collider.name);  //이 부분을 활성화 하면, 선택된 오브젝트의 이름이 찍혀 나옵니다. 
                target = hit.collider.gameObject;  //히트 된 게임 오브젝트를 타겟으로 지정
            }
        }

    }
}
