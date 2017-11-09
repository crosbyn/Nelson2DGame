using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //Step 1: Declare Variables
    private AudioSource audioSource;
    private BoxCollider2D boxCollider2D;
    private SpriteRenderer spriteRender;

    public static int coinCount = 0; 
    //make this static so that there is only one coinCount for the whole class rather than every instance



    //Step 2: Initialize Variables
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        spriteRender = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            audioSource.Play();
            boxCollider2D.enabled = false;
            spriteRender.enabled = false;

            float length = audioSource.clip.length;
            coinCount = coinCount + 1; //Adds 1 to coinCount


            Destroy(gameObject, audioSource.clip.length);
        }

        
    }
	
}
