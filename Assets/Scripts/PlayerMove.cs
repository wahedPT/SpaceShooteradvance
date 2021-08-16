using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float PmoveSpeed;
    [SerializeField]
    private float horizontalInput;
    [SerializeField]
    private float verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
       
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * PmoveSpeed*horizontalInput);
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * Time.deltaTime * PmoveSpeed * verticalInput);


        // bounds for y
        if(transform.position.y> 2f)
        {
            transform.position = new Vector3(transform.position.x, 2f, 0);

        }
        else if(transform.position.y<-4.2f)

        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }

        // bounds for x
        //if (transform.position.x > 8.2f)
        //{
        //    transform.position = new Vector3(8.2f, transform.position.y, 0);

        //}
        //else if (transform.position.x < -8.2f)

        //{
        //    transform.position = new Vector3( -8.2f,transform.position.y, 0);
        //}
        //bounds sharing
        if (transform.position.x > 9.5f)
        {
            transform.position = new Vector3(-9.5f, transform.position.y, 0);

        }
        else if (transform.position.x < -9.5f)

        {
            transform.position = new Vector3(9.5f, transform.position.y, 0);
        }
    }
}
