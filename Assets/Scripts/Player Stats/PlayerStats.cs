using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public Stat Str;
    public Stat End;
    public Stat Con;
    public Stat Wis;
    public Stat Cha;
    public Stat Agi;

    public Text StrText;
    public Text EndText;
    public Text ConText; //huhu
    public Text WisText;
    public Text ChaTex;
    public Text AgiText;

    public Text damageText;
    public Text speedText;
    public Text staminaText;
    public Text healthText;
    public int health;
    public int speed;
    public int stamina;
    public int damage;

    private void Start()
    {
        Str.baseValue = 3;
        End.baseValue = 3;
        Con.baseValue = 3;
        Wis.baseValue = 3;
        Cha.baseValue = 3;
        Agi.baseValue = 3;
    }
    private void Update()
    {
        health = Con.baseValue * 10;
        speed = Agi.baseValue * 10;
        stamina = End.baseValue * 20;
        damage = Str.baseValue * 5;
        #region SecondaryText
        healthText.text ="Health: "+ health.ToString();
        speedText.text = speed.ToString() + " meters";
        damageText.text = damage.ToString() + " DPS";
        staminaText.text = "Stamina" + stamina.ToString();
        #endregion

        #region StatTexts
        StrText.text ="Strength: " +  Str.baseValue.ToString();
        EndText.text = "Endurance: " + End.baseValue.ToString();
        ConText.text = "Constitution: " + Con.baseValue.ToString();
        WisText.text = "Wisdom: " + Wis.baseValue.ToString();
        ChaTex.text = "Charisma: " + Cha.baseValue.ToString();
        AgiText.text = "Agility: " + Agi.baseValue.ToString();
        #endregion
    }
    #region Add and Remove
    public void StrAdd()
    {
        Str.baseValue++;
    }
    public void StrRemove()
    {
        Str.baseValue--;
    }
    public void AgiAdd()
    {
        Agi.baseValue++;
    }
    public void AgiRemove()
    {
        Agi.baseValue--;
    }
    public void EndAdd()
    {
        End.baseValue++;
    }
    public void EndRemove()
    {
        End.baseValue--;
    }
    public void ConAdd()
    {
        Con.baseValue++;
    }
    public void ConRemove()
    {
        Con.baseValue--;
    }
    public void WisAdd()
    {
        Wis.baseValue++;
    }
    public void WisRemove()
    {
        Wis.baseValue--;
    }
    public void ChaAdd()
    {
        Cha.baseValue++;
    }
    public void ChaRemove()
    {
        Cha.baseValue--;
    }
    #endregion
}