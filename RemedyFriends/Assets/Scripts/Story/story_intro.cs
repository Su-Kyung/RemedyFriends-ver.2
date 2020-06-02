using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class story_intro : MonoBehaviour
{
    public GameObject intro1, intro2, intro3, intro4, intro5, intro6, intro7, intro8, intro9,
        intro10, intro11, intro12, intro13;
    List<GameObject> IntroList = new List<GameObject>(); // 인트로 이미지 리스트
    int index = 0;  // 리스트 인덱스

    public Button btnNext;  // 다음으로 넘어가는 버튼

    // Start is called before the first frame update
    void Start()
    {
        // 인트로리스트에 이미지들 추가
        IntroList.Add(intro1);
        IntroList.Add(intro2);
        IntroList.Add(intro3);
        IntroList.Add(intro4);
        IntroList.Add(intro5);
        IntroList.Add(intro6);
        IntroList.Add(intro7);
        IntroList.Add(intro8);
        IntroList.Add(intro9);
        IntroList.Add(intro10);
        IntroList.Add(intro11);
        IntroList.Add(intro12);
        IntroList.Add(intro13);

        // 첫번째 인트로 이미지만 보이게 설정
        HideIntro();
        intro1.SetActive(true);

        // 다음으로 넘어가는 버튼 리스너 추가
        btnNext.onClick.AddListener(NextIntro);
    }

    void NextIntro()
    {
        if (index != 12)
        {
            IntroList[index].SetActive(false);
            index += 1;
            IntroList[index].SetActive(true);
        }
        else SceneManager.LoadScene(1);

    }

    void HideIntro()
    {
        intro1.SetActive(false);
        intro2.SetActive(false);
        intro3.SetActive(false);
        intro4.SetActive(false);
        intro5.SetActive(false);
        intro6.SetActive(false);
        intro7.SetActive(false);
        intro8.SetActive(false);
        intro9.SetActive(false);
        intro10.SetActive(false);
        intro11.SetActive(false);
        intro12.SetActive(false);
        intro13.SetActive(false);
    }
}
