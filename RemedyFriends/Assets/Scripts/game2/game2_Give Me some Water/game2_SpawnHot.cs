using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 레머디 프렌즈 각각 적용
public class game2_SpawnHot : MonoBehaviour
{
    public GameObject Hot1, Hot2, Hot3, Hot4;
    List<GameObject> HotList = new List<GameObject>(); // 위 더위단계 리스트

    // Start is called before the first frame update
    void Start()
    {
        // 리스트에 할당
        HotList.Add(Hot1);
        HotList.Add(Hot2);
        HotList.Add(Hot3);
        HotList.Add(Hot4);

        // 처음에 다 안보이게
        HideHot();

        // 최초 실행
        Invoke("ShowHot", 1.8f);
    }

    // director에서 호출하면 .. 그 변수에 따라서 보이게 하기
    void ShowHot()
    {
        // 임시 랜덤 변수
        int temp = Random.Range(0, 4);

        HotList[temp].SetActive(true);

        Invoke("HideHot", 2);
    }

    // 더위 모두 안보이게 하게
    void HideHot()
    {
        Hot1.SetActive(false);
        Hot2.SetActive(false);
        Hot3.SetActive(false);
        Hot4.SetActive(false);
    }
}
