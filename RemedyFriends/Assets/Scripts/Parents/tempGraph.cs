using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tempGraph : MonoBehaviour
{
    // 영역 선택 버튼
    public Button btnArea1, btnArea2, btnArea3, btnArea4, btnArea5, btnArea6;
    // 그래프 점 활성화 오브젝트
    public GameObject point1, point2, point3, point4, point5, point6;

    // Start is called before the first frame update
    void Start()
    {
        // 시작 시엔 모두 비활성화
        point1.SetActive(false);
        point2.SetActive(false);
        point3.SetActive(false);
        point4.SetActive(false);
        point5.SetActive(false);
        point6.SetActive(false);

        // 버튼 리스너
        btnArea1.onClick.AddListener(Show1);
        btnArea2.onClick.AddListener(Show2);
        btnArea3.onClick.AddListener(Show3);
        btnArea4.onClick.AddListener(Show4);
        btnArea5.onClick.AddListener(Show5);
        btnArea6.onClick.AddListener(Show6);
    }

    void Show1()
    {
        point1.SetActive(true);
        point2.SetActive(false);
        point3.SetActive(false);
        point4.SetActive(false);
        point5.SetActive(false);
        point6.SetActive(false);
    }
    void Show2()
    {
        point1.SetActive(false);
        point2.SetActive(true);
        point3.SetActive(false);
        point4.SetActive(false);
        point5.SetActive(false);
        point6.SetActive(false);
    }
    void Show3()
    {
        point1.SetActive(false);
        point2.SetActive(false);
        point3.SetActive(true);
        point4.SetActive(false);
        point5.SetActive(false);
        point6.SetActive(false);
    }
    void Show4()
    {
        point1.SetActive(false);
        point2.SetActive(false);
        point3.SetActive(false);
        point4.SetActive(true);
        point5.SetActive(false);
        point6.SetActive(false);
    }
    void Show5()
    {
        point1.SetActive(false);
        point2.SetActive(false);
        point3.SetActive(false);
        point4.SetActive(false);
        point5.SetActive(true);
        point6.SetActive(false);
    }
    void Show6()
    {
        point1.SetActive(false);
        point2.SetActive(false);
        point3.SetActive(false);
        point4.SetActive(false);
        point5.SetActive(false);
        point6.SetActive(true);
    }
}
