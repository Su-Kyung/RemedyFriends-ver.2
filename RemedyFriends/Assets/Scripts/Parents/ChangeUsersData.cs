using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class ChangeUsersData : MonoBehaviour
{
    public Text textUserId;

    string userId;

    public InputField InputField_pw;
    public InputField InputField_pw_master;

    private User_data UserData_Script;
    
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
        textUserId.text = UserData_Script.userId;
    }

    public void onClickUpdateButton()
    {
        userId = UserData_Script.userId;
        string passwd = InputField_pw.text.Trim();
        string master = InputField_pw_master.text.Trim();
        if (passwd != "") {
            reference.Child("users").Child(userId).Child("password").SetValueAsync(passwd);
            UserData_Script.saveUserIdpw(UserData_Script.userId, passwd);
            Debug.Log("비밀번호 변경완료");
        }
        if (master != "") {
            reference.Child("users").Child(userId).Child("master").SetValueAsync(master);
            Debug.Log("마스터 비밀번호 변경완료");
        }
    }

}
