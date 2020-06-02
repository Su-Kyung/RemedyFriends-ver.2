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

    //게임 2
    public bool saveGame2Score(string part, int score, int preScore, int count)
    {
        int sumscore;

        userId = UserData_Script.userId;
        date = System.DateTime.Now.ToString("yyyy/MM/dd");

        if (preScore == 0)
        {
            if (count == 0)
            {
                count = 0;
            }
            else { count++; }

            sumscore = score;
        }
        else
        {
            sumscore = (int)(score + preScore) / 2;
        }

        if (score != null)
        {
            //firebase에 저장
            Dictionary<string, object> update = ToDictionary(date, sumscore);
            reference.Child("game2").Child(userId).Child(part).Child("Score").Child(count.ToString()).UpdateChildrenAsync(update);
            Debug.Log("score 저장 성공");
            return true;
        }
        return false;
    }
}
