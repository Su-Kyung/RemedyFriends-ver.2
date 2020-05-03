using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Select_char : MonoBehaviour
{/*
    private GameObject target;

    public GameObject join_char_surl_unselected;
    public GameObject join_char_golden_unselected;
    public GameObject join_char_harp_unselected;
    public GameObject join_char_luna_unselected;
    public int selected = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CastRay();

            if (target.name == "join_char_surl_unselected")
            {
                Selected();
            }
            else if (target.name == "join_char_golden_unselected")
            {
                Selected();
            }
            else if (target.name == "join_char_harp_unselected")
            {
                Selected();
            }
            else if (target.name == "join_char_luna_unselected")
            {
                Selected();
            }
        }
    }

   public void Selected() {
        if (target.name == "join_char_surl_unselected")
        {
            join_char_surl_unselected.GetComponent<SpriteRenderer>().sprite = Resources.Load("character/join_char_surl_selected", typeof(Sprite)) as Sprite;
            join_char_golden_unselected.GetComponent<SpriteRenderer>().sprite = Resources.Load("character/join_char_golden_unselected", typeof(Sprite)) as Sprite;
            join_char_harp_unselected.GetComponent<SpriteRenderer>().sprite = Resources.Load("character/join_char_harp_unselected", typeof(Sprite)) as Sprite;
            join_char_luna_unselected.GetComponent<SpriteRenderer>().sprite = Resources.Load("character/join_char_luna_unselected", typeof(Sprite)) as Sprite;
            selected = 1;
            PlayerPrefs.SetString("Character", selected.ToString());
        }
        else if (target.name == "join_char_golden_unselected")
        {
            join_char_surl_unselected.GetComponent<SpriteRenderer>().sprite = Resources.Load("character/join_char_surl_unselected", typeof(Sprite)) as Sprite;
            join_char_golden_unselected.GetComponent<SpriteRenderer>().sprite = Resources.Load("character/join_char_golden_selected", typeof(Sprite)) as Sprite;
            join_char_harp_unselected.GetComponent<SpriteRenderer>().sprite = Resources.Load("character/join_char_harp_unselected", typeof(Sprite)) as Sprite;
            join_char_luna_unselected.GetComponent<SpriteRenderer>().sprite = Resources.Load("character/join_char_luna_unselected", typeof(Sprite)) as Sprite;
            selected =  2;
            PlayerPrefs.SetString("Character", selected.ToString());
        }
        else if (target.name == "join_char_harp_unselected")
        {
            join_char_surl_unselected.GetComponent<SpriteRenderer>().sprite = Resources.Load("character/join_char_surl_unselected", typeof(Sprite)) as Sprite;
            join_char_golden_unselected.GetComponent<SpriteRenderer>().sprite = Resources.Load("character/join_char_golden_unselected", typeof(Sprite)) as Sprite;
            join_char_harp_unselected.GetComponent<SpriteRenderer>().sprite = Resources.Load("character/join_char_harp_selected", typeof(Sprite)) as Sprite;
            join_char_luna_unselected.GetComponent<SpriteRenderer>().sprite = Resources.Load("character/join_char_luna_unselected", typeof(Sprite)) as Sprite;
            selected = 3;
            PlayerPrefs.SetString("Character", selected.ToString());
        }
        else if (target.name == "join_char_luna_unselected")
        {
            join_char_surl_unselected.GetComponent<SpriteRenderer>().sprite = Resources.Load("character/join_char_surl_unselected", typeof(Sprite)) as Sprite;
            join_char_golden_unselected.GetComponent<SpriteRenderer>().sprite = Resources.Load("character/join_char_golden_unselected", typeof(Sprite)) as Sprite;
            join_char_harp_unselected.GetComponent<SpriteRenderer>().sprite = Resources.Load("character/join_char_harp_unselected", typeof(Sprite)) as Sprite;
            join_char_luna_unselected.GetComponent<SpriteRenderer>().sprite = Resources.Load("character/join_char_luna_selected", typeof(Sprite)) as Sprite;
            selected = 4;
            PlayerPrefs.SetString("Character", selected.ToString());
        }
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
    }*/
}
