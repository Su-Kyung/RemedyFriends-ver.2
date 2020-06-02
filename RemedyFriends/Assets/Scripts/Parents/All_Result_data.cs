using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class All_Result_data : MonoBehaviour
{
    FirebaseApp firebaseApp;
    DatabaseReference reference;

    string userId;

    public int count;

    public Text scoreText1;
    public Text scoreText2;
    public Text scoreText3;
    public Text scoreText4;
    public Text scoreText5;

    string score1;
    string score2;
    string score3;
    string score4;
    string score5;
/*
    public Text dateText1;
    public Text dateText2;
    public Text dateText3;
    public Text dateText4;
    public Text dateText5;

    string day1;
    string day2;
    string day3;
    string day4;
    string day5;
    */
    private User_data UserData_Script;

    void Awake()
    {
        firebaseApp = FirebaseDatabase.DefaultInstance.App;
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://remedy-stones.firebaseio.com/");
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        UserData_Script = GameObject.Find("UserData").GetComponent<User_data>();
    }

    void Start()
    {
        
        score1 = "-";
        score2 = "-";
        score3 = "-";
        score4 = "-";
        score5 = "-";
/*
        day1 = "00/00";
        day2 = "00/00";
        day3 = "00/00";
        day4 = "00/00";
        day5 = "00/00";
        */
    }
    void Update()
    {
        scoreText1.text = score1;
        scoreText2.text = score2;
        scoreText3.text = score3;
        scoreText4.text = score4;
        scoreText5.text = score5;
        /*
        dateText1.text = day1;
        dateText2.text = day2;
        dateText3.text = day3;
        dateText4.text = day4;
        dateText5.text = day5;*/

    }

    public void getGameAllScore(string game, string part)
    {
        userId = UserData_Script.userId;
        Debug.LogFormat("UserID = {0}", userId);
        FirebaseDatabase.DefaultInstance.GetReference(game)
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
                            //int i = 0;
                            if (userIds.Key == userId)
                            {
                                ScoreList list = JsonUtility.FromJson<ScoreList>(userIds.Child(part).GetRawJsonValue());
                                count = list.Score.Length - 1;
                                Debug.Log(count);

                                score1 = list.Score[count].userscore + "";
                                score2 = list.Score[count - 1].userscore + "";
                                score3 = list.Score[count - 2].userscore + "";
                                score4 = list.Score[count - 3].userscore + "";
                                score5 = list.Score[count - 4].userscore + "";
                                /*
                                day1 = list.Score[count].date.Substring(5);
                                //day1.Replace("-", "/");
                                Debug.LogFormat("day1 = {0}", day1);
                                day2 = list.Score[count-1].date.Substring(5);
                                //day2.Replace("-", "/");
                                Debug.LogFormat("day2 = {0}", day2);
                                day3 = list.Score[count-2].date.Substring(5);
                                //day3.Replace("-", "/");
                                Debug.LogFormat("day3 = {0}", day3);
                                day4 = list.Score[count-3].date.Substring(5);
                                //day4.Replace("-", "/");
                                day5 = list.Score[count-4].date.Substring(5);
                                //day5.Replace("-", "/");
                                */
                            }
                        }
                    }
                });
    }

    public void onClickVisual()
    {
        setNull();
        //진주조개
        getGameAllScore("game1", "visual");
    }
    public void onClickAuditory()
    {
        setNull();
        //낙타
        getGameAllScore("game2", "auditory");
    }
    public void onClickMemory()
    {
        setNull();
        //버블
        getGameAllScore("game1", "memory");
    }
    public void onClickControl()
    {
        setNull();
        //상어
        getGameAllScore("game1", "control");
    }
    public void onClickOrganization()
    {
        setNull();
        //퍼즐
        getGameAllScore("game2", "organization");
    }
    public void onClickActivate()
    {
        setNull();
    }
    public void setNull() {
        score5 = "-";
        score4 = "-";
        score3 = "-";
        score2 = "-";
        score1 = "-";
        /*
        day1 = "00/00";
        day2 = "00/00";
        day3 = "00/00";
        day4 = "00/00";
        day5 = "00/00";*/
    }

}