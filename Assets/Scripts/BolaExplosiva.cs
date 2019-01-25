using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaExplosiva : MonoBehaviour
{
    Rigidbody2D rb;
    CircleCollider2D colliderBola;
    BoxCollider2D colliderExplosion;
    public float velocidad = 100;

    public GameObject animBloqueRoto;
    GameObject bloqueRompiendo;

    int explosion = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        colliderBola = GetComponent<CircleCollider2D>();
        //rb.AddForce(Vector2.up * velocidad);
        colliderBola.isTrigger = false;
        colliderExplosion = GetComponent<BoxCollider2D>();
        colliderExplosion.enabled = false;
    }



    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Bloque"))
        {
            
            bloqueRompiendo = Instantiate(animBloqueRoto, col.transform.position, col.transform.rotation);
            Destroy(bloqueRompiendo, 1f);
            Destroy(col.gameObject);

            if (explosion == 1)
            {
                colliderExplosion.enabled = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Bloque"))
        {
            bloqueRompiendo = Instantiate(animBloqueRoto, col.transform.position, col.transform.rotation);
            Destroy(bloqueRompiendo, 1f);
            Destroy(col.gameObject);
            colliderExplosion.enabled = false;
            --explosion;
        }
    }
}
