using UnityEngine;

public class PlayerIdleState : IPlayerState
{
    public void Enter(Player player)
    {
        player.Body.linearVelocity = new Vector2(0f, player.Body.linearVelocity.y);
        player.Animator.SetFloat("speed", 0f);
    }

    public void Execute(Player player)
    {
        if (!player.IsGrounded() && player.Body.linearVelocity.y < -0.1f)
        {
            player.Animator.SetBool("Falling", true);
            player.ChangeState(new PlayerFallState());
            return;
        }

        float horizontalInput = Input.GetAxis("Horizontal");

        if (Mathf.Abs(horizontalInput) > 0.01f)
        {
            player.ChangeState(new PlayerMoveState());
        }
    }

    public void Exit(Player player)
    {
    }
}