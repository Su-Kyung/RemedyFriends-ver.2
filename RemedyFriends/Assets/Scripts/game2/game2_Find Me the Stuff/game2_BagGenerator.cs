using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 가방의 생성 및 삭제를 담당하는 스크립트
// 가방 속에 들어있는 물건을 찾는 타임인지, 가방 속 물건을 보여주는 타임인지 제어한다. 
public class game2_BagGenerator : MonoBehaviour
{

    // 게임 제어에 대한 변수 -> false로 바꾸기. true는 그냥 테스트하려고 한거
    public bool enableSpawn = true;    // 게임 진행 제어
    public bool showBag = true;        // 가방 보여주기 제어
   
    // 가방 가져오기
    public GameObject Bag;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (enableSpawn)
        {
            switch (showBag)
            {
                case true:
                    Bag.SetActive(true);
                    break;
                case false:
                    Bag.SetActive(false);
                    break;
            }
        }
    }

}
