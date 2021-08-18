using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject enemyExplosion;
    public float enemySpeed;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * enemySpeed * Time.deltaTime);
        if(transform.position.y<-6.0f)

        {
            transform.position = new Vector3(Random.Range(-8.0f, 8.0f), 6, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Laser")
        {

            if(collision.transform.parent!=null)
            {
                Destroy(transform.parent);
            }
            Destroy(collision.gameObject);
            Instantiate(enemyExplosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);


        }
        if (collision.tag == "Player")
        {
            PlayerMove player = collision.GetComponent<PlayerMove>();
            if(player!=null)
            {
                player.Damage();
            }

        }
    }
}
