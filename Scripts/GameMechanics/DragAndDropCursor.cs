using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropCursor : MonoBehaviour
{
    private void OnEnable()
    {
        gameObject.transform.position = new Vector3 (gameObject.transform.position.x, 0, gameObject.transform.position.z);    
    }

    private void Update()
    {
        Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(gameObject.transform.position).z);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
        gameObject.transform.position = new Vector3(worldPosition.x, gameObject.transform.position.y, worldPosition.z);
    }
}
