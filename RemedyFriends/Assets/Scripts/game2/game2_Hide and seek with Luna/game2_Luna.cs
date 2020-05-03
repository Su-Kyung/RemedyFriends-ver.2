using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game2_Luna : MonoBehaviour
{

    public GameObject tent_luna;
    public GameObject cactus_luna;
    public GameObject camel_luna;
    public GameObject rock_luna;

    private GameObject target;
    public int random;

    public int score;

    // Start is called before the first frame update
    void Start()
    {
        tent_luna.SetActive(false);
        cactus_luna.SetActive(false);
        camel_luna.SetActive(false);
        rock_luna.SetActive(false);

        Debug.Log(score);
        random = Random.Range(0, 3);
        Debug.Log(random);
        RandomLuna(random);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CastRay();
            InActiveLuna(random);
        }
    }
    //루나가 나타남
    //루나 나타나는 함수 
    //stop 표시
    public void InActiveLuna(int random)
    {
        Debug.Log(random);
        if (random == 0)
        {
            if (target.name == "tent_luna")
            {
                StopCoroutine(ActiveTentLuna(10));
                score += 26;

                Start();
            }
        }
        else if (random == 1)
        {
            if (target.name == "cactus_luna")
            {

                StopCoroutine(ActiveCactusLuna(10));
                score += 26;

                Start();
            }
        }
        else if (random == 2)
        {
            if (target.name == "camel_luna")
            {
                StopCoroutine(ActiveCamelLuna(10));
                score += 26;

                Start();
            }
        }
        else if (random == 3)
        {
            if (target.name == "rock_luna")
            {
                StopCoroutine(ActiveRockLuna(10));
                score += 26;

                Start();
            }
        }
        score -= 13;
    }

    public void RandomLuna(int random)
    {
        if (random == 0)
        {
            tent_luna.SetActive(true);
            StartCoroutine(ActiveTentLuna(10));
        }
        else if (random == 1)
        {
            cactus_luna.SetActive(true);
            StartCoroutine(ActiveCactusLuna(10));
        }
        else if (random == 2)
        {
            camel_luna.SetActive(true);
            StartCoroutine(ActiveCamelLuna(10));
        }
        else if (random == 3)
        {
            rock_luna.SetActive(true);
            StartCoroutine(ActiveRockLuna(10));
        }

    }

    private IEnumerator ActiveTentLuna(float duration)
    {
        yield return new WaitForSeconds(duration);
        tent_luna.SetActive(false);
        Start();
    }
    private IEnumerator ActiveCactusLuna(float duration)
    {
        yield return new WaitForSeconds(duration);
        cactus_luna.SetActive(false);
        Start();
    }
    private IEnumerator ActiveCamelLuna(float duration)
    {
        yield return new WaitForSeconds(duration);
        camel_luna.SetActive(false);
        Start();
    }
    private IEnumerator ActiveRockLuna(float duration)
    {
        yield return new WaitForSeconds(duration);
        rock_luna.SetActive(false);
        Start();
    }

    void CastRay()
    {
        target = null;

        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

        if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);
            target = hit.collider.gameObject;
        }
    }

}