using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaDivisible : MonoBehaviour
{
    Rigidbody2D rb;
    CircleCollider2D colliderBola;
    public float velocidad = 100;
    public GameObject division;
    Rigidbody2D rbDivision;
    Vector2 guardarVelocidad;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        colliderBola = GetComponent<CircleCollider2D>();
        //rb.AddForce(Vector2.up * velocidad);
        colliderBola.isTrigger = false;

        guardarVelocidad = rb.velocity;
    }



    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Bloque"))
        {
            for (int i = 0; i < 2; i++)
            {
                Instantiate(division, transform.position, transform.rotation);
                rbDivision = division.gameObject.GetComponent<Rigidbody2D>();
                rbDivision.velocity = guardarVelocidad;
            }
            
            
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
