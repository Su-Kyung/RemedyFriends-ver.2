using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class Get_game2_data : MonoBehaviour
{
    FirebaseApp firebaseApp;
    DatabaseReference reference;

    string userId;
    string date;

    string scoreWater;
    string scoreCamel;
    string scoreStuff;
    string scoreLuna;
    string scorePuzzle;

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
        if (UserData_Script.userId == null || UserData_Script.userId =="")
        {
            userId = "test1";
        }
        else
        {
            userId = UserData_Script.userId;
        } 
    }
    //게임 2 우리는 목이 말라요 (시각) 
    public string getGame2WaterScore(string currentDate)
    {
        date = currentDate;
        Debug.LogFormat("UserID = {0}", userId);
        FirebaseDatabase.DefaultInstance.GetReference("game2").GetValueAsync().ContinueWith(task =>
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
                    if (userIds.Key == userId)
                    {
                        scoreWater = userIds.Child("visual").Child(date).Value.ToString();
                        //Debug.LogFormat("scoreWater = {0}", scoreWater);
                    }
                }
            }
        });
        if (scoreWater == null || scoreWater == "")
            return "0";
        return scoreWater;
    }
    //ㄱㅔ임 2 내 낙타를 찾아줘 (청각)
    public string getGame2CamelScore(string currentDate)
    {
        date = currentDate;
        Debug.LogFormat("UserID = {0}", userId);
        FirebaseDatabase.DefaultInstance.GetReference("game2").GetValueAsync().ContinueWith(task =>
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
                    if (userIds.Key == userId)
                    {
                        scoreCamel = userIds.Child("auditory").Child(date).Value.ToString();
                        //Debug.LogFormat("scoreCamel = {0}", scoreCamel);
                    }
                }
            }
        });
        if (scoreCamel == null || scoreCamel == "")
            return "0";
        return scoreCamel;
    }
    //게임 2 가방 속 물건을 찾아줘 (기억력)
    public string getGame2StuffScore(string currentDate)
    {
        date = currentDate;
        Debug.LogFormat("UserID = {0}", userId);
        FirebaseDatabase.DefaultInstance.GetReference("game2").GetValueAsync().ContinueWith(task =>
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
                    if (userIds.Key == userId)
                    {
                        scoreStuff = userIds.Child("memory").Child(date).Value.ToString();
                        //Debug.LogFormat("scoreStuff = {0}", scoreStuff);
                    }
                }
            }
        });
        if (scoreStuff == null || scoreStuff == "")
            return "0";
        return scoreStuff;
    }
    //게임 2 루나와 숨바꼭질 (행동 조절) 
    public string getGame2LunaScore(string currentDate)
    {
        date = currentDate;
        Debug.LogFormat("UserID = {0}", userId);
        FirebaseDatabase.DefaultInstance.GetReference("game2").GetValueAsync().ContinueWith(task =>
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
                    if (userIds.Key == userId)
                    {
                        scoreLuna = userIds.Child("control").Child(date).Value.ToString();
                        //Debug.LogFormat("scoreLuna = {0}", scoreLuna);
                    }
                }
            }
        });
        if (scoreLuna == null || scoreLuna == "")
            return "0";
        return scoreLuna;
    }
    //게임 2 소중한 추억을 맞춰줘 (문제해결: 범주화)
    public string getGame2PuzzleScore(string currentDate)
    {
        date = currentDate;
        Debug.LogFormat("UserID = {0}", userId);
        FirebaseDatabase.DefaultInstance.GetReference("game2").GetValueAsync().ContinueWith(task =>
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
                    if (userIds.Key == userId)
                    {
                        scorePuzzle = userIds.Child("organization").Child(date).Value.ToString();
                        //Debug.LogFormat("scorePuzzle = {0}", scorePuzzle);
                    }
                }
            }
        });
        if (scorePuzzle == null || scorePuzzle == "")
            return "0";
        return scorePuzzle;
    }
}
