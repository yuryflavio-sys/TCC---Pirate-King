using UnityEngine;

public class PlayerFallState : IPlayerState
{
    public void Enter(Player player)
    {
        player.Animator.SetBool("Falling", true);
    }

    public void Execute(Player player)
    {
        float moveInput = Input.GetAxis("Horizontal");
        player.Body.linearVelocity = new Vector2(moveInput * player.speed, player.Body.linearVelocity.y);
        player.Flip(moveInput);

        if (player.IsGrounded())
        {
            player.Animator.SetBool("Falling", false);
            player.ChangeState(new PlayerIdleState());
        }
    }

    public void Exit(Player player)
    {
        player.Animator.SetBool("Falling", false);
    }
}