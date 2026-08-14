using UnityEngine;

public class CrabbyIdleState : ICrabbyState
{
    private float timer;
    private float idleDuration = 2.0f;

    public void Enter(Crabby enemy)
    {
        timer = idleDuration;
        enemy.Body.linearVelocity = Vector2.zero;
        // 0 significa estado Idle/Parado no Animator
        enemy.Animator.SetInteger("State", 0);
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