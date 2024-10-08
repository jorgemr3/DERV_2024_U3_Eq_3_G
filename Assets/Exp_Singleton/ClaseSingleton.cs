using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ClaseSingleton : MonoBehaviour
{
    public static ClaseSingleton Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this && this != null)
        {
            //instance diferente de null
            //this diferente de instance 
            //ololllll
            Destroy(this);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            int idx_escena = SceneManager.GetActiveScene().buildIndex;
            idx_escena++;
            idx_escena %= 3;   //total de escenas
            cambioEscena(idx_escena);
        }

    }
    public void cambioEscena(int index)
    {
        SceneManager.LoadScene(index);
    }
}
