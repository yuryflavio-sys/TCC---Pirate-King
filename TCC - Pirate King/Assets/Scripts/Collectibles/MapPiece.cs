using UnityEngine;

public class MapPiece : MonoBehaviour
{
    private Animator anim;
    private bool jaColetado = false; // Evita que o jogador colete duas vezes seguidas

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se quem encostou foi o Player e se ainda não foi coletado
        if (collision.CompareTag("Player") && !jaColetado)
        {
            jaColetado = true;

            // Dispara exatamente o gatilho que você criou na imagem
            anim.SetTrigger("Colect");

            // Destrói o objeto após 0.5 segundos (ajuste esse valor para o tempo exato da sua animação PieceMap_Out)
            Destroy(gameObject, 0.5f);
        }
    }
}