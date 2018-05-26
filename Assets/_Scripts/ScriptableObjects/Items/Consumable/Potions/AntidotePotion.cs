using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Antidote Potion", menuName = "Item/Potion/AntidotePotion", order = 1)]
public class AntidotePotion : Consumable {

    [SerializeField]
    private string malusToClean;

    public string MalusToClean
    {
        get
        {
            return malusToClean;
        }

        set
        {
            malusToClean = value;
        }
    }

    public override void Drink(Hero h)
    {
        throw new System.NotImplementedException();
    }
}
