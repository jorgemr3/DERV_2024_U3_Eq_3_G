using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class ManagerUI : MonoBehaviour
{
    float tiempo_transcurrido;
    float con_segundos;
    TextMeshProUGUI[] contador;
    public static ManagerUI Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            //instance diferente de null
            //this diferente de instance 
            //Destroy(this);
            Destroy(gameObject);
        }
        else
        {
            contador = GetComponentsInChildren<TextMeshProUGUI>();
            Instance = this;
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        con_segundos = 0;
        tiempo_transcurrido = 0;
    }
    // Update is called once per frame
    void Update()
    {
        tiempo_transcurrido += Time.deltaTime;
        if (tiempo_transcurrido > 1.0f)
        {
            con_segundos++;
            tiempo_transcurrido = 0;
            contador[0].text = con_segundos.ToString();
        }
    }
}
