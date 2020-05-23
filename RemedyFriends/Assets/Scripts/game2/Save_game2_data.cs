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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool SaveGame2CamelScore(int score)
    {
        userId = "test1";
        date = System.DateTime.Now.ToString("yyyy/MM/dd");
        Debug.Log(date);
        if (score != null)
        {
            reference.Child("game2").Child(userId).Child("camel").Child(date).SetValueAsync(score);
            Debug.Log("score 저장 성공");
            return true;
        }
        return false;
    }
}
