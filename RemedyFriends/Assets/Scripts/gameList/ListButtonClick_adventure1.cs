using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[RequireComponent(typeof(Button))]
public class ListButtonClick : MonoBehaviour
{
    //리스트 버튼
    public Button shell_button; //버튼
    public Sprite shell_Nclick; //클릭 X 이미지
    public Sprite shell_Oclick; //클릭 O 이미지
    bool isShell = false;       // 선택?

    public Button listening_button;
    public Sprite listening_Nclick;
    public Sprite listening_Oclick;
    bool isListening = false;

    public Button bubble_button;
    public Sprite bubble_Nclick;
    public Sprite bubble_Oclick;
    bool isBubble = false;

    public Button face_button;
    public Sprite face_Nclick;
    public Sprite face_Oclick;
    bool isFace = false;

    // 화면 이미지
    public GameObject game_pick_1st_listening_title; //추후 default인 shell로 변경
    public GameObject game_pick_1st_listening_screen;
    public GameObject game_pick_1st_listening_text;
   


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
        isShell = true;

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
            isShell = true;
            isListening = false;
            isBubble = false;
            isFace = false;
        });
        listening_button.onClick.AddListener(() => {
            isListening = true;
            isShell = false;
            isBubble = false;
            isFace = false;
        });
        bubble_button.onClick.AddListener(() => {
            isBubble = true;
            isShell = false;
            isListening = false;
            isFace = false;
        });
        face_button.onClick.AddListener(() => {
            isFace = true;
            isShell = false;
            isListening = false;
            isBubble = false;
        });

        //클릭 되었을 시
        if (isShell)
        {
            //리스트 버튼 이미지 번경
            shell_button.image.overrideSprite = shell_Oclick;
            listening_button.image.overrideSprite = listening_Nclick;
            bubble_button.image.overrideSprite = bubble_Nclick;
            face_button.image.overrideSprite = face_Nclick;

            //화면 이미지&소개 변경
            //추후 default인 shell로 변경
            game_pick_1st_listening_title.GetComponent<SpriteRenderer>().sprite = Resources.Load("gameTitle/game_pick_1st_shell_title", typeof(Sprite)) as Sprite;
            game_pick_1st_listening_screen.GetComponent<SpriteRenderer>().sprite = Resources.Load("gameScreen/game_shell_all", typeof(Sprite)) as Sprite; //데모
            game_pick_1st_listening_text.GetComponent<SpriteRenderer>().sprite = Resources.Load("gameText/game_pick_1st_shell_text", typeof(Sprite)) as Sprite;

            onclick_tutorialButton();
        }
        else if (isListening) {
            //리스트 버튼 이미지 번경
            listening_button.image.overrideSprite = listening_Oclick;
            shell_button.image.overrideSprite = shell_Nclick;
            bubble_button.image.overrideSprite = bubble_Nclick;
            face_button.image.overrideSprite = face_Nclick;

            //화면 이미지&소개 변경
            //추후 default인 shell로 변경
            game_pick_1st_listening_title.GetComponent<SpriteRenderer>().sprite = Resources.Load("gameTitle/game_pick_1st_listening_title", typeof(Sprite)) as Sprite;
            game_pick_1st_listening_screen.GetComponent<SpriteRenderer>().sprite = Resources.Load("gameScreen/game_pick_1st_listening_screen", typeof(Sprite)) as Sprite;
            game_pick_1st_listening_text.GetComponent<SpriteRenderer>().sprite = Resources.Load("gameText/game_pick_1st_listening_text", typeof(Sprite)) as Sprite;

            onclick_tutorialButton();
        }
        else if (isBubble)
        {
            //리스트 버튼 이미지 번경
            bubble_button.image.overrideSprite = bubble_Oclick;
            shell_button.image.overrideSprite = shell_Nclick;
            listening_button.image.overrideSprite = listening_Nclick;
            face_button.image.overrideSprite = face_Nclick;

            //화면 이미지&소개 변경
            //추후 default인 shell로 변경
            game_pick_1st_listening_title.GetComponent<SpriteRenderer>().sprite = Resources.Load("gameTitle/game_pick_1st_bubble_title", typeof(Sprite)) as Sprite;
            game_pick_1st_listening_screen.GetComponent<SpriteRenderer>().sprite = Resources.Load("gameScreen/game_bboggeul_all", typeof(Sprite)) as Sprite;//데모
            game_pick_1st_listening_text.GetComponent<SpriteRenderer>().sprite = Resources.Load("gameText/game_pick_1st_bubble_text", typeof(Sprite)) as Sprite;

            onclick_tutorialButton();
        }
        else if (isFace)
        {
            //리스트 버튼 이미지 번경
            face_button.image.overrideSprite = face_Oclick;
            shell_button.image.overrideSprite = shell_Nclick;
            listening_button.image.overrideSprite = listening_Nclick;
            bubble_button.image.overrideSprite = bubble_Nclick;

            //화면 이미지&소개 변경
            //추후 default인 shell로 변경
            game_pick_1st_listening_title.GetComponent<SpriteRenderer>().sprite = Resources.Load("gameTitle/game_pick_1st_face_title", typeof(Sprite)) as Sprite;
            game_pick_1st_listening_screen.GetComponent<SpriteRenderer>().sprite = Resources.Load("gameScreen/game_eating_all", typeof(Sprite)) as Sprite; //데모
            game_pick_1st_listening_text.GetComponent<SpriteRenderer>().sprite = Resources.Load("gameText/game_pick_1st_face_text", typeof(Sprite)) as Sprite;

            onclick_tutorialButton();
        }
    }

    public void onclick_tutorialButton()
    {

    }
    public void onclick_startButton() {

    }
   
}
