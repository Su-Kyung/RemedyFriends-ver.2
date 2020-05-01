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

    void Awake()
    {
        firebaseApp = FirebaseDatabase.DefaultInstance.App;
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://remedy-stones.firebaseio.com/");
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        // FirebaseApp.DefaultInstance.SetEditorP12FileName("remedy-stones-55aaa9275afb.p12");
        //FirebaseApp.DefaultInstance.SetEditorServiceAccountEmail("remedy-stones@appspot.gserviceaccount.com");
        //FirebaseApp.DefaultInstance.SetEditorP12Password("notasecret");
    }
    

    public string findPasswd()
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
                    Debug.LogFormat("Key = {0}", userIds.Key);
                    if (userIds.Key == InputField_login_id.text)
                    {
                        pw = userIds.Child("password").Value.ToString();
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
            string userspw = findPasswd();
            Debug.LogFormat("userspw = {0}", userspw);
            if (userspw == InputField_login_pw.text)
            {
                Debug.Log("로그인 성공");
                return true;
            }
        }
        return false;
    }
}
//id 유무 체크, id 중복 체크(회원가입) , 닉네임 중복( 필요시)
