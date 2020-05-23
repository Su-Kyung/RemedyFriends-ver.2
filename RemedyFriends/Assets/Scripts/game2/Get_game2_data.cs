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

    string scoreCamel;

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

    public string getGame2CamelScore(string currentDate)
    {
        date = currentDate;
        userId = "test1";
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
}
