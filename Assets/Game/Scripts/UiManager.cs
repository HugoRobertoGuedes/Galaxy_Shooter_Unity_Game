using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    #region Seralized
    // Sprites Lives
    [SerializeField]
    private List<Sprite> lives;

    // Image Display Lives
    [SerializeField]
    private Image livesImageDisplay;

    // text Score
    [SerializeField]
    private Text scoreDisplay;

    // Title Screen
    [SerializeField]
    private GameObject titleScreen;

    // Text Triple Shoot
    [SerializeField]
    private Text tripleShotDisplay;

    // Message Start Game
    [SerializeField]
    private Text messageNewGame;
    #endregion

    #region Privates
    private int totalscore = 0;
    #endregion

    public void UpdateLive(int currentLives)
    {
        Debug.Log(currentLives);
        livesImageDisplay.sprite = lives[currentLives];
    }

    public void UpdateScore(int score)
    {
        totalscore += score;
        scoreDisplay.text = "Score: " + totalscore;
    }

    public void UpdateTripleShoot(int shots)
    {
        tripleShotDisplay.text = "Triple Shoot:" + shots;
    }

    public void ShowTitleScreen()
    {
        titleScreen.SetActive(true);
        messageNewGame.enabled = true;
    }

    public void HideTitleScreen()
    {
        titleScreen.SetActive(false);
        messageNewGame.enabled = false;
    }
}
