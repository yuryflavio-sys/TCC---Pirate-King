using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public int damageValue = 3; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth health = collision.GetComponent<PlayerHealth>();
            if (health != null)
            {
                // Envia o valor do dano E a posição deste espinho (transform)
                health.TakeDamage(damageValue, transform);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth health = collision.gameObject.GetComponent<PlayerHealth>();
            if (health != null)
            {
                // Envia o valor do dano E a posição deste espinho (transform)
                health.TakeDamage(damageValue, transform);
            }
        }
    }
}