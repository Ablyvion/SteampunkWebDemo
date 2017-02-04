using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeTeams : MonoBehaviour {

    // Use this for initialization
    public static string[] teams = new string[] { "Rory", "Pedro", "Jack", "Kit", "Natalie", "Sophie", "Emilia", "Maisie" };
    
    void Start () {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
            RandomTeams();
    }

    public void RandomTeams ()
    {
        GameObject newChar0;
        GameObject newChar1;
        GameObject newChar2;
        GameObject newChar3;
        GameObject newChar4;
        GameObject newChar5;
        GameObject newChar6;
        GameObject newChar7;

        GameObject.Destroy(GameObject.Find("char0"));
        GameObject.Destroy(GameObject.Find("char1"));
        GameObject.Destroy(GameObject.Find("char2"));
        GameObject.Destroy(GameObject.Find("char3"));
        GameObject.Destroy(GameObject.Find("char4"));
        GameObject.Destroy(GameObject.Find("char5"));
        GameObject.Destroy(GameObject.Find("char6"));
        GameObject.Destroy(GameObject.Find("char7"));
        GetComponent<FightParser>().PlayerHealth = GetComponent<FightParser>().PlayerMaxHealth;
        GetComponent<FightParser>().EnemyHealth = GetComponent<FightParser>().EnemyMaxHealth;

        for (int i = teams.Length - 1; i > 0; i--)
        {
            int r = Random.Range(0, i + 1);
            string tmp = teams[i];
            teams[i] = teams[r];
            teams[r] = tmp;
        }
        newChar0 = Instantiate(GameObject.Find(teams[0]));
        newChar0.name = "char0";
        newChar0.transform.position = new Vector2(-150f, -165f);
        newChar1 = Instantiate(GameObject.Find(teams[1]));
        newChar1.name = "char1";
        newChar1.transform.position = new Vector2(-50f, -165f);
        newChar2 = Instantiate(GameObject.Find(teams[2]));
        newChar2.name = "char2";
        newChar2.transform.position = new Vector2(50f, -165f);
        newChar3 = Instantiate(GameObject.Find(teams[3]));
        newChar3.name = "char3";
        newChar3.transform.position = new Vector2(150f, -165f);
        newChar4 = Instantiate(GameObject.Find(teams[4]));
        newChar4.name = "char4";
        newChar4.transform.position = new Vector2(-150f, 165f);
        newChar5 = Instantiate(GameObject.Find(teams[5]));
        newChar5.name = "char5";
        newChar5.transform.position = new Vector2(-50f, 165f);
        newChar6 = Instantiate(GameObject.Find(teams[6]));
        newChar6.name = "char6";
        newChar6.transform.position = new Vector2(50f, 165f);
        newChar7 = Instantiate(GameObject.Find(teams[7]));
        newChar7.name = "char7";
        newChar7.transform.position = new Vector2(150f, 165f);
    }
}
