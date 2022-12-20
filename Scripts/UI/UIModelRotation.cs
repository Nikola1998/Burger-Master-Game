using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIModelRotation : MonoBehaviour
{
    [SerializeField]
    private Vector3 rotation;

    [SerializeField]
    private float rotationSpeed;

    private void FixedUpdate()
    {
        gameObject.transform.Rotate(rotation * rotationSpeed * Time.fixedDeltaTime);
    }
}
