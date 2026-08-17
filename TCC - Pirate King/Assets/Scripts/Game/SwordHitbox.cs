using UnityEngine;

public class SwordHitbox : MonoBehaviour
{
    public int attackDamage = 3; // 3 de dano (3 hits para matar o Crabby)

    // Usamos OnTriggerEnter2D para colisões do tipo Trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckAndHit(collision.gameObject);
    }

    // Usamos OnCollisionEnter2D caso o colisor da espada deixe de ser Trigger algum dia
    private void OnCollisionEnter2D(Collision2D collision)
    {
        CheckAndHit(collision.gameObject);
    }

    private void CheckAndHit(GameObject target)
    {
        // Verifica se o objeto atingido tem a Tag "Enemy"
        if (target.CompareTag("Enemy"))
        {
            Crabby crabby = target.GetComponent<Crabby>();
            if (crabby != null)
            {
                crabby.TakeDamage(attackDamage);
                Debug.Log("Espada atingiu o Crabby com sucesso!");
            }
        }
    }
}