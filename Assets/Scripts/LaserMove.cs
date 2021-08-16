using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMove : MonoBehaviour
{
    [SerializeField] float lSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * lSpeed * Time.deltaTime);
        if(transform.position.y>=6)
        {
            Destroy(gameObject);
        }
    }
}
