using UnityEngine;

public class CrabbyAttackState : ICrabbyState
{
    private bool hasDealtDamage;

    public void Enter(Crabby enemy)
    {
        enemy.Body.linearVelocity = Vector2.zero;
        enemy.Animator.SetInteger("State", 1);
        hasDealtDamage = false;
    }

    public void Execute(Crabby enemy) 
    {
        enemy.Body.linearVelocity = Vector2.zero;

        // Opcional: Você pode checar se o Player está perto o suficiente durante o ataque
        // Ou deixar que o dano aconteça por colisão direta no momento do bote.
    }

    public void Exit(Crabby enemy) { }
}