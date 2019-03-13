using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GestionBanderas : MonoBehaviour
{

    public Image xNivel2;
    public Image xNivel3;


    public GameObject banderaMundo1;
    SpriteRenderer bM1;
    public GameObject banderaMundo2;
    SpriteRenderer bM2;
    public GameObject banderaMundo3;
    SpriteRenderer bM3;
    // Start is called before the first frame update
    void Start()
    {
        bM1 = banderaMundo1.GetComponent<SpriteRenderer>();
        bM1.enabled = false;
        bM2 = banderaMundo2.GetComponent<SpriteRenderer>();
        bM2.enabled = false;
        bM3 = banderaMundo3.GetComponent<SpriteRenderer>();
        bM3.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ControlDeJuego.nivel1Completo)
        {
            xNivel2.enabled = false;
        }
        if (ControlDeJuego.nivel2Completo)
        {
            xNivel3.enabled = false;
        }

        bM1.enabled = ControlDeJuego.nivel1Completo;
        bM2.enabled = ControlDeJuego.nivel2Completo;
        bM3.enabled = ControlDeJuego.nivel3Completo;
    }
}
