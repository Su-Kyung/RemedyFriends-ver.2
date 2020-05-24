using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class game2_PuzzleController : MonoBehaviour
{
    
    // 스크립트를 적용한 퍼즐조각
    public Button piece1;
    public Button piece2;
    public Button piece3;
    public Button piece4;
    public Button piece5;
    public Button piece6;
    public Button piece7;
    public Button piece8;
    public Button piece9;
    public Button piece10;
    public Button piece11;
    public Button piece12;
    public Button piece13;
    public Button piece14;
    public Button piece15;

    // director에서 호출
    public void StartPuzzle()
    {
        // 각각의 조각 시작
        StartPiece(piece1);
        StartPiece(piece2);
        StartPiece(piece3);
        StartPiece(piece4);
        StartPiece(piece5);
        StartPiece(piece6);
        StartPiece(piece7);
        StartPiece(piece8);
        StartPiece(piece9);
        StartPiece(piece10);
        StartPiece(piece11);
        StartPiece(piece12);
        StartPiece(piece13);
        StartPiece(piece14);
        StartPiece(piece15);
        Debug.Log("호출되었음");
    }

    void StartPiece(Button b)
    {
        // 처음 보일 때 랜덤하게 회전한 상태
        int r = Random.Range(0, 4);
        Debug.Log(r);
        b.transform.Rotate(0, 0, 90 * r);
        Debug.Log(b.transform.eulerAngles.z);
    }




    // Start is called before the first frame update
    void Start()
    {
        // 클릭 시 회전하는 함수 호출
        piece1.onClick.AddListener(RotatePiece1);
        piece2.onClick.AddListener(RotatePiece2);
        piece3.onClick.AddListener(RotatePiece3);
        piece4.onClick.AddListener(RotatePiece4);
        piece5.onClick.AddListener(RotatePiece5);
        piece6.onClick.AddListener(RotatePiece6);
        piece7.onClick.AddListener(RotatePiece7);
        piece8.onClick.AddListener(RotatePiece8);
        piece9.onClick.AddListener(RotatePiece9);
        piece10.onClick.AddListener(RotatePiece10);
        piece11.onClick.AddListener(RotatePiece11);
        piece12.onClick.AddListener(RotatePiece12);
        piece13.onClick.AddListener(RotatePiece13);
        piece14.onClick.AddListener(RotatePiece14);
        piece15.onClick.AddListener(RotatePiece15);
    }


    /*
    // Update is called once per frame
    void Update()
    {
        // GameCountdown.cs의 enablespawn 가져오기
        game2_PuzzleDirector Puzzle = GameObject.Find("Canvas_puzzle_GameObject").GetComponent<game2_PuzzleDirector>();
        
        // GameCountdown.cs의 enablespawn 가져오기
        GameCountdown Countdown = GameObject.Find("countdown_PanelUI").GetComponent<GameCountdown>();

        // 게임 진행중이고 퍼즐 출력해야 할 때
        if (Countdown.enableSpawn)
        {
            if (Puzzle.newPuzzle)
            {
                StartPuzzle();

                /*
                if (piece.transform.eulerAngles.z == 0)
                {
                    Puzzle.countPiece += 1;
                    Debug.Log("맞춘 퍼즐 개수: " + Puzzle.countPiece);
                }
                //
            }
        }
        
    }
    */

    
   
    void RotatePiece1() { piece1.transform.Rotate(0, 0, -90); }
    void RotatePiece2() { piece2.transform.Rotate(0, 0, -90); }
    void RotatePiece3() { piece3.transform.Rotate(0, 0, -90); }
    void RotatePiece4() { piece4.transform.Rotate(0, 0, -90); }
    void RotatePiece5() { piece5.transform.Rotate(0, 0, -90); }
    void RotatePiece6() { piece6.transform.Rotate(0, 0, -90); }
    void RotatePiece7() { piece7.transform.Rotate(0, 0, -90); }
    void RotatePiece8() { piece8.transform.Rotate(0, 0, -90); }
    void RotatePiece9() { piece9.transform.Rotate(0, 0, -90); }
    void RotatePiece10() { piece10.transform.Rotate(0, 0, -90); }
    void RotatePiece11() { piece11.transform.Rotate(0, 0, -90); }
    void RotatePiece12() { piece12.transform.Rotate(0, 0, -90); }
    void RotatePiece13() { piece13.transform.Rotate(0, 0, -90); }
    void RotatePiece14() { piece14.transform.Rotate(0, 0, -90); }
    void RotatePiece15() { piece15.transform.Rotate(0, 0, -90); }

}
