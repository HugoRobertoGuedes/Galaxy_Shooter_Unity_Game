using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour
{
    #region Publics
    // Game Over
    public bool gameOver = true;

    // Player
    public GameObject player;

    // Display
    public UiManager uiManager;
    #endregion

    #region Private
    // Game IA
    private Game_IA game_IA;
    #endregion
    void Start()
    {
        uiManager = GameObject.Find("Game_UI").GetComponent<UiManager>();
        game_IA = GameObject.Find("Game_IA").GetComponent<Game_IA>();
    }

    void Update()
    {
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Start Game");
                Instantiate(player, Vector3.zero, Quaternion.identity);
                gameOver = false;
                game_IA.generateEnemies = true;
                game_IA.generatePowerUps = true;
                game_IA.StartGenerate();
                uiManager.HideTitleScreen();
            }
        }
    }
}
