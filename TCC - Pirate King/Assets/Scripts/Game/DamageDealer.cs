using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public int damageValue = 3;

    // Colisão Física - Frame Inicial
    private void OnCollisionEnter2D(Collision2D collision)
    {
        TryDealDamage(collision.gameObject);
    }

    // Colisão Física - Enquanto estiver tocando (O SEGREDO ESTÁ AQUI)
    private void OnCollisionStay2D(Collision2D collision)
    {
        TryDealDamage(collision.gameObject);
    }

    // Trigger - Frame Inicial
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TryDealDamage(collision.gameObject);
    }

    // Trigger - Enquanto estiver tocando (O SEGREDO ESTÁ AQUI)
    private void OnTriggerStay2D(Collider2D collision)
    {
        TryDealDamage(collision.gameObject);
    }

    // Centralizamos a lógica num lugar só para ficar limpo
    private void TryDealDamage(GameObject target)
    {
        if (target.CompareTag("Player"))
        {
            PlayerHealth health = target.GetComponent<PlayerHealth>();
            if (health != null)
            {
                // O PlayerHealth vai tentar aplicar o dano. 
                // Se o player estiver invencível (piscando), o próprio PlayerHealth ignora!
                health.TakeDamage(damageValue, transform);
            }
        }
    }
}