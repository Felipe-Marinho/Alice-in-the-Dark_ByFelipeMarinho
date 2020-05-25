using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FimDeJogo : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(FimDeJogoCoroutine());
    }
    IEnumerator FimDeJogoCoroutine()
    {
        
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene(0);
             
    }
    
}
