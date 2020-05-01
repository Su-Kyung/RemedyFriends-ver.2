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

    public Button red_Button;
    public Button green_Button;

    public int answer_button;

    public int score = 180;

    [SerializeField]
    private float delay = 1f;

    public GameObject redLight;
    public GameObject greenLight;

    public void Start()
    {
        red_Button = GameObject.Find("redButton").GetComponent<Button>();
        green_Button = GameObject.Find("greenButton").GetComponent<Button>();
        if (red_Button && green_Button)
        {
            redLight.SetActive(false);
            greenLight.SetActive(false);
            Debug.Log(score);
            setCurrentQuestion();
        }
        else
        {
            Debug.Log("No game object called wibble found");
        }
    }

    IEnumerator TransitionToNextQuesion()
    {
        yield return new WaitForSeconds(delay);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Start();
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
        if (answer == "green")
        {
            answer_button = 1;
        }
        else if (answer == "noGreen_noRed_green")
        {
            answer_button = 1;
        }
        else if (answer == "noRed_green")
        {
            answer_button = 1;
        }
        else if (answer == "red_blue")
        {
            answer_button = 0;
        }
        else if (answer == "red_blue_blue")
        {
            answer_button = 0;
        }
    }

    public void UserSelectRed()
    {
        redLight.SetActive(true);
        if (answer_button == 0)
        {
            Debug.Log("correct");
            score += 30;
        }
        else
        {
            Debug.Log("wrong");
            score -= 30;
        }
        StartCoroutine(TransitionToNextQuesion());
    }
    public void UserSelectGreen()
    {
        greenLight.SetActive(true);
        if (answer_button == 1)
        {
            Debug.Log("correct");
            score += 30;
        }
        else
        {
            Debug.Log("wrong");
            score -= 30;
        }
        StartCoroutine(TransitionToNextQuesion());
    }
}
