using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlDeNivel : MonoBehaviour
{

    public Text bloquesTotales;
    public Text bloquesActuales;
    int numeroBloques;

    // Start is called before the first frame update
    void Start()
    {
        numeroBloques = GameObject.FindGameObjectsWithTag("Bloque").Length;
        bloquesTotales.text = ""+ numeroBloques;
    }

    // Update is called once per frame
    void Update()
    {
        
        bloquesActuales.text = "" + GameObject.FindGameObjectsWithTag("Bloque").Length;
        if(GameObject.FindGameObjectsWithTag("Bloque").Length == 0)
        {
            ControlDeJuego.nivel1Completo = true;
            
        }
    }
}
