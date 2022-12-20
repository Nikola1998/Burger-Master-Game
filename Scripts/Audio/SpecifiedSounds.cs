using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecifiedSounds : MonoBehaviour
{
    [SerializeField]
    public AudioClip pickupSound, hitGroundSound, burnSound;
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Grill"))
            audioManager.PlaySFX(burnSound);
        else
            audioManager.PlaySFX(hitGroundSound);
    }
}
