using UnityEngine;

public class PlayerDeadState : IPlayerState
{
    public void Enter(Player player)
    {
        player.Body.linearVelocity = new Vector2(0, -15f);

        BoxCollider2D col = player.GetComponent<BoxCollider2D>();
        if (col != null)
        {
            col.size = new Vector2(col.size.x, col.size.y * 0.3f);
            col.offset = new Vector2(col.offset.x, col.offset.y - 0.3f); 
        }
    }

    public void Execute(Player player)
    {
        player.Body.linearVelocity = new Vector2(0, player.Body.linearVelocity.y);
    }

    public void Exit(Player player) { }
}