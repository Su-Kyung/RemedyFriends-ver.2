using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;


public class PopupChange : MonoBehaviour
{
    private GameObject target;

    GameObject loginObj;
    GameObject joinObj;
    GameObject nicknameObj;
    GameObject select_charObj;

    public InputField InputField_login_id;
    public InputField InputField_login_pw;
    public InputField InputField_join_id;
    public InputField InputField_join_pw;

    public int selected_Character;

    private Login_Demo Script;
    private Select_char Character_Script;

    void Awake()
    {
        loginObj = GameObject.FindWithTag("Login");
        joinObj = GameObject.FindWithTag("Join");
        nicknameObj = GameObject.FindWithTag("Nickname");
        select_charObj = GameObject.FindWithTag("Select_char");

        loginObj.SetActive(true);
        joinObj.SetActive(false);
        nicknameObj.SetActive(false);
        select_charObj.SetActive(false);

        Script = GameObject.Find("LoginObj").GetComponent<Login_Demo>();
        Character_Script = GameObject.Find("Select_Character").GetComponent<Select_char>();
        //DontDestroyOnLoad(GameObject.Find("LoginObj")); //향후 수정 가능하면 수정바람...
        //DontDestroyOnLoad(GameObject.Find("Select_Character"));
        DontDestroyOnLoad(this);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CastRay();

            if (target.name == "login_joinBtn")
            {
                //로그인 화면 숨기고 회원가입 창 열기
                loginObj.SetActive(false);
                joinObj.SetActive(true);
            }

            else if (target.name == "login_submit")
            {//Login 스크립트로 옮길 수 있으면 옮기기
                if (InputField_join_id.text == InputField_login_id.text)
                {
                    if (InputField_join_pw.text == InputField_login_pw.text)
                    {//로그인 화면 숨기고 닉네임 설정창 열기
                        loginObj.SetActive(false);
                        nicknameObj.SetActive(true);
                        Debug.Log("로그인 성공");
                    }
                    else
                    {
                        Debug.Log("응 님 비번 틀림");
                    }
                }
                else
                {
                    Debug.Log("응 님 아이디 없음");
                }
            }
            else if (target.name == "join_submit")
            {

                if (Script.Save())
                {
                    loginObj.SetActive(true);
                    joinObj.SetActive(false);
                    Debug.Log("회원가입 성공");
                }
                else
                {
                    Debug.Log("님 비번 틀림 다시 시도하셈");
                }
            }
            else if (target.name == "nickname_submit") {
                if (Script.Save_nick())
                { nicknameObj.SetActive(false);
                    select_charObj.SetActive(true);
                    Debug.Log("닉네임 저장 완료");
                }
            }
            else if (target.name == "join_char_startBtn")
            {
                //캐릭터 선택하면 색 바뀌고 값 반환하는 스크립트 작성 후 연결
                //변수에 저장 -> 메인 스크립트에서 연결
                selected_Character = Character_Script.selected;
                if (selected_Character == 1 | selected_Character == 2 || selected_Character == 3 || selected_Character == 4)
                {
                    Debug.Log("캐릭터 선택 완료");
                    SceneManager.LoadScene("main");

                }
                else {
                      Debug.Log("캐릭터 선택 안됨");
                }
                //시작하기 누르면 메인 화면으로 씬 전환
                //전환 시 LoginObj 남겨두기... //향후 좋은 코드로 고치자 // 너무 더러워...언니 미안....
            }
        }//end of Mouse Button Down
    }

    void CastRay()
    {
        target = null;

        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

        if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);
            target = hit.collider.gameObject;
        }
    }
}
