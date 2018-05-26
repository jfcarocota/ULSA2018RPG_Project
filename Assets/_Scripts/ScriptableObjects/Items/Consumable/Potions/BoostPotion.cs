using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Boost Potion", menuName = "Item/Potion/BoostPotion", order = 1)]
public class BoostPotion : Consumable {

    [SerializeField]
    private string statBoost;
    [SerializeField]
    private int boostValue;

    public string StatBoost
    {
        get
        {
            return statBoost;
        }

        set
        {
            statBoost = value;
        }
    }

    public int BoostValue
    {
        get
        {
            return boostValue;
        }

        set
        {
            boostValue = value;
        }
    }

    public override void Drink(Hero h)
    {
        throw new System.NotImplementedException();
    }
}
