using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

// 퍼즐조각 맞출때마다 점수 추가, 클릭하면 회전 (조각마다 적용)
public class game2_PuzzlePieceScore : MonoBehaviour
{
    public Button piece;

    void Start()
    {
        piece.onClick.AddListener(RotatePiece);
    }

    
    void RotatePiece() {
        game2_PuzzleDirector PuzzleDirector = GameObject.Find("Canvas_puzzle_GameObject").GetComponent<game2_PuzzleDirector>();  // game2_PuzzleDirector 스크립트의 객체 받아옴

        piece.transform.Rotate(0, 0, -90);
        Debug.Log(Math.Truncate(piece.transform.rotation.eulerAngles.z));
        if (Math.Truncate(piece.transform.rotation.eulerAngles.z) == 0)
        {
            PuzzleDirector.scorePuzzle += 13;
            Debug.Log(piece.name + " is matched");
            //PuzzleDirector.countPiece += 1;
        }
    }
}
