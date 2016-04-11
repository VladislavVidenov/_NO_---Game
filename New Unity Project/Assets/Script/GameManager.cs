using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{

    //Singleton for game manager.
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindGameObjectWithTag("Managers").AddComponent<GameManager>();
                _instance.tag = "GameManager";
            }
            return _instance;
        }
    }

    private GameState current_state;
    public GameState Current_State
    {
        get { return current_state; }
        set { current_state = value; }
    }

    public SceneManager sceneManger;

    private GameObject _player;
    public GameObject Player
    {
        get
        {
            if (_player == null)
                _player = GameObject.FindGameObjectWithTag("player");
            return _player;
        }
    }
    public int keysCollected = 0;

    void Awake()
    {
        if (Application.loadedLevel != 0) //dirty way, 
        {
            current_state = GameState.InGame;
            FindRefferenceToGameObject();
        }
    }

     public void ResetKeysCollected()
    {
        keysCollected = 0;
    }
    void OnLevelWasLoaded()
    {
        if (current_state == GameState.InGame)
        {
            FindRefferenceToGameObject();
        }
    }

    void FindRefferenceToGameObject()
    {
        sceneManger = FindObjectOfType<SceneManager>();
    }





}
