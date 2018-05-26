using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agroTrigger : MonoBehaviour {

    [SerializeField] private GenericEnemy enemy;
    [SerializeField] private Transform obstacle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemy.EnemyState = GenericEnemy.botStates.chase;
            if (obstacle != null)
            {
                gameManager.instance.ChangeBackGroundMusic(3);
                obstacle.position = new Vector3(obstacle.position.x, 0f, obstacle.position.z);
            }
        }
    }
}
