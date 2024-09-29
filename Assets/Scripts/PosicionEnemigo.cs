using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosicionEnemigo : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Transform ubi_spawn;

   public GameObject enemigo;

    private void Awake(){
        enemigo = GameObject.Find("Enemigo");
    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Jugador")){
            enemigo.transform.position = ubi_spawn.position;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
