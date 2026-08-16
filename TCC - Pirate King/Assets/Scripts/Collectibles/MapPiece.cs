using UnityEngine;

public class MapPiece : MonoBehaviour
{
    private Animator anim;
    
    // Flag para evitar que o jogador colete o mesmo item duas vezes no mesmo frame
    private bool isCollected = false; 

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se quem colidiu foi o Player e se o item ainda não foi pego
        if (collision.CompareTag("Player") && !isCollected)
        {
            isCollected = true;

            // Dispara a animação de coleta do mapa pequeno
            anim.SetTrigger("Colect");

            // Acessa o Singleton para adicionar +1 na contagem
            GameManager.Instance.CollectMapPiece();

            // Destrói o objeto após a animação terminar (ajuste o tempo se necessário)
            Destroy(gameObject, 0.5f);
        }
    }
}