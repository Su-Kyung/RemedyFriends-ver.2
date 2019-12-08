using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class SceneChange : MonoBehaviour
{
    /*
     * 혹시 몰라서 기존 코드 그냥 남겨둠 ( 그냥 무시하고 나중에 필요하면 참고 )
     * 
    //public GameObject main_stageBtn_1st;
    public UnityEvent OnClick = new UnityEvent();

    void Start()
    {
        //main_stageBtn_1st = GameObject.Find("main_stageBtn_1st");
        //main_stageBtn_1st = this.gameObject;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
            if (hit.collider != null)
                OnClick.Invoke();
        }

    }
    public void ButtonClick_Sea() {
        SceneManager.LoadScene("gameList");
    }
    public void ButtonClick_Back()
    {
        SceneManager.LoadScene("main");
    }

    public void ButtonClick_game1_Shell()
    {
        SceneManager.LoadScene("game1_Find the Pearl Shell");
    }
    */

    // GameObject에 대한 클릭 이벤트 필요하면 충돌 방지 위해 아래 코드 긁어서 사용할 것

    private GameObject target;  // 어떤 Object를 클릭했는지 저장 위한 target 변수 선언


    void Update()
    {
        // 1. 터치했을 때(마우스 클릭했을 때)
        if (Input.GetMouseButtonDown(0))
        {
            // 터치(클릭)에 대한 함수 실행(함수 정의는 아래에 있음)
            CastRay();

            // 3. CastRay() 실행 결과 할당받은 target에 대해 어떻게 할 것인지 경우를 나누어 작성한다.
            // if문 말고 case문으로 바꾸는게 나을듯,, (일단 기말때까지는 if문으로..귀찮음)

            // if문의 조건 안에는 (target.name == "얘를 클릭했을 때의 얘를 담당하는 애 이름")
            // 그니까 Hierarchy 창에서 오브젝트 이름 바꿀 때 특히 클릭이벤트 발생시켜야 하는 애면 신중에 신중을 가해야 함
            // 바다 버튼 클릭했을 때
            if (target.name == "main_stageBtn_1st")
            {
                // 게임리스트 씬으로 넘어간다
                SceneManager.LoadScene("gameList");
            }
            // 바다 리스트에서 뒤로가기 클릭했을 때
            else if (target.name == "game_pick_backBtn")
            {
                // main 씬으로 넘어간다
                SceneManager.LoadScene("main");
            }
            // 게임시작 버튼 눌렀을 때(이거 리스트에서 게임 선택해서 바껴도 시작은 그대로임.. 걍 시작버튼에 콜라이더만 달랑 띄워둔 상태라 ㅎㅎ...)
            else if (target.name == "game_pick_startBtn")
            {
                // 진주조개 게임 씬으로 넘어간다.
                SceneManager.LoadScene("game1_Find the Pearl Shell");
            }
        }
    }

    void CastRay() // 2. 유닛 히트처리 부분.  레이를 쏴서 처리하는 방식 
    {
        target = null;  // 히트된 유닛(=Object)를 null로 초기화

        // 히트 좌표 설정
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

        // 히트된 콜라이더가 무효(null값)가 아니라면
        if (hit.collider != null)
        {
            /* 만약, UI / GameObject 등 뭔가 겹칠 위험이 있으면 무조건 tag로 분류.
             * 그리고 여기에서 다시 if문 실행한다(tag가 A일때, tag가 B일때 등등 위해서..)
             * 예제는 game1_shell.cs의 54 line 참고!!
             * 이 스크립트의 경우에는 씬 바꾸는거만 일단 들어가 있기 때문에 굳이 추가 안했다.
             * 단, 겹치는 Layer가 없더라도 추후에 설정은 하는것이 깔끔은 할듯 하지만 당장 필요한거 아니라서 데모까지는 일단 안할래
             */

            //즉, 히트되었다면 여기서 실행
            Debug.Log(hit.collider.name);  //이 부분을 활성화 하면, 선택된 오브젝트의 이름이 찍혀 나온다. 
            target = hit.collider.gameObject;  //히트 된 게임 오브젝트를 타겟으로 지정(드디어 해당 타겟에 대한 동작 코딩 가능(Update()에서)
        }

    }
}
