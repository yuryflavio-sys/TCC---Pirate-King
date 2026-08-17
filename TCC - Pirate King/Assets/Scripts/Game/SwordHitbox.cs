using UnityEngine;

public class SwordHitbox : MonoBehaviour
{
    public int attackDamage = 3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckAndHit(collision.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CheckAndHit(collision.gameObject);
    }

    private void CheckAndHit(GameObject target)
    {
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