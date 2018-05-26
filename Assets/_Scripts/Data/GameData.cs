using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class GameData {

    //name
    [SerializeField]
    private string playerName;

    //position
    [SerializeField]
    private int actualScene;
    [SerializeField]
    private float actualPositionX;
    [SerializeField]
    private float actualPositionY;
    [SerializeField]
    private float actualPositionZ;

    //OnGUIData
    [SerializeField]
    private int maxHealth;
    [SerializeField]
    private int actualHealth;
    [SerializeField]
    private int maxMana;
    [SerializeField]
    private int actualMana;

    //Level & Experience
    [SerializeField]
    private int level;
    [SerializeField]
    private int currentExperience;
    [SerializeField]
    private int experienceToNextLevel;

    //stats
    [SerializeField]
    private int streight;
    [SerializeField]
    private int dextery;
    [SerializeField]
    private int agility;
    [SerializeField]
    private int inteligence;
    [SerializeField]
    private int luck;
    [SerializeField]
    private int vitality;

    public GameData(string playerName, int actualScene, Vector3 actualPosition, int maxHealth, int actualHealth,
        int maxMana, int actualMana, int level,  int currentExperience, int experienceToNextLevel,
        int streight, int dextery, int agility, int inteligence, int luck, int vitality)
    {
        //name
        this.playerName = playerName;

        //position
        this.actualScene = actualScene;
        this.actualPositionX = actualPosition.x;
        this.actualPositionY = actualPosition.y;
        this.actualPositionZ = actualPosition.z;

        //OnGUIData
        this.maxHealth = maxHealth;
        this.actualHealth = actualHealth;
        this.maxMana = maxMana;
        this.actualMana = actualMana;

        //level & experience
        this.level = level;
        this.CurrentExperience = currentExperience;
        this.ExperienceToNextLevel = experienceToNextLevel;

        //Stats
        this.streight = streight;
        this.dextery = dextery;
        this.agility = agility;
        this.inteligence = inteligence;
        this.luck = luck;
        this.vitality = vitality;
    }

    public GameData(Hero h)
    {
        //name
        this.PlayerName = h.PlayerName;

        //position
        this.ActualScene = h.ActualScene;
        this.ActualPositionX = h.ActualPosition.x;
        this.ActualPositionY = h.ActualPosition.y;
        this.ActualPositionZ = h.ActualPosition.z;

        //OnGUIData
        this.MaxHealth = h.MaxHealth;
        this.ActualHealth = h.ActualHealth;
        this.MaxMana = h.MaxMana;
        this.ActualMana = h.ActualMana;

        //level & experience
        this.Level = h.Level;
        this.CurrentExperience = h.CurrentExperience;
        this.ExperienceToNextLevel = h.ExperienceToNextLevel;

        //Stats
        this.Streight = h.Streight;
        this.Dextery = h.Dextery;
        this.Agility = h.Agility;
        this.Inteligence = h.Inteligence;
        this.Luck = h.Luck;
        this.Vitality = h.Vitality;
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

    public float ActualPositionX
    {
        get
        {
            return actualPositionX;
        }

        set
        {
            actualPositionX = value;
        }
    }

    public float ActualPositionY
    {
        get
        {
            return actualPositionY;
        }

        set
        {
            actualPositionY = value;
        }
    }

    public float ActualPositionZ
    {
        get
        {
            return actualPositionZ;
        }

        set
        {
            actualPositionZ = value;
        }
    }

    public int MaxHealth
    {
        get
        {
            return maxHealth;
        }

        set
        {
            maxHealth = value;
        }
    }

    public int ActualHealth
    {
        get
        {
            return actualHealth;
        }

        set
        {
            actualHealth = value;
        }
    }

    public int MaxMana
    {
        get
        {
            return maxMana;
        }

        set
        {
            maxMana = value;
        }
    }

    public int ActualMana
    {
        get
        {
            return actualMana;
        }

        set
        {
            actualMana = value;
        }
    }

    public int Level
    {
        get
        {
            return level;
        }

        set
        {
            level = value;
        }
    }

    public int Streight
    {
        get
        {
            return streight;
        }

        set
        {
            streight = value;
        }
    }

    public int Dextery
    {
        get
        {
            return dextery;
        }

        set
        {
            dextery = value;
        }
    }

    public int Agility
    {
        get
        {
            return agility;
        }

        set
        {
            agility = value;
        }
    }

    public int Inteligence
    {
        get
        {
            return inteligence;
        }

        set
        {
            inteligence = value;
        }
    }

    public int Luck
    {
        get
        {
            return luck;
        }

        set
        {
            luck = value;
        }
    }

    public int Vitality
    {
        get
        {
            return vitality;
        }

        set
        {
            vitality = value;
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
}
