using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class PlayerData
{
    public int[] stats = new int[6];
    public CharacterClass playerClass;
    public Races playerRace;
    public string charName;
    public int currentSkin;
    public int currentEyes;
    public int currentHair;
    public int currentClothes;
    public int currentArmour;

    public PlayerData(Customize player)
    {
        stats = player.stats;
        playerClass = player.charClass;
        charName = player.charName;
        currentArmour = player.currentArmour;
        currentClothes = player.currentClothes;
        currentEyes = player.currentEyes;
        currentHair = player.currentHair;
        currentSkin = player.currentSkin;
        playerRace = player.charRace;
    }
}
