using UnityEngine;

public class SwordHitbox : MonoBehaviour
{
    public int damage = 3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Se encostar no próprio Player, ignora
        if (collision.gameObject.CompareTag("Player") || collision.transform.root == transform.root)
            return;

        // Se encostar no caranguejo, aplica o dano e avisa no Console
        Crabby enemy = collision.GetComponent<Crabby>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Debug.Log("Acertou o Crabby!");
        }
    }
}