using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    public Button btnTarget;    //씬 전환시 사용할 버튼
    public Scene sceneTarget;   //이동할 씬

    void Start()
    {
        btnTarget.onClick.AddListener(MoveScene);
    }

    void MoveScene()
    {
        SceneManager.LoadScene(sceneTarget.handle);
        Debug.Log(sceneTarget.handle + "로 이동");
    }

}
