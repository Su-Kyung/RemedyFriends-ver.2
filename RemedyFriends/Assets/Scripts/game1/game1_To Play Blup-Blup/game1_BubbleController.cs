using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;
using UnityEngine.UI;

// 아래 스크립트는 Bubble1이 활성화되었을 때 움직임만 담당. 즉, Bubble마다 적용
public class game1_BubbleController : MonoBehaviour
{
    /*
    // bubble 오브젝트 받아오기
    public GameObject Bubble;
    // bubble 위치 저장해두기 위한 변수
    private UnityEngine.Vector3 pos;
    
    // pop 속도
    float popSpeed;


    // Start is called before the first frame update
    void Start()
    {
        pos = Bubble.transform.position;
        Bubble.transform.position = pos;    // 저장해둔 위치로 변경
    }

    // Update is called once per frame
    void Update()
    {
        // SetActive(true)이면 처음 속도 설정하고, 점점 줄어듦.
        if (Bubble.activeSelf)
        {
            Bubble.transform.position = pos;
            popSpeed = 0.2f;
        }

        transform.Translate(0, popSpeed, 0);    // 이동
        popSpeed *= 0.9f;   // 감속


        // SetActive(false);
    }
    */

    float speed = 0;
    public bool enableSpawn = false;

    void Update()
    {
        if (this.isActiveAndEnabled & this.speed == 0)
        {
            this.speed = 0.08f;
        }

        transform.Translate(0, this.speed, 0, 0);
        this.speed *= 0.98f;
    }
}
