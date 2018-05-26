using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combatant : Actor {

    [Header("Audios")]
    [SerializeField] protected AudioClip audioAttack;
    [SerializeField] protected AudioClip audioDamage;
    [SerializeField] protected AudioClip audioDeath;
    [SerializeField] protected AudioClip audioHit;
    [SerializeField] protected AudioClip audioWalk; 

    [Header("Stats")]
    [SerializeField] protected int maxHealth;
    [SerializeField] public int damage;
    [SerializeField] protected int defense;
    private int health;

    [Header("DamageBox")]
    [Tooltip("Its required a pivot with the boxTrigger inside it")]
    [SerializeField] protected Transform damageBox;
    protected Vector3 damageBoxStartPosition;
    protected Vector3 damageBoxMaxScale;

    protected bool isAttacking;

    protected bool grougi;
    protected bool invulnerable;

    protected virtual int Health
    {
        get
        {
            return health;
        }

        set
        {
            health = value;
        }
    }

    // Use this for initialization
    protected override void Start () {
        base.Start();
        Health = maxHealth;

        damageBoxStartPosition = damageBox.position;
        damageBoxMaxScale = damageBox.localScale;
        damageBox.localScale = Vector3.zero;
        //StartCoroutine(ShowInvulnerability());
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DamageBox"))
        {
            GetHurt(other.transform.parent.parent.GetComponent<Combatant>().damage);    
        }
    }

    protected virtual void GetHurt(int inDamageValue)
    {
        if (!invulnerable)
        {
            Health -= (inDamageValue - defense);
            if (Health > 0)
            {
                Aud.PlayOneShot(audioDamage);
                Anim.SetTrigger("damage");
            }
            else
            {
                Aud.PlayOneShot(audioDeath);
                Anim.SetTrigger("death");
            }
            invulnerable = true;
            if(Health > 0) StartCoroutine(ModifierCountDown(1, (x) => invulnerable = x));
        }
        
    }

    //Se inicializa con
    //StartCoroutine(ModifierCountDown(time, (x) => modifier = x));
    protected IEnumerator ModifierCountDown(float time, System.Action<bool> modifier)
    {
        yield return new WaitForSeconds(time);
        modifier(false);
    }

    protected virtual IEnumerator attack(float animationTime)
    {
        //Anim.SetTrigger("attack");

        Aud.PlayOneShot(audioAttack);
        yield return new WaitForSeconds(animationTime / 2);
        
        //Desplega el damageBox
        damageBox.localPosition = new Vector3(0, 0, 0);
        damageBox.localScale = Vector3.one;


        yield return new WaitForSeconds(animationTime / 2);
        //reset damagebox
        damageBox.localScale = Vector3.zero;
    }

    private IEnumerator ShowInvulnerability()
    {
        Color initialColor; //= rend.material.GetColor("Specular");
        while(true){
            if (invulnerable)
            {
                //if(initialColor == rend.material.GetColor("Specular")) rend.material.SetColor("Specular", Color.white);
                //else rend.material.SetColor("Specular", initialColor);
                //cambiar color a blanco
                yield return new WaitForSeconds(0.5f);
            }
            /*else{
             rend.material.SetColor("Specular", initialColor);
            }*/
        }
        
    }
}
