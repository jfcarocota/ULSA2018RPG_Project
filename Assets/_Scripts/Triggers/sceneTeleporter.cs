using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneTeleporter : MonoBehaviour {

    [SerializeField] private int sceneNumber;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.instance.ChangeBackGroundMusic(sceneNumber);
            gameManager.instance.changeScene(sceneNumber);
            
        }
    }

}