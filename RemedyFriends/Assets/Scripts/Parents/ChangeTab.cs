using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTab : MonoBehaviour
{
    public Canvas All, Part, Info;
    public Button btnAll, btnPart, btnInfo; // 탭 변경하는 버튼

    // Start is called before the first frame update
    void Start()
    {
        // 처음에는 종합 결과 캔버스만 보이게
        ShowAllTab();

        // 버튼 클릭 이벤트 리스너
        btnAll.onClick.AddListener(ShowAllTab);
        btnPart.onClick.AddListener(ShowPartTab);
        btnInfo.onClick.AddListener(ShowInfoTab);
    }

    // 종합 탭 보이기
    void ShowAllTab()
    {
        Debug.Log("종합결과 탭");
        All.gameObject.SetActive(true);
        Part.gameObject.SetActive(false);
        Info.gameObject.SetActive(false);
        btnAll.gameObject.SetActive(false);
        btnPart.gameObject.SetActive(true);
        btnInfo.gameObject.SetActive(true);
    }
    // 영역별 탭 보이기
    void ShowPartTab()
    {
        Debug.Log("영역별 결과 탭");
        // 캔버스
        All.gameObject.SetActive(false);
        Part.gameObject.SetActive(true);
        Info.gameObject.SetActive(false);
        // 버튼
        btnAll.gameObject.SetActive(true);
        btnPart.gameObject.SetActive(false);
        btnInfo.gameObject.SetActive(true);
    }
    // 개인정보 탭 보이기
    void ShowInfoTab()
    {
        Debug.Log("개인정보 탭");
        All.gameObject.SetActive(false);
        Part.gameObject.SetActive(false);
        Info.gameObject.SetActive(true);
        btnAll.gameObject.SetActive(true);
        btnPart.gameObject.SetActive(true);
        btnInfo.gameObject.SetActive(false);
    }
}
