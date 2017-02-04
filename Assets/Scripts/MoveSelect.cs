using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSelect : MonoBehaviour
{

    int CurrentChar;
    GameObject CurrentObj;
    public int chosen1 = -1;
    public int chosen2 = -1;
    public int chosen3 = -1;
    public bool ParseFight = false;

    //Use this for initialization
    void Start()
    {
        CurrentChar = 1;
    }   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            CurrentObj = GameObject.Find("char0");
            if (CurrentChar == 1)
            {
                GameObject.Find("ChooseBox1").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(CurrentObj.GetComponent<CharData>().MoveUtility);
                chosen1 = CurrentObj.GetComponent<CharData>().ID;
            }
            if (CurrentChar == 2)
            {
                GameObject.Find("ChooseBox2").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(CurrentObj.GetComponent<CharData>().MovePrimary);
                chosen2 = CurrentObj.GetComponent<CharData>().ID;
            }
            if (CurrentChar == 3)
            {
                GameObject.Find("ChooseBox3").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(CurrentObj.GetComponent<CharData>().MoveSecondary);
                chosen3 = CurrentObj.GetComponent<CharData>().ID;
            }
            if (CurrentChar == 4)
                ParseFight = true;
            CurrentChar++;
        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            CurrentObj = GameObject.Find("char1");
            if (CurrentChar == 1)
            {
                GameObject.Find("ChooseBox1").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(CurrentObj.GetComponent<CharData>().MoveUtility);
                chosen1 = CurrentObj.GetComponent<CharData>().ID;
            }
            if (CurrentChar == 2)
            {
                GameObject.Find("ChooseBox2").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(CurrentObj.GetComponent<CharData>().MovePrimary);
                chosen2 = CurrentObj.GetComponent<CharData>().ID;
            }
            if (CurrentChar == 3)
            {
                GameObject.Find("ChooseBox3").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(CurrentObj.GetComponent<CharData>().MoveSecondary);
                chosen3 = CurrentObj.GetComponent<CharData>().ID;
            }
            if (CurrentChar == 4)
                ParseFight = true;
            CurrentChar++;
        }
        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            CurrentObj = GameObject.Find("char2");
            if (CurrentChar == 1)
            {
                GameObject.Find("ChooseBox1").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(CurrentObj.GetComponent<CharData>().MoveUtility);
                chosen1 = CurrentObj.GetComponent<CharData>().ID;
            }
            if (CurrentChar == 2)
            {
                GameObject.Find("ChooseBox2").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(CurrentObj.GetComponent<CharData>().MovePrimary);
                chosen2 = CurrentObj.GetComponent<CharData>().ID;
            }
            if (CurrentChar == 3)
            {
                GameObject.Find("ChooseBox3").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(CurrentObj.GetComponent<CharData>().MoveSecondary);
                chosen3 = CurrentObj.GetComponent<CharData>().ID;
            }
            if (CurrentChar == 4)
                ParseFight = true;
            CurrentChar++;
        }
        if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            CurrentObj = GameObject.Find("char3");
            if (CurrentChar == 1)
            {
                GameObject.Find("ChooseBox1").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(CurrentObj.GetComponent<CharData>().MoveUtility);
                chosen1 = CurrentObj.GetComponent<CharData>().ID;
            }
            if (CurrentChar == 2)
            {
                GameObject.Find("ChooseBox2").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(CurrentObj.GetComponent<CharData>().MovePrimary);
                chosen2 = CurrentObj.GetComponent<CharData>().ID;
            }
            if (CurrentChar == 3)
            {
                GameObject.Find("ChooseBox3").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(CurrentObj.GetComponent<CharData>().MoveSecondary);
                chosen3 = CurrentObj.GetComponent<CharData>().ID;
            }
            if (CurrentChar == 4)
                ParseFight = true;
            CurrentChar++;
        }
        if (CurrentChar > 5)
        {
            chosen1 = -1;
            chosen2 = -1;
            chosen3 = -1;
            CurrentChar = 1;
        }
            
    }
}
