using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class Get_game1_data : MonoBehaviour
{
    FirebaseApp firebaseApp;
    DatabaseReference reference;

    string userId;
    string date;

    public int score;

    private User_data UserData_Script;

    void Awake()
    {
        firebaseApp = FirebaseDatabase.DefaultInstance.App;
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://remedy-stones.firebaseio.com/");
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        UserData_Script = GameObject.Find("UserData").GetComponent<User_data>();
    }
    //게임 1
    public void getGame1Score(string part, string currentDate)
    {
        userId = UserData_Script.userId;
        Debug.LogFormat("UserID = {0}", userId);
        FirebaseDatabase.DefaultInstance.GetReference("game1").GetValueAsync().ContinueWith(task =>
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
                        ScoreList list = JsonUtility.FromJson<ScoreList>(userIds.Child(part).GetRawJsonValue());
                        int count = list.Score.Length - 1;
                        Debug.Log(count);
                        Debug.Log(list.Score[count].date);
                        if (list.Score[count].date == currentDate)
                        {
                            score = list.Score[count].userscore;
                            Debug.Log("날짜 같음");
                            Debug.Log("userscore" + score);
                        }
                        else
                        {
                            score = 0;
                            Debug.Log("날짜 다름");
                        }
                    }
                }
            }
        });
    }
    /*
    //게임 1 고장난 잠수함을 고쳐줘 (청각)
    public string getGame1SubmarineScore(string currentDate)
    {
        date = currentDate;
        userId = UserData_Script.userId;
        Debug.LogFormat("UserID = {0}", userId);
        FirebaseDatabase.DefaultInstance.GetReference("game1").GetValueAsync().ContinueWith(task =>
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
                        scoreSubmarine = userIds.Child("auditory").Child(date).Value.ToString();
                        //Debug.LogFormat("scoreSubmarine = {0}", scoreSubmarine);
                    }
                }
            }
        });
        if (scoreSubmarine == null || scoreSubmarine == "")
            return "0";
        return scoreSubmarine;
    }
    //게임 1 뽀글뽀글 연주하기 (기억력)
    public string getGame1BubbleScore(string currentDate)
    {
        date = currentDate;
        userId = UserData_Script.userId;
        Debug.LogFormat("UserID = {0}", userId);
        FirebaseDatabase.DefaultInstance.GetReference("game1").GetValueAsync().ContinueWith(task =>
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
                        scoreBubble = userIds.Child("memory").Child(date).Value.ToString();
                        //Debug.LogFormat("scoreBubble = {0}", scoreBubble);
                    }
                }
            }
        });
        if (scoreBubble == null || scoreBubble == "")
            return "0";
        return scoreBubble;
    }
    //게임 1 상어몰래 사냥하기 (행동조절)
    public string getGame1SharkScore(string currentDate)
    {
        date = currentDate;
        userId = UserData_Script.userId;
        Debug.LogFormat("UserID = {0}", userId);
        FirebaseDatabase.DefaultInstance.GetReference("game1").GetValueAsync().ContinueWith(task =>
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
                        scoreShark = userIds.Child("control").Child(date).Value.ToString();
                        //Debug.LogFormat("scoreShark = {0}", scoreShark);
                    }
                }
            }
        });
        if (scoreShark == null || scoreShark == "")
            return "0";
        return scoreShark;
    }*/
}
