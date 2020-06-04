using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class QuestData : MonoBehaviour
{
    string userId;

    private User_data UserData_Script;

    public int questdata;

    FirebaseApp firebaseApp;
    DatabaseReference reference;

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
    //파라미터 : quest1,2,3 中 1 , 각 게임 파트 명
    public void getQuestData(string quest, string part) {

        userId = UserData_Script.userId;

        FirebaseDatabase.DefaultInstance.GetReference(quest).GetValueAsync().ContinueWith(task =>
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
                        questdata = int.Parse(userIds.Child(part).Value.ToString());
                        Debug.LogFormat("questdata = {0}", questdata);
                    }
                }
            }
        });
    }
    public void saveQuestData(string quest, string part, int questNum) {
        userId = UserData_Script.userId;
        reference.Child(quest).Child(userId).Child(part).SetValueAsync(questNum);
        Debug.LogFormat("questNum = {0}", questNum);
        Debug.Log("퀘스트 저장완료");
    }
}
