using UnityEngine;

public class PlayerDeadState : IPlayerState
{
    public void Enter(Player player)
    {
        // Ao entrar neste estado, garantimos que o pirata pare totalmente
        player.Body.linearVelocity = Vector2.zero;
    }

    public void Execute(Player player)
    {
        // O SEGREDO ESTÁ AQUI: Fica totalmente em branco!
        // Como não há Input.GetAxis nem player.Flip aqui dentro,
        // o jogador pode esmagar o teclado que o pirata não vai responder.
    }

    public void Exit(Player player)
    {
        // Não precisa fazer nada, pois ele não sai desse estado (a fase reinicia)
    }
}