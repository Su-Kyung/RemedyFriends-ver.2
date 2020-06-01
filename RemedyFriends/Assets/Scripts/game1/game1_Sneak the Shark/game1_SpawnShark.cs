using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game1_SpawnShark : MonoBehaviour
{
    public bool isShark;    // 상어가 활성화 되었는지 아닌지 판별 위한 변수
    public GameObject imgShark; // 나타날 상어

    // Start is called before the first frame update
    void Start()
    {
        // 처음에는 안나타난 상태
        imgShark.SetActive(false);
        isShark = false;

        // 3~5초 사에 상어 나타나기
        Invoke("SpawnShark", Random.Range(3, 5));
    }

    void SpawnShark()
    {
        // 상어 생성
        imgShark.SetActive(true);
        isShark = true;

        // 상어 사라지기
        Invoke("HideShark", Random.Range(1, 3.5f));
    }

    void HideShark()
    {
        // 상어 사라지기
        imgShark.SetActive(false);
        isShark = false;

        game1_FishDirector Fish = GameObject.Find("Fishes").GetComponent<game1_FishDirector>();  // game1_FishDirector 스크립트의 객체 받아옴
        Fish.scoreShark += 50;

        GameCountdown Countdown = GameObject.Find("countdown_PanelUI").GetComponent<GameCountdown>();  // GameCountdown 스크립트의 객체 받아옴

        if (Countdown.enableSpawn)
        {
            // 다시 생성 인보크 (2~7초)
            Invoke("SpawnShark", Random.Range(2, 7));
        }
    }
}
