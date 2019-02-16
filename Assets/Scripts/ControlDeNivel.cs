using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlDeNivel : MonoBehaviour
{
    public GameObject panelPausa;
    Animator animPausa;
    public bool pausa = false;

    public MovimientoBarra scriptControl;
    public Text bloquesTotales;
    public Text bloquesActuales;
    int numeroBloques;

    public Text bolasTotales;
    public static int usoBotones;
    int usoExplosiva;
    int usoAfilada;
    int usoDivisible;

    public GameObject panelCompletado;
    Animator animCompletado;

    public Image botonExplosiva;
    public Image botonDivisible;
    public Image botonAfilada;
    public Sprite noExplosiva, noDivisible, noAfilada;


    int timerInSeconds = 0;
    float levelTimer = 0f;
    bool updateTimer = false;
    public Text textoTiempo;
   
    // Start is called before the first frame update
    void Start()
    {
        

        numeroBloques = GameObject.FindGameObjectsWithTag("Bloque").Length;
        bloquesTotales.text = ""+ numeroBloques;
        animPausa = panelPausa.GetComponent<Animator>();

        usoBotones = 1;
        usoExplosiva = 1;
        usoAfilada = 1;
        usoDivisible = 1;

        animCompletado = panelCompletado.GetComponent<Animator>();

        updateTimer = true;
        levelTimer = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        if (updateTimer)
        {
            levelTimer += Time.deltaTime * 1;
        }
        timerInSeconds = Mathf.RoundToInt(levelTimer);


        bloquesActuales.text = "" + GameObject.FindGameObjectsWithTag("Bloque").Length;
        if(GameObject.FindGameObjectsWithTag("Bloque").Length == 0)
        {
            if (SceneManager.GetActiveScene().name == "Nivel_1")
            {
                ControlDeJuego.MarcarNivel1ComoCompletado();
            }
            if(SceneManager.GetActiveScene().name == "Nivel_2")
            {
                ControlDeJuego.MarcarNivel2ComoCompletado();
            }
            if(SceneManager.GetActiveScene().name == "Nivel_3")
            {
                ControlDeJuego.MarcarNivel3ComoCompletado();
            }
            
            animCompletado.SetTrigger("NivelCompletado");
            updateTimer = false;
            textoTiempo.text = timerInSeconds.ToString() + "s";
        }
        
        bolasTotales.text = "" + scriptControl.cantidadBolas;
    }

    public void MenuPausa()
    {
        pausa = !pausa;
        animPausa.SetBool("visible", pausa);

        if (pausa)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
        
    }


    public void AnadirExplosiva()
    {
        
        if (usoBotones > 0 && usoExplosiva > 0)
        {
            scriptControl.bolasRecogidas.Insert(0, 3);
            usoBotones--;
            usoExplosiva--;
            botonExplosiva.sprite = noExplosiva;
        }
    }
  
    public void AnadirDivisible()
    {
        if (usoBotones > 0 && usoDivisible > 0)
        {
            scriptControl.bolasRecogidas.Insert(0, 2);
            usoBotones--;
            usoDivisible--;
            botonDivisible.sprite = noDivisible;
        }
    }

    public void AnadirAfilada()
    {
        if (usoBotones > 0 && usoAfilada > 0)
        {
            scriptControl.bolasRecogidas.Insert(0, 1);
            usoBotones--;
            usoAfilada--;
            botonAfilada.sprite = noAfilada;
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("BolaDivisible"))
        {
            scriptControl.bolasLanzadas.Remove(col.gameObject);
            Destroy(col.gameObject);
        }

        if (col.gameObject.CompareTag("BolaExplosiva"))
        {
            scriptControl.bolasLanzadas.Remove(col.gameObject);
            Destroy(col.gameObject);
        }

        if (col.gameObject.CompareTag("BolaAfilada"))
        {
            scriptControl.bolasLanzadas.Remove(col.gameObject);
            Destroy(col.gameObject);
        }

        if (col.gameObject.CompareTag("BolaBase"))
        {
            scriptControl.bolasLanzadas.Remove(col.gameObject);
            Destroy(col.gameObject);
        }
    }

   

}
