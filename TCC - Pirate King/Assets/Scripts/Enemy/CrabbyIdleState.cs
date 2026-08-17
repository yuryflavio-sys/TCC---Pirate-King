using UnityEngine;

public class CrabbyIdleState : ICrabbyState
{
    private float timer;
    private float idleDuration = 2.0f;

    public void Enter(Crabby enemy)
    {
        timer = idleDuration;
        enemy.Body.linearVelocity = Vector2.zero;
        
        // Garante que a velocidade de movimento no animator fique zerada
        if (enemy.Animator != null)
        {
            enemy.Animator.SetFloat("speed", 0f);
        }
    }

    public void Execute(Crabby enemy)
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            if (Random.value > 0.5f)
            {
                enemy.ChangeState(new CrabbyPatrolState());
            }
            else
            {
                enemy.ChangeState(new CrabbyAttackState());
            }
        }
    }

    public void Exit(Crabby enemy) { }
}