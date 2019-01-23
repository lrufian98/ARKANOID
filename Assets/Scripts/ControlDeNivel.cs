using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        numeroBloques = GameObject.FindGameObjectsWithTag("Bloque").Length;
        bloquesActuales.text = "" + numeroBloques;
    }
}
