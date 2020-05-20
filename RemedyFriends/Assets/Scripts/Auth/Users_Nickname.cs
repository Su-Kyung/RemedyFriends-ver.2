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

    void Start()
    {
        checkIsDone = 0;
    }

    public string checkNicknameOfUserId()
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
                        nicknameOfUserId = userIds.Child("nickname").Value.ToString();
                        Debug.LogFormat("nickname = {0}", nicknameOfUserId);
                    }
                }
            }
        });
        return nicknameOfUserId;
    }

    //닉네임 존재 여부
    public bool haveNickname() {
        if (IsUserNickname)
        {
            IsUserNickname = false;
            return true;
        }
        else
            return false;
        return false;
    }

    public void startFindNick() {
        StartCoroutine("checkNickname");
    }

    IEnumerator checkNickname()
    {
        checkNicknameOfUserId();
        yield return new WaitForSeconds(1.0f);
        if (nicknameOfUserId != "")
            IsUserNickname = true;
        else
            IsUserNickname = false;
        checkIsDone = 1;
        Debug.Log("닉네임체크 끝");
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
