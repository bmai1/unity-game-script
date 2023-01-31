using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private AudioSource doorOpen;

    private bool levelCompleted = false;
    
    private void Start()
    {
        doorOpen = GetComponent<AudioSource>();
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted) {
            doorOpen.Play();
            levelCompleted = true;
            Invoke("CompleteLevel", 1f);
            CompleteLevel();
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
