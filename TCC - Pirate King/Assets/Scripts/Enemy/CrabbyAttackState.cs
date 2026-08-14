using UnityEngine;

public class CrabbyAttackState : ICrabbyState
{
    public void Enter(Crabby enemy)
    {
        enemy.Body.linearVelocity = Vector2.zero;
        // 1 significa estado de ataque no Animator
        enemy.Animator.SetInteger("State", 1);
    }

    public void Execute(Crabby enemy) 
    {
        enemy.Body.linearVelocity = Vector2.zero;
    }

    public void Exit(Crabby enemy) { }
}