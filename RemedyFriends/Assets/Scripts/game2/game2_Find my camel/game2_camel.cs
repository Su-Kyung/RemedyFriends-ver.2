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

    public Button camel1;
    public Button camel2;
    public Button camel3;
    public Button camel4;
    
    const int nMAX = 4;
    int[] nImg = new int[nMAX];
    
    public int answer_button;
    public int[] answer;

    public int score = 180;
    public int random;

    [SerializeField]
    private float delay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        camel1 = GameObject.Find("camel1").GetComponent<Button>();
        camel2 = GameObject.Find("camel2").GetComponent<Button>();
        camel3 = GameObject.Find("camel3").GetComponent<Button>();
        camel4 = GameObject.Find("camel4").GetComponent<Button>();

random = Random.Range(0, question.Length);

        
        bool[] bCheckExistOfNum = new bool[question.Length];

        int nAnswer = Random.Range(0, 3);
        bCheckExistOfNum[random] = true;
        nImg[nAnswer] = random;

        Debug.Log(nImg[0]);
        Debug.Log(nImg[1]);
        Debug.Log(nImg[2]);
        Debug.Log(nImg[3]);

        for (int i = 0; i < nAnswer;)
        {
            int nTemp = Random.Range(0, question.Length);
            Debug.Log("nTemp"+ nTemp);
            if (bCheckExistOfNum[nTemp] == false)
            {
                bCheckExistOfNum[nTemp] = true;
                nImg[i] = nTemp;
                ++i;
            }
        }

        for (int i = nAnswer+1; i < nMAX;)
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
        Debug.Log(nImg[0]);
        Debug.Log(nImg[1]);
        Debug.Log(nImg[2]);
        Debug.Log(nImg[3]);

        camel1.GetComponent<Image>().sprite = Resources.Load("game2/camel/image"+nImg[0], typeof(Sprite)) as Sprite;
        camel2.GetComponent<Image>().sprite = Resources.Load("game2/camel/image" + nImg[1], typeof(Sprite)) as Sprite;
        camel3.GetComponent<Image>().sprite = Resources.Load("game2/camel/image" + nImg[2], typeof(Sprite)) as Sprite;
        camel4.GetComponent<Image>().sprite = Resources.Load("game2/camel/image" + nImg[3], typeof(Sprite)) as Sprite;

        setCurrentQuestion();
    }

    IEnumerator TransitionToNextQuesion()
    {
        yield return new WaitForSeconds(delay);
        Start();
    }
    void setCurrentQuestion() {
        sound = playQuestion();
        sound_string = sound.name.ToString();

        clickcamel(sound_string);
    }

    AudioClip playQuestion()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = question[random];
        audio.Play();
        return audio.clip;
    }

    void clickcamel(string sound_string)
    {
        Debug.Log(sound_string);
        if (sound_string == "bag")
        {
            answer_button = 0;
        }
        else if (sound_string == "cushion")
        {
            answer_button = 1;
        }
        else if (sound_string == "earring")
        {
            answer_button = 2;
        }
        else if (sound_string == "necklace")
        {
            answer_button = 3;
        }
        else if (sound_string == "shoes")
        {
            answer_button = 4;
        }
        else if (sound_string == "turban")
        {
            answer_button = 5;
        }
    }

    public void selectCamel1()
    {
        if (answer_button == nImg[0])
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

    public void selectCamel2()
    {
        if (answer_button == nImg[1])
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

    public void selectCamel3()
    {
        if (answer_button == nImg[2])
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

    public void selectCamel4()
    {
        if (answer_button == nImg[3])
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
