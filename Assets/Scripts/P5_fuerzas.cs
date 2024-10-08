using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P5_fuerzas : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float velocidad;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.AddForce(transform.right * velocidad * 15f, ForceMode.VelocityChange);
        //rb.AddForce(transform.right*velocidad* 15f, ForceMode.Acceleration); 
    }

    void FixedUpdate()
    {
        rb.AddForce(transform.right * velocidad * 15f, ForceMode.Impulse);

    }
}
