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

    // 맞춘 조각 세기
    public int matchedPiece;

    // 맞았다는 이미지
    public GameObject isCorrect;

    void Start()
    {
        isCorrect.SetActive(false);
    }

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

    // 퍼즐 다 맞추면 새로운 퍼즐 생성
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
            PuzzleDirector.scorePuzzle += 100;
            // 시간 5초 증가
            GameTimeSlider gameTimeSlider = GameObject.Find("TimeSlider").GetComponent<GameTimeSlider>();  // GameTimeSlider 스크립트의 객체 받아옴
            gameTimeSlider.remainTime += 5;   // remainTime멤버변수 가져옴

            isCorrect.SetActive(true);
            PuzzleDirector.setPuzzle(false);    // 퍼즐 전부 안보이게
            Invoke("AfterCorrect", 1.5f);
        }
        
    }

    void AfterCorrect()
    {
        game2_PuzzleDirector PuzzleDirector = GameObject.Find("Canvas_puzzle_GameObject").GetComponent<game2_PuzzleDirector>();  // game2_PuzzleDirector 스크립트의 객체 받아옴

        isCorrect.SetActive(false);
        PuzzleDirector.PlayPuzzle();    // 새 퍼즐 시작
    }
    
}
