using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// 비밀번호 검사하고 보호자 페이지로 넘어가기
public class OpenChart : MonoBehaviour
{
    // 메인에 있는 보호자 페이지 버튼, 팝업창의 확인, 취소
    public Button btnChart, btnEnter, btnCancel;

    // 비밀번호 입력 캔버스
    public Canvas canvasChart1, canvasChart2;
    public GameObject canvasError;

    // 입력한 비밀번호
    public Text txtPW;

    public InputField InputField_master_pw;

    // Start is called before the first frame update
    void Start()
    {
        // 시작 시에는 모두 안보이게
        canvasChart1.gameObject.SetActive(false);
        canvasChart2.gameObject.SetActive(false);
        canvasError.SetActive(false);

        // 버튼 리스너
        btnChart.onClick.AddListener(OpenChartCanvas);
        btnEnter.onClick.AddListener(GotoChart);
        btnCancel.onClick.AddListener(CloseChartCanvas);
    }

    // 보호자 페이지 접근 위한 팝업 창 나타내기
    void OpenChartCanvas()
    {
        canvasChart1.gameObject.SetActive(true);
        canvasChart2.gameObject.SetActive(true);
    }

    // 보호자 페이지 접근 위한 팝업 창 닫기
    void CloseChartCanvas()
    {
        canvasChart1.gameObject.SetActive(false);
        canvasChart2.gameObject.SetActive(false);
    }

    // 비밀번호 확인해서 맞으면 씬 이동, 틀리면 틀렸다고 2초간 팝업 (DB연결)
    void GotoChart()
    {
        // 비밀번호 맞으면 (임시로 123456으로 함)
        if (InputField_master_pw.text == "123456")
        {
            SceneManager.LoadScene(14); //14: Chart 씬 번호
        }
        else
        {
            canvasError.SetActive(true);
            Invoke("CloseError", 2);  // 2초 뒤에 닫기
        }
    }

    //2초 뒤에 닫기
    void CloseError()
    {
        canvasError.SetActive(false);
    }
}
