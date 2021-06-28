using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customize : MonoBehaviour
{
    public Texture[] armour;
    public GameObject player;
    private int currentArmour;
    private Renderer playerRenderer;
    public Material[] mat;

    public Texture[] eyes;
    private int currentEyes;

    public Texture[] mouth;
    private int currentMouth;

    public Texture[] hair;
    private int currentHair;

    public Texture[] skin;
    private int currentSkin;

    private void Start()
    {
        playerRenderer = player.GetComponent<Renderer>();
        mat = playerRenderer.materials;
    }
    private void Update()
    {
        mat[2].mainTexture = armour[currentArmour];
        mat[1].mainTexture = eyes[currentEyes];
        mat[3].mainTexture = mouth[currentMouth];
        mat[4].mainTexture = hair[currentHair];
        mat[5].mainTexture = skin[currentSkin];
    }

    public void SwitchArmour()
    {
        if (currentArmour == armour.Length - 1)
        {
            currentArmour = 0;
        }
        else
        {
            currentArmour++;
        }
    }
    public void SwitchEyes()
    {
        if (currentEyes == eyes.Length -1)
        {
            currentEyes = 0;
        }
        else
        {
            currentEyes++;
        }
    }
    public void SwitchMouth()
    {
        if(currentMouth == mouth.Length - 1)
        {
            currentMouth = 0;
        }
        else
        {
            currentMouth++;
        }
    }
    public void SwitchHair()
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
    public void SwitchSkin()
    {
        if(currentSkin == skin.Length - 1)
        {
            currentSkin = 0;
        }
        else
        {
            currentSkin++;
        }
    }
}
