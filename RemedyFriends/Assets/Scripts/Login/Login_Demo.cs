using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;

public class Login_Demo : MonoBehaviour
{
    public InputField InputField_login_id;
    public InputField InputField_login_pw;
    public InputField InputField_join_id;
    public InputField InputField_join_pw;
    public InputField InputField_pw_check;
    public InputField InputField_nickname;
    public string txt;

    public bool Save() {
        if (InputField_join_id.text != "") {
            if (InputField_join_pw.text == InputField_pw_check.text)
            {
                PlayerPrefs.SetString("ID", InputField_join_id.text);
                PlayerPrefs.SetString("PW", InputField_join_pw.text);
                return true;
            }
            else
            {
                Debug.Log("비밀번호가 같지 않습니다.");
                return false;
            }
        }
        return false;
    }
    public bool Save_nick() {
        if (InputField_nickname.text != "")
        {
            PlayerPrefs.SetString("Nickname", InputField_nickname.text); //닉네임 저장되는지 확인
            return true;
        }
        return false;
    }
    public void Load() {
        //if (PlayerPrefs.HasKey("Nickname")) {
            //닉네임 칸에 설정 --> 수정
            txt = PlayerPrefs.GetString("Nickname", InputField_nickname.text);
        //}
    }
    /*
    public bool Isjoined() {
        if (InputField_join_id.text == InputField_login_id.text) {
            if (InputField_join_pw.text == InputField_login_pw.text) {
                return true;
            }
        }
    }
    */
}
