using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

//[RequireComponent(typeof(Button))]
public class ListButtonClick_adventure1 : MonoBehaviour
{
    //리스트 버튼
    public Button shell_button; //버튼
    //public Sprite shell_Nclick; //클릭 X 이미지
    //public Sprite shell_Oclick; //클릭 O 이미지
    public const int SHELL = 1;       // 선택?

    public Button listening_button;
    //public Sprite listening_Nclick;
    //public Sprite listening_Oclick;
    public const int LISTENING = 2;

    public Button bubble_button;
    //public Sprite bubble_Nclick;
    //public Sprite bubble_Oclick;
    public const int BUBBLE = 3;

    public Button face_button;
    //public Sprite face_Nclick;
    //public Sprite face_Oclick;
    public const int FACE = 4;

    // 화면 이미지
    public GameObject game_pick_1st_listening_title; //추후 default인 shell로 변경
    public GameObject game_pick_1st_listening_screen;
    public GameObject game_pick_1st_listening_text;

    public int screen = 1;

    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        //shell_button = GetComponent<Button>();
        //버튼 찾기
        shell_button = GameObject.Find("shell_Button").GetComponent<Button>();
        listening_button = GameObject.Find("listening_Button").GetComponent<Button>();
        bubble_button = GameObject.Find("bubble_Button").GetComponent<Button>();
        face_button = GameObject.Find("face_Button").GetComponent<Button>();
        //default
        screen = SHELL;

        //화면 이미지 찾기
        game_pick_1st_listening_title = GameObject.Find("game_pick_1st_listening_title"); //추후 default인 shell로 변경
        game_pick_1st_listening_screen = GameObject.Find("game_pick_1st_listening_screen");
        game_pick_1st_listening_text = GameObject.Find("game_pick_1st_listening_text"); 
    }

    // Update is called once per frame
    void Update()
    {
        //클릭 리스너
        shell_button.onClick.AddListener(() => {
            screen = SHELL;
        });
        listening_button.onClick.AddListener(() => {
            screen = LISTENING;
        });
        bubble_button.onClick.AddListener(() => {
            screen = BUBBLE;
        });
        face_button.onClick.AddListener(() => {
            screen = FACE;
        });

        //클릭 되었을 시
        if (screen == SHELL)
        {
            //리스트 버튼 이미지 번경
            //shell_button.image.overrideSprite = shell_Oclick;
            //listening_button.image.overrideSprite = listening_Nclick;
            //bubble_button.image.overrideSprite = bubble_Nclick;
            //face_button.image.overrideSprite = face_Nclick;

            //화면 이미지&소개 변경
            //추후 default인 shell로 변경
            game_pick_1st_listening_title.GetComponent<SpriteRenderer>().sprite = Resources.Load("gameTitle/game_pick_1st_shell_title", typeof(Sprite)) as Sprite;
            game_pick_1st_listening_screen.GetComponent<SpriteRenderer>().sprite = Resources.Load("gameScreen/game_shell_all", typeof(Sprite)) as Sprite; //데모
            game_pick_1st_listening_text.GetComponent<SpriteRenderer>().sprite = Resources.Load("gameText/game_pick_1st_shell_text", typeof(Sprite)) as Sprite;

            onclick_startButton();
        }
        else if (screen == LISTENING) {
            //리스트 버튼 이미지 번경
            //listening_button.image.overrideSprite = listening_Oclick;
            //shell_button.image.overrideSprite = shell_Nclick;
            //bubble_button.image.overrideSprite = bubble_Nclick;
            //face_button.image.overrideSprite = face_Nclick;

            //화면 이미지&소개 변경
            //추후 default인 shell로 변경
            game_pick_1st_listening_title.GetComponent<SpriteRenderer>().sprite = Resources.Load("gameTitle/game_pick_1st_listening_title", typeof(Sprite)) as Sprite;
            game_pick_1st_listening_screen.GetComponent<SpriteRenderer>().sprite = Resources.Load("gameScreen/game_pick_1st_listening_screen", typeof(Sprite)) as Sprite;
            game_pick_1st_listening_text.GetComponent<SpriteRenderer>().sprite = Resources.Load("gameText/game_pick_1st_listening_text", typeof(Sprite)) as Sprite;

            onclick_startButton();
        }
        else if (screen == BUBBLE)
        {
            //리스트 버튼 이미지 번경
            //bubble_button.image.overrideSprite = bubble_Oclick;
            //shell_button.image.overrideSprite = shell_Nclick;
            //listening_button.image.overrideSprite = listening_Nclick;
            //face_button.image.overrideSprite = face_Nclick;

            //화면 이미지&소개 변경
            //추후 default인 shell로 변경
            game_pick_1st_listening_title.GetComponent<SpriteRenderer>().sprite = Resources.Load("gameTitle/game_pick_1st_bubble_title", typeof(Sprite)) as Sprite;
            game_pick_1st_listening_screen.GetComponent<SpriteRenderer>().sprite = Resources.Load("gameScreen/game_bboggeul_all", typeof(Sprite)) as Sprite;//데모
            game_pick_1st_listening_text.GetComponent<SpriteRenderer>().sprite = Resources.Load("gameText/game_pick_1st_bubble_text", typeof(Sprite)) as Sprite;

            onclick_startButton();
        }
        else if (screen == FACE)
        {
            //리스트 버튼 이미지 번경
            //face_button.image.overrideSprite = face_Oclick;
            //shell_button.image.overrideSprite = shell_Nclick;
            //listening_button.image.overrideSprite = listening_Nclick;
            //bubble_button.image.overrideSprite = bubble_Nclick;

            //화면 이미지&소개 변경
            //추후 default인 shell로 변경
            game_pick_1st_listening_title.GetComponent<SpriteRenderer>().sprite = Resources.Load("gameTitle/game_pick_1st_face_title", typeof(Sprite)) as Sprite;
            game_pick_1st_listening_screen.GetComponent<SpriteRenderer>().sprite = Resources.Load("gameScreen/game_eating_all", typeof(Sprite)) as Sprite; //데모
            game_pick_1st_listening_text.GetComponent<SpriteRenderer>().sprite = Resources.Load("gameText/game_pick_1st_face_text", typeof(Sprite)) as Sprite;

            onclick_startButton();
        }
    }

    public void onclick_startButton() {
        if (Input.GetMouseButtonDown(0))
        {
            target = null;  // 히트된 유닛(=Object)를 null로 초기화

            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

            if (hit.collider != null)
            {
                Debug.Log(hit.collider.name);  //이 부분을 활성화 하면, 선택된 오브젝트의 이름이 찍혀 나온다. 
                target = hit.collider.gameObject;  //히트 된 게임 오브젝트를 타겟으로 지정(드디어 해당 타겟에 대한 동작 코딩 가능(Update()에서)
            }

            if (target.name == "game_pick_startBtn" && screen == SHELL)
            {
                SceneManager.LoadScene("game1_Find the Pearl Shell");
            }
            else if (target.name == "game_pick_startBtn" && screen == LISTENING)
            {
                SceneManager.LoadScene("game1_Fix the Broken Submarine");
            }
            else if (target.name == "game_pick_startBtn" && screen == BUBBLE)
            {
                SceneManager.LoadScene("game1_To Play Blup-Blup");
            }
            else if (target.name == "game_pick_startBtn" && screen == FACE)
            {
                SceneManager.LoadScene("game1_Sneak the Shark");
            }
        }
    }

}
