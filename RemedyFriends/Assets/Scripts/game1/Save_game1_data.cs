using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class Save_game1_data : MonoBehaviour
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
    // Start is called before the first frame update
    void Start()
    {
        userId = UserData_Script.userId;
        if (userId == "")
        {
            userId = "test1";
        }
    }
    //게임 1 진주조개 찾기 (시각)
    public bool SaveGame1ShellScore(int score)
    {
        date = System.DateTime.Now.ToString("yyyy/MM/dd");
        if (score != null)
        {
            reference.Child("game1").Child(userId).Child("visual").Child(date).SetValueAsync(score);
            Debug.Log("score 저장 성공");
            return true;
        }
        return false;
    }
    //게임 1 고장난 잠수함을 고쳐줘 (청각)
    public bool saveGame1SubmarineScore(int score)
    {
        date = System.DateTime.Now.ToString("yyyy/MM/dd");
        if (score != null)
        {
            reference.Child("game1").Child(userId).Child("auditory").Child(date).SetValueAsync(score);
            Debug.Log("score 저장 성공");
            return true;
        }
        return false;
    }
    //게임 1 뽀글뽀글 연주하기 (기억력)
    public bool saveGame1BubbleScore(int score)
    {
        date = System.DateTime.Now.ToString("yyyy/MM/dd");
        if (score != null)
        {
            reference.Child("game1").Child(userId).Child("memory").Child(date).SetValueAsync(score);
            Debug.Log("score 저장 성공");
            return true;
        }
        return false;
    }
    //게임 1 상어몰래 사냥하기 (행동조절)
    public bool saveGame1SharkScore(int score)
    {
        date = System.DateTime.Now.ToString("yyyy/MM/dd");
        if (score != null)
        {
            reference.Child("game1").Child(userId).Child("control").Child(date).SetValueAsync(score);
            Debug.Log("score 저장 성공");
            return true;
        }
        return false;
    }
}
