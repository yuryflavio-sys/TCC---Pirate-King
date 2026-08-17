using UnityEngine;

public class Crabby : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D body;
    private SpriteRenderer sprite;
    private ICrabbyState currentState;
    private Transform player;
    private bool isDead = false;

    [Header("Movement Settings")]
    public float speed = 1.0f;
    private Vector2 startPosition;

    [Header("Health & Combat")]
    public int maxHealth = 9;
    private int currentHealth;

    public Animator Animator => animator;
    public Rigidbody2D Body => body;
    public SpriteRenderer Sprite => sprite;
    public Vector2 StartPosition => startPosition;

    void Start()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        startPosition = transform.position;

        currentHealth = maxHealth;

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }

        ChangeState(new CrabbyIdleState());
    }

    void Update()
    {
        if (isDead) return;

        if (player != null)
        {
            bool isPlayerOnRight = player.position.x > transform.position.x;
            sprite.flipX = isPlayerOnRight; 
        }

        if (currentState != null)
        {
            currentState.Execute(this);
        }
    }

    public void ChangeState(ICrabbyState newState)
    {
        if (isDead) return;
        currentState?.Exit(this);
        currentState = newState;
        currentState.Enter(this);
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;
        Debug.Log("Crabby tomou " + damage + " de dano! Vida restante: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            if (animator != null)
            {
                animator.SetTrigger("Hit");
            }
        }
    }

    private void Die()
    {
        isDead = true;
        Debug.Log("Crabby foi derrotado!");

        if (animator != null)
        {
            animator.SetTrigger("Dead");
        }

        if (body != null) body.simulated = false;
        Collider2D col = GetComponent<Collider2D>();
        if (col != null) col.enabled = false;

        Destroy(gameObject, 2.0f);
    }

    public void EndAttack()
    {
        if (currentState is CrabbyAttackState && !isDead)
        {
            ChangeState(new CrabbyIdleState());
        }
    }
}