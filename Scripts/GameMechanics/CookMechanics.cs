using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class CookMechanics : MonoBehaviour
{
    [SerializeField]
    private Material postCookedMaterial;
    [SerializeField][Range(0f, 1f)] private float lerpTime = 1f;


    [SerializeField] private Renderer thisRenderer;

    private bool isCooking;

    

    private void FixedUpdate()
    {
        if (isCooking)
        {
            thisRenderer.material.color = Color.Lerp(thisRenderer.material.color, postCookedMaterial.color, lerpTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Grill"))
        {
            isCooking = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Grill"))
        {
            isCooking = false;
        }
    }
}
