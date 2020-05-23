using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;

using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class Users_login : MonoBehaviour
{
    public InputField InputField_login_id;
    public InputField InputField_login_pw;

    FirebaseApp firebaseApp;
    DatabaseReference reference;

    public string pw;
    public bool userHavePw;

    public string nicknameOfUserId;
    public bool IsUserNickname;

    void Awake()
    {
        firebaseApp = FirebaseDatabase.DefaultInstance.App;
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://remedy-stones.firebaseio.com/");
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        // FirebaseApp.DefaultInstance.SetEditorP12FileName("remedy-stones-55aaa9275afb.p12");
        //FirebaseApp.DefaultInstance.SetEditorServiceAccountEmail("remedy-stones@appspot.gserviceaccount.com");
        //FirebaseApp.DefaultInstance.SetEditorP12Password("notasecret");
    }


    public string findPasswdAndNickname()
    {
        FirebaseDatabase.DefaultInstance.GetReference("users").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                Debug.Log("error");
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;

                foreach (var userIds in snapshot.Children)
                {
                    //Debug.LogFormat("Key = {0}", userIds.Key);
                    if (userIds.Key == InputField_login_id.text)
                    {
                        pw = userIds.Child("password").Value.ToString();
                        nicknameOfUserId = userIds.Child("nickname").Value.ToString();
                        Debug.LogFormat("nickname = {0}", nicknameOfUserId);
                        Debug.LogFormat("pw = {0}", pw);
                    }
                }
            }
        });

        return pw;
    }

    public bool userLogin()
    {
        Debug.Log("Users_Login 실행");
        if (InputField_login_id.text != "")
        {
            StartCoroutine("checkPassword");
            return true;
            /*
            if (userHavePw)
            {
                userHavePw = false;
                Debug.LogFormat("pw넘어온 값 = {0}", pw);
                if (pw == InputField_login_pw.text)
                {
                    Debug.Log("로그인 성공");
                    return true;
                }
                else
                    return false;
            }
            else return false;
*/
        }
        return false;
    }

    public bool checkPasswordAndNickname()
    {/*
        findPasswdAndNickname();
        Debug.Log("코루틴");
        yield return new WaitForSeconds(1.5f);*/
        if (pw != "")
        {
            if (nicknameOfUserId != "")
                IsUserNickname = true;
            else
                IsUserNickname = false;
            return true;
        }
        else
            return false;
        return false;
    }

    public bool haveNickname()
    {
        if (IsUserNickname)
        {
            IsUserNickname = false;
            return true;
        }
        else
            return false;
        return false;
    }
}
