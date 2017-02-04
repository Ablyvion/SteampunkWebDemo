using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharData : MonoBehaviour
{
    public enum Buffs { BUFF_NONE, BUFF_FLAT_DAMAGE, BUFF_PERCENT_DAMAGE, BUFF_PERCENT_LEECH, BUFF_LUCKY };
    public enum Debuffs { DEBUFF_NONE, DEBUFF_FLAT_DAMAGE, DEBUFF_PERCENT_DAMAGE, DEBUFF_REFLECT_DAMAGE };
    public int ID;
    public string Name;
    public string CharacterSprite;
    public string CharacterInfoImage;
    public string MovePrimary;
    public string MoveSecondary;
    public string MoveUtility;
    public int PrimaryMin;
    public int PrimaryMax;
    public int PrimaryStrikes;
    public int SecondaryMin;
    public int SecondaryMax;
    public int SecondaryHealMin;
    public int SecondaryHealMax;
    public int SecondaryStrikes;
    public int SecondaryLeechPercent;
    public int SecondaryBlocks;
    public Buffs UtilityBuff;
    public int UtilityBuffValue;
    public int UtilityBuffDuration;
    public Debuffs UtilityDebuff;
    public int UtilityDebuffValue;
    public int UtilityDebuffDuration;
    public int UtilityPassiveBuff;
    public int UtilityPassiveBuffValue;
    public int UtilityPassiveDebuff;
    public int UtilityPassiveDebuffValue;
}
