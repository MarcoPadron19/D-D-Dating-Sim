using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    // "static" means that there can only be one of these in the scene. So if anything
    // calls for gm, it will access the GameManager. And that's fine, because you only
    // want one of those.
    public static GameManager gameManagerInstance = null;
    [Tooltip("If not set, the player will default to the gameObject tagged as Player.")]
    public GameObject player;

    public enum gameStates { Playing, Death, GameOver, BeatLevel };
    public gameStates gameState = gameStates.Playing;

    public GameObject mainCanvas;
    public Text heliumPickedUp;
    public Text starHasThisMuch;
    public GameObject gameOverCanvas;
    public Text gameOverScoreDisplay;

    public GameObject canvas;

    public AudioSource backgroundMusic;
    public AudioClip gameOverSFX;

    private Transform playerStart;



    void Start()
    {
        // If there is no instance of the game manager, this is that instance
        // if there already is one, and it isn't this, kill it. (this is 
        // standard boilerplate game manager stuff. You should always have a
        // bit like this to make sure you don't end up with multiples
        if (gameManagerInstance == null)
            gameManagerInstance = gameObject.GetComponent<GameManager>();
        else if (gameManagerInstance != this)
            Destroy(gameObject);

        // Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        // This sets the player. I've also tagged the Player as "Player". You 
        // can see this in the Inspector. Tags are useful for finding things.
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }


        mainCanvas = GameObject.FindGameObjectWithTag("Main_Menu_canvas");

        // make other UI inactive
        // gameOverCanvas.SetActive(false);
    }

    void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Lounge_Room"))
        {
            mainCanvas = GameObject.FindGameObjectWithTag("Status");
            heliumPickedUp = GameObject.FindGameObjectWithTag("H_PickedUp").GetComponent<Text>();
            starHasThisMuch = GameObject.FindGameObjectWithTag("S_PickedUp").GetComponent<Text>();
            // setup score display
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Title_Screen"))
        {
            mainCanvas = GameObject.FindGameObjectWithTag("Main_Menu_canvas");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("End_Screen"))
        {
            mainCanvas = GameObject.FindGameObjectWithTag("Death_Canvas");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        /*     switch (gameState)
             {
                 case gameStates.Playing:
                     if (playerHealth.isAlive == false)
                     {
                         // update gameState
                         gameState = gameStates.Death;

                         // set the end game score
                         gameOverScoreDisplay.text = mainScoreDisplay.text;

                         // switch which GUI is showing      
                         mainCanvas.SetActive(false);
                         gameOverCanvas.SetActive(true);
                     }
                     else if (score >= beatLevelScore)
                     {
                         // update gameState
                         gameState = gameStates.BeatLevel;

                         // hide the player so game doesn't continue playing
                         player.SetActive(false);

                         // switch which GUI is showing          
                         mainCanvas.SetActive(false);
                         beatLevelCanvas.SetActive(true);
                     }

                     break;
                 case gameStates.Death:
                     backgroundMusic.volume -= 0.01f;
                     if (backgroundMusic.volume <= 0.0f)
                     {
                         AudioSource.PlayClipAtPoint(gameOverSFX, gameObject.transform.position);

                         gameState = gameStates.GameOver;
                     }
                     break;
                 case gameStates.BeatLevel:
                     backgroundMusic.volume -= 0.01f;
                     if (backgroundMusic.volume <= 0.0f)
                     {
       //                  AudioSource.PlayClipAtPoint(beatLevelSFX, gameObject.transform.position);

                         gameState = gameStates.GameOver;
                     }
                     break;
                 case gameStates.GameOver:
                     // nothing
                     break;
             }
             */ //We don't have different game states just yet...
    }
}