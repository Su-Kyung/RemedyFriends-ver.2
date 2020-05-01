using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game1_SpawnShells : MonoBehaviour
{
    public GameObject PearlShell;
    public GameObject Shell;

    //GameCountdown Countdown = GameObject.Find("countdown_PanelUI").GetComponent<GameCountdown>();  // GameCountdown 스크립트의 객체 받아옴


    // 진주조개 랜덤생성 및 삭제 함수
    void SpawnPearlShell()
    {
        GameCountdown Countdown = GameObject.Find("countdown_PanelUI").GetComponent<GameCountdown>();  // GameCountdown 스크립트의 객체 받아옴

        float pRandomX = Random.Range(-10f, 10f);
        float pRandomY = Random.Range(-6f, 6f);
        if (Countdown.enableSpawn)
        {
            GameObject game1_shell_pearl = (GameObject)Instantiate(PearlShell, new Vector2(pRandomX, pRandomY), Quaternion.identity);
            // 일정 시간 뒤에 진주조개 Clone 삭제
            Destroy(game1_shell_pearl, 5f);
        }
    }

    // 조개 랜덤생성 및 삭제 함수
    void SpawnShell()
    {
        GameCountdown Countdown = GameObject.Find("countdown_PanelUI").GetComponent<GameCountdown>();  // GameCountdown 스크립트의 객체 받아옴

        float sRandomX = Random.Range(-10f, 10f);
        float sRandomY = Random.Range(-6f, 6f);
        if (Countdown.enableSpawn)
        {
            GameObject game1_shell_nonPearl = (GameObject)Instantiate(Shell, new Vector2(sRandomX, sRandomY), Quaternion.identity);
            // 일정 시간 뒤에 조개 Clone 삭제
            Destroy(game1_shell_nonPearl, 5f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnPearlShell", 1, 0.7f);
        InvokeRepeating("SpawnShell", 1, 1.5f);
    }
}
