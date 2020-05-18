using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;
using UnityEngine.UI;

// 전체 진행로직
public class game1_BubbleDirector : MonoBehaviour
{
    public bool newBubble = false;      // 새로운 버블 순서
    
    void Start()
    {
        GameCountdown Countdown = GameObject.Find("countdown_PanelUI").GetComponent<GameCountdown>();  // GameCountdown 스크립트의 객체 받아옴
        if (Countdown.enableSpawn) newBubble = true;
    }
    void Update()
    {
        GameCountdown Countdown = GameObject.Find("countdown_PanelUI").GetComponent<GameCountdown>();  // GameCountdown 스크립트의 객체 받아옴
        if (Countdown.enableSpawn) newBubble = false;
    }

   
}
