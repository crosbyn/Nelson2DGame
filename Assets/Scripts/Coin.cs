using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //Step 1: Declare Variables
    private AudioSource audioSource;
    private BoxCollider2D boxCollider2D;
    private SpriteRenderer spriteRender;


    //Step 2: Initialize Variables
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        spriteRender = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Coin Touched");
        audioSource.Play();
        boxCollider2D.enabled = false;
        spriteRender.enabled = false;

        float length = audioSource.clip.length + 0.2f;
        Destroy(gameObject, audioSource.clip.length);
    }
	
}
