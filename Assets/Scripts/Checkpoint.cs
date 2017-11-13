using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    private float activatedScale = 1.1f, deactivatedScale = 1f;

    [SerializeField]
    private Color activatedColor, deactivatedColor;

    private SpriteRenderer spriteRenderer;

    public static Checkpoint currentCheckpoint;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        transform.localScale = Vector3.one * deactivatedScale;
        //spriteRenderer.color = deactivatedColor;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audioSource.Play();
            currentCheckpoint = this;
            transform.localScale = Vector3.one * activatedScale;
            spriteRenderer.color = activatedColor;

        }
    }

}
