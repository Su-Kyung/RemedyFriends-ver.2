using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

[System.Serializable]
public class ScoreList
{
    public ScoreData[] Score;
}
[System.Serializable]
public class ScoreData
{
    public string date;
    public int userscore;
    //public ScoreData(string date, int userscore)
    //{
    //this.date = date;
    //this.userscore = userscore;
    //}
}

public class Save_game1_data : MonoBehaviour
{
    FirebaseApp firebaseApp;
    DatabaseReference reference;

    public ScoreList scoreList;
    public ScoreData scoreData;

    string userId;
    string date;

    private User_data UserData_Script;

    List<ScoreData> objectList = new List<ScoreData>();

    void Awake()
    {
        firebaseApp = FirebaseDatabase.DefaultInstance.App;
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://remedy-stones.firebaseio.com/");
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        UserData_Script = GameObject.Find("UserData").GetComponent<User_data>();
    }
    public ScoreData createSubObject(string date, int score)
    {
        ScoreData myscore = new ScoreData();
        myscore.date = date;
        myscore.userscore = score;
        return myscore;
    }

    public Dictionary<string, object> ToDictionary(string date, int score)
    {
        Dictionary<string, object> result = new Dictionary<string, object>();
        result["date"] = date;
        result["userscore"] = score;

        return result;
    }

    //게임 1
    public bool saveGame1Score(string part, int score, int preScore)
    {
        //userId
        userId = UserData_Script.userId;
        //current date
        date = System.DateTime.Now.ToString("yyyy/MM/dd");
        //date = "2020-05-29";

        //data 저장
        //ScoreData data = new ScoreData(date, score);
        //리스트에 담기
        objectList.Add(createSubObject(date, score));

        //int count = scoreList.Score.Length;
        //Debug.Log("pre" + count);

        scoreList.Score = objectList.ToArray();

        //count = scoreList.Score.Length;
        //Debug.Log("post" + count);

        //json 으로 변경
        string json = JsonUtility.ToJson(scoreList);
        Debug.Log("json" + json);

        if (score != null)
        {
            //firebase에 저장
            Dictionary<string, object> update = ToDictionary(date, score);
            reference.Child("game1").Child(userId).Child(part).UpdateChildrenAsync(update);
            Debug.Log("score 저장 성공");
            return true;
        }
        return false;
    }
}
