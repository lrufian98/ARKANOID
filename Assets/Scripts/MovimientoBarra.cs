using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovimientoBarra : MonoBehaviour
{
    public AudioSource lanzaBola;
    public List<int> bolasRecogidas;
    public List<GameObject> prefabsBolas;
    public GameObject salidaBola;
    public List<GameObject> bolasLanzadas;
    public GameObject puntoApuntar;
    public bool apuntando = true;
    public float velocidad = 100;
    public float tiempoEntreBolas = 0.2f;

    public GameObject pj;
    Animator pjAnimator;

    public int cantidadBolas;




    // Start is called before the first frame update
    void Start()
    {
        pjAnimator = pj.GetComponent<Animator>();

        lanzaBola = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (bolasLanzadas.Count > 0)
        {
            apuntando = false;
            pjAnimator.SetBool("apuntando", apuntando);
        }
        else
        {
            apuntando = true;
            pjAnimator.SetBool("apuntando", apuntando);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        bolasLanzadas.Remove(col.gameObject);

        if(col.gameObject.CompareTag("BolaBase"))
        {
            bolasRecogidas.Add(0);
            Destroy(col.gameObject);
        }
        if (col.gameObject.CompareTag("BolaAfilada"))
        {
            bolasRecogidas.Add(1);
            Destroy(col.gameObject);
        }
        if (col.gameObject.CompareTag("BolaExplosiva"))
        {
            bolasRecogidas.Add(3);
            Destroy(col.gameObject);
        }
        if (col.gameObject.CompareTag("BolaDivisible"))
        {
            bolasRecogidas.Add(0);
            bolasRecogidas.Add(0);
            Destroy(col.gameObject);
        }

        if(bolasLanzadas.Count == 0)
        {
            bolasRecogidas.Add(0); 
            cantidadBolas = bolasRecogidas.Count;
            ControlDeNivel.usoBotones++;
        }

    }

    IEnumerator LanzaBolas()
    {
        cantidadBolas = bolasRecogidas.Count;
        pjAnimator.SetTrigger("lanzamiento");

        for (int i = 0; i < cantidadBolas; i++)
        {

            GameObject nuevaBola;
            Rigidbody2D rbBola;
            nuevaBola = Instantiate(prefabsBolas[bolasRecogidas[0]], salidaBola.transform.position, new Quaternion (0, 0, 0, salidaBola.transform.rotation.w));
            IgnorarColisionesEntreBolas(nuevaBola);
            bolasLanzadas.Add(nuevaBola);

            rbBola = nuevaBola.GetComponent<Rigidbody2D>();
            rbBola.AddForce(salidaBola.transform.forward * velocidad);
            bolasRecogidas.RemoveAt(0);
            yield return new WaitForSeconds(tiempoEntreBolas);

        }
        apuntando = false;
        pjAnimator.SetBool("apuntando", apuntando);
        puntoApuntar.transform.position = salidaBola.transform.position;


    }
    void IgnorarColisionesEntreBolas(GameObject objNuevo)
    {
        for (int i = 0; i < bolasLanzadas.Count; i++)
        {
            Physics2D.IgnoreCollision(objNuevo.GetComponent<Collider2D>(), bolasLanzadas[i].GetComponent<Collider2D>());
        }
    }

    private void OnMouseDrag()
    {
        if (!apuntando)
        {
            gameObject.transform.position = Vector2.MoveTowards(transform.position, new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, transform.position.y), 0.5f);
        }
        if (apuntando)
        {
            puntoApuntar.transform.position = Vector2.MoveTowards(puntoApuntar.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), 0.5f);
        }
    }
    private void OnMouseUp()
    {
        if (apuntando)
        {
            if(puntoApuntar.transform.position.y > salidaBola.transform.position.y) StartCoroutine(LanzaBolas());
            lanzaBola.Play(0);
        }
    }

    


}
