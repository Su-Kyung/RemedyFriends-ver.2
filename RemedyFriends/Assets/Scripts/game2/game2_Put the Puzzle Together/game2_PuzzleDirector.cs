using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 게임 흐름에 대한 스크립트
public class game2_PuzzleDirector : MonoBehaviour
{
    // 게임 흐름 제어 변수
    public bool newPuzzle;   // 1: 비활성화, 2: 퍼즐 있을 때 기다리기, 3: 새 퍼즐 출력
    public int countPiece;

    // 점수 변수
    public Text txtResult; // 점수
    public int puzzleResult;   // 점수

    // 퍼즐 캔버스
    public GameObject canvasPuzzle;

    // Start is called before the first frame update
    void Start()
    {
        // GameCountdown.cs의 enablespawn 가져오기
        GameCountdown Countdown = GameObject.Find("countdown_PanelUI").GetComponent<GameCountdown>();

        // 처음에는 출력 안함
        newPuzzle = true;

        // 점수 0
        puzzleResult = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // 가장 먼저 enableSpawn 일 때
        // GameCountdown.cs의 enablespawn 가져오기
        GameCountdown Countdown = GameObject.Find("countdown_PanelUI").GetComponent<GameCountdown>();

        

        if (Countdown.enableSpawn)
        {
            // 퍼즐 출력 해야 할 때
            if (newPuzzle)
            {
                canvasPuzzle.SetActive(true);   //트루일 때 회전은 다른 스크립트로. 점수도
                newPuzzle = false;
                countPiece = 0;
            }
            
        }

        // 퍼즐 조각 15개 모두 맞추면
        if (countPiece == 15)
        {
            // 퍼즐 지우기
            canvasPuzzle.SetActive(false);
            // 새로운 퍼즐 나타나도록 하기
            newPuzzle = true;
        }
    }
}
