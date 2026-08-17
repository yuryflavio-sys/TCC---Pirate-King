using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public int damageValue = 3;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TryDealDamage(collision.gameObject);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        TryDealDamage(collision.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TryDealDamage(collision.gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        TryDealDamage(collision.gameObject);
    }

    private void TryDealDamage(GameObject target)
    {
        if (target.CompareTag("Player"))
        {
            PlayerHealth health = target.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.TakeDamage(damageValue, transform);
            }
        }
    }
}