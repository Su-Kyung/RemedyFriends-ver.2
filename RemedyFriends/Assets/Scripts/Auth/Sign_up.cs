using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class Sign_up : MonoBehaviour
{

    public InputField InputField_join_id;
    public InputField InputField_join_pw;
    public InputField InputField_pw_check;

    public Text dublecheckText;
    public string currentStatus;

    public string dbId;

    FirebaseApp firebaseApp;
    DatabaseReference reference;


    void Awake()
    {
        firebaseApp = FirebaseDatabase.DefaultInstance.App;
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://remedy-stones.firebaseio.com/");
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        // FirebaseApp.DefaultInstance.SetEditorP12FileName("remedy-stones-55aaa9275afb.p12");
        //FirebaseApp.DefaultInstance.SetEditorServiceAccountEmail("remedy-stones@appspot.gserviceaccount.com");
        //FirebaseApp.DefaultInstance.SetEditorP12Password("notasecret");

    }
    void Start()
    {
        currentStatus = "중복확인 해주세요.";
    }
    void Update()
    {
        dublecheckText.text = currentStatus;
    }

    public void checkExistkUserId()
    {
        dbId = "";
        int allcount = 0;
        int count = 0;
        FirebaseDatabase.DefaultInstance.GetReference("users").GetValueAsync().ContinueWith(task =>
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
                    allcount++;
                    Debug.LogFormat("allcount = {0}", allcount);
                    //Debug.LogFormat("Key = {0}", userIds.Key);
                    if (userIds.Key == InputField_join_id.text)
                    {
                        Debug.Log("이미 있는 아이디 입니다.");
                        currentStatus = "존재하는 아이디입니다.";
                        dbId = userIds.Key;
                        Debug.LogFormat("dbId = {0}", dbId);
                    }
                    else
                    {
                        count++;
                        Debug.LogFormat("count = {0}", count);
                        if (allcount == count)
                        {
                            dbId = "dhfjksnfkhsuieilmqlieio123keifi30fj";
                            currentStatus = "사용가능한 아이디";
                        }
                    }
                }
            }
        });
    }

    public bool signUp()
    {
        string userId = InputField_join_id.text;
        string passwd = InputField_join_pw.text;

        //StartCoroutine("checkuserId");
        if (userId != "")
        {

            if (dbId != "" && dbId != InputField_join_id.text)
            {
                if (passwd == InputField_pw_check.text)
                {
                    //PlayerPrefs.SetString("ID", userId);
                    //PlayerPrefs.SetString("PW", passwd);

                    reference.Child("users").Child(userId).Child("password").SetValueAsync(passwd);
                    Debug.Log("회원가입 성공");

                    return true;
                }
                else
                {
                    Debug.Log("비밀번호가 같지 않습니다.");
                    return false;
                }
            }
            else
            {
                Debug.Log("같은 아이디가 존재합니다. 다른 아이디를 입력해주세요.");
                return false;
            }

        }
        else
        {
            Debug.Log("아이디를 입력해주세요.");
            return false;
        }
        return false;
    }

    IEnumerator checkuserId()
    {
        checkExistkUserId();
        Debug.Log("코루틴");
        yield return new WaitForSeconds(2.1f);
    }

}
