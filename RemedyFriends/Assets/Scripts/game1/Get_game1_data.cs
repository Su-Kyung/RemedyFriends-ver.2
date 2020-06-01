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

    public int count;

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
                        count = list.Score.Length - 1;
                       // Debug.Log(count);
                        //Debug.Log(list.Score[count].date);
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
}
