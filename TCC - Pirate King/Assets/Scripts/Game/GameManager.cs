using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int collectedPieces = 0;
    public GameObject bigMap;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    public void CollectMapPiece()
    {
        collectedPieces++;

        if (collectedPieces >= 4)
        {
            if (bigMap != null)
            {
                bigMap.SetActive(true);
            }
        }
    }
}