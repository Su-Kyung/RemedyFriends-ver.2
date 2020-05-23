using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User_data : MonoBehaviour
{
    public string userId;
    public string userPasswd;
    public string userNickname;

    void Awake() {
        DontDestroyOnLoad(this);
    }

    public void saveUserIdpw(string id, string pw) {
        userId = id;
        userPasswd = pw;
    }

    public void saveUserNickname(string nickname) {
        userNickname = nickname;
    }
}
