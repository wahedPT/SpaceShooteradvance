using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnner : MonoBehaviour
{
    public GameObject enemyPrefab;
    float time = 0;
    //Playermovement player;
    // Start is called before the first frame update
    private void Start()
    {
       // player = GameObject.Find("SpaceShip").GetComponent<Playermovement>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 2.0f)
        {
            float value = Random.Range(-9f, 9f);

            GameObject enemyRef = Instantiate(enemyPrefab);
            enemyRef.transform.position = new Vector3(value, 6.0f, 0);
            time = 0;
        }
    }
}
