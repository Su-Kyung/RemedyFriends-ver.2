using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class game2_camel : MonoBehaviour
{
    public AudioClip[] question;
    public AudioClip sound;
    public string sound_string;

    public AudioClip[] correctSound;
    public AudioClip wrongSound;

    public Button camel1;
    public Button camel2;
    public Button camel3;
    public Button camel4;

    const int nMAX = 4;
    int[] nImg = new int[nMAX];

    public int answer_button;
    public int[] answer;

    public Text txtScore;
    public int score = 63;
    public int random;

    //[SerializeField]
    //private float delay = 2.0f;

    public float delay = 1.88f;

    bool first = true;
    // Update is called once per frame
    void Update()
    {
        GameCountdown Countdown = GameObject.Find("countdown_PanelUI").GetComponent<GameCountdown>();
        if (!Countdown.enableSpawn)
        {
            if (score < 0)
            {
                score = 0;
                txtScore.text = score.ToString();
            }
            else
                txtScore.text = score.ToString();
            StopAllCoroutines();
            GetComponent<AudioSource>().Stop();
        }
        else if (Countdown.enableSpawn && first == true)
        {
            StartCamelGame();
            first = false;
        }
    }
    // Start is called before the first frame update
    void StartCamelGame()
    {
        camel1 = GameObject.Find("camel1").GetComponent<Button>();
        camel2 = GameObject.Find("camel2").GetComponent<Button>();
        camel3 = GameObject.Find("camel3").GetComponent<Button>();
        camel4 = GameObject.Find("camel4").GetComponent<Button>();

        random = Random.Range(0, question.Length); //음성 문제 랜덤 ( 정답)


        bool[] bCheckExistOfNum = new bool[question.Length]; //랜덤 숫자 겹치지 않게

        int nAnswer = Random.Range(0, 3);//낙타 중 정답
        bCheckExistOfNum[random] = true; //정답 중복 방지
        nImg[nAnswer] = random;//정답 저장

        //Debug.Log(nImg[0]);
        // Debug.Log(nImg[1]);
        // Debug.Log(nImg[2]);
        //Debug.Log(nImg[3]);

        for (int i = 0; i < nAnswer;)
        {
            int nTemp = Random.Range(0, question.Length);//음성 문제 랜덤 ( 정답 아님)
            Debug.Log("nTemp" + nTemp);
            if (bCheckExistOfNum[nTemp] == false)
            {
                bCheckExistOfNum[nTemp] = true;
                nImg[i] = nTemp;
                ++i;
            }
        }

        for (int i = nAnswer + 1; i < nMAX;)
        {
            int nTemp = Random.Range(0, question.Length);
            Debug.Log("nTemp" + nTemp);
            if (bCheckExistOfNum[nTemp] == false)
            {
                bCheckExistOfNum[nTemp] = true;
                nImg[i] = nTemp;
                ++i;
            }
        }
        //Debug.Log(nImg[0]);
        //Debug.Log(nImg[1]);
        //Debug.Log(nImg[2]);
        // Debug.Log(nImg[3]);

        camel1.GetComponent<Image>().sprite = Resources.Load("game2/camel/img_camel_" + nImg[0] + "_l", typeof(Sprite)) as Sprite;
        camel2.GetComponent<Image>().sprite = Resources.Load("game2/camel/img_camel_" + nImg[1] + "_r", typeof(Sprite)) as Sprite;
        camel3.GetComponent<Image>().sprite = Resources.Load("game2/camel/img_camel_" + nImg[2] + "_l", typeof(Sprite)) as Sprite;
        camel4.GetComponent<Image>().sprite = Resources.Load("game2/camel/img_camel_" + nImg[3] + "_r", typeof(Sprite)) as Sprite;

        setCurrentQuestion();
    }

    IEnumerator TransitionToNextQuesion()
    {
        yield return new WaitForSeconds(delay);
        StartCamelGame();
    }
    void setCurrentQuestion()
    {
        sound = playQuestion();
        sound_string = sound.name.ToString();

    }

    AudioClip playQuestion()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = question[random];
        audio.Play();
        return audio.clip;
    }

    public void selectCamel1()
    {
        if (random == nImg[0])
        {
            Debug.Log("correct");
            soundCorrect();
            score += 133;
        }
        else
        {
            Debug.Log("wrong");
            soundWrong();
            score -= 7;
        }
        StartCoroutine(TransitionToNextQuesion());
    }

    public void selectCamel2()
    {
        if (random == nImg[1])
        {
            Debug.Log("correct");
            soundCorrect();
            score += 133;
        }
        else
        {
            Debug.Log("wrong");
            soundWrong();
            score -= 7;
        }
        StartCoroutine(TransitionToNextQuesion());
    }

    public void selectCamel3()
    {
        if (random == nImg[2])
        {
            Debug.Log("correct");
            soundCorrect();
            score += 133;
        }
        else
        {
            Debug.Log("wrong");
            soundWrong();
            score -= 7;
        }
        StartCoroutine(TransitionToNextQuesion());
    }

    public void selectCamel4()
    {
        if (random == nImg[3])
        {
            Debug.Log("correct");
            soundCorrect();
            score += 133;
        }
        else
        {
            Debug.Log("wrong");
            soundWrong();
            score -= 7;
        }
        StartCoroutine(TransitionToNextQuesion());
    }

    public void soundCorrect() {
        int correctRandom = Random.Range(0, correctSound.Length);
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = correctSound[correctRandom];
        audio.Play();
    }

    public void soundWrong() {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = wrongSound;
        audio.Play();
    }
}
