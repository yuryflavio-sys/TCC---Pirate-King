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

            // Dispara a animação de fechar (Folding) e sumir (Out)
            anim.SetTrigger("BigColect");

            // Inicia a contagem de tempo antes de congelar (ex: espera 1.5 segundos)
            // Ajuste esse valor para o tempo exato que suas animações demoram para terminar
            StartCoroutine(FreezeGameRoutine(2.0f)); 
        }
    }

    // Coroutine: Uma função especial que pode "esperar" antes de continuar
    private IEnumerator FreezeGameRoutine(float delayTime)
    {
        // O código pausa nesta linha e espera os segundos definidos
        yield return new WaitForSeconds(delayTime);

        // Após o tempo acabar, o jogo é congelado
        Time.timeScale = 0f;
        
        Debug.Log("Level Complete! Game frozen.");
    }
}