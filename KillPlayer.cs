using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    public int Respawn;
    public AudioSource SFX;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SFX.Play();
            Invoke("Break", 1);
            Invoke("Death", 1);
        }
        else
        {
            SFX.Play();
            Destroy(gameObject);
        }

    }
    void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void Break()
    {
        Destroy(gameObject);
    }
}
