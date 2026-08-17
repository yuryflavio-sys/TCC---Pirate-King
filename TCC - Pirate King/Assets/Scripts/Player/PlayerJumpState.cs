using UnityEngine;

public class PlayerJumpState : IPlayerState
{
    public void Enter(Player player)
    {
        player.Body.linearVelocity = new Vector2(player.Body.linearVelocity.x, 0f);
        player.Body.AddForce(new Vector2(0, player.jumpForce), ForceMode2D.Impulse);
        player.Animator.SetTrigger("Jump");
    }

    public void Execute(Player player)
    {
        float moveInput = Input.GetAxis("Horizontal");
        player.Body.linearVelocity = new Vector2(moveInput * player.speed, player.Body.linearVelocity.y);
        player.Flip(moveInput);

        if (player.Body.linearVelocity.y < -0.1f) 
        {
            player.Animator.SetBool("Falling", true);
            player.ChangeState(new PlayerFallState());
        }
    }

    public void Exit(Player player)
    {
    }
}