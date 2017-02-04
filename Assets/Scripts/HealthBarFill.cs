using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarFill : MonoBehaviour {

    Image playerhealth;
    Image enemyhealth;
	// Use this for initialization
	void Start () {
        playerhealth = GameObject.Find("PlayerHealthBar").GetComponent<Image>();
        enemyhealth = GameObject.Find("EnemyHealthBar").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update () {
        playerhealth.fillAmount = GetComponent<FightParser>().PlayerHealth / GetComponent<FightParser>().PlayerMaxHealth;
        enemyhealth.fillAmount = GetComponent<FightParser>().EnemyHealth / GetComponent<FightParser>().EnemyMaxHealth;

    }
}
