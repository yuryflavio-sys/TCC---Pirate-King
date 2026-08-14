using UnityEngine;

public class Crabby : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D body;
    private SpriteRenderer sprite;
    private ICrabbyState currentState;
    private Transform player;

    [Header("Movement Settings")]
    public float speed = 1.0f;
    private Vector2 startPosition;

    [Header("Health & Combat")]
    public int maxHealth = 9;
    private int currentHealth;

    // Propriedades públicas para os Estados acessarem com segurança
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

        // Inicializa a vida do caranguejo
        currentHealth = maxHealth;

        // Procura o jogador na cena automaticamente usando a Tag
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }

        ChangeState(new CrabbyIdleState());
    }

    void Update()
    {
        // LÓGICA DE MIRA: O caranguejo SEMPRE olha para o jogador
        if (player != null)
        {
            bool isPlayerOnRight = player.position.x > transform.position.x;
            sprite.flipX = isPlayerOnRight; 
        }

        // Executa o comportamento do estado atual (Idle, Patrol, Attack)
        if (currentState != null)
        {
            currentState.Execute(this);
        }
    }

    public void ChangeState(ICrabbyState newState)
    {
        currentState?.Exit(this);
        currentState = newState;
        currentState.Enter(this);
    }

    // Chamado pelo Player quando a espada atinge o caranguejo
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Crabby tomou " + damage + " de dano! Vida restante: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Crabby foi derrotado!");
        Destroy(gameObject); // Remove o caranguejo da cena
    }

    // Chamado pelo Animation Event no último frame da animação de ataque
    public void EndAttack()
    {
        if (currentState is CrabbyAttackState)
        {
            ChangeState(new CrabbyIdleState());
        }
    }
}