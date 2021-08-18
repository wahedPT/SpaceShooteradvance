using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoTripleandSpeedup : MonoBehaviour
{
    private float tripleShotPowerUp = 3.0f;
    public float powerupid;
    //Player player;
    // Start is called before the first frame update
    void Start()
    {
        //player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * tripleShotPowerUp);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //accessing the can
        //player.canTripleShoot = true;
        if (collision.tag == "Player")
        {
            PlayerMove player = collision.GetComponent<PlayerMove>();
            if (player != null)
            {
                if(powerupid==0)
                {
                    //player.cantripleShot = true;
                    player.TripleShotPowerUp();
                }
                else if(powerupid==1)
                {
                    player.SpeedPowerUpON();
                }
                else if (powerupid == 2)
                {

                }

            }
            this.gameObject.SetActive(false);
        }
    }


}
