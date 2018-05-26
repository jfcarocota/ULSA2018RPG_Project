using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class GenericEnemy : Combatant {

    [Header("Enemy IA Values")]
    [SerializeField] float patrolTime;
    [SerializeField] float visionRange;
    [SerializeField] float visionDistance;
    [SerializeField] float chaseDistance;
    [SerializeField] float attackDistance;
    [SerializeField] float attackTime;

    [SerializeField] private float RespawnTime;
    private Vector3 RespawnPlace;

    [Header("Drop")]
    [SerializeField] GameObject drop;
    [SerializeField] float dropRate;

    NavMeshAgent Nav;

    public enum botStates { waiting, chase, attack, dying };
    private botStates enemyState;

    private bool isPatrolling;

    public botStates EnemyState
    {
        get
        {
            return enemyState;
        }

        set
        {
            enemyState = value;
            Axis = Vector2.zero;
            Nav.SetDestination(transform.position);
        }
    }

    protected override void Start()
    {
        base.Start();
        Nav = GetComponent<NavMeshAgent>();
        Nav.speed = Speed;
        Nav.angularSpeed = 360;
        EnemyState = botStates.waiting;
        RespawnPlace = transform.position;
    }

    private void Update()
    {
        //pausa
        if (gameManager.instance.IsPaused) return;

        //IA
        switch (EnemyState)
        {
            case botStates.waiting:
                //inicia patrullaje en caso de no haberse activado ya
                if (!isPatrolling) StartCoroutine(patrol(patrolTime));
                //revisa constamente en busqueda del objetivo a atacar
                if (Vector3.Distance(gameManager.instance.player.position, transform.position) <= visionDistance)
                {
                    if (Vector3.Angle(gameManager.instance.player.position, transform.position) <= visionRange)
                    {
                        EnemyState = botStates.chase;
                    }
                }
                break;
            case botStates.chase:
                if (!Aud.isPlaying) Aud.Play();
                if (Axis != Vector2.zero) Axis = Vector2.zero;
                if (Vector3.Distance(gameManager.instance.player.position, transform.position) <= chaseDistance)
                {
                    if (Vector3.Distance(gameManager.instance.player.position, transform.position) <= attackDistance)
                    {
                        Anim.SetFloat("speed", 0f);
                        EnemyState = botStates.attack;
                    }
                    else
                    {
                        Nav.SetDestination(gameManager.instance.player.position);
                        Anim.SetFloat("speed", 1f);
                    }
                }
                else EnemyState = botStates.waiting;
                break;
            case botStates.attack:
                Aud.Stop();
                if (!isAttacking)
                {
                    transform.LookAt(gameManager.instance.player);
                    StartCoroutine(attack(attackTime));
                }
                break;
            case botStates.dying:
                //Deja de realizar acciones
                break;
            default:
                Debug.Log("Error en update del objeto" + transform.name);
                break;
        }
    }

    //patruyaje
    IEnumerator patrol(float time)
    {
        isPatrolling = true;
        while (EnemyState == botStates.waiting)
        {
            if (gameManager.instance.IsPaused)
            {
                isPatrolling = false;
                yield break;
            }
            if (Axis == Vector2.zero)
            {
                Axis = (new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f))).normalized;
                if (!Aud.isPlaying) Aud.Play();
            }
            else
            {
                Aud.Stop();
                Axis = Vector2.zero;
            }
            Anim.SetFloat("speed", Axis.magnitude);
            yield return new WaitForSeconds(time);
        }
        isPatrolling = false;
    }

    protected override IEnumerator attack(float animationTime)
    {
        isAttacking = true;

        Anim.SetTrigger("attack");

        yield return new WaitForSeconds(animationTime / 2);
        //Desplega el damageBox
        Aud.PlayOneShot(audioAttack);
        damageBox.localPosition = new Vector3(0, 0, 0);
        damageBox.localScale = Vector3.one;


        yield return new WaitForSeconds(animationTime / 2);
        //reset damagebox
        damageBox.localScale = Vector3.zero;

        isAttacking = false;

        EnemyState = botStates.chase;
    }

    protected override void GetHurt(int inDamageValue)
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
                EnemyState = botStates.dying;
                Anim.SetTrigger("death");
                gameManager.instance.StartCoroutine(DespawnNWait(RespawnTime));
                
            }
            invulnerable = true;
            if (Health > 0) StartCoroutine(ModifierCountDown(1, (x) => invulnerable = x));
        }

    }

    private IEnumerator DespawnNWait(float RespawnTime)
    {
        //WaitForDie
        yield return new WaitForSeconds(audioDeath.length);

        //Deactive
        gameObject.SetActive(false);
        if (RespawnTime <= 0) yield break;

        yield return new WaitForSeconds(RespawnTime);
        //Reset
        transform.position = RespawnPlace;
        invulnerable = false;
        isAttacking = false;
        Anim.SetTrigger("respawn");
        EnemyState = botStates.waiting;
        Health = maxHealth;

        gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        if (Random.Range(0, 100) < dropRate) Instantiate(drop, transform.position, Quaternion.identity);
    }

}
