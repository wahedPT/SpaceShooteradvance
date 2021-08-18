using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject[] powerUps;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public void callCoroutines()
    {
        StartCoroutine(EnemySpawn());
        StartCoroutine(PowerUpsSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        print(gameManager.GameOver);
    }
    IEnumerator EnemySpawn()
    {
        while (gameManager.GameOver == false)
        {
            Instantiate(enemyPrefab, new Vector3(Random.Range(-8, 8), 6, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }
    IEnumerator PowerUpsSpawn()
    {
        while (gameManager.GameOver == false)
        {
            int r = Random.Range(0, powerUps.Length);
            Instantiate(powerUps[r], new Vector3(Random.Range(-8, 8), 6, 0), Quaternion.identity);
            yield return new WaitForSeconds(10.0f);
        }
    }
}
