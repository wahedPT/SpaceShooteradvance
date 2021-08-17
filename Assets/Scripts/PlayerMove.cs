using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public bool cantripleShot;
    public float canFire = 0;
    Vector3 direction;
    public float PmoveSpeed;
    [SerializeField]
    private float horizontalInput;
    [SerializeField]
    private float verticalInput;
    public GameObject lasePrefab,tripleShotPrefab;
    public float fireRate = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
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
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * PmoveSpeed * horizontalInput);
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * Time.deltaTime * PmoveSpeed * verticalInput);
    }
       IEnumerator TripleshotPowerDown()
    {
        y
    }
  }
