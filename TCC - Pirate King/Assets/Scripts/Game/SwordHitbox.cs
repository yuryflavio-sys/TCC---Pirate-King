using UnityEngine;

public class SwordHitbox : MonoBehaviour
{
    public int attackDamage = 3; // 3 de dano (3 hits para matar o Crabby de 9 de vida)

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se a espada encostou no Crabby
        if (collision.CompareTag("Enemy"))
        {
            Crabby crabby = collision.GetComponent<Crabby>();
            if (crabby != null)
            {
                crabby.TakeDamage(attackDamage);
            }
        }
    }
}