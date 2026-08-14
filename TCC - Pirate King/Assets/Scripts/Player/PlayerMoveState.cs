using UnityEngine;

public class PlayerMoveState : IPlayerState
{
    public void Enter(Player player)
    {
    }

    public void Execute(Player player)
    {
        // NOVO: Detecta se ele andou para fora da beirada da plataforma
        if (!player.IsGrounded() && player.Body.linearVelocity.y < -0.1f)
        {
            player.Animator.SetBool("Falling", true);
            player.ChangeState(new PlayerFallState());
            return; // Sai do método para parar de tocar a animação de correr
        }

        float moveInput = Input.GetAxis("Horizontal");

        if (Mathf.Abs(moveInput) <= 0.01f)
        {
            player.ChangeState(new PlayerIdleState());
            return;
        }

        player.Body.linearVelocity = new Vector2(moveInput * player.speed, player.Body.linearVelocity.y);
        player.Flip(moveInput);

        player.Animator.SetFloat("speed", Mathf.Abs(moveInput));
    }

    public void Exit(Player player)
    {
        player.Animator.SetFloat("speed", 0f);
    }
}