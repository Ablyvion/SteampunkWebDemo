using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightParser : MonoBehaviour {

    public int[] EnemyChosen = new int[3];
    public int[] PlayerChosen = new int[3];
    public int[] EnemyTeam = new int[4];
    private string[] CharList = new string[] { "Rory", "Pedro", "Jack", "Kit", "Natalie", "Sophie", "Emilia", "Maisie" };
    public int PlayerHealth;
    public int EnemyHealth;
    public CharData.Buffs StoredPlayerBuff = CharData.Buffs.BUFF_NONE;
    public int StoredPlayerBuffValue = 0;
    public CharData.Buffs StoredEnemyBuff = CharData.Buffs.BUFF_NONE;
    public int StoredEnemyBuffValue = 0;
    public CharData.Debuffs StoredPlayerDebuff = CharData.Debuffs.DEBUFF_NONE;
    public int StoredPlayerDebuffValue = 0;
    public CharData.Debuffs StoredEnemyDebuff = CharData.Debuffs.DEBUFF_NONE;
    public int StoredEnemyDebuffValue = 0;
    public int PlayerMaxHealth = 100;
    public int EnemyMaxHealth = 100;
    // Use this for initialization
    void Start () {
        PlayerHealth = PlayerMaxHealth;
        EnemyHealth = EnemyMaxHealth;
    }

    // Update is called once per frame
    void Update() {
        if (GetComponent<MoveSelect>().ParseFight == true)
        {
            GetComponent<MoveSelect>().ParseFight = false;
            Fight();
        }
    } 

    void Fight() {
            int[] PlayerDamage = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] EnemyDamage = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] PlayerHeal = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] EnemyHeal = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int PlayerHitCount = 0;
            int PlayerHealCount = 0;
            int EnemyHitCount = 0;
            int EnemyHealCount = 0;
            PlayerChosen[0] = GetComponent<MoveSelect>().chosen1;
            PlayerChosen[1] = GetComponent<MoveSelect>().chosen2;
            PlayerChosen[2] = GetComponent<MoveSelect>().chosen3;
            EnemyTeam[0] = GameObject.Find("char4").GetComponent<CharData>().ID;
            EnemyTeam[1] = GameObject.Find("char5").GetComponent<CharData>().ID;
            EnemyTeam[2] = GameObject.Find("char6").GetComponent<CharData>().ID;
            EnemyTeam[3] = GameObject.Find("char7").GetComponent<CharData>().ID;
            for (int i = EnemyTeam.Length - 1; i > 0; i--)
            {
                int r = Random.Range(0, i + 1);
                int tmp = EnemyTeam[i];
                EnemyTeam[i] = EnemyTeam[r];
                EnemyTeam[r] = tmp;
            }
            EnemyChosen[0] = EnemyTeam[0];
            EnemyChosen[1] = EnemyTeam[1];
            EnemyChosen[2] = EnemyTeam[2];
            GameObject.Find("EnemyChooseBox1").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(GameObject.Find(CharList[EnemyChosen[0]]).GetComponent<CharData>().MoveUtility);
            GameObject.Find("EnemyChooseBox2").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(GameObject.Find(CharList[EnemyChosen[1]]).GetComponent<CharData>().MovePrimary);
            GameObject.Find("EnemyChooseBox3").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(GameObject.Find(CharList[EnemyChosen[2]]).GetComponent<CharData>().MoveSecondary);
            CharData.Buffs PlayerUtilityBuff = GameObject.Find(CharList[PlayerChosen[0]]).GetComponent<CharData>().UtilityBuff;
            int PlayerUtilityBuffValue = GameObject.Find(CharList[PlayerChosen[0]]).GetComponent<CharData>().UtilityBuffValue;
            int PlayerUtilityBuffDuration = GameObject.Find(CharList[PlayerChosen[0]]).GetComponent<CharData>().UtilityBuffDuration;
            CharData.Debuffs PlayerUtilityDebuff = GameObject.Find(CharList[PlayerChosen[0]]).GetComponent<CharData>().UtilityDebuff;
            int PlayerUtilityDebuffValue = GameObject.Find(CharList[PlayerChosen[0]]).GetComponent<CharData>().UtilityDebuffValue;
            int PlayerUtilityDebuffDuration = GameObject.Find(CharList[PlayerChosen[0]]).GetComponent<CharData>().UtilityDebuffDuration;
//            int PlayerUtilityPassiveBuff = GameObject.Find(CharList[PlayerChosen[0]]).GetComponent<CharData>().UtilityPassiveBuff;
//            int PlayerUtilityPassiveBuffValue = GameObject.Find(CharList[PlayerChosen[0]]).GetComponent<CharData>().UtilityPassiveBuffValue;
//            int PlayerUtilityPassiveDebuff = GameObject.Find(CharList[PlayerChosen[0]]).GetComponent<CharData>().UtilityPassiveDebuff;
//            int PlayerUtilityPassiveDebuffValue = GameObject.Find(CharList[PlayerChosen[0]]).GetComponent<CharData>().UtilityPassiveDebuffValue;
            int PlayerPrimaryDamageMin = GameObject.Find(CharList[PlayerChosen[1]]).GetComponent<CharData>().PrimaryMin;
            int PlayerPrimaryDamageMax = GameObject.Find(CharList[PlayerChosen[1]]).GetComponent<CharData>().PrimaryMax;
            int PlayerPrimaryStrikes = GameObject.Find(CharList[PlayerChosen[1]]).GetComponent<CharData>().PrimaryStrikes;
            int PlayerSecondaryDamageMin = GameObject.Find(CharList[PlayerChosen[2]]).GetComponent<CharData>().SecondaryMin;
            int PlayerSecondaryDamageMax = GameObject.Find(CharList[PlayerChosen[2]]).GetComponent<CharData>().SecondaryMax;
            int PlayerSecondaryHealMin = GameObject.Find(CharList[PlayerChosen[2]]).GetComponent<CharData>().SecondaryHealMin;
            int PlayerSecondaryHealMax = GameObject.Find(CharList[PlayerChosen[2]]).GetComponent<CharData>().SecondaryHealMax;
            int PlayerSecondaryStrikes = GameObject.Find(CharList[PlayerChosen[2]]).GetComponent<CharData>().SecondaryStrikes;
            int PlayerSecondaryLeechPercent = GameObject.Find(CharList[PlayerChosen[2]]).GetComponent<CharData>().SecondaryLeechPercent;
            int PlayerSecondaryBlocks = GameObject.Find(CharList[PlayerChosen[2]]).GetComponent<CharData>().SecondaryBlocks;

            CharData.Buffs EnemyUtilityBuff = GameObject.Find(CharList[EnemyChosen[0]]).GetComponent<CharData>().UtilityBuff;
            int EnemyUtilityBuffValue = GameObject.Find(CharList[EnemyChosen[0]]).GetComponent<CharData>().UtilityBuffValue;
            int EnemyUtilityBuffDuration = GameObject.Find(CharList[EnemyChosen[0]]).GetComponent<CharData>().UtilityBuffDuration;
            CharData.Debuffs EnemyUtilityDebuff = GameObject.Find(CharList[EnemyChosen[0]]).GetComponent<CharData>().UtilityDebuff;
            int EnemyUtilityDebuffValue = GameObject.Find(CharList[EnemyChosen[0]]).GetComponent<CharData>().UtilityDebuffValue;
            int EnemyUtilityDebuffDuration = GameObject.Find(CharList[EnemyChosen[0]]).GetComponent<CharData>().UtilityDebuffDuration;
//            int EnemyUtilityPassiveBuff = GameObject.Find(CharList[EnemyChosen[0]]).GetComponent<CharData>().UtilityPassiveBuff;
//            int EnemyUtilityPassiveBuffValue = GameObject.Find(CharList[EnemyChosen[0]]).GetComponent<CharData>().UtilityPassiveBuffValue;
//            int EnemyUtilityPassiveDebuff = GameObject.Find(CharList[EnemyChosen[0]]).GetComponent<CharData>().UtilityPassiveDebuff;
//            int EnemyUtilityPassiveDebuffValue = GameObject.Find(CharList[EnemyChosen[0]]).GetComponent<CharData>().UtilityPassiveDebuffValue;
            int EnemyPrimaryDamageMin = GameObject.Find(CharList[EnemyChosen[1]]).GetComponent<CharData>().PrimaryMin;
            int EnemyPrimaryDamageMax = GameObject.Find(CharList[EnemyChosen[1]]).GetComponent<CharData>().PrimaryMax;
            int EnemyPrimaryStrikes = GameObject.Find(CharList[EnemyChosen[1]]).GetComponent<CharData>().PrimaryStrikes;
            int EnemySecondaryDamageMin = GameObject.Find(CharList[EnemyChosen[2]]).GetComponent<CharData>().SecondaryMin;
            int EnemySecondaryDamageMax = GameObject.Find(CharList[EnemyChosen[2]]).GetComponent<CharData>().SecondaryMax;
            int EnemySecondaryHealMin = GameObject.Find(CharList[EnemyChosen[2]]).GetComponent<CharData>().SecondaryHealMin;
            int EnemySecondaryHealMax = GameObject.Find(CharList[EnemyChosen[2]]).GetComponent<CharData>().SecondaryHealMax;
            int EnemySecondaryStrikes = GameObject.Find(CharList[EnemyChosen[2]]).GetComponent<CharData>().SecondaryStrikes;
            int EnemySecondaryLeechPercent = GameObject.Find(CharList[EnemyChosen[2]]).GetComponent<CharData>().SecondaryLeechPercent;
            int EnemySecondaryBlocks = GameObject.Find(CharList[EnemyChosen[2]]).GetComponent<CharData>().SecondaryBlocks;

            //total buffs and debuffs first
            int PlayerPercentDamage = 100;
            int PlayerFlatDamage = 0;
            int PlayerPercentLeechReflect = 0;
            int PlayerLucky = 0;
            int EnemyPercentDamage = 100;
            int EnemyFlatDamage = 0;
            int EnemyPercentLeechReflect = 0;
            int EnemyLucky = 0;
            int LuckyRoll;
            int LowestPlayerDamage = 0;
            int LowestEnemyDamage = 0;
            int PlayerFinalDamage = 0;
            int PlayerFinalHeal = 0;
            int EnemyFinalDamage = 0;
            int EnemyFinalHeal = 0;

            if (PlayerUtilityBuff == CharData.Buffs.BUFF_PERCENT_DAMAGE)
                PlayerPercentDamage += PlayerUtilityBuffValue;
            if (StoredPlayerBuff == CharData.Buffs.BUFF_PERCENT_DAMAGE)
                PlayerPercentDamage += StoredPlayerBuffValue;
            if (PlayerUtilityBuff == CharData.Buffs.BUFF_FLAT_DAMAGE)
                PlayerFlatDamage += PlayerUtilityBuffValue;
            if (StoredPlayerBuff == CharData.Buffs.BUFF_FLAT_DAMAGE)
                PlayerFlatDamage += StoredPlayerBuffValue;
            if (PlayerUtilityBuff == CharData.Buffs.BUFF_PERCENT_LEECH)
                PlayerPercentLeechReflect += PlayerUtilityBuffValue;
            if (StoredPlayerBuff == CharData.Buffs.BUFF_PERCENT_LEECH)
                PlayerPercentLeechReflect += StoredPlayerBuffValue;
            if (PlayerUtilityBuff == CharData.Buffs.BUFF_LUCKY)
                PlayerLucky = 1;
            if (StoredPlayerBuff == CharData.Buffs.BUFF_LUCKY)
                PlayerLucky = 1;
            if (EnemyUtilityDebuff == CharData.Debuffs.DEBUFF_PERCENT_DAMAGE)
                PlayerPercentDamage -= EnemyUtilityDebuffValue;
            if (StoredPlayerDebuff == CharData.Debuffs.DEBUFF_PERCENT_DAMAGE)
                PlayerPercentDamage -= StoredPlayerDebuffValue;
            if (EnemyUtilityDebuff == CharData.Debuffs.DEBUFF_FLAT_DAMAGE)
                PlayerFlatDamage -= EnemyUtilityDebuffValue;
            if (StoredPlayerDebuff == CharData.Debuffs.DEBUFF_FLAT_DAMAGE)
                PlayerFlatDamage -= StoredPlayerDebuffValue;
            if (EnemyUtilityDebuff == CharData.Debuffs.DEBUFF_REFLECT_DAMAGE)
                PlayerPercentLeechReflect -= EnemyUtilityDebuffValue;
            if (StoredPlayerDebuff == CharData.Debuffs.DEBUFF_REFLECT_DAMAGE)
                PlayerPercentLeechReflect -= StoredPlayerDebuffValue;

            if (EnemyUtilityBuff == CharData.Buffs.BUFF_PERCENT_DAMAGE)
                EnemyPercentDamage += EnemyUtilityBuffValue;
            if (StoredEnemyBuff == CharData.Buffs.BUFF_PERCENT_DAMAGE)
                EnemyPercentDamage += StoredEnemyBuffValue;
            if (EnemyUtilityBuff == CharData.Buffs.BUFF_FLAT_DAMAGE)
                EnemyFlatDamage += EnemyUtilityBuffValue;
            if (StoredEnemyBuff == CharData.Buffs.BUFF_FLAT_DAMAGE)
                EnemyFlatDamage += StoredEnemyBuffValue;
            if (EnemyUtilityBuff == CharData.Buffs.BUFF_PERCENT_LEECH)
                EnemyPercentLeechReflect += EnemyUtilityBuffValue;
            if (StoredEnemyBuff == CharData.Buffs.BUFF_PERCENT_LEECH)
                EnemyPercentLeechReflect += StoredEnemyBuffValue;
            if (EnemyUtilityBuff == CharData.Buffs.BUFF_LUCKY)
                EnemyLucky = 1;
            if (StoredEnemyBuff == CharData.Buffs.BUFF_LUCKY)
                EnemyLucky = 1;
            if (PlayerUtilityDebuff == CharData.Debuffs.DEBUFF_PERCENT_DAMAGE)
                EnemyPercentDamage -= PlayerUtilityDebuffValue;
            if (StoredEnemyDebuff == CharData.Debuffs.DEBUFF_PERCENT_DAMAGE)
                EnemyPercentDamage -= StoredEnemyDebuffValue;
            if (PlayerUtilityDebuff == CharData.Debuffs.DEBUFF_FLAT_DAMAGE)
                EnemyFlatDamage -= PlayerUtilityDebuffValue;
            if (StoredEnemyDebuff == CharData.Debuffs.DEBUFF_FLAT_DAMAGE)
                EnemyFlatDamage -= StoredEnemyDebuffValue;
            if (PlayerUtilityDebuff == CharData.Debuffs.DEBUFF_REFLECT_DAMAGE)
                EnemyPercentLeechReflect -= PlayerUtilityDebuffValue;
            if (StoredEnemyDebuff == CharData.Debuffs.DEBUFF_REFLECT_DAMAGE)
                EnemyPercentLeechReflect -= StoredEnemyDebuffValue;
            if (PlayerUtilityBuffDuration > 1)
            {
                StoredPlayerBuff = PlayerUtilityBuff;
                StoredPlayerBuffValue = PlayerUtilityBuffValue;
            }
            if (PlayerUtilityDebuffDuration > 1)
            {
                StoredPlayerDebuff = PlayerUtilityDebuff;
                StoredPlayerDebuffValue = PlayerUtilityDebuffValue;
            }
            if (EnemyUtilityBuffDuration > 1)
            {
                StoredEnemyBuff = EnemyUtilityBuff;
                StoredEnemyBuffValue = EnemyUtilityBuffValue;
            }
            if (EnemyUtilityDebuffDuration > 1)
            {
                StoredEnemyDebuff = EnemyUtilityDebuff;
                StoredEnemyDebuffValue = EnemyUtilityDebuffValue;
            }

            // process player primary attack
            for (int i = 0; i < PlayerPrimaryStrikes; i++)
            {
                PlayerHitCount = i;
                PlayerHealCount = i;
                PlayerDamage[PlayerHitCount] = Random.Range(PlayerPrimaryDamageMin, PlayerPrimaryDamageMax) + PlayerFlatDamage;
                LuckyRoll = Random.Range(PlayerPrimaryDamageMin, PlayerPrimaryDamageMax) + PlayerFlatDamage;
                if (PlayerLucky == 1 && LuckyRoll > PlayerDamage[PlayerHitCount])
                    PlayerDamage[PlayerHitCount] = LuckyRoll;
                PlayerDamage[PlayerHitCount] = PlayerDamage[PlayerHitCount] * PlayerPercentDamage / 100;
                PlayerHeal[PlayerHealCount] = PlayerDamage[PlayerHitCount] * PlayerPercentLeechReflect / 100;
            }
            // process player secondary attack
            for (int j = 0; j < PlayerSecondaryStrikes; j++)
            {
                PlayerHitCount++;
                PlayerHealCount++;
                if (PlayerSecondaryDamageMin > 0)
                {
                    PlayerDamage[PlayerHitCount] = Random.Range(PlayerSecondaryDamageMin, PlayerSecondaryDamageMax) + PlayerFlatDamage;
                    LuckyRoll = Random.Range(PlayerSecondaryDamageMin, PlayerSecondaryDamageMax) + PlayerFlatDamage;
                    if (PlayerLucky == 1 && LuckyRoll > PlayerDamage[PlayerHitCount])
                        PlayerDamage[PlayerHitCount] = LuckyRoll;
                    PlayerDamage[PlayerHitCount] = PlayerDamage[PlayerHitCount] * PlayerPercentDamage / 100;
                    PlayerHeal[PlayerHealCount] = PlayerDamage[PlayerHitCount] * (PlayerPercentLeechReflect + PlayerSecondaryLeechPercent) / 100;
                    if (PlayerHeal[PlayerHealCount] != 0)
                        PlayerHealCount++;
                }
                if (PlayerSecondaryHealMin > 0)
                {
                    PlayerHeal[PlayerHealCount] = Random.Range(PlayerSecondaryHealMin, PlayerSecondaryHealMax);
                    LuckyRoll = Random.Range(PlayerSecondaryHealMin, PlayerSecondaryHealMax);
                    if (PlayerLucky == 1 && LuckyRoll > PlayerHeal[PlayerHealCount])
                        PlayerHeal[PlayerHealCount] = LuckyRoll;
                }
            }
            // process enemy primary attack
            for (int i = 0; i < EnemyPrimaryStrikes; i++)
            {
                EnemyHitCount = i;
                EnemyHealCount = i;
                EnemyDamage[EnemyHitCount] = Random.Range(EnemyPrimaryDamageMin, EnemyPrimaryDamageMax) + EnemyFlatDamage;
                LuckyRoll = Random.Range(EnemyPrimaryDamageMin, EnemyPrimaryDamageMax) + EnemyFlatDamage;
                if (EnemyLucky == 1 && LuckyRoll > EnemyDamage[EnemyHitCount])
                    EnemyDamage[EnemyHitCount] = LuckyRoll;
                EnemyDamage[EnemyHitCount] = EnemyDamage[EnemyHitCount] * EnemyPercentDamage / 100;
                EnemyHeal[EnemyHealCount] = EnemyDamage[EnemyHitCount] * EnemyPercentLeechReflect / 100;
            }
            // process Enemy secondary attack
            for (int j = 0; j < EnemySecondaryStrikes; j++)
            {
                EnemyHitCount++;
                EnemyHealCount++;
                if (EnemySecondaryDamageMin > 0)
                {
                    EnemyDamage[EnemyHitCount] = Random.Range(EnemySecondaryDamageMin, EnemySecondaryDamageMax) + EnemyFlatDamage;
                    LuckyRoll = Random.Range(EnemySecondaryDamageMin, EnemySecondaryDamageMax) + EnemyFlatDamage;
                    if (EnemyLucky == 1 && LuckyRoll > EnemyDamage[EnemyHitCount])
                        EnemyDamage[EnemyHitCount] = LuckyRoll;
                    EnemyDamage[EnemyHitCount] = EnemyDamage[EnemyHitCount] * EnemyPercentDamage / 100;
                    EnemyHeal[EnemyHealCount] = EnemyDamage[EnemyHitCount] * (EnemyPercentLeechReflect + EnemySecondaryLeechPercent) / 100;
                    if (EnemyHeal[EnemyHealCount] != 0)
                        EnemyHealCount++;
                }
                if (EnemySecondaryHealMin > 0)
                {
                    EnemyHeal[EnemyHealCount] = Random.Range(EnemySecondaryHealMin, EnemySecondaryHealMax);
                    LuckyRoll = Random.Range(EnemySecondaryHealMin, EnemySecondaryHealMax);
                    if (EnemyLucky == 1 && LuckyRoll > EnemyHeal[EnemyHealCount])
                        EnemyHeal[EnemyHealCount] = LuckyRoll;
                }
            }
            if (PlayerSecondaryBlocks > 0)
            {
                LowestEnemyDamage = EnemyDamage[0];
                for (int i = 0; i < EnemyDamage.Length - 1; i++)
                {
                    if (EnemyDamage[i] > 0 && EnemyDamage[i] < EnemyDamage[LowestEnemyDamage])
                        LowestEnemyDamage = i;
                }
                EnemyDamage[LowestEnemyDamage] = 0;
            }
            if (EnemySecondaryBlocks > 0)
            {
                LowestPlayerDamage = PlayerDamage[0];
                for (int i = 0; i < PlayerDamage.Length - 1; i++)
                {
                    if (PlayerDamage[i] > 0 && PlayerDamage[i] < PlayerDamage[LowestPlayerDamage])
                        LowestPlayerDamage = i;
                }
                PlayerDamage[LowestPlayerDamage] = 0;
            }
            //actually do damage
            foreach (int item in PlayerDamage)
            {
                PlayerFinalDamage += item;
            }
            foreach (int item in PlayerHeal)
            {
                PlayerFinalHeal += item;
            }
            foreach (int item in EnemyDamage)
            {
                EnemyFinalDamage += item;
            }
            foreach (int item in EnemyHeal)
            {
                EnemyFinalHeal += item;
            }
            PlayerHealth = PlayerHealth - EnemyFinalDamage + PlayerFinalHeal;
            EnemyHealth = EnemyHealth - PlayerFinalDamage + EnemyFinalHeal;
    }
}
