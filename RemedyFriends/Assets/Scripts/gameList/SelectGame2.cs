using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectGame2 : MonoBehaviour
{
    // 리스트에서 선택할 게임 버튼
    public Button btnGame1;
    public Button btnGame2;
    public Button btnGame3;
    public Button btnGame4;
    public Button btnGame5;

    // 리스트에서 선택한 게임에 해당하는 게임설명 캔버스
    public Canvas canvasGame1;
    public Canvas canvasGame2;
    public Canvas canvasGame3;
    public Canvas canvasGame4;
    public Canvas canvasGame5;

    // 게임 시작 버튼
    public Button btnStartGame;

    // Start is called before the first frame update
    void Start()
    {
        // 처음에는 첫번째 게임 선택된 상태로 설정
        canvasGame1.gameObject.SetActive(true);
        canvasGame2.gameObject.SetActive(false);
        canvasGame3.gameObject.SetActive(false);
        canvasGame4.gameObject.SetActive(false);
        canvasGame5.gameObject.SetActive(false);

        // 리스트의 게임 버튼마다 리스너 추가
        btnGame1.onClick.AddListener(SelectStuff);
        btnGame2.onClick.AddListener(SelectCamel);
        btnGame3.onClick.AddListener(SelectWater);
        btnGame4.onClick.AddListener(SelectHide);
        btnGame5.onClick.AddListener(SelectPuzzle);

        // 게임 시작 버튼 리스너 추가
        btnStartGame.onClick.AddListener(StartGame);
    }

    void SelectStuff()
    {
        canvasGame1.gameObject.SetActive(true);
        canvasGame2.gameObject.SetActive(false);
        canvasGame3.gameObject.SetActive(false);
        canvasGame4.gameObject.SetActive(false);
        canvasGame5.gameObject.SetActive(false);
    }
    void SelectCamel()
    {
        canvasGame1.gameObject.SetActive(false);
        canvasGame2.gameObject.SetActive(true);
        canvasGame3.gameObject.SetActive(false);
        canvasGame4.gameObject.SetActive(false);
        canvasGame5.gameObject.SetActive(false);
    }
    void SelectWater()
    {
        canvasGame1.gameObject.SetActive(false);
        canvasGame2.gameObject.SetActive(false);
        canvasGame3.gameObject.SetActive(true);
        canvasGame4.gameObject.SetActive(false);
        canvasGame5.gameObject.SetActive(false);
    }
    void SelectHide()
    {
        canvasGame1.gameObject.SetActive(false);
        canvasGame2.gameObject.SetActive(false);
        canvasGame3.gameObject.SetActive(false);
        canvasGame4.gameObject.SetActive(true);
        canvasGame5.gameObject.SetActive(false);
    }
    void SelectPuzzle()
    {
        canvasGame1.gameObject.SetActive(false);
        canvasGame2.gameObject.SetActive(false);
        canvasGame3.gameObject.SetActive(false);
        canvasGame4.gameObject.SetActive(false);
        canvasGame5.gameObject.SetActive(true);
    }

    // 게임 시작 버튼 리스너 함수
    void StartGame()
    {
        // 물건찾기 게임 시작
        if (canvasGame1.isActiveAndEnabled) SceneManager.LoadScene(8);
        // 낙타찾기 게임 시작
        else if (canvasGame2.isActiveAndEnabled) SceneManager.LoadScene(9);
        // 물주기 게임 시작
        if (canvasGame3.isActiveAndEnabled) SceneManager.LoadScene(10);
        // 루나찾기 게임 시작
        if (canvasGame4.isActiveAndEnabled) SceneManager.LoadScene(11);
        // 퍼즐 게임 시작
        if (canvasGame5.isActiveAndEnabled) SceneManager.LoadScene(12);
    }
}
