using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public AudioClip mainMenu;
    public AudioClip upperWorld;
    public AudioClip lowerWorld;
    private bool backgroudIsPlaying;
    public static GameManager instance = null;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked;
        AudioManager.instance.PlayBackground(mainMenu);
    }
	
	void Update ()
    {
        if ((SceneManager.GetActiveScene().buildIndex % 2) == 1 && (backgroudIsPlaying == false))
        {
            AudioManager.instance.PlayBackground(lowerWorld);
            backgroudIsPlaying = true;
        }
        if ((SceneManager.GetActiveScene().buildIndex % 2) == 0 && (backgroudIsPlaying == false) && (SceneManager.GetActiveScene().buildIndex != 0))
        {
            AudioManager.instance.PlayBackground(upperWorld);
            backgroudIsPlaying = true;
        }

    }

    public void changeBackgroundMusic()
    {
        backgroudIsPlaying = false;
    }
}
