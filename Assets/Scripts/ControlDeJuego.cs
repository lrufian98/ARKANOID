using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlDeJuego : MonoBehaviour
{

    public static bool nivel1Completo = false;
    public static bool nivel2Completo = false;
    public static bool nivel3Completo = false;

    

    

    // Start is called before the first frame update
    void Start()
    {
        
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void CargarSeleccionDeNivel()
    {
        SceneManager.LoadScene(1);
    }


    public void CargarPantallaInicio()
    {
        SceneManager.LoadScene(0);
    }


    public void CargarAjustes()
    {
        SceneManager.LoadScene(2);
    }


    public void CargarNivel1()
    {
        SceneManager.LoadScene("Nivel_1");
    }


    public void CargarNivel2()
    {
        if (nivel1Completo)
        {
            SceneManager.LoadScene("Nivel_2");
        }
    }


    public void CargarNivel3()
    {
        if(nivel1Completo && nivel2Completo)
        {
            SceneManager.LoadScene("Nivel_3");
        }
    }

    public void CargarCreditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void CargarNivelOculto()
    {
        SceneManager.LoadScene("Nivel_Oculto");

    }

    public void SalirDelJuego()
    {
        Application.Quit();
    }



}
