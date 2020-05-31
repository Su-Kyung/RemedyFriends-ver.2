using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

    public class All_Result_data : MonoBehaviour
{
    FirebaseApp firebaseApp;
    DatabaseReference reference;

    string userId;
    string date;
   // string[] userdate;
    string scoreShell;

    private User_data UserData_Script;

    void Awake()
    {
        firebaseApp = FirebaseDatabase.DefaultInstance.App;
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://remedy-stones.firebaseio.com/");
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        //UserData_Script = GameObject.Find("UserData").GetComponent<User_data>();
    }

    void Start()
    {
        getGame1AllScore();
    }

    public string getGame1AllScore()
    {
        //date = currentDate;
        //userId = UserData_Script.userId;
        userId = "test1";
        Debug.LogFormat("UserID = {0}", userId);
        FirebaseDatabase.DefaultInstance.GetReference("game1")
                .LimitToLast(20).GetValueAsync().ContinueWith(task =>
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
                    int i = 0;
                    if (userIds.Key == userId)
                    {
                        ScoreList list = JsonUtility.FromJson<ScoreList>(userIds.Child("visual").GetRawJsonValue());
                        int count = list.Score.Length-1;
                        Debug.Log(count);
                        Debug.Log(list.Score[count].date);
                    }
                }
            }
        });
        //if (scoreShell == null || scoreShell == "")
            //return "0";
        return "0";
    }

}
