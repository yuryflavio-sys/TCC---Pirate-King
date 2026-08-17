using UnityEngine;

public class CrabbyAttackState : ICrabbyState
{
    public void Enter(Crabby enemy)
    {
        enemy.Body.linearVelocity = Vector2.zero;
        
        // Dispara o Trigger de ataque no Animator para acionar a Antecipação/Ataque
        if (enemy.Animator != null)
        {
            enemy.Animator.SetTrigger("Attack");
        }
    }

    public void Execute(Crabby enemy) 
    {
        enemy.Body.linearVelocity = Vector2.zero;
    }

    public void Exit(Crabby enemy) { }
}