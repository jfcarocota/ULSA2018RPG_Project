using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameUtils
{
    namespace CombatantSystem
    {
        public abstract class CombatantStats : ScriptableObject
        {
            [SerializeField]
            private int maxHealth;
            [SerializeField]
            private int actualHealth;
            [SerializeField]
            private int maxMana;
            [SerializeField]
            private int actualMana;

            //stats
            [SerializeField]
            private int level;
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
        }
    }
}
