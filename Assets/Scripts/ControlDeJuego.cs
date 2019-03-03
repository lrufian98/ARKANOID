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
        nivel1Completo = (PlayerPrefs.GetInt("nivel1Completo") == 1);
        nivel2Completo = (PlayerPrefs.GetInt("nivel2Completo") == 1);
        nivel3Completo = (PlayerPrefs.GetInt("nivel3Completo") == 1);

        Time.timeScale = 1f;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CargarAyuda()
    {
        SceneManager.LoadScene("PantallaAyuda");
    }

    public void CargarSeleccionDeNivel()
    {
        SceneManager.LoadScene(1);
    }


    public void CargarPantallaInicio()
    {
        SceneManager.LoadScene(0);
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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


    public void SalirDelJuego()
    {
        Application.Quit();
    }

    public static void MarcarNivel1ComoCompletado()
    {
        nivel1Completo = true;
        PlayerPrefs.SetInt("nivel1Completo", 1);
        PlayerPrefs.Save();
    }
    public static void MarcarNivel2ComoCompletado()
    {
        nivel2Completo = true;
        PlayerPrefs.SetInt("nivel2Completo", 1);
        PlayerPrefs.Save();
    }
    public static void MarcarNivel3ComoCompletado()
    {
        nivel3Completo = true;
        PlayerPrefs.SetInt("nivel3Completo", 1);
        PlayerPrefs.Save();
    }


}
