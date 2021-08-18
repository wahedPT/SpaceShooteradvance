using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public bool isSpeedpowerup = false;
    public bool cantripleShot;
    public bool isShieldActive = false;
    public float PlayerLives = 5;
    public float canFire = 0;
    Vector3 direction;
    public float PmoveSpeed;
    [SerializeField]
    private float horizontalInput;
    [SerializeField]
    private float verticalInput;
    public GameObject lasePrefab,tripleShotPrefab;
    public float fireRate = 0.25f;
    Animator anim;
    public GameObject Pexplosion;
    public GameObject shieldGameobj;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Player input movement
        PlayerMovement();
        //Player  Boundarys
        playerBound(transform.position.x, transform.position.y);
        //Instantiating laser
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {
            Shoot();

        }

        //if(Input.GetKeyDown(KeyCode.A))
        //{
        //    anim.SetTrigger("Left");
        //}
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    anim.SetTrigger("Right");
        //}

    }

    private void Shoot()
    {
        if (Time.time > canFire)
        {
            if(cantripleShot==true)
            {
                Instantiate(tripleShotPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);//center
              //  Instantiate(lasePrefab, transform.position + new Vector3(-0.55f, 0.05f, 0), Quaternion.identity);//left
               // Instantiate(lasePrefab, transform.position + new Vector3(0.55f, 0.5f, 0), Quaternion.identity);//right
            }
            else
            {
                Instantiate(lasePrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);//center
            }


            //Instantiate(lasePrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            canFire = Time.time + fireRate;
        }
    }

    private void playerBound(float boundX, float boundY)
    {
        if (boundY > 2)
        {
            transform.position = new Vector3(boundX, 2, 0);
        }
        else if (boundY < -4.1f)
        {
            transform.position = new Vector3(boundX, -4.1f, 0);
        }
        if (boundX >= 10f)
        {
            transform.position = new Vector3(-10f, boundY, 0);
           

        }
        else if (boundX <= -10f)
        {
            transform.position = new Vector3(10f, boundY, 0);
           
        }
    }

public void Key(Vector3 vector, float axis)
    {

        transform.Translate(vector * Time.deltaTime * PmoveSpeed * axis);
    }
    private void PlayerMovement()
    {

        if(isSpeedpowerup==true)
        {
            transform.Translate(Vector3.right * Time.deltaTime * PmoveSpeed*2.0f * horizontalInput);
            transform.Translate(Vector3.up * Time.deltaTime * PmoveSpeed*2.0f * verticalInput);
        }
        else
        {
            transform.Translate(Vector3.right * Time.deltaTime * PmoveSpeed  * horizontalInput);
            transform.Translate(Vector3.up * Time.deltaTime * PmoveSpeed  * verticalInput);
        }
        horizontalInput = Input.GetAxis("Horizontal");
        
       
        verticalInput = Input.GetAxis("Vertical");

      //anim.SetTrigger("RightM");
      //  anim.SetTrigger("LeftM");
    }

    public void TripleShotPowerUp()
    {
        cantripleShot = true;
        StartCoroutine(TripleShotPowerDown());

    }

    public void SpeedPowerupOn()
    {
        isSpeedpowerup = true;
        StartCoroutine(SpeedPowerDown());
    }

    public IEnumerator TripleShotPowerDown()
    {
        yield return new WaitForSeconds(5.0f);
        cantripleShot = false;
    }

    public IEnumerator SpeedPowerDown()
    {
        yield return new WaitForSeconds(2);
        isSpeedpowerup = false;
    }

    public void Damage()
    {


        if(isShieldActive==true)
        {
            isShieldActive = false;
            shieldGameobj.SetActive(false);
            return;
        }
        else
        {
            PlayerLives--;
            if (PlayerLives < 1)
            {
                Instantiate(Pexplosion, transform.position, Quaternion.identity);
                //anim.SetTrigger("RocketExplode");
                Destroy(this.gameObject);

            }
        }

       
    }

    //public IEnumerator TripleshotDown()
    // {
    //     yield return. WaitForSeconds(5f);
    // }

    public void EnableShieldPowerUp()
    {
        isShieldActive = true;
        shieldGameobj.SetActive(true);

    }
}
