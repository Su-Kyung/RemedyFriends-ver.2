using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

[System.Serializable]
class Quest2 {
    public int camel;
    public int luna;
    public int puzzle;
    public int stuff;
    public int water;
}

public class Quest2_Data : MonoBehaviour
{
    string userId;

    public GameObject quest2Gem1;
    public GameObject quest2Gem2;
    public GameObject quest2Gem3;
    public GameObject quest2Gem4;
    public GameObject quest2Gem5;
    public GameObject quest2Gem6;
    public GameObject quest2Gem7;
    public GameObject quest2Gem8;

    public int camel, luna, puzzle, stuff, water;

    //private User_data UserData_Script;

    FirebaseApp firebaseApp;
    DatabaseReference reference;
    void Awake()
    {
        firebaseApp = FirebaseDatabase.DefaultInstance.App;
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://remedy-stones.firebaseio.com/");
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        //UserData_Script = GameObject.Find("UserData").GetComponent<User_data>();
    }
    void Start()
    {
        quest2Gem3.SetActive(false);
        quest2Gem4.SetActive(false);
        quest2Gem5.SetActive(false);
        quest2Gem6.SetActive(false);
        quest2Gem7.SetActive(false);
        getQuest2Data();
    }
    void Update()
    {
        setGem();
    }
    public void getQuest2Data()
    {

        //userId = UserData_Script.userId;
        userId = "test1";

        FirebaseDatabase.DefaultInstance.GetReference("quest2").GetValueAsync().ContinueWith(task =>
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
                    //IDictionary<string, int> quest2 = new IDictionary<string, int>();
                    if (userIds.Key == userId)
                    {
                        //questdata = int.Parse(userIds.Child(part).Value.ToString());
                        //Debug.LogFormat("questdata = {0}", questdata);
                        //quest2 = (IDictionary)userIds.Value;
                        //Debug.Log("bubble: " + quest2["bubble"] + ", camel: " + quest2["camel"]);
                        Quest2 q2 = JsonUtility.FromJson<Quest2>(userIds.GetRawJsonValue());

                        Debug.Log(q2.camel);
                        camel = q2.camel;
                        luna = q2.luna;
                        puzzle = q2.puzzle;
                        stuff = q2.stuff;
                        water = q2.water;
                        
                        setGem();
                    }
                }
            }
        });
    }

    void setGem()
    {
        

        if(water >= 30)
        {
            quest2Gem3.SetActive(true);
        }
        else
        {
            quest2Gem3.SetActive(false);
        }

        if (luna >= 50)
        {
            quest2Gem4.SetActive(true);
        }
        else
        {
            quest2Gem4.SetActive(false);
        }
        if (camel >= 30)
        {
            quest2Gem5.SetActive(true);
        }
        else
        {
            quest2Gem5.SetActive(false);
        }
        if (stuff >= 10)
        {
            quest2Gem6.SetActive(true);
        }
        else
        {
            quest2Gem6.SetActive(false);
        }

        if (puzzle >= 10)
        {
            quest2Gem7.SetActive(true);
        }
        else
        {
            quest2Gem7.SetActive(false);
        }

    }

}
