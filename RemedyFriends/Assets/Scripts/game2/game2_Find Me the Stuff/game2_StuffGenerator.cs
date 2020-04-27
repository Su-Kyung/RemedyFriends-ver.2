using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 각 물건들을 발생시키거나 감추는 역할을 한다.
// 가방과 각 물건들의 그룹 중 하나씩 랜덤으로 골라서 발생시키고 5초 뒤 삭제한다.
// 삭제한 뒤에는 showBag을 비활성화해준다.

// Stuff 별로 스크립트를 나눌지 안나눌지는 잘 모르겠음. -> 그룹별로 해도 괜찮을듯?
// 지금은 한꺼번에 코드 작성하고 있지만 하나씩 나누는게 나을 것 같기도 함..(코드 너무 길고 변수 많아서)
public class game2_StuffGenerator : MonoBehaviour
{
    // 게임 제어에 대한 변수
    public bool enableSpawn = false;    // 게임 진행 제어
    public bool showBag = false;        // 가방 보여주기 제어

    // stuff 그룹 가져오기(아래와 같이 하면 game1_stuff_GameObject에 적용해서 한번에 제어)
    public static GameObject StuffGroup_compass; //private 괜찮은가? static은 아래에서 오브젝트 가져오려면 필요함
    public static GameObject StuffGroup_sunglasses;
    public static GameObject StuffGroup_suncream;
    public static GameObject StuffGroup_clothes;
    public static GameObject StuffGroup_socks;
    public static GameObject StuffGroup_passport;

    // 그 오브젝트의 자식 오브젝트 가져오기
    Transform[] stuffList_compass = StuffGroup_compass.gameObject.GetComponentsInChildren<Transform>();
    Transform[] stuffList_sunglasses = StuffGroup_sunglasses.gameObject.GetComponentsInChildren<Transform>();
    Transform[] stuffList_suncream = StuffGroup_suncream.gameObject.GetComponentsInChildren<Transform>();
    Transform[] stuffList_clothes = StuffGroup_clothes.gameObject.GetComponentsInChildren<Transform>();
    Transform[] stuffList_socks = StuffGroup_socks.gameObject.GetComponentsInChildren<Transform>();
    Transform[] stuffList_passport = StuffGroup_passport.gameObject.GetComponentsInChildren<Transform>();
    
    // 가방 가져오기
    public GameObject Bag;

    // Start is called before the first frame update
    void Start()
    {
        // 시작할 때 모두 안보이게 하기
        StuffGroup_compass.SetActive(false);
        StuffGroup_sunglasses.SetActive(false);
        StuffGroup_suncream.SetActive(false);
        StuffGroup_clothes.SetActive(false);
        StuffGroup_socks.SetActive(false);
        StuffGroup_passport.SetActive(false);
        Bag.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        SpawnStuff();
    }

    // update안에 들어갈지 어떨지는 모르겠음
    void SpawnStuff()
    { 
        if (enableSpawn) 
        {
            if (showBag)    //게임 중이고 가방 보여줘야 할 때면
            {
                // 가방 보이게 하기 (근데 이거는 여기가 아니라director에서 해야하나
                Bag.SetActive(true);

                // 랜덤으로 뽑힌 자식 오브젝트 활성화하기
                chooseChild(StuffGroup_compass, stuffList_compass).gameObject.SetActive(true);
                chooseChild(StuffGroup_sunglasses, stuffList_sunglasses).gameObject.SetActive(true);
                chooseChild(StuffGroup_suncream, stuffList_suncream).gameObject.SetActive(true);
                chooseChild(StuffGroup_clothes, stuffList_clothes).gameObject.SetActive(true);
                chooseChild(StuffGroup_socks, stuffList_socks).gameObject.SetActive(true);
                chooseChild(StuffGroup_passport, stuffList_passport).gameObject.SetActive(true);


                // 5초 뒤 모두 없애기
                DestroyStuff(Bag);
                DestroyStuff(chooseChild(StuffGroup_compass, stuffList_compass).gameObject);
                DestroyStuff(chooseChild(StuffGroup_compass, stuffList_compass).gameObject);
                DestroyStuff(chooseChild(StuffGroup_compass, stuffList_compass).gameObject);
                DestroyStuff(chooseChild(StuffGroup_compass, stuffList_compass).gameObject);
                DestroyStuff(chooseChild(StuffGroup_compass, stuffList_compass).gameObject);
                DestroyStuff(chooseChild(StuffGroup_compass, stuffList_compass).gameObject);

                // showBag 비활성화 하기 -> 물건 맞추는거로 바꾸기
                showBag = false;


                /*
                // 랜덤으로 뽑힌 자식 오브젝트 활성화하기
                chooseChild(StuffGroup_compass, stuffList_compass).gameObject.SetActive(true);
                chooseChild(StuffGroup_sunglasses, stuffList_sunglasses).gameObject.SetActive(true);
                chooseChild(StuffGroup_suncream, stuffList_suncream).gameObject.SetActive(true);
                chooseChild(StuffGroup_clothes, stuffList_clothes).gameObject.SetActive(true);
                chooseChild(StuffGroup_socks, stuffList_socks).gameObject.SetActive(true);
                chooseChild(StuffGroup_passport, stuffList_passport).gameObject.SetActive(true);
                */

            }
        }
    }

    // 각 오브젝트의 자식 중에서 하나 골라내는 함수(인덱스로 받고 싶다)
    // 이렇게 앞에 transform 하면 그거로 반환이
    Transform chooseChild(GameObject g, Transform[] t)
    {
        // 오브젝트의 자식 수를 get으로 받아와서 그 중에 하나의 숫자를 랜덤으로 뽑아 index로 설정
        int index = Random.Range(0, g.transform.childCount);
        // 나중에 비교하려면 이 인덱스 결과값 따로 가져와야하나? 해야할듯..

        // 그 자식 반환
        return t[index];

        // 그 index에 따른 자식을 활성화한다.
        //t[index].gameObject.SetActive(true);
    }

    // 5초 뒤 삭제하는 함수
    void DestroyStuff(GameObject g)
    {
        float _time = 0;
        _time += Time.fixedDeltaTime;
        if (_time >= 5.0f)
            g.SetActive(false);
    }
    
    // 참고 링크: https://stackoverrun.com/ko/q/2124347
    // http://devkorea.co.kr/bbs/board.php?bo_table=m03_qna&wr_id=62333
}
