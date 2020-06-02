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

    public string score1;
    public string score2;
    public string score3;
    public string score4;
    public string score5;


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
        score1 = "-";
        score2 = "-";
        score3 = "-";
        score4 = "-";
        score5 = "-";
    }
    void Update()
    {
        scoreText1.text = score1;
        scoreText2.text = score2;
        scoreText3.text = score3;
        scoreText4.text = score4;
        scoreText5.text = score5;
    }

    public void getGameAllScore(string game, string part)
    {
        //userId = UserData_Script.userId;
        userId = "test1";
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

                                if (count == 0)
                                {
                                    score5 = "-";
                                    score4 = "-";
                                    score3 = "-";
                                    score2 = "-";
                                    score1 = list.Score[count].userscore + "";
                                }
                                else if (count == 1)
                                {
                                    score5 = "-";
                                    score4 = "-";
                                    score3 = "-";
                                    score2 = list.Score[count - 1].userscore + "";
                                    score1 = list.Score[count].userscore + "";
                                }
                                else if (count == 2)
                                {
                                    score5 = "-";
                                    score4 = "-";
                                    score1 = list.Score[count].userscore + "";
                                    score2 = list.Score[count - 1].userscore + "";
                                    score3 = list.Score[count - 2].userscore + "";
                                }else if(count == 3){
                                    score5 = "-";
                                    score1 = list.Score[count].userscore + "";
                                    score2 = list.Score[count - 1].userscore + "";
                                    score3 = list.Score[count - 2].userscore + "";
                                    score4 = list.Score[count - 3].userscore + "";
                                }
                                else if (count >= 4)
                                {
                                    score1 = list.Score[count].userscore + "";
                                    score2 = list.Score[count - 1].userscore + "";
                                    score3 = list.Score[count - 2].userscore + "";
                                    score4 = list.Score[count - 3].userscore + "";
                                    score5 = list.Score[count - 4].userscore + "";
                                }
                                else {
                                    score5 = "-";
                                    score4 = "-";
                                    score3 = "-";
                                    score2 = "-";
                                    score1 = "-";
                                }
                                
                            }
                        }
                    }
                });
    }

    public void onClickVisual()
    {
        //진주조개
        getGameAllScore("game1", "visual");
    }
    public void onClickAuditory()
    {
        //낙타
        getGameAllScore("game2", "auditory");
    }
    public void onClickMemory()
    {
        //버블
        getGameAllScore("game1", "memory");
    }
    public void onClickControl()
    {
        //상어
        getGameAllScore("game1", "control");
    }
    public void onClickOrganization()
    {
        //퍼즐
        getGameAllScore("game2", "organization");
    }
    public void onClickActivate()
    {
        score5 = "-";
        score4 = "-";
        score3 = "-";
        score2 = "-";
        score1 = "-";
    }

}