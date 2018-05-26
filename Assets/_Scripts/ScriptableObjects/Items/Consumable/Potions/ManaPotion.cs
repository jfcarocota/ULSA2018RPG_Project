using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Mana Potion", menuName = "Item/Potion/ManaPotion", order = 1)]
public class ManaPotion : Consumable {

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
        throw new System.NotImplementedException();
    }
}
