using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerTomarObjetos : MonoBehaviour
{
    
    public bool isTaken;
    public bool isObjectNextYou;
    public GameObject objectTaken;

    public Transform original_scale;

    GameObject padre;

    private void Awake() {
        padre = GameObject.Find("Personaje");
    }

    // Start is called before the first frame update
    void Start()
    {
        isTaken = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            if (!isTaken){ 
                isTaken = true;
            }
            else{
                isTaken = false;
            }
        }
    }


private void OnTriggerEnter(Collider other) {
    if (other.gameObject.CompareTag("TakenObject")){
        //modificado por corrutina... ->
        isObjectNextYou = true;        
    }
}

private void OnTriggerStay(Collider other) {
    GameObject temporal = other.gameObject;

if (temporal.CompareTag("TakenObject")){
    if(isObjectNextYou){
        if (isTaken){            
            objectTaken = temporal;  //guarda la instancia al objeto tomado

            temporal.transform.SetParent(padre.transform); //cambia de padre
            Rigidbody rb = temporal.GetComponent<Rigidbody>(); //obtiene el rigidbody del objeto tomado
            rb.isKinematic = true; //activa la funcionalidad kinematica
            rb.useGravity = false; //desactiva la gravedad del objeto tomado para que no caiga de las manos
            temporal.transform.position = transform.position; //posiciona al obj tomado en las manos del personaje
            temporal.transform.rotation = transform.rotation; //posiciona al obj tomado en la rotacion de las manos del personaje
            original_scale = temporal.transform; //respalda la escala original
            temporal.transform.localScale = transform.localScale; 
        }else{
            if(objectTaken!=null){
            objectTaken = null;

            temporal.transform.SetParent(null); //cambia de padre
            Rigidbody rb = temporal.GetComponent<Rigidbody>(); //obtiene el rigidbody del objeto tomado
            rb.isKinematic = false; 
            rb.useGravity = true; 
            temporal.transform.localScale = original_scale.localScale; //recupera la escala original
            }
        }
    }
}
}

private void OnTriggerExit(Collider other) {
    if (other.gameObject.CompareTag("TakenObject")){
        isObjectNextYou = false;
    }
}



}