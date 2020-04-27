using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game2_StuffGenerator_sunglasses : MonoBehaviour
{
    // 게임 제어에 대한 변수 -> false로 바꾸기. true는 그냥 테스트하려고 한거
    public bool enableSpawn = true;    // 게임 진행 제어
    public bool showBag = true;        // 가방 보여주기 제어
    public bool groupActive = false;        // 각 그룹에 하나라도 활성화 되어있는 것이 있는지 체크

    // stuff 그룹 가져오기
    public GameObject StuffGroup;

    // 그 오브젝트의 자식 오브젝트 가져오기위한 배열 생성
    public Transform[] stuffList;

    // Start is called before the first frame update
    void Start()
    {
        // 시작할 때 모두 안보이게 하기
        stuffList[0].gameObject.SetActive(false);
        stuffList[1].gameObject.SetActive(false);
        stuffList[2].gameObject.SetActive(false);
        stuffList[3].gameObject.SetActive(false);
        stuffList[4].gameObject.SetActive(false);
        stuffList[5].gameObject.SetActive(false);

        // 그 오브젝트의 자식 오브젝트 가져오기
        //stuffList = StuffGroup.gameObject.GetComponentsInChildren<Transform>();

    }

    void FixedUpdate()
    {
        if (enableSpawn)
        {
            switch (showBag)
            {
                case true:
                    if (!groupActive)
                    {
                        // 모두 안보이게 하기
                        stuffList[0].gameObject.SetActive(false);
                        stuffList[1].gameObject.SetActive(false);
                        stuffList[2].gameObject.SetActive(false);
                        stuffList[3].gameObject.SetActive(false);
                        stuffList[4].gameObject.SetActive(false);
                        stuffList[5].gameObject.SetActive(false);

                        // 랜덤으로 숫자 뽑고 각각 출력하기
                        int index = Random.Range(0, StuffGroup.transform.childCount);
                        Debug.Log(stuffList[index].name);

                        // 랜덤으로 뽑힌 자식 오브젝트 활성화하기
                        //StuffGroup.transform.Find(stuffList[index].name).gameObject.SetActive(true);
                        //StuffGroup.transform.GetChild(index).gameObject.SetActive(true);
                        stuffList[index].gameObject.SetActive(true);
                        groupActive = true;
                        
                    }
                    break;
                case false:
                    StuffGroup.SetActive(false);
                    break;
            }
        }
    }
    
}
