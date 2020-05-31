using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;


//[RequireComponent(typeof(Button))]
public class ListButtonClick_adventure2 : MonoBehaviour
{
    //리스트 버튼
    public Button thirsty_button; //버튼
    public Sprite thirsty_Nclick; //클릭 X 이미지
    public Sprite thirsty_Oclick; //클릭 O 이미지
    public const int THIRSTY = 1;       // 선택?

    public Button camel_button;
    public Sprite camel_Nclick;
    public Sprite camel_Oclick;
    public const int CAMEL = 2;

    public Button bag_button;
    public Sprite bag_Nclick;
    public Sprite bag_Oclick;
    public const int BAG = 3;

    public Button luna_button;
    public Sprite luna_Nclick;
    public Sprite luna_Oclick;
    public const int LUNA = 4;

    public Button puzzle_button;
    public Sprite puzzle_Nclick;
    public Sprite puzzle_Oclick;
    public const int PUZZLE = 5;
    //_------------------------------------------------------------------------------------------ 수정 시작
    // 화면 이미지
    public GameObject game_pick_1st_listening_title; //추후 default인 thirsty로 변경
    public GameObject game_pick_1st_listening_screen;
    public GameObject game_pick_1st_listening_text;
    //---------------------------------------------------------------------------------------------끝
    public int screen = 1;

    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        //shell_button = GetComponent<Button>();
        //버튼 찾기
        thirsty_button = GameObject.Find("thirsty_Button").GetComponent<Button>();
        camel_button = GameObject.Find("camel_Button").GetComponent<Button>();
        bag_button = GameObject.Find("bag_Button").GetComponent<Button>();
        luna_button = GameObject.Find("luna_Button").GetComponent<Button>();
        puzzle_button = GameObject.Find("puzzle_Button").GetComponent<Button>();
        //default
        screen = THIRSTY;
        //_------------------------------------------------------------------------------------------ 수정 시작
        //화면 이미지 찾기
        game_pick_1st_listening_title = GameObject.Find("game_pick_1st_listening_title"); //추후 default인 thirsty로 변경
        game_pick_1st_listening_screen = GameObject.Find("game_pick_1st_listening_screen");
        game_pick_1st_listening_text = GameObject.Find("game_pick_1st_listening_text");
        //---------------------------------------------------------------------------------------------끝
    }

    // Update is called once per frame
    void Update()
    {
        //클릭 리스너
        thirsty_button.onClick.AddListener(() =>
        {
            screen = THIRSTY;
        });
        camel_button.onClick.AddListener(() =>
        {
            screen = CAMEL;
        });
        bag_button.onClick.AddListener(() =>
        {
            screen = BAG;
        });
        luna_button.onClick.AddListener(() =>
        {
            screen = LUNA;
        });
        puzzle_button.onClick.AddListener(() =>
        {
            screen = PUZZLE;
        });
        //_------------------------------------------------------------------------------------------ 수정 시작 (스크린만 남음)
        //클릭 되었을 시
        if (screen == THIRSTY)
        {
            //리스트 버튼 이미지 번경
            thirsty_button.image.overrideSprite = thirsty_Oclick;
            camel_button.image.overrideSprite = camel_Nclick;
            bag_button.image.overrideSprite = bag_Nclick;
            luna_button.image.overrideSprite = luna_Nclick;
            puzzle_button.image.overrideSprite = puzzle_Nclick;

            //화면 이미지&소개 변경
            //추후 default인 thirsty로 변경
            game_pick_1st_listening_title.GetComponent<SpriteRenderer>().sprite = Resources.Load("gameTitle/game02_thirsty_title", typeof(Sprite)) as Sprite;
            game_pick_1st_listening_screen.GetComponent<SpriteRenderer>().sprite = Resources.Load("gameScreen/game_2nd_hot", typeof(Sprite)) as Sprite; //데모
            game_pick_1st_listening_text.GetComponent<SpriteRenderer>().sprite = Resources.Load("gameText/game02_thirsty_text", typeof(Sprite)) as Sprite;

            onclick_startButton();
        }
        else if (screen == CAMEL)
        {
            //리스트 버튼 이미지 번경
            camel_button.image.overrideSprite = camel_Oclick;
            thirsty_button.image.overrideSprite = thirsty_Nclick;
            bag_button.image.overrideSprite = bag_Nclick;
            luna_button.image.overrideSprite = luna_Nclick;
            puzzle_button.image.overrideSprite = puzzle_Nclick;

            //화면 이미지&소개 변경
            //추후 default인 thirsty로 변경
            game_pick_1st_listening_title.GetComponent<SpriteRenderer>().sprite = Resources.Load("gameTitle/game02_camel_title", typeof(Sprite)) as Sprite;
            game_pick_1st_listening_screen.GetComponent<SpriteRenderer>().sprite = Resources.Load("gameScreen/game_2nd_camel", typeof(Sprite)) as Sprite;
            game_pick_1st_listening_text.GetComponent<SpriteRenderer>().sprite = Resources.Load("gameText/game02_camel_text", typeof(Sprite)) as Sprite;

            onclick_startButton();
        }
        else if (screen == BAG)
        {
            //리스트 버튼 이미지 번경
            bag_button.image.overrideSprite = bag_Oclick;
            thirsty_button.image.overrideSprite = thirsty_Nclick;
            camel_button.image.overrideSprite = camel_Nclick;
            luna_button.image.overrideSprite = luna_Nclick;
            puzzle_button.image.overrideSprite = puzzle_Nclick;

            //화면 이미지&소개 변경
            //추후 default인 shell로 변경
            game_pick_1st_listening_title.GetComponent<SpriteRenderer>().sprite = Resources.Load("gameTitle/game02_bag_title", typeof(Sprite)) as Sprite;
            game_pick_1st_listening_screen.GetComponent<SpriteRenderer>().sprite = Resources.Load("gameScreen/bag_bg", typeof(Sprite)) as Sprite;//데모
            game_pick_1st_listening_text.GetComponent<SpriteRenderer>().sprite = Resources.Load("gameText/game02_bag_text", typeof(Sprite)) as Sprite;

            onclick_startButton();
        }
        else if (screen == LUNA)
        {
            //리스트 버튼 이미지 번경
            luna_button.image.overrideSprite = luna_Oclick;
            thirsty_button.image.overrideSprite = thirsty_Nclick;
            camel_button.image.overrideSprite = camel_Nclick;
            bag_button.image.overrideSprite = bag_Nclick;
            puzzle_button.image.overrideSprite = puzzle_Nclick;

            //화면 이미지&소개 변경
            //추후 default인 shell로 변경
            game_pick_1st_listening_title.GetComponent<SpriteRenderer>().sprite = Resources.Load("gameTitle/game02_luna_title", typeof(Sprite)) as Sprite;
            game_pick_1st_listening_screen.GetComponent<SpriteRenderer>().sprite = Resources.Load("gameScreen/game_2nd_luna", typeof(Sprite)) as Sprite; //데모
            game_pick_1st_listening_text.GetComponent<SpriteRenderer>().sprite = Resources.Load("gameText/game02_luna_text", typeof(Sprite)) as Sprite;

            onclick_startButton();
        }
        else if (screen == PUZZLE)
        {
            //리스트 버튼 이미지 번경
            puzzle_button.image.overrideSprite = puzzle_Oclick;
            thirsty_button.image.overrideSprite = thirsty_Nclick;
            camel_button.image.overrideSprite = camel_Nclick;
            bag_button.image.overrideSprite = bag_Nclick;
            luna_button.image.overrideSprite = luna_Nclick;

            //화면 이미지&소개 변경
            //추후 default인 shell로 변경
            game_pick_1st_listening_title.GetComponent<SpriteRenderer>().sprite = Resources.Load("gameTitle/game02_puzzle_title", typeof(Sprite)) as Sprite;
            game_pick_1st_listening_screen.GetComponent<SpriteRenderer>().sprite = Resources.Load("gameScreen/game_2nd_puzzle", typeof(Sprite)) as Sprite; //데모
            game_pick_1st_listening_text.GetComponent<SpriteRenderer>().sprite = Resources.Load("gameText/game02_puzzle_text", typeof(Sprite)) as Sprite;

            onclick_startButton();
        }
        //---------------------------------------------------------------------------------------------끝
    }
    public void onclick_startButton()
    {
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

            if (target.name == "game_pick_startBtn" && screen == THIRSTY)
            {
                SceneManager.LoadScene("game2_Give Me some Water");
            }
            else if (target.name == "game_pick_startBtn" && screen == CAMEL)
            {
                SceneManager.LoadScene("game2_Find my camel");
            }
            else if (target.name == "game_pick_startBtn" && screen == BAG)
            {
                SceneManager.LoadScene("game2_Find Me the Stuff");
            }
            else if (target.name == "game_pick_startBtn" && screen == LUNA)
            {
                SceneManager.LoadScene("game2_Hide and seek with Luna");
            }
            else if (target.name == "game_pick_startBtn" && screen == PUZZLE)
            {
                SceneManager.LoadScene("game2_Put the Puzzle Together");
            }
        }
    }
}
