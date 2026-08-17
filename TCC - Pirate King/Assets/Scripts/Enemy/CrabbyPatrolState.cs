using UnityEngine;

public class CrabbyPatrolState : ICrabbyState
{
    private float moveTimer;
    private float patrolTime = 2.0f; 
    private int direction = 1;
    private float maxDistance = 1.5f;

    public void Enter(Crabby enemy)
    {
        moveTimer = patrolTime;
        
        // Ativa a animação de corrida informando que a velocidade é maior que 0
        if (enemy.Animator != null)
        {
            enemy.Animator.SetFloat("speed", 1.0f);
        }
    }

    public void Execute(Crabby enemy)
    {
        enemy.Body.linearVelocity = new Vector2(direction * enemy.speed, enemy.Body.linearVelocity.y);

        moveTimer -= Time.deltaTime;

        float currentX = enemy.transform.position.x;
        float startX = enemy.StartPosition.x;

        if (currentX > startX + maxDistance && direction == 1)
        {
            direction = -1;
        }
        else if (currentX < startX - maxDistance && direction == -1)
        {
            direction = 1;
        }

        if (moveTimer <= 0f)
        {
            enemy.ChangeState(new CrabbyAttackState());
        }
    }

    public void Exit(Crabby enemy)
    {
        enemy.Body.linearVelocity = Vector2.zero;

        // Zera a velocidade ao sair da patrulha para ele voltar ao Idle
        if (enemy.Animator != null)
        {
            enemy.Animator.SetFloat("speed", 0f);
        }
    }
}