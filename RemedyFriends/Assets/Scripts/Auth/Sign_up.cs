using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class Sign_up : MonoBehaviour
{

    public InputField InputField_join_id;
    public InputField InputField_join_pw;
    public InputField InputField_pw_check;
    public InputField InputField_nickname;


    FirebaseApp firebaseApp;
    DatabaseReference reference;


    void Awake()
    {
        firebaseApp = FirebaseDatabase.DefaultInstance.App;
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://remedy-stones.firebaseio.com/");
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        // FirebaseApp.DefaultInstance.SetEditorP12FileName("remedy-stones-55aaa9275afb.p12");
        //FirebaseApp.DefaultInstance.SetEditorServiceAccountEmail("remedy-stones@appspot.gserviceaccount.com");
        //FirebaseApp.DefaultInstance.SetEditorP12Password("notasecret");

    }
    public bool signUp()
    {
        string userId = InputField_join_id.text;
        string passwd = InputField_join_pw.text;

        if (userId != "")
        {
            if (passwd == InputField_pw_check.text)
            {
                PlayerPrefs.SetString("ID", userId);
                PlayerPrefs.SetString("PW", passwd);

                reference.Child("users").Child(userId).Child("password").SetValueAsync(passwd);
                Debug.Log("회원가입 성공");

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

    public bool Save_nick()
    {
        string userId = InputField_join_id.text;
        string nickname = InputField_nickname.text;

        if (nickname != "")
        {
            PlayerPrefs.SetString("Nickname", nickname);
            reference.Child("users").Child(userId).Child("nickname").SetValueAsync(nickname);
            Debug.Log("닉네임저장 성공");
            return true;
        }
        return false;
    }
}
