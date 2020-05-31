using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class Save_game2_data : MonoBehaviour
{
    FirebaseApp firebaseApp;
    DatabaseReference reference;

    string userId;
    string date;

    private User_data UserData_Script;

    void Awake()
    {
        firebaseApp = FirebaseDatabase.DefaultInstance.App;
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://remedy-stones.firebaseio.com/");
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        UserData_Script = GameObject.Find("UserData").GetComponent<User_data>();
    }
    //게임 2 우리는 목이 말라요 (시각)
    public bool saveGame2WaterScore(int score)
    {
        userId = UserData_Script.userId;
        date = System.DateTime.Now.ToString("yyyy/MM/dd");
        if (score != null)
        {
            reference.Child("game2").Child(userId).Child("visual").Child(date).SetValueAsync(score);
            Debug.Log("score 저장 성공");
            return true;
        }
        return false;
    }
    //게임 2 내 낙타를 찾아줘 (청각)
    public bool saveGame2CamelScore(int score)
    {
        userId = UserData_Script.userId;
        date = System.DateTime.Now.ToString("yyyy/MM/dd");
        if (score != null)
        {
            reference.Child("game2").Child(userId).Child("auditory").Child("date").Child(date).Child("score").SetValueAsync(score);
            Debug.Log("score 저장 성공");
            return true;
        }
        return false;
    }
    //게임 2 가방 속 물건을 찾아줘 (기억력)
    public bool saveGame2StuffScore(int score)
    {
        userId = UserData_Script.userId;
        date = System.DateTime.Now.ToString("yyyy/MM/dd");
        if (score != null)
        {
            reference.Child("game2").Child(userId).Child("memory").Child(date).SetValueAsync(score);
            Debug.Log("score 저장 성공");
            return true;
        }
        return false;
    }
    //게임 2 루나와 숨바꼭질 ( 행동조절)
    public bool saveGame2LunaScore(int score)
    {
        userId = UserData_Script.userId;
        date = System.DateTime.Now.ToString("yyyy/MM/dd");
        if (score != null)
        {
            reference.Child("game2").Child(userId).Child("control").Child(date).SetValueAsync(score);
            Debug.Log("score 저장 성공");
            return true;
        }
        return false;
    }
    //게임2 소중한 추억을 맞춰줘 ( 문제해결 범주화)
    public bool saveGame2PuzzleScore(int score)
    {
        userId = UserData_Script.userId;
        date = System.DateTime.Now.ToString("yyyy/MM/dd");
        if (score != null)
        {
            reference.Child("game2").Child(userId).Child("organization").Child(date).SetValueAsync(score);
            Debug.Log("score 저장 성공");
            return true;
        }
        return false;
    }
}
