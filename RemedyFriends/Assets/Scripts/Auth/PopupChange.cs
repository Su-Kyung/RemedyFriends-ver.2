using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;


public class PopupChange : MonoBehaviour
{
    private GameObject target;

    //팝업을 위해 생성
    GameObject loginObj;
    GameObject joinObj;
    GameObject nicknameObj;
    //GameObject select_charObj;

    public InputField InputField_login_id;
    public InputField InputField_login_pw;
    public InputField InputField_join_id;
    public InputField InputField_join_pw;
    public InputField InputField_nickname;

    public int selected_Character;

    private Sign_up SignUp_Script;
    private Users_login Login_Script;
    private Users_Nickname Nickname_Script;
    private User_data UserData_Script;
    //private Select_char Character_Script;

    void Awake()
    {
        loginObj = GameObject.FindWithTag("Login");
        joinObj = GameObject.FindWithTag("Join");
        nicknameObj = GameObject.FindWithTag("Nickname");
        //select_charObj = GameObject.FindWithTag("Select_char");

        loginObj.SetActive(true);
        joinObj.SetActive(false);
        nicknameObj.SetActive(false);
        //select_charObj.SetActive(false);

        SignUp_Script = GameObject.Find("SignUp").GetComponent<Sign_up>();
        Login_Script = GameObject.Find("Login_user").GetComponent<Users_login>();
        Nickname_Script = GameObject.Find("SignUp").GetComponent<Users_Nickname>();
        UserData_Script = GameObject.Find("UserData").GetComponent<User_data>();
        //Character_Script = GameObject.Find("Select_Character").GetComponent<Select_char>();
    }

    void LockInput(InputField input)
    {
        if (input.text.Length > 0)
        {
            Login_Script.findPasswdAndNickname();
            Debug.Log("Text has been entered");
        }
        else if (input.text.Length == 0)
        {
            Debug.Log("아이디를 입력해주세요");
        }
    }
    void Start()
    {
        InputField_login_id.onEndEdit.AddListener(delegate { LockInput(InputField_login_id); });
    }
    public void clickLoginSubmitButton()
    {
        if (InputField_login_id.text != "")
        {
            if (InputField_login_pw.text != "")
            {
                if (Login_Script.checkPasswordAndNickname() && Login_Script.pw == InputField_login_pw.text)
                {
                    Debug.Log("로그인 성공");
                    if (Login_Script.haveNickname())
                    {
                        Debug.Log("닉네임 있음 메인으로");
                        UserData_Script.saveUserIdpw(InputField_login_id.text, InputField_login_pw.text);
                        UserData_Script.saveUserNickname(Login_Script.nicknameOfUserId);
                        SceneManager.LoadScene(1);
                    }
                    else
                    {
                        loginObj.SetActive(false);
                        Debug.Log("닉네임 창으로");
                        nicknameObj.SetActive(true);
                    }
                }
                else
                {
                    Debug.Log("해당 아이디가 존재하지 않음 || 비밀번호가 다름");
                }
            }
            else
            {
                Debug.Log("비밀번호 입력해주세요");
            }
        }
        else
        {
            Debug.Log("아이디를 입력해주세요");
        }
    }
    public void clickLoginJoinButton()
    {
        //로그인 화면 숨기고 회원가입 창 열기
        loginObj.SetActive(false);
        joinObj.SetActive(true);
    }
    public void clickJoinSubmitButton()
    {
        if (SignUp_Script.signUp())
        {
            loginObj.SetActive(true);
            joinObj.SetActive(false);
        }
    }
    public void clickNicknameSubmitButton()
    {
        if (Nickname_Script.Save_nick())
        {
            UserData_Script.saveUserIdpw(InputField_login_id.text, InputField_login_pw.text);
            UserData_Script.saveUserNickname(InputField_nickname.text.Trim());
            //nicknameObj.SetActive(false);
            SceneManager.LoadScene("intro");
            //select_charObj.SetActive(true);
        }
    }
}

/*
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
       }*/
