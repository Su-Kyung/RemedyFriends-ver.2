using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

[System.Serializable]
public class Data
{
    public string date;
    public int score;

    public void printData()
    {
        Debug.Log("date : " + date);
        Debug.Log("score : " + score);
    }
}

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
        getGame1ShellAllScore();
    }

    public string getGame1ShellAllScore()
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
                        //IDictionary rank = (IDictionary)userIds.Child("auditory").Value;
                        //Debug.Log("이름: " + rank["date"] + ", 점수: " + rank["score"]);

                        //scoreShell= userIds.Child("auditory").Value.ToString();
                        //Debug.Log(scoreShell);
                        //i++;
                        //Data d = JsonUtility.FromJson(userIds.Child("auditory").Value);
                        //Debug.Log(d.date);
                        //IDictionary<string, GameObject> dictDate = new IDictionary<string, GameObject>();
                        //Dictionary<string ,string> dictDate = (Dictionary)userIds.Child("auditory").Child("date").Value;
                        //var list = new List<int>(dictDate.Values);
                        //for (int i = 0; i < list.Count; i++)
                        // {
                        // Debug.Log(list[i]);
                        // }

                        //IDictionary dictScore = (IDictionary)userIds.Child("auditory").Child("date").Value;
                        // Debug.Log(dictScore["score"]);

                        //userdate[i] = userIds.Child("auditory").Child("date").Value.ToString();
                        //Debug.Log(userdate[i]);
                        //i++;
                        // Debug.Log(userIds.Child("visual").Child("date").GetRawJsonValue());
                        Debug.Log(userIds.Child("visual").GetRawJsonValue());
                    }
                }
            }
        });
        //if (scoreShell == null || scoreShell == "")
            //return "0";
        return "0";
    }

}
