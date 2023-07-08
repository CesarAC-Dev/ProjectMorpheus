using UnityEngine;

public class Sticky : MonoBehaviour
{
    public float fuerzaDeRebote = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            Rigidbody2D otherRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();

            Vector2 normal = collision.GetContact(0).normal;
            Vector2 incidentDirection = rb.velocity.normalized;

            // Calculamos la dirección de rebote reflejando la dirección incidente en la normal.
            Vector2 bounceDirection = Vector2.Reflect(incidentDirection, normal).normalized;

            // Calculamos la velocidad de rebote basada en la velocidad incidente y la fuerza de rebote.
            Vector2 bounceVelocity = bounceDirection * rb.velocity.magnitude * fuerzaDeRebote;

            // Aplicamos la velocidad de rebote al objeto que colisionó.
            otherRigidbody.velocity = bounceVelocity;
        }
    }
}



/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rebote : MonoBehaviour
{
    public float fuerzaDeRebote = 10f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Comprobamos si la colisión ha ocurrido con otro objeto que tenga un Rigidbody2D.
        if (collision.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            // Obtenemos la normal de la colisión.
            Vector2 normal = collision.GetContact(0).normal;

            // Calculamos el vector de rebote utilizando la normal.
            Vector2 bounceDirection = Vector2.Reflect(collision.relativeVelocity, normal).normalized;

            // Aplicamos la fuerza de rebote al objeto que colisionó.
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(bounceDirection * fuerzaDeRebote, ForceMode2D.Impulse);
        }
    }
}
*/