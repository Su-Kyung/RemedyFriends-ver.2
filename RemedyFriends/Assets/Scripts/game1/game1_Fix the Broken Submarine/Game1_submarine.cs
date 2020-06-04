using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class Game1_submarine : MonoBehaviour
{
    public AudioClip[] question;
    public AudioClip sound;
    public string answer;

    public AudioClip[] correctSound;
    public AudioClip wrongSound;

    public Button red_Button;
    public Button green_Button;

    public int answer_button;

    public Text txtScore;
    public int score = 180;

    bool first = true;

    [SerializeField]
    private float delay = 1f;

    public GameObject redLight;
    public GameObject greenLight;
    public GameObject yellowLight;
    public GameObject blueLight;

    public GameObject correct;
    public GameObject wrong;

    void Update()
    {
        GameCountdown Countdown = GameObject.Find("countdown_PanelUI").GetComponent<GameCountdown>();
        if (!Countdown.enableSpawn && first == false)
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
           
            first = true;
        }
        else if (Countdown.enableSpawn && first == true)
        {
            submarineStart();
            first = false;
        }
    }
    void Start()
    {
        correct.SetActive(false);
        wrong.SetActive(false);
    }

    public void submarineStart()
    {
        redLight.SetActive(false);
        greenLight.SetActive(false);
        yellowLight.SetActive(false);
        blueLight.SetActive(false);
        correct.SetActive(false);
        wrong.SetActive(false);
        Debug.Log(score);
        setCurrentQuestion();
    }

    IEnumerator TransitionToNextQuesion()
    {
        yield return new WaitForSeconds(delay);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        submarineStart();
    }

    void setCurrentQuestion()
    {
        sound = playQuestion();
        answer = sound.name.ToString();

        clickRedGreenButton(answer);
    }

    AudioClip playQuestion()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = question[Random.Range(0, question.Length)];
        audio.Play();
        return audio.clip;
    }

    void clickRedGreenButton(string answer)
    {
        Debug.Log(answer);
        if (answer == "nbyr")
        {
            answer_button = 0;
        }
        else if (answer == "nryy")
        {
            answer_button = 2;
        }
        else if (answer == "nyyg")
        {
            answer_button = 1;
        }
        else if (answer == "nbnyyg")
        {
            answer_button = 1;
        }
        else if (answer == "nyngyb")
        {
            answer_button = 3;
        }
    }

    public void UserSelectRed()
    {
        redLight.SetActive(true);
        if (answer_button == 0)
        {
            correct.SetActive(true);
            soundCorrect();
            Debug.Log("correct");
            score += 33;
        }
        else
        {
            wrong.SetActive(true);
            soundWrong();
            Debug.Log("wrong");
            score -= 33;
        }
        StartCoroutine(TransitionToNextQuesion());
    }
    public void UserSelectGreen()
    {
        greenLight.SetActive(true);
        if (answer_button == 1)
        {
            correct.SetActive(true);
            soundCorrect();
            Debug.Log("correct");
            score += 33;
        }
        else
        {
            wrong.SetActive(true);
            soundWrong();
            Debug.Log("wrong");
            score -= 33;
        }
        StartCoroutine(TransitionToNextQuesion());
    }
    public void UserSelectYellow()
    {
        yellowLight.SetActive(true);
        if (answer_button == 2)
        {
            correct.SetActive(true);
            soundCorrect();
            Debug.Log("correct");
            score += 33;
        }
        else
        {
            wrong.SetActive(true);
            soundWrong();
            Debug.Log("wrong");
            score -= 33;
        }
        StartCoroutine(TransitionToNextQuesion());
    }
    public void UserSelectblue()
    {
        blueLight.SetActive(true);
        if (answer_button == 3)
        {
            correct.SetActive(true);
            soundCorrect();
            Debug.Log("correct");
            score += 33;
        }
        else
        {
            wrong.SetActive(true);
            soundWrong();
            Debug.Log("wrong");
            score -= 33;
        }
        StartCoroutine(TransitionToNextQuesion());
    }

    public void soundCorrect()
    {
        int correctRandom = Random.Range(0, correctSound.Length);
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = correctSound[correctRandom];
        audio.Play();
    }

    public void soundWrong()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = wrongSound;
        audio.Play();
    }
}
