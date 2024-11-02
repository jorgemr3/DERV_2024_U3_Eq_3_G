using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacaTrigger : MonoBehaviour
{
    GameObject placa; // La placa que pedirá un color
    List<string> colores = new List<string> { "Verde", "Amarillo", "Cafe" };
    string colorPedido;
    Renderer placaRenderer;

    [SerializeField] Material verde;
    [SerializeField] Material amarillo;
    [SerializeField] Material cafe;

    void Awake()
    {
        placa = GameObject.Find("Placa");
        placaRenderer = placa.GetComponent<Renderer>();
        colorPedido = colores[Random.Range(0, colores.Count)];
        Debug.Log("Color pedido: " + colorPedido);

        // Cambiar el color de la placa para indicar el color pedido
        CambiarColorPlaca(colorPedido);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Jugador"))
        {
            Debug.Log("Jugador ha entrado en contacto con la placa");

            // Comprobar si el jugador está llevando un cubo
            Renderer cuboRenderer = other.GetComponentInChildren<Renderer>();
            if (cuboRenderer != null)
            {
                string colorCubo = DeterminarColor(cuboRenderer.material);
                Debug.Log("Color del cubo: " + colorCubo);

                if (colorCubo == colorPedido)
                {
                    Debug.Log("Color correcto");
                    CambiarColorPlaca(colorCubo);
                }
                else
                {
                    Debug.Log("Color incorrecto");
                }
            }
        }
    }

    void CambiarColorPlaca(string color)
    {
        switch (color)
        {
            case "Verde":
                placaRenderer.material = verde;
                break;
            case "Amarillo":
                placaRenderer.material = amarillo;
                break;
            case "Cafe":
                placaRenderer.material = cafe;
                break;
        }
    }

    string DeterminarColor(Material material)
    {
        if (material == verde)
            return "Verde";
        else if (material == amarillo)
            return "Amarillo";
        else if (material == cafe)
            return "Cafe";
        else
            return "Color incorrecto";
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
