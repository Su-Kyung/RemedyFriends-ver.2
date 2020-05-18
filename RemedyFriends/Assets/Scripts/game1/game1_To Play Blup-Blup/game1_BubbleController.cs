using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;
using UnityEngine.UI;

// 아래 스크립트는 Bubble1이 활성화되었을 때 움직임만 담당. 즉, Bubble마다 적용
public class game1_BubbleController : MonoBehaviour
{
    public float speed = 0; // 실제 속도
    public Button bubble;
    
    void Update()
    {
       if (bubble.isActiveAndEnabled) // 가져온 bool 변수
        {
            bubble.gameObject.transform.Translate(0, this.speed, 0, 0);
            speed *= 0.96f;
        }

        

        if (!bubble.isActiveAndEnabled) speed = 0.08f;
    }
}
