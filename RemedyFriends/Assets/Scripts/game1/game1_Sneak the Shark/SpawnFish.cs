using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFish : MonoBehaviour
{
    public GameObject Fish1, Fish2, Fish3, Fish4;   // 생성될 물고기(빨 노 초 보)
    List<GameObject> FishList = new List<GameObject>(); // 위 물고기 리스트

    void Start()
    {
        // 물고기 리스트에 물고기들 추가
        FishList.Add(Fish1);
        FishList.Add(Fish2);
        FishList.Add(Fish3);
        FishList.Add(Fish4);

        // 물고기들 게임 시작 시 안보이게
        HideFish();

        // 게임 최초 시작
        Invoke("ShowFish", 1.2f);
    }

    // 랜덤으로 물고기 보여주는 함수
    public void ShowFish()
    {
        int temp = Random.Range(0, FishList.Count); // temp: 리스트 중 하나 무작위로 뽑는다.

        // 뽑은 수를 FishDirector.cs의 indexFish에 저장한다
        game1_FishDirector Fish = GameObject.Find("Fishes").GetComponent<game1_FishDirector>();  // game1_FishDirector 스크립트의 객체 받아옴
        Fish.indexFish = temp;
        Debug.Log("indexFish: " + Fish.indexFish + " / temp: " + temp);

        FishList[temp].SetActive(true); // 뽑힌 물고기 보여주기
        Debug.Log(temp + 1 + "번째 물고기 맞춰야함~");

        Invoke("HideFish", 0.3f);   // 금방 사라지기
    }

    // 물고기 모두 안보이게 하는 함수
    void HideFish()
    {
        Fish1.SetActive(false);
        Fish2.SetActive(false);
        Fish3.SetActive(false);
        Fish4.SetActive(false);
    }
}
