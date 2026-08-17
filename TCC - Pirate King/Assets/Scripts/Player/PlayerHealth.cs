using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 9;
    private int currentHealth;
    private bool isDead = false; // Flag para avisar que o pirata já morreu

    [Header("Invincibility Settings")]
    public float invincibilityDuration = 1f;
    private bool isInvincible = false;

    [Header("Knockback Settings")]
    public float knockbackForce = 5f;
    private Rigidbody2D rb;

    [Header("Components")]
    private Animator anim;

    public event Action<float> OnHealthChanged;

    private void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damageAmount, Transform damageSource = null)
    {
        // Se já estiver morto ou invencível, ignora o resto do código
        if (isDead || isInvincible) return;

        currentHealth -= damageAmount;

        if (currentHealth < 0) currentHealth = 0;

        // Atualiza a barra de vida
        float healthPercentage = (float)currentHealth / maxHealth;
        OnHealthChanged?.Invoke(healthPercentage);

        Debug.Log("Vida atual do pirata: " + currentHealth);

        // Verifica se a vida zerou
        if (currentHealth <= 0)
        {
            // Se morreu, inicia a rotina de morte (não toca a animação de Hit normal)
            StartCoroutine(DieRoutine());
        }
        else
        {
            // Se sobreviveu, toca o Hit normal, dá o empurrão e fica invencível
            if (anim != null) anim.SetTrigger("Hit");
            
            if (damageSource != null) ApplyKnockback(damageSource);
            
            StartCoroutine(InvincibilityRoutine());
        }
    }

    private void ApplyKnockback(Transform damageSource)
    {
        if (rb == null) return;

        rb.linearVelocity = Vector2.zero;
        int direction = damageSource.position.x < transform.position.x ? 1 : -1;
        Vector2 knockbackDirection = new Vector2(direction, 1).normalized;
        rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
    }

    private IEnumerator InvincibilityRoutine()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibilityDuration);
        isInvincible = false;
    }

    private IEnumerator DieRoutine()
    {
        isDead = true; 

        if (anim != null) anim.SetTrigger("Dead");

        Player playerScript = GetComponent<Player>();
        if (playerScript != null)
        {
            playerScript.ChangeState(new PlayerDeadState());
        }

        Debug.Log("Player morreu! Tocando animações...");

        yield return new WaitForSeconds(2.5f);

        Debug.Log("Reiniciando fase...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}