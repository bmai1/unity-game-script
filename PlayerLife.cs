using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
   
    private Animator anim; 
    private Rigidbody2D rb;

    [SerializeField] private AudioSource deathSoundEffect;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("trap")) {
            rb.velocity = new Vector2(0, 13);
            GameObject.Find("Player").GetComponent<Player_movement>().enabled = false;
            Die();
        }
    }

    private void Die() {
        deathSoundEffect.time = 0.05f;
        deathSoundEffect.Play();
        anim.SetTrigger("death");
    }

    private void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
