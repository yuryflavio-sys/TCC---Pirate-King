using UnityEngine;

public class PlayerDeadState : IPlayerState
{
    public void Enter(Player player)
    {
        // O SEGREDO AQUI: Em vez de manter o Y atual (que pode estar jogando ele para cima por causa do knockback),
        // nós forçamos uma velocidade negativa forte para ele "despencar" no chão/espinho na mesma hora.
        player.Body.linearVelocity = new Vector2(0, -15f); // O -15f puxa ele violentamente para baixo

        // Mantém o código do colisor que você já ajustou para ele deitar certinho!
        BoxCollider2D col = player.GetComponent<BoxCollider2D>();
        if (col != null)
        {
            col.size = new Vector2(col.size.x, col.size.y * 0.3f);
            col.offset = new Vector2(col.offset.x, col.offset.y - 0.3f); 
        }
    }

    public void Execute(Player player)
    {
        // Trava o X para não deslizar, mas deixa a gravidade continuar puxando para o chão
        player.Body.linearVelocity = new Vector2(0, player.Body.linearVelocity.y);
    }

    public void Exit(Player player) { }
}