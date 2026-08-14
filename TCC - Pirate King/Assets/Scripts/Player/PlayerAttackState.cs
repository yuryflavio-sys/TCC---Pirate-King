using UnityEngine;

public class PlayerAttackState : IPlayerState
{
    public void Enter(Player player)
    {
        player.Animator.SetTrigger("Attack");
       
        player.Body.linearVelocity = new Vector2(0, player.Body.linearVelocity.y);
        player.Animator.SetFloat("speed", 0f);

        // Ativa a espada que funcionava
        player.EnableHitbox();
    }

    public void Execute(Player player)
    {
    }

    public void Exit(Player player)
    {
        // Desativa a espada ao sair
        player.DisableHitbox();
    }
}