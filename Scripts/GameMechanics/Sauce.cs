using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sauce : MonoBehaviour
{
    [SerializeField]
    private float fallSpeed;
    private bool shouldFall;

    private void OnEnable()
    {
        shouldFall = true;
    }

    private void FixedUpdate()
    {
        if (shouldFall)
            gameObject.transform.position += Vector3.down * fallSpeed * Time.fixedDeltaTime;
        else
            gameObject.transform.position = gameObject.transform.position;
    }

    private void OnTriggerStay(Collider other)
    {
        shouldFall = false;
    }

    private void OnTriggerExit(Collider other)
    {
        shouldFall = true;
    }
}
