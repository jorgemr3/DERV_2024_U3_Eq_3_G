using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerUI_adv : MonoBehaviour
{
    private static ManagerUI_adv instance;
    [SerializeField] GameObject user;
    TextMeshProUGUI nombre_usuario;
    string usuario;
    int id_escena_activa;


    // Start is called before the first frame update
    void Start()
    {
    
        
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        id_escena_activa = SceneManager.GetActiveScene().buildIndex;
        if(id_escena_activa!=3){
            usuario = PlayerPrefs.GetString("usuario", "");
            Debug.Log("usuario: "+ usuario);
        }
        /*
        si la escena es diferente de 3 entonces significa que el usuario no ha presionado el boton 
        */
    }

    public void CambiaEscena(int index){
       
        Debug.Log(""+ id_escena_activa);
        if (id_escena_activa ==3)
        {
            nombre_usuario = user.GetComponent<TextMeshProUGUI>();
            usuario = nombre_usuario.text;  //contiene el nombre que el usuario ingresa
            PlayerPrefs.SetString("usuario", usuario);
        }
        SceneManager.LoadScene(index);
     
    }
}
