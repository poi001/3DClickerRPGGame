using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("GameManager").AddComponent<GameManager>();
            }
            return _instance;
        }
    }

    //플레이어
    public Player Player
    {
        get { return _player; }
        set { _player = value; }
    }
    private Player _player;

    //오디오 매니저
    public AudioManager Audio
    {
        get { return _audio; }
        set { _audio = value; }
    }
    private AudioManager _audio;


    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (_instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
}
