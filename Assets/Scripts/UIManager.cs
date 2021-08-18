using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{


    public Sprite[] liveImages;
    public Image displayLiveImage;
    public int Score;
    public Text scoreText;
    public GameObject gameOverScrn;

    public void UpdateLIves(int currentLives)
    {
        displayLiveImage.sprite = liveImages[currentLives];
    }
    public void updateScore()
    {
        Score++;
        scoreText.text = "Score:  " + Score;
    }
     
    public void showGameoverScreen()
    {
        gameOverScrn.SetActive(true);
    }
    public void hideGameoverScreen()
    {
        gameOverScrn.SetActive(false);
    }
}
