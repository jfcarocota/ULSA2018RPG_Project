using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour {

    [SerializeField]
    Consumable Consumable;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            potion.Drink(gameManager.instance.player.GetComponent<Player>().HeroStats);
            gameManager.instance.player.GetComponent<Player>().ResetVariantValues();
            Destroy(gameObject);
        }
    }

    public Consumable potion
    {
        get
        {
            return Consumable;
        }

        set
        {
            Consumable = value;
        }
    }
}
