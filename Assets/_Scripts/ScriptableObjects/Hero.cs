using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameUtils.CombatantSystem;

[CreateAssetMenu(fileName = "Hero", menuName = "Combatant/Hero", order = 1)]
public class Hero : CombatantStats
{
    //name
    [SerializeField]
    private string playerName;

    //position
    [SerializeField]
    private int actualScene;
    [SerializeField]
    private Vector3 actualPosition;

    //experience
    [SerializeField]
    private int currentExperience;
    [SerializeField]
    private int experienceToNextLevel;

    //sprite
    [SerializeField]
    private Sprite heroSprite;

    public void InitData(GameData gd)
    {
        //name
        PlayerName = gd.PlayerName;

        //position
        ActualScene = gd.ActualScene;
        float actualPosX = gd.ActualPositionX;
        float actualPosY = gd.ActualPositionY;
        float actualPosZ = gd.ActualPositionZ;
        ActualPosition = new Vector3(actualPosX, actualPosY, actualPosZ);

        //OnGUIData
        MaxHealth = gd.MaxHealth;
        ActualHealth = gd.ActualHealth;
        MaxMana = gd.MaxMana;
        ActualMana = gd.ActualMana;

        //Level & Experience
        Level = gd.Level;
        CurrentExperience = gd.CurrentExperience;
        ExperienceToNextLevel = gd.ExperienceToNextLevel;

        //Stats
        Streight = gd.Streight;
        Dextery = gd.Dextery;
        Agility = gd.Agility;
        Inteligence = gd.Inteligence;
        Luck = gd.Luck;
        Vitality = gd.Vitality;
    }

    public string PlayerName
    {
        get
        {
            return playerName;
        }

        set
        {
            playerName = value;
        }
    }

    public int ActualScene
    {
        get
        {
            return actualScene;
        }

        set
        {
            actualScene = value;
        }
    }

    public int CurrentExperience
    {
        get
        {
            return currentExperience;
        }

        set
        {
            currentExperience = value;
        }
    }

    public int ExperienceToNextLevel
    {
        get
        {
            return experienceToNextLevel;
        }

        set
        {
            experienceToNextLevel = value;
        }
    }

    public Sprite HeroSprite
    {
        get
        {
            return heroSprite;
        }

        set
        {
            heroSprite = value;
        }
    }

    public Vector3 ActualPosition
    {
        get
        {
            return actualPosition;
        }

        set
        {
            actualPosition = value;
        }
    }
}

