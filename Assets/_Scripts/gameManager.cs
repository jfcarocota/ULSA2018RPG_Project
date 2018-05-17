using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using audioManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using GameUtils.DataSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManager : MonoBehaviour {

    public static gameManager instance;

    private bool isPaused;   //menciona cuando el sistema esta pausado
    private bool inScene;    //menciona cuando el sistema se encuentra en una escena

    private GameData gameData;

    public Transform player;
    [SerializeField] audioClips audioClip;

    private AudioSource audBG;

    [Header("FadePanel")]

    [SerializeField] protected Image fadePanel;
    CanvasRenderer cvr;



    private void Awake()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        } else if(instance != this)
        {
            Destroy(gameObject);
        }

        audBG = GetComponent<AudioSource>();
    }
    
    private void Start()
    {
        //Booleanos globales
        isPaused = false;
        inScene = false;

        //background audio
        audBG.clip = audioClip.GetAudio(0);
        audBG.loop = true;
        audBG.Play();

        //fade panel
        cvr = fadePanel.GetComponent<CanvasRenderer>();
        fadePanel.CrossFadeAlpha(0, 1f, false);
    }

    /////////////////////////////////////////////////////AudioManagement/////////////////////////////////////////////////////
    public void ChangeBackGroundMusic(int index)
    {
        audBG.Stop();
        audBG.clip = audioClip.GetAudio(index);
        audBG.Play();
    }

    //////////////////////////////////////////////////////DataManagement//////////////////////////////////////////////////////
    public void saveGame()
    {
        DataSystem.SaveData(gameData);
    }

    public void loadGame()
    {
        gameData = DataSystem.LoadGame();
    }

    public bool existData
    {
        get { return DataSystem.FileExist; }
    }

    /////////////////////////////////////////////////////SceneManagement/////////////////////////////////////////////////////
    public void changeScene(int sceneNumber)
    {
        FadeOut();
        SceneManager.LoadScene(sceneNumber);
        FadeIn();

    }

    ////////////////////////////////////////////////////////FadePanel////////////////////////////////////////////////////////
    public void ResetAlpha()
    {
        cvr.SetAlpha(1f);
    }

    protected void FadeOut()
    {
        //cvr.SetAlpha(0f);
        fadePanel.CrossFadeAlpha(1, 0f, false);
    }

    protected void FadeIn()
    {
        fadePanel.CrossFadeAlpha(0f, 1f, false);
    }

    ////////////////////////////////////////////////////////GET-SET////////////////////////////////////////////////////////
    public bool IsPaused
    {
        get
        {
            return isPaused;
        }

        set
        {
            Time.timeScale = value ? 0 : 1;
            isPaused = value;
        }
    }

    public bool InScene
    {
        get
        {
            return inScene;
        }

        set
        {
            inScene = value;
        }
    }

    public GameData GameData
    {
        get
        {
            return gameData;
        }

        set
        {
            gameData = value;
        }
    }
}
