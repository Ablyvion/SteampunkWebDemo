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
        float PlayerHp;
        float PlayerMaxHp;
        float EnemyHp;
        float EnemyMaxHp;

        PlayerHp = GetComponent<FightParser>().PlayerHealth;
        PlayerMaxHp = GetComponent<FightParser>().PlayerMaxHealth;
        EnemyHp = GetComponent<FightParser>().EnemyHealth;
        EnemyMaxHp = GetComponent<FightParser>().EnemyMaxHealth;

        playerhealth.fillAmount = PlayerHp / PlayerMaxHp;
        enemyhealth.fillAmount = EnemyHp / EnemyMaxHp;

    }
}
