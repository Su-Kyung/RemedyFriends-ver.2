using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class game1_submarine : MonoBehaviour
{
    public AudioClip[] question;
    public AudioClip sound;
    public string answer;

    public bool start_game;
    public bool end_game;

    public Button red_Button;
    public Button green_Button;

    public int button = 0;
    public const int RED = 1;
    public const int GREEN = 2;

    public int time;
    public int add = 3; //맞거나 틀릴 시 추가 감소 시간

    // Start is called before the first frame update
    void Start()
    {
        time = 180;
        red_Button = GameObject.Find("red_Button").GetComponent<Button>();
        green_Button = GameObject.Find("green_Button").GetComponent<Button>();
        start_game = true;
        end_game = false;
    }

    // Update is called once per frame
    void Update()
    {
        //소리가 랜덤으로 나옴
        //소리에 따라 버튼 다르게 
        //소리 나올때는 버튼 disable
        //맞으면 O 틀리면 X
        //stop .Pause()

        //true
        //true & 0이 아니면 play
        //false
        //버튼 누르면 true

        red_Button.onClick.AddListener(() =>
        {
            button = RED;
        });
        green_Button.onClick.AddListener(() =>
        {
            button = GREEN;
        });

        if (start_game == true && end_game == false)
        {
            start_game = false;
            Debug.Log(time);
            sound = playQuestion();
            answer = sound.name.ToString();
            
            start_game = clickRedGreenButton(answer);
            if (time <= 0)
                end_game = true;
        }
    }

    AudioClip playQuestion() {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = question[Random.Range(0, 1)];
        audio.Play();
        return audio.clip;
    }

    bool clickRedGreenButton(string answer) {
        Debug.Log(answer);
        if (answer == "green")
        {
            if (button == GREEN)
            {
                time += add;
                showCorrect();
                return true;
            }
            else if (button == RED)
            {
                time -= add;
                showWrong();
                return true;
            }
        }
        else if (answer == "noGreen_noRed_green")
        {
            time = time - 60;
            return true;
        }
        else if (answer == "noRed_green")
        {
            time = time - 60;
            return true;
        }
        else if (answer == "red_blue")
        {
            time = time - 60;
            return true;
        }
        else if (answer == "red_blue_blue")
        {
            time = time - 60;
            return true;
        }
        button = 0;
        return false;
    }

    void showCorrect() {
        Debug.Log("correct");
    }

    void showWrong() {
        Debug.Log("wrong");
    }
}


//답변 리스트를 만든다.
// 답변 리스트와 비교해서 틀리면 wrong 맞으면 correct
// 문제 이름이랑 답변 리스트 크기랑 비교해서도 처리하면 될듯
