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

    string scoreShell;
    string scoreSubmarine;
    string scoreBubble;
    string scoreShark;

    private User_data UserData_Script;

    void Awake()
    {
        firebaseApp = FirebaseDatabase.DefaultInstance.App;
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://remedy-stones.firebaseio.com/");
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        UserData_Script = GameObject.Find("UserData").GetComponent<User_data>();
    }
    //게임 1 진주조개 찾기 (시각)
    public string getGame1ShellScore(string currentDate)
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
                        scoreShell = userIds.Child("visual").Child(date).Value.ToString();
                        //Debug.LogFormat("scoreShell = {0}", scoreShell);
                    }
                }
            }
        });
        if (scoreShell == null || scoreShell == "")
            return "0";
        return scoreShell;
    }
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
    }
}
