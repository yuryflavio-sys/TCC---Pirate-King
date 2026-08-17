using System.Collections; // Necessário adicionar para usar Coroutines
using UnityEngine;

public class BigMap : MonoBehaviour
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

            anim.SetTrigger("BigColect");

            StartCoroutine(FreezeGameRoutine(1.5f)); 
        }
    }

    private IEnumerator FreezeGameRoutine(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        Time.timeScale = 0f;
        
        Debug.Log("Level Complete! Game frozen.");
    }
}