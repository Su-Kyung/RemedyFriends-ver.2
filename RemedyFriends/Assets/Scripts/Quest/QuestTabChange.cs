using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestTabChange : MonoBehaviour
{
    public Canvas Stage1, Stage2, Stage3;
    public Button btn1, btn2, btn3; // 탭 변경하는 버튼
    public Button activeBtn1, activeBtn2, activeBtn3;   // 탭 이랑 콘텐츠 넣는 판넬?이랑 달라서....

    // Start is called before the first frame update
    void Start()
    {
        // 처음에는 종합 결과 캔버스만 보이게
        ShowTab1();

        // 버튼 클릭 이벤트 리스너
        btn1.onClick.AddListener(ShowTab1);
        btn2.onClick.AddListener(ShowTab2);
        btn3.onClick.AddListener(ShowTab3);
    }

    // 1단계 퀘스트 탭 보이기
    void ShowTab1()
    {
        Debug.Log("1단계 퀘스트 탭");
        Stage1.gameObject.SetActive(true);
        Stage2.gameObject.SetActive(false);
        Stage3.gameObject.SetActive(false);

        btn1.gameObject.SetActive(false);
        btn2.gameObject.SetActive(true);
        btn3.gameObject.SetActive(true);
        activeBtn1.gameObject.SetActive(true);
        activeBtn2.gameObject.SetActive(false);
        activeBtn3.gameObject.SetActive(false);
    }
    // 2단계 퀘스트 탭 보이기
    void ShowTab2()
    {
        Debug.Log("2단계 퀘스트 탭");
        // 캔버스
        Stage1.gameObject.SetActive(false);
        Stage2.gameObject.SetActive(true);
        Stage3.gameObject.SetActive(false);
        // 버튼
        btn1.gameObject.SetActive(true);
        btn2.gameObject.SetActive(false);
        btn3.gameObject.SetActive(true);
        activeBtn1.gameObject.SetActive(false);
        activeBtn2.gameObject.SetActive(true);
        activeBtn3.gameObject.SetActive(false);
    }
    // 3단계 퀘스트 탭 보이기
    void ShowTab3()
    {
        Debug.Log("개인정보 탭");
        Stage1.gameObject.SetActive(false);
        Stage2.gameObject.SetActive(false);
        Stage3.gameObject.SetActive(true);

        btn1.gameObject.SetActive(true);
        btn2.gameObject.SetActive(true);
        btn3.gameObject.SetActive(false);
        activeBtn1.gameObject.SetActive(false);
        activeBtn2.gameObject.SetActive(false);
        activeBtn3.gameObject.SetActive(true);
    }
}
