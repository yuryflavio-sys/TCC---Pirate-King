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
        enemy.Animator.SetInteger("State", 0);
    }

    public void Execute(Crabby enemy)
    {
        // Move o caranguejo fisicamente (a rotação do sprite já está garantida no Crabby.cs)
        enemy.Body.linearVelocity = new Vector2(direction * enemy.speed, enemy.Body.linearVelocity.y);

        moveTimer -= Time.deltaTime;

        // Verificação limpa de limites para evitar o bug de tremedeira (flick)
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

        // Vai para o ataque quando o tempo de patrulha acaba
        if (moveTimer <= 0f)
        {
            enemy.ChangeState(new CrabbyAttackState());
        }
    }

    public void Exit(Crabby enemy)
    {
        // Zera a velocidade ao parar para atacar
        enemy.Body.linearVelocity = Vector2.zero;
    }
}