using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FPSWalk : MonoBehaviour
{
    public AudioSource steps;
    public CharacterController character;
    public Vector3 positionToGo;
    bool safe = false;
    float counttodie=14;
    public AudioSource warning;
    // Start is called before the first frame update
    void Start()
    {
        positionToGo = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 diftowalk = positionToGo - transform.position;

        character.SimpleMove(diftowalk.normalized);
       
        steps.volume = diftowalk.magnitude-1;

        if (!safe)
        {
            counttodie -= Time.deltaTime;
            warning.volume += Time.deltaTime / 14;
            if (counttodie < 0)
            {
                SceneManager.LoadScene("Menu");
            }
        }
        else
        {
            counttodie = 14;
            warning.volume = Mathf.Lerp(warning.volume, 0, Time.deltaTime);
        }

        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Walkable"))
        {
            print("Safe");
            safe = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Walkable"))
        {
            print("notSafe");
            safe = false;
        }
    }
}
