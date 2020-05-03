using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetUserData : MonoBehaviour
{
    /*
     * 혹시 몰라서 메일로 보내준 코드 복붙 전꺼 주석처리 해둠
    public Text nickname;
   // private Login_Demo Script;
    //private Select_char Character_Script;

    // Start is called before the first frame update
    void Awake()
    {
       // Script = GameObject.Find("LoginObj").GetComponent<Login_Demo>();
        //Character_Script = GameObject.Find("Select_Character").GetComponent<Select_char>();
        //nickname = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
      nickname.text = PlayerPrefs.GetString("Nickname");

    }
    void changeChar() {
        string character = PlayerPrefs.GetString("Character");
        //급해서 이미지 변경으로 처리했는데 향후 오브젝트가 변하게 하면 좋겠음.
        //오브젝트마다 캐릭터 변경 처리도 훨씬 쉬울듯.
        if (character == "1") {
            Debug.Log("1qjs");
        }

    }
    */

    public Text nickname;
/*
    string character;



    GameObject surl;

    GameObject golden;

    GameObject harf;

    GameObject luna;


    */
    void Awake()

    {
        /*
        surl = GameObject.Find("surl_simple_char");

        golden = GameObject.Find("golden_simple_char");

        harf = GameObject.Find("harf_simple_char");

        luna = GameObject.Find("luna_simple_char");



        surl.SetActive(false);

        golden.SetActive(false);

        harf.SetActive(false);

        luna.SetActive(false);


    */
        nickname.text = PlayerPrefs.GetString("Nickname");
        /*
        character = PlayerPrefs.GetString("Character");

        if (character == "1")

        {

            Debug.Log("1- 설이 선택");

            surl.SetActive(true);

        }

        else if (character == "2")

        {

            Debug.Log("2- 골든 선택");

            golden.SetActive(true);

        }

        else if (character == "3")

        {

            Debug.Log("3- 하프 선택");

            harf.SetActive(true);

        }

        else if (character == "4")

        {

            Debug.Log("4 - 루나 선택");

            luna.SetActive(true);

        }

        else { }


*/
    }
}
