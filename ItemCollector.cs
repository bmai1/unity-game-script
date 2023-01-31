using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    // public SpriteRenderer spriteRenderer;
    // public Sprite effect;
    [SerializeField] private GameObject effect;
    [SerializeField] private AudioSource gemSfx;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("gem")) {
            gemSfx.time = 0.3f;
            gemSfx.Play(); 
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
    }
}
