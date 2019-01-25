using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaAfilada : MonoBehaviour
{
    Rigidbody2D rb;
    CircleCollider2D colliderBola;
    public float velocidad = 10;
    public GameObject animBloqueRoto;
    GameObject bloqueRompiendo;
    //Animator colAnimacion;
    //BoxCollider2D colCollider;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        colliderBola = GetComponent<CircleCollider2D>();
        //rb.AddForce(Vector2.up*velocidad);
        colliderBola.isTrigger = true;
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Bloque"))
        {
            /*
            colAnimacion = col.gameObject.GetComponent<Animator>();
            colCollider = col.gameObject.GetComponent<BoxCollider2D>();
            colCollider.enabled = false;
            colAnimacion.SetTrigger("Roto");
            */
            bloqueRompiendo = Instantiate(animBloqueRoto, col.transform.position, col.transform.rotation);
            Destroy(bloqueRompiendo, 1f);
            Destroy(col.gameObject);

            colliderBola.isTrigger = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.CompareTag("Bloque"))
        {
            /*
            colAnimacion = col.gameObject.GetComponent<Animator>();
            colCollider = col.gameObject.GetComponent<BoxCollider2D>();
            colCollider.enabled = false;
            colAnimacion.SetTrigger("Roto");
            */
            bloqueRompiendo = Instantiate(animBloqueRoto, col.transform.position, col.transform.rotation);
            Destroy(bloqueRompiendo, 1f);
            Destroy(col.gameObject);
        }
    }
}
