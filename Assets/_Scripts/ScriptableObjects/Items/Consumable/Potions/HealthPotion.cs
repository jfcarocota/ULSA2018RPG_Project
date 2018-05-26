using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Health Potion", menuName = "Item/Consumable/Potion/HealthPotion", order = 1)]
public class HealthPotion : Consumable {

    [SerializeField]
    int recoverValue;

    public int RecoverValue
    {
        get
        {
            return recoverValue;
        }

        set
        {
            recoverValue = value;
        }
    }

    public override void Drink(Hero h)
    {
        h.ActualHealth = ((effectValue + h.ActualHealth) <= h.MaxHealth) ? effectValue + h.ActualHealth : h.MaxHealth;
    }
}
