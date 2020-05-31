using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectGame1 : MonoBehaviour
{
    // 리스트에서 선택할 게임 버튼
    public Button btnGame1;
    public Button btnGame2;
    public Button btnGame3;
    public Button btnGame4;

    // 리스트에서 선택한 게임에 해당하는 게임설명 캔버스
    public Canvas canvasGame1;
    public Canvas canvasGame2;
    public Canvas canvasGame3;
    public Canvas canvasGame4;

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

        // 리스트의 게임 버튼마다 리스너 추가
        btnGame1.onClick.AddListener(SelectPearl);
        btnGame2.onClick.AddListener(SelectSubmarine);
        btnGame3.onClick.AddListener(SelectBubble);
        btnGame4.onClick.AddListener(SelectShark);

        // 게임 시작 버튼 리스너 추가
        btnStartGame.onClick.AddListener(StartGame);
    }
    
    void SelectPearl()
    {
        // 진주조개 게임 선택된 상태로 설정
        canvasGame1.gameObject.SetActive(true);
        canvasGame2.gameObject.SetActive(false);
        canvasGame3.gameObject.SetActive(false);
        canvasGame4.gameObject.SetActive(false);
    }
    void SelectSubmarine()
    {
        // 진주조개 게임 선택된 상태로 설정
        canvasGame1.gameObject.SetActive(false);
        canvasGame2.gameObject.SetActive(true);
        canvasGame3.gameObject.SetActive(false);
        canvasGame4.gameObject.SetActive(false);
    }
    void SelectBubble()
    {
        // 진주조개 게임 선택된 상태로 설정
        canvasGame1.gameObject.SetActive(false);
        canvasGame2.gameObject.SetActive(false);
        canvasGame3.gameObject.SetActive(true);
        canvasGame4.gameObject.SetActive(false);
    }
    void SelectShark()
    {
        // 진주조개 게임 선택된 상태로 설정
        canvasGame1.gameObject.SetActive(false);
        canvasGame2.gameObject.SetActive(false);
        canvasGame3.gameObject.SetActive(false);
        canvasGame4.gameObject.SetActive(true);
    }

    // 게임 시작 버튼 리스너 함수
    void StartGame()
    {
        // 진주조개 게임 시작
        if (canvasGame1.isActiveAndEnabled) SceneManager.LoadScene(4);
        // 잠수함 게임 시작
        else if (canvasGame2.isActiveAndEnabled) SceneManager.LoadScene(5);
        // 버블 게임 시작
        if (canvasGame3.isActiveAndEnabled) SceneManager.LoadScene(7);
        // 상어 게임 시작
        if (canvasGame4.isActiveAndEnabled) SceneManager.LoadScene(6);
    }
}
