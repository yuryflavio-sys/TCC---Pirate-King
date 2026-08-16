using UnityEngine;



public class Player : MonoBehaviour

{

    private Animator animator;

    private Rigidbody2D body;

    private IPlayerState currentState;



    public float speed = 3.0f;

    public float jumpForce = 8.0f;



    public Transform groundCheck;

    public LayerMask groundLayer;



    // Propriedades públicas para os Estados acessarem com segurança

    public Animator Animator => animator;

    public Rigidbody2D Body => body;



    void Start()

    {

        animator = GetComponent<Animator>();

        body = GetComponent<Rigidbody2D>();

        ChangeState(new PlayerIdleState());

    }



    void Update()

    {

        // Executa o comportamento do estado atual (Idle, Run, Jump, Fall, Attack)

        if (currentState != null)

        {

            currentState.Execute(this);

        }



        // Atalhos globais de input (como Pular ou Atacar se estiver no chão)

        CheckGlobalInputs();

        ManageLayers();

    }



    private void CheckGlobalInputs()
    {
        // === A TRAVA DE SEGURANÇA AQUI ===
        // Se o estado atual for a morte, ignoramos totalmente os botões e saímos do método.
        if (currentState is PlayerDeadState)
        {
            return;
        }

        // Se apertar para pular e estiver no chão, muda para o estado de Pulo
        if (Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded() && !(currentState is PlayerAttackState))
        {
            ChangeState(new PlayerJumpState());
        }

        // Se apertar espaço e estiver no chão, inicia o estado de Ataque
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() && !(currentState is PlayerAttackState))
        {
            ChangeState(new PlayerAttackState());
        }
    }



    public void ChangeState(IPlayerState newState)

    {

        currentState?.Exit(this);

        currentState = newState;

        currentState.Enter(this);

    }



  public void Flip(float horizontal)
    {
        Vector3 currentScale = transform.localScale;

        if (horizontal > 0)
        {
            currentScale.x = Mathf.Abs(currentScale.x);
        }
        else if (horizontal < 0)
        {
            currentScale.x = -Mathf.Abs(currentScale.x);
        }

        transform.localScale = currentScale;
    }



    public bool IsGrounded()

    {

        float groundCheckRadius = 0.15f;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundCheckRadius, groundLayer);

        for (int i = 0; i < colliders.Length; i++)

        {

            if (colliders[i].gameObject != gameObject)

            {

                return true;

            }

        }

        return false;

    }



    public void ManageLayers()

    {

        if (!IsGrounded())

        {

            animator.SetLayerWeight(1, 1);

        }

        else

        {

            animator.SetLayerWeight(1, 0);

        }

    }



    // Chamado pelo Animation Event no último frame da animação de ataque

    public void EndAttack()

    {

        if (currentState is PlayerAttackState)

        {

            ChangeState(new PlayerIdleState());

        }

    }



    [Header("Combat")]

    public Collider2D swordHitboxCollider; // Arraste o BoxCollider2D da hitbox aqui no Inspector



    public void EnableHitbox()

    {

        if (swordHitboxCollider != null)

            swordHitboxCollider.enabled = true;

    }



    public void DisableHitbox()

    {

        if (swordHitboxCollider != null)

            swordHitboxCollider.enabled = false;

    }

}