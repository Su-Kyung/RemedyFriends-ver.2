using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCountdown : MonoBehaviour
{
    private int Timer = 0;

    public GameObject IMG_tutorial; // 튜토리얼 이미지
    public GameObject Num_A;   //1번
    public GameObject Num_B;   //2번
    public GameObject Num_C;   //3번
    public GameObject Num_GO;   //시작 이미지

    public bool enableSpawn;    // 여기서 게임오브젝트 spawn 총 지휘
    
    void Start()
    {
        //시작시 카운트 다운 초기화, 게임 시작 false 설정
        Timer = 0;
        enableSpawn = false;
        Debug.Log("enableSpawn is false. - GameCountdown");

        // 튜토리얼, 나머지 (카운트다운 이미지) 안보이기
        IMG_tutorial.SetActive(false);
        Num_A.SetActive(false);
        Num_B.SetActive(false);
        Num_C.SetActive(false);
        Num_GO.SetActive(false);
    }
    
    void Update()
    {
        //게임 시작시 정지
        if (Timer == 0)
        {
            Time.timeScale = 0.0f;
        }

        //Timer 가 90보다 작거나 같을경우 Timer 계속증가
        if (Timer <= 150)
        {
            Timer++;
            // Timer가 30보다 작을경우 3번켜기
            if (Timer < 60)
            {
                IMG_tutorial.SetActive(true);
            }
            // Timer가 30보다 클경우 3번끄고 2번켜기
            if (Timer > 60)
            {
                IMG_tutorial.SetActive(false);
                Num_C.SetActive(true);
            }
            // Timer가 60보다 작을경우 2번끄고 1번켜기
            if (Timer > 90)
            {
                Num_C.SetActive(false);
                Num_B.SetActive(true);
            }
            //Timer 가 90보다 클경우 1번끄고 GO 켜기 LoadingEnd () 코루틴호출
            if (Timer > 120)
            {
                Num_B.SetActive(false);
                Num_A.SetActive(true);
            }
            if (Timer >= 150)
            {
                Num_A.SetActive(false);
                Num_GO.SetActive(true);
                StartCoroutine(this.LoadingEnd());
                Time.timeScale = 1.0f; //게임시작
            }
        }
    }
  
    
    IEnumerator LoadingEnd()
    {
        yield return new WaitForSeconds(1.0f);
        Num_GO.SetActive(false);
        enableSpawn = true;
        Debug.Log("enableSpawn is true. - GameCountdown");
    }
 
    
}
