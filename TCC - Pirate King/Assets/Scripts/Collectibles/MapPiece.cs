using UnityEngine;

public class MapPiece : MonoBehaviour
{
    private Animator anim;
    
    private bool isCollected = false; 

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isCollected)
        {
            isCollected = true;

            anim.SetTrigger("Colect");

            GameManager.Instance.CollectMapPiece();

            Destroy(gameObject, 0.5f);
        }
    }
}