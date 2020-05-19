using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 전체 진행로직
public class game1_BubbleDirector : MonoBehaviour
{
    public bool newBubble = true;      // 새로운 버블 순서
    
    void Start()
    {
        Invoke("PlayBubble", 1.8f);
    }
  
    public void PlayBubble()
    {
        GameCountdown Countdown = GameObject.Find("countdown_PanelUI").GetComponent<GameCountdown>();  // GameCountdown 스크립트의 객체 받아옴
        
        game1_SpawnBubble SpawnBubble =  GameObject.Find("GameObject_bubble").GetComponent<game1_SpawnBubble>();  
        
        if (Countdown.enableSpawn)
        {
            Debug.Log("Director: ShuffleBubble()");
            SpawnBubble.ShuffleBubble();
        }
    }

}
