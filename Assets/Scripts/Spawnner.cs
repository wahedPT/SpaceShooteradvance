using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject[] powerUps;
    private GameManager gamemanager;

    private void Start()
    {
        EnemySpawn();
        PowerUpSpawn();
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    IEnumerator EnemySpawn()
    {
        while (gamemanager.gameOver == false)
        {
            Instantiate(enemyPrefab, new Vector3(Random.Range(-8f, 8f), 6f, 0),Quaternion.identity);
            yield return new WaitForSeconds(5.0f);

        }
    }

    IEnumerator PowerUpSpawn()
    {
        while (gamemanager.gameOver==false)
        {
            int RandomPowerup = Random.Range(0, powerUps.Length);
            Instantiate(powerUps[RandomPowerup], new Vector3(Random.Range(-8f, 8f), 6f, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
          
    }
}
