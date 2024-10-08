using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S5RayCast : MonoBehaviour
{
    [SerializeField] Transform jugador;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direccion = jugador.position - transform.position;
        direccion = direccion.normalized;
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.right * -1, out hit, 10f))
        {
            Debug.Log("colision");
            //hit 
            Debug.DrawRay(transform.position, direccion * hit.distance, Color.white);
        }
        else
        {
             Debug.Log("no colision");
             Debug.DrawRay(transform.position, transform.right * -1 * 10f, Color.black);
        }
    }
}
