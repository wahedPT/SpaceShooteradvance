using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedupandTripleShot : MonoBehaviour
{
    private float tripleShotPowerUp = 3.0f;
    [SerializeField]
    private int powerUpId;//0-TripleShot, 1-Speed, 2-Shields

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * tripleShotPowerUp);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerMove player = collision.GetComponent<PlayerMove>();
            if (player != null)
            {
                if (powerUpId == 0)
                {
                    player.TripleShotPowerUp();
                }
                else if (powerUpId == 1)
                {
                    player.SpeedPowerUpON();
                }
                else if (powerUpId == 2)
                {
                    //shields
                }
            }
            this.gameObject.SetActive(false);
        }
    }
}
