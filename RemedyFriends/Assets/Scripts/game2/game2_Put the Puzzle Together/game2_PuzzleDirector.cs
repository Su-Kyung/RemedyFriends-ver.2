using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

// 게임 흐름 및 점수 (점수 계산 자체는 컨트롤러 스크립트에서 함
public class game2_PuzzleDirector : MonoBehaviour
{
    public GameObject Puzzle1, Puzzle2, Puzzle3, Puzzle4, Puzzle5;  // 퍼즐판
    List<GameObject> PuzzleList = new List<GameObject>();           // 퍼즐판 리스트

    // 점수 텍스트
    public Text txtScore;   // 스코어 팝업에 나타낼 텍스트
    // 점수 위한 변수
    public int scorePuzzle;    // 점수
    // 퍼즐 한 조각당 중복 채점 안되도록 조각 수 세는 변수
    //public int countPiece;


    // 각 퍼즐판의 스크립트 가져오기 (해당 스크립트의 함수 참조 위해서)
    public game2_PuzzleController PuzzleControl1;
    public game2_PuzzleController PuzzleControl2;
    public game2_PuzzleController PuzzleControl3;
    public game2_PuzzleController PuzzleControl4;
    public game2_PuzzleController PuzzleControl5;


    void Start()
    {
        // 게임오브젝트 리스트에 퍼즐묶음 넣기
        PuzzleList.Add(Puzzle1);
        PuzzleList.Add(Puzzle2);
        PuzzleList.Add(Puzzle3);
        PuzzleList.Add(Puzzle4);
        PuzzleList.Add(Puzzle5);
        Debug.Log(PuzzleList.Count);

        // 게임 시작 시 모든 퍼즐 안보이게
        setPuzzle(false);

        // 점수 초기화, 조각 수 초기화
        scorePuzzle = 0;
        //countPiece = 0;

        // 최초 시작
        Invoke("PlayPuzzle", 1.2f);
    }

    // 여기서 db에 점수 넘기기
    void Update()
    {
        GameCountdown Countdown = GameObject.Find("countdown_PanelUI").GetComponent<GameCountdown>();  // GameCountdown 스크립트의 객체 받아옴

        if (!Countdown.enableSpawn)
        {
            txtScore.text = scorePuzzle.ToString();
        }
    }

    // 퍼즐 리스트중에 하나 골라서 보이기, 흐트러트리기
    public void PlayPuzzle()
    {
        // 조각 수 초기화
        //countPiece = 0;

        // 게임오브젝트로 받아온 퍼즐 목록중에 하나 고르기
        int temp = Random.Range(0, PuzzleList.Count);    // 랜덤으로 숫자 하나 뽑기
        Debug.Log(PuzzleList[temp].name);

        PuzzleList[temp].SetActive(true);    // 뽑힌 퍼즐 보이기
        Debug.Log(PuzzleList[temp].activeSelf);

        // 각 퍼즐의 함수 참조 (활성화된 퍼즐만 호출됨)
        PuzzleControl1.StartPuzzle();
        PuzzleControl2.StartPuzzle();
        PuzzleControl3.StartPuzzle();
        PuzzleControl4.StartPuzzle();
        PuzzleControl5.StartPuzzle();
        
    }

    // 퍼즐 전체 active 제어
    public void setPuzzle(bool b)
    {
        Puzzle1.SetActive(b);
        Puzzle2.SetActive(b);
        Puzzle3.SetActive(b);
        Puzzle4.SetActive(b);
        Puzzle5.SetActive(b);
    }
    
}
