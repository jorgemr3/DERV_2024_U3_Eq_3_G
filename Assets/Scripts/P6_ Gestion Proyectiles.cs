using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P6_GestionProyectiles : MonoBehaviour
{
    [SerializeField] GameObject proyectil; //prefab del proyectil 
    [SerializeField] Transform pos_inicio_proyectiles;
    [SerializeField] List<GameObject> proyectiles;

    int proyectil_a_despachar;
    // Start is called before the first frame update
    void Start()
    {
        int n = 10; //proyectiles de inicio longitud de lista de proyectiles
        proyectiles = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < n; i++)
        {
            tmp = Instantiate
                     (proyectil, pos_inicio_proyectiles.position, pos_inicio_proyectiles.rotation);
            tmp.name = "Proyectil" + i;
            tmp.tag = "bala";
            tmp.SetActive(false);
            proyectiles.Add(tmp);
        }
        proyectil_a_despachar = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            proyectiles[proyectil_a_despachar].transform.position = pos_inicio_proyectiles.position;
            proyectiles[proyectil_a_despachar].transform.rotation = pos_inicio_proyectiles.rotation;
              proyectiles[proyectil_a_despachar].GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
            proyectiles[proyectil_a_despachar].SetActive(true);
            proyectil_a_despachar++;
            proyectil_a_despachar %= proyectiles.Count;
        }
    }
}
