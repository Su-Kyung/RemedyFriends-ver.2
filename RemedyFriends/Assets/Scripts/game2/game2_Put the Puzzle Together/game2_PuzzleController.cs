using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

// 퍼즐 깔릴 때 최초 회전
public class game2_PuzzleController : MonoBehaviour
{
    // 스크립트를 적용한 퍼즐조각
    public Button piece1, piece2, piece3, piece4, piece5, piece6, piece7,
        piece8, piece9, piece10, piece11, piece12, piece13, piece14, piece15;

    /*
    // 조각당 점수 한번만 체킹하기 위한 변수
    bool score1, score2, score3, score4, score5, score6, score7, score8,
        score9, score10, score11, score12, score13, score14, score15;
    */

    // 맞춘 조각 세기
    public int matchedPiece;

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

        //enableScore(true);
    }

    void StartPiece(Button b)
    {
        // 처음 보일 때 랜덤하게 회전한 상태
        int r = UnityEngine.Random.Range(1, 4);
        b.transform.Rotate(0, 0, 90 * r);
    }

    // 점수 계산 -> update로?
    void Update()
    {
        game2_PuzzleDirector PuzzleDirector = GameObject.Find("Canvas_puzzle_GameObject").GetComponent<game2_PuzzleDirector>();  // game2_PuzzleDirector 스크립트의 객체 받아옴


        // 모두 맞췄을 때
        if (Math.Truncate(piece1.transform.rotation.eulerAngles.z) == 0 && Math.Truncate(piece2.transform.rotation.eulerAngles.z) == 0
            && Math.Truncate(piece3.transform.rotation.eulerAngles.z) == 0 && Math.Truncate(piece4.transform.rotation.eulerAngles.z) == 0
            && Math.Truncate(piece5.transform.rotation.eulerAngles.z) == 0 && Math.Truncate(piece6.transform.rotation.eulerAngles.z) == 0
            && Math.Truncate(piece7.transform.rotation.eulerAngles.z) == 0 && Math.Truncate(piece8.transform.rotation.eulerAngles.z) == 0
            && Math.Truncate(piece9.transform.rotation.eulerAngles.z) == 0 && Math.Truncate(piece10.transform.rotation.eulerAngles.z) == 0
            && Math.Truncate(piece11.transform.rotation.eulerAngles.z) == 0 && Math.Truncate(piece12.transform.rotation.eulerAngles.z) == 0
            && Math.Truncate(piece13.transform.rotation.eulerAngles.z) == 0 && Math.Truncate(piece14.transform.rotation.eulerAngles.z) == 0
            && Math.Truncate(piece15.transform.rotation.eulerAngles.z) == 0)
        {
            PuzzleDirector.scorePuzzle += 300;
            PuzzleDirector.setPuzzle(false);    // 퍼즐 전부 안보이게
            PuzzleDirector.PlayPuzzle();    // 새 퍼즐 시작
        }
        
    }
    
    /*
    // 점수 체킹 변수 제어
    void enableScore(bool b)
    {
        score1 = b;
        score2 = b;
        score3 = b;
        score4 = b;
        score5 = b;
        score6 = b;
        score7 = b;
        score8 = b;
        score9 = b;
        score10 = b;
        score11 = b;
        score12 = b;
        score13 = b;
        score14 = b;
        score15 = b;
    }
    */

    /*
    // 조각 클릭하면 회전하는 함수: 합치면안됨 (AddListener 때문에)
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
    */
}
