using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class game2_PuzzleGenerator : MonoBehaviour
{
    
    // 스크립트를 적용한 퍼즐조각
    public Button piece;

    
    // Start is called before the first frame update
    void Start()
    {
        // GameCountdown.cs의 enablespawn 가져오기
        GameCountdown Countdown = GameObject.Find("countdown_PanelUI").GetComponent<GameCountdown>();


        piece.gameObject.SetActive(false);

        
    }

    // Update is called once per frame
    void Update()
    {
        // GameCountdown.cs의 enablespawn 가져오기
        GameCountdown Countdown = GameObject.Find("countdown_PanelUI").GetComponent<GameCountdown>();

        // 나중에 조건 하나 더 추가
        if (Countdown.enableSpawn)
        {
            piece.gameObject.SetActive(true);
        }
    }
}
