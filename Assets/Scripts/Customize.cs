using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Customize : MonoBehaviour
{
    #region Material Customization Variables
    public GameObject player;
    private Renderer playerRenderer;
    public Material[] mat;

    public Texture[] armour;
    public int currentArmour;

    public Texture[] eyes;
    public int currentEyes;

    public Texture[] mouth;
    public int currentMouth;

    public Texture[] hair;
    public int currentHair;

    public Texture[] skin;
    public int currentSkin;


    public Texture[] clothes;
    public int currentClothes;
    #endregion
    #region Name and Stats
    [Header("Character Name")]
    public string charName = "Prisoner";

    public TMP_InputField charNameInput;
    public TMP_Text usersName;
    public TMP_Text classText;
    public TMP_Text strStat;
    public TMP_Text dexStat;
    public TMP_Text conStat;
    public TMP_Text intStat;
    public TMP_Text wisStat;
    public TMP_Text chaStat;
    public TMP_Text raceText;
    public TMP_Text rBonusText;

    //stats
    public string[] statArray = new string[6];
    public int[] stats = new int[6];
    public int[] tempStats = new int[6];
    public int points = 10;
    public CharacterClass charClass = CharacterClass.Fighter;
    public Races charRace = Races.Human;
    public string[] selectedClass = new string[3];
    public int selectedIndex = 0;
    public int raceIndex = 0; //YIKES that sounds worse than it is
    public RaceBonus newBonus = RaceBonus.Charm;
    #endregion
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        playerRenderer = player.GetComponent<Renderer>();
        mat = playerRenderer.materials;
        statArray = new string[] { "Strength", "Dexterity", "Constitution", "Intelligence", "Wisdom", "Charisma" };
        selectedClass = new string[] { "Fighter", "Mage", "Rogue" };
        Load();
        usersName.text = charName.ToString();
    }
    private void Update()
    {
        mat[2].mainTexture = eyes[currentEyes];
        mat[1].mainTexture = skin[currentSkin];
        mat[3].mainTexture = mouth[currentMouth];
        mat[4].mainTexture = hair[currentHair];
        mat[5].mainTexture = armour[currentArmour];
        mat[6].mainTexture = clothes[currentClothes];
        strStat.text ="Str: " + (stats[0] + tempStats[0]).ToString();
        dexStat.text ="Dex: " + (stats[1] + tempStats[1]).ToString();
        conStat.text = "Con: " +(stats[2] + tempStats[2]).ToString();
        intStat.text = "Int: " + (stats[3] + tempStats[3]).ToString();
        wisStat.text = "Wis: " +(stats[4] + tempStats[4]).ToString();
        chaStat.text = "Cha: " +(stats[5] + tempStats[5]).ToString();
        raceText.text = "Race: " + charRace.ToString() ;
        rBonusText.text = "Racial Bonus: " + newBonus.ToString();
        //these materials will take the type (clothes, eyes, etc) and use the currentX int to figure out which one
    }
    public void Save()
    {
        Debug.Log("Saving");
        SaveLoad.SavePlayer(this);
        SceneManager.LoadScene(1);
        //cant figure out keeping the character across scenes AHHHHH
        //this will have to do for now
    }
    #region Change Materials
    public void ClothesUp()
    {
        if (currentClothes == clothes.Length - 1)
        {
            currentClothes = 0;
        }
        else
        {
            currentClothes++;
        }
    }
    public void ClothesDown()
    {
        if (currentClothes == 0)
        {
            currentClothes = clothes.Length - 1;
        }
        else
        {
            currentClothes--;
        }
    }
    public void ArmourPlus()
    {
        if (currentArmour == armour.Length - 1)
        {
            currentArmour = 0;
        }
        else
        {
            currentArmour++;
            Debug.Log("Clicki");
        }
    }
    public void ArmourMinus()
    {
        if (currentArmour == 0)
        {
            currentArmour = (armour.Length - 1);
        }
        else
        {
            currentArmour--;
        }
    }
    public void EyesPlus()
    {
        if (currentEyes == eyes.Length - 1)
        {
            currentEyes = 0;
        }
        else
        {
            currentEyes++;
        }
    }
    public void EyesMinus()
    {
        if (currentEyes == 0)
        {
            currentEyes = eyes.Length - 1;
        }
        else
        {
            currentEyes--;
        }
    }
    public void MouthUp()
    {
        if (currentMouth == mouth.Length - 1)
        {
            currentMouth = 0;
        }
        else
        {
            currentMouth++;
        }
    }
    public void MouthDown()
    {
        if (currentMouth == 0)
        {
            currentMouth = mouth.Length - 1;
        }
        else
        {
            currentMouth--;
        }
    }
    public void HairPlus()
    {
        if (currentHair == hair.Length - 1)
        {
            currentHair = 0;
        }
        else
        {
            currentHair++;
        }
    }
    public void HairMinus()
    {
        if (currentHair == 0)
        {
            currentHair = hair.Length - 1;
        }
        else
        {
            currentHair--;
        }
    }
    public void SkinPlus()
    {
        if (currentSkin == skin.Length - 1)
        {
            currentSkin = 0;
        }
        else
        {
            currentSkin++;
        }
    }
    public void SkinMinus()
    {
        if (currentSkin == 0)
        {
            currentSkin = (skin.Length - 1);
        }
        else
        {
            currentSkin--;
        }
    }
    public void ResetCustom()
    {
        currentArmour = 0;
        currentClothes = 0;
        currentEyes = 0;
        currentHair = 0;
        currentSkin = 0;
    }
    public void Randomize()
    {
        currentArmour = Random.Range(0, armour.Length - 1);
        currentClothes = Random.Range(0, clothes.Length - 1);
        currentEyes = Random.Range(0, eyes.Length - 1);
        currentHair = Random.Range(0, hair.Length - 1);
        currentSkin = Random.Range(0, skin.Length - 1);
    }
    public void ClassDown()
    {
        selectedIndex--;
        if (selectedIndex < 0)
        {
            selectedIndex = selectedClass.Length - 1;
        }
        ChooseClass(selectedIndex);
        classText.text = charClass.ToString();
    }
    public void ClassUp()
    {
        selectedIndex++;
        if (selectedIndex > selectedClass.Length - 1)
        {
            selectedIndex = 0;
        }
        ChooseClass(selectedIndex);
        classText.text = charClass.ToString();
    }

    public void StrUp()
    {
        if (points > 0)
        {
            tempStats[0]++;
            points--;
        }
    }
    public void StrDown()
    {
        if(points < 10 && tempStats[0] > 0)
        {
            points++;
            tempStats[0]--;
        }
    }
    public void DexUp()
    {
        if (points > 0)
        {
            tempStats[1]++;
            points--;
        }
    }
    public void DexDown()
    {
        if (points < 10 && tempStats[1] > 0)
        {
            points++;
            tempStats[1]--;
        }
    }
    public void ConUp()
    {
        if (points > 0)
        {
            tempStats[2]++;
            points--;
        }
    }
    public void ConDown()
    {
        if (points < 10 && tempStats[2] > 0)
        {
            points++;
            tempStats[2]--;
        }
    }
    public void intUp()
    {
        if (points > 0)
        {
            tempStats[3]++;
            points--;
        }
    }
    public void IntDown()
    {
        if (points < 10 && tempStats[3] > 0)
        {
            points++;
            tempStats[3]--;
        }
    }
    public void WisUp()
    {
        if (points > 0)
        {
            tempStats[4]++;
            points--;
        }
    }
    public void WisDown()
    {
        if (points < 10 && tempStats[4] > 0)
        {
            points++;
            tempStats[4]--;
        }
    }
    public void ChaUp()
    {
        if (points > 0)
        {
            tempStats[5]++;
            points--;
        }
    }
    public void ChaDown()
    {
        if (points < 10 && tempStats[5] > 0)
        {
            points++;
            tempStats[5]--;
        }
    }

    void ChooseClass(int className)
    {
        switch (className)
        {
            case 0:
                stats[0] = 13;
                stats[1] = 12;
                stats[2] = 10;
                stats[3] = 10;
                stats[4] = 10;
                stats[5] = 11;
                charClass = CharacterClass.Fighter;
                break;
            case 1:
                stats[0] = 8;
                stats[1] = 10;
                stats[2] = 8;
                stats[3] = 14;
                stats[4] = 15;
                stats[5] = 11;
                charClass = CharacterClass.Mage;
                break;
            case 2:
                stats[0] = 8;
                stats[1] = 16;
                stats[2] = 10;
                stats[3] = 10;
                stats[4] = 10;
                stats[5] = 12;
                charClass = CharacterClass.Rogue;
                break;
        }
    }
    public void Load()
    {
        PlayerData data = SaveLoad.LoadPlayer();
        stats = data.stats;
        charClass = data.playerClass;
        charRace = data.playerRace;
        charName = data.charName;
        currentArmour = data.currentArmour;
        currentClothes = data.currentClothes;
        currentEyes = data.currentEyes;
        currentHair = data.currentHair;
        currentSkin = data.currentSkin;
    }
    public void ChangeName()
    {
        charName = usersName.text;
    }
    public void ChangeRace()
    {
        raceIndex++;
        if (raceIndex > 2)
        {
            raceIndex = 0;
        }
        ChooseRace(raceIndex);
    }
    void ChooseRace(int raceName)
    {
        switch (raceName)
        {
            case 0:
                charRace = Races.Human;
                newBonus = RaceBonus.Charm;
                break;
            case 1:
                charRace = Races.Elf;
                newBonus = RaceBonus.ArcheryProficiency;
                break;
            case 2:
                charRace = Races.Dwarf;
                newBonus = RaceBonus.IronStomach;
                break;
        }
    }
    
    }
#endregion
#region Character Class
public enum CharacterClass
    {
        Fighter,
        Mage,
        Rogue
    }

#endregion
#region Race And Bonuses
public enum Races
{
    Human, 
    Elf,
    Dwarf
}
public enum RaceBonus
{
    Charm, 
    ArcheryProficiency,
    IronStomach
}
#endregion
