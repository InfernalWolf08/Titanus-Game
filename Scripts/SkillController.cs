using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillController : MonoBehaviour
{
    [Header("Stat Data")]
    public Image[] statKnobs;
    public string stat;
    public int statNum;
    public Color activeColor;

    [Header("Player Data")]
    public MenuController mainCont;

    void Start()
    {
        if (stat=="attack")
        {
            statNum = mainCont.attack;
        } else if (stat=="defence") {
            statNum = mainCont.defence;
        } else if (stat=="speed") {
            statNum = mainCont.speed;
            mainCont.player.speed += statNum;
            mainCont.player.defaultSpeed += statNum;
        } else if (stat=="crafting") {
            statNum = mainCont.crafting;
        } else if (stat=="effeciency") {
            statNum = mainCont.effeciency;
        }

        for (int i=1;i<=statNum;i++)
        {
            statKnobs[i].color = activeColor;
        }
    }

    public void increaseStat()
    {
        // Increase stat visually
        statKnobs[statNum].color = activeColor;
        statNum += 1;

        // Affect the stat
        if (stat=="attack")
        {

        } else if (stat=="defence") {

        } else if (stat=="speed") {
            mainCont.player.speed += 1;
            mainCont.player.defaultSpeed += 1;
        } else if (stat=="crafting") {
            
        } else if (stat=="effeciency") {
            mainCont.effeciency += 1;
        }
    }
}