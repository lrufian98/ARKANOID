using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovimientoBarra : MonoBehaviour
{

    public List<int> bolasRecogidas;
    public List<GameObject> prefabsBolas;
    public GameObject salidaBola;
    public List<GameObject> bolasLanzadas;
    public GameObject puntoApuntar;
    public bool apuntando = true
        ;
    public float velocidad = 100;
    public float tiempoEntreBolas = 0.2f;
    

    
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bolasLanzadas.Count > 0)
        {
            apuntando = false;
        }
        else
        {
            apuntando = true;
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
            bolasRecogidas.Add(2);
            Destroy(col.gameObject);
        }


    }

    IEnumerator LanzaBolas()
    {
        int cantidadBolas = bolasRecogidas.Count;

        for (int i = 0; i < cantidadBolas; i++)
        {

            GameObject nuevaBola;
            Rigidbody2D rbBola;
            nuevaBola = Instantiate(prefabsBolas[bolasRecogidas[0]], salidaBola.transform.position, salidaBola.transform.rotation);
            IgnorarColisionesEntreBolas(nuevaBola);
            bolasLanzadas.Add(nuevaBola);

            rbBola = nuevaBola.GetComponent<Rigidbody2D>();
            rbBola.AddForce(salidaBola.transform.forward * velocidad);
            bolasRecogidas.RemoveAt(0);
            yield return new WaitForSeconds(tiempoEntreBolas);

        }
        apuntando = false;
        
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
            StartCoroutine(LanzaBolas());
        }
    }

    


}
