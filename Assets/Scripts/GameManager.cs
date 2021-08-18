using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool GameOver = true;
    public GameObject player;
    public UIManager Uiobject;

    void Start()
    {
        Uiobject = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //gameover screen to be inactive and player has to respawn
                Instantiate(player, Vector3.zero, Quaternion.identity);
                GameOver = false;
                Uiobject.ShowGameOverScreen();
            }
        }
        else
        {
            Uiobject.HideGameOverScreen();
        }
    }
}
