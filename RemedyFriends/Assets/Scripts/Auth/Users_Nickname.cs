using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class Users_Nickname : MonoBehaviour
{
    public InputField InputField_login_id;
    public InputField InputField_nickname;

    public string nicknameOfUserId;
    public bool IsUserNickname;

    public int checkIsDone;

    FirebaseApp firebaseApp;
    DatabaseReference reference;

    void Awake()
    {
        firebaseApp = FirebaseDatabase.DefaultInstance.App;
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://remedy-stones.firebaseio.com/");
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }


    //닉네임 저장
    public bool Save_nick()
    {
        string userId = InputField_login_id.text;
        string nickname = InputField_nickname.text;

        if (nickname != "")
        {
            //PlayerPrefs.SetString("Nickname", nickname);
            reference.Child("users").Child(userId).Child("nickname").SetValueAsync(nickname);
            Debug.Log("닉네임저장 성공");
            return true;
        }
        return false;
    }
}
