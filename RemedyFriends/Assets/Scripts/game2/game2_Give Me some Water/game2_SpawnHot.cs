using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 레머디 프렌즈 각각 적용
public class game2_SpawnHot : MonoBehaviour
{
    public GameObject Hot1, Hot2, Hot3, Hot4;
    List<GameObject> HotList = new List<GameObject>(); // 위 더위단계 리스트

    // 해당 프렌즈 버튼
    public Button btnFriend;

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

        // 캐릭터 버튼 리스터
        btnFriend.onClick.AddListener(btnFriendClicked);
    }

    // director에서 호출하면 .. 그 변수에 따라서 보이게 하기
    public void ShowHot(int i)
    {
        HotList[i].SetActive(true);

        Invoke("HideHot", 2);
    }

    // 더위 모두 안보이게 하게
    void HideHot()
    {
        Hot1.SetActive(false);
        Hot2.SetActive(false);
        Hot3.SetActive(false);
        Hot4.SetActive(false);

        // 버튼 활성화
        btnFriend.gameObject.SetActive(true);
    }

    void btnFriendClicked()
    {
        game2_HotDirector Director = GameObject.Find("FriendsFaceObject").GetComponent<game2_HotDirector>();
        Director.ShuffleHot();
    }
}
