using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grill : MonoBehaviour
{
    [SerializeField]
    private AudioClip grillingSound;
    private AudioManager audioManager;

    private int collisions;
    private bool cooking;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        collisions = 0;
        cooking = false;
    }

    private void FixedUpdate()
    {
        if (cooking && collisions <= 0)
        {
            audioManager.StopSFX();
            cooking = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Draggable"))
        {
            audioManager.PlaySFXLoop(grillingSound.name);
            collisions++;
            cooking = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Draggable"))
            collisions--;
    }
}
