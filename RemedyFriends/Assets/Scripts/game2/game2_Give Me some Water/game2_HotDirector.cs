using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
//using System.Linq;

public class game2_HotDirector : MonoBehaviour
{
    // 순서 저장할 배열 -> SpawnHot.cs에 넘기기
    public int[] WaterOrder = new int[4];

    // 비교 위한 변수
    int order = 0; int clicked = 0;
    
    // 점수 텍스트
    public Text txtScore;   // 스코어 팝업에 나타낼 텍스트
    // 점수 위한 변수
    private int scoreWater = 0;    // 점수

    // 맞고 틀리고 이미지
    public GameObject isYes, isNo;

    // 캐릭터 버튼
    public Button btnSurl, btnGolden, btnHarp, btnLuna;

    // 여기에 디비 변수 추가하면 됩니다 (버블 복붙해왔음)-------------
    /*
    //점수 가져오기/저장 스크립트
    private Save_game1_data SaveData_Script;
    private Get_game1_data GetData_Script;

    public int getScore;
    public int count;

    public bool isFirst;
    */
    //----------------------------------------------------------------


    // Start is called before the first frame update
    void Start()
    {
        // 처음에 정답/오답 이미지 안보이게
        isYes.SetActive(false);
        isNo.SetActive(false);

        // 캐릭터 버튼 비활성화
        HideFriendsButton();

        // 최초 순서 정하기
        ShuffleHot();
    }
    

    // 더위 단계 정하는 함수
    public void ShuffleHot()
    {
        // 캐릭터들 버튼 비활성화
        HideFriendsButton();

        // 순서 정할때만 잠깐 쓰일 배열
        int[] nTemp = { 0, 1, 2, 3 };
        var nTempList = nTemp.ToList(); // 리스트로 바꾸기

        // 순서 정하기
        for (int i = 0; i < 4; i++)
        {
            // i번째 HotObject 는 누가 될지 rand에 저장
            int temp = Random.Range(0, nTempList.Count);
            int rand = nTempList[temp];

            WaterOrder.SetValue(rand, i);  // 순서를 배열에 저장

            // 뽑힌 '누가'는 리스트에서 삭제
            nTempList.Remove(rand);
        }

        //timer = 0.0f;

        // 클릭 순서 비교
        //order = 0; clicked = 0;
        //ShowBubble();


        // 정해진 목록대로 Hot 보여주기
        game2_SpawnHot Spawn1 = GameObject.Find("Surl").GetComponent<game2_SpawnHot>();
        game2_SpawnHot Spawn2 = GameObject.Find("Golden").GetComponent<game2_SpawnHot>();
        game2_SpawnHot Spawn3 = GameObject.Find("Harp").GetComponent<game2_SpawnHot>();
        game2_SpawnHot Spawn4 = GameObject.Find("Luna").GetComponent<game2_SpawnHot>();

        Spawn1.ShowHot(WaterOrder[0]);
        Spawn2.ShowHot(WaterOrder[1]);
        Spawn3.ShowHot(WaterOrder[2]);
        Spawn4.ShowHot(WaterOrder[3]);
    }

    // 캐릭터 버튼 비활성화
    void HideFriendsButton()
    {
        btnSurl.gameObject.SetActive(false);
        btnGolden.gameObject.SetActive(false);
        btnHarp.gameObject.SetActive(false);
        btnLuna.gameObject.SetActive(false);
    }
}
