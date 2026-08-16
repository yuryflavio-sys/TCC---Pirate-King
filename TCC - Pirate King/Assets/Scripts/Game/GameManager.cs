using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Instância única do padrão Singleton
    public static GameManager Instance;

    public int collectedPieces = 0;
    public GameObject bigMap;

    private void Awake()
    {
        // Garante que exista apenas uma instância do GameManager
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            // Destrói duplicatas por segurança
            Destroy(gameObject); 
        }
    }

    // Método chamado pelos pedaços menores quando são coletados
    public void CollectMapPiece()
    {
        collectedPieces++;

        // Verifica se todas as 4 partes foram coletadas
        if (collectedPieces >= 4)
        {
            // Ativa o Mapa Grande, o que automaticamente inicia a animação "BigMap_In"
            if (bigMap != null)
            {
                bigMap.SetActive(true);
            }
        }
    }
}