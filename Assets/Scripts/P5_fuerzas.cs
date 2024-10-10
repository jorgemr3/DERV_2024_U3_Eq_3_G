using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P5_fuerzas : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float velocidad;

    float tmp_en_pantalla;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tmp_en_pantalla=0;
        //rb.AddForce(transform.right * velocidad * 15f, ForceMode.VelocityChange); // ignoran la masa
        //rb.AddForce(transform.right*velocidad* 15f, ForceMode.Acceleration); 
    }


    private void Update(){
          tmp_en_pantalla += Time.deltaTime;
          if(tmp_en_pantalla > 1.5f){
            tmp_en_pantalla=0;
            gameObject.SetActive(false);
          }
    }
    void FixedUpdate()
    {
        rb.AddForce( velocidad * Time.fixedDeltaTime* transform.forward , ForceMode.Impulse); //escalar * escalar * matriz
    }

    // se multiplica en la actualidad con fixeddeltatime?
}
