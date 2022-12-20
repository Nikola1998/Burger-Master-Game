using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField]
    private float dragDistanceForSpawnY;

    private DragAndDrop dragAndDropMechanics;
    private GameObject gameObjectToSpawn;
    private bool isSpawning;
    private Vector3 dragDestination;

    private void Start()
    {
        isSpawning = false;
        dragAndDropMechanics = FindObjectOfType<DragAndDrop>();
    }

    private void Update()
    {
        if (isSpawning && Input.mousePosition.y > dragDestination.y)
        {
            FinalizeSpawn();
        }
        if (Input.GetMouseButtonUp(0))
        {
            isSpawning = false;
        }
    }

    public void InitiateSpawn(GameObject gameObject)
    {
        gameObjectToSpawn = gameObject;
        isSpawning = true;
        dragDestination = Input.mousePosition + Vector3.up * dragDistanceForSpawnY;
    }

    private void FinalizeSpawn()
    {
        GameObject spawnedObject = Instantiate(gameObjectToSpawn);
        dragAndDropMechanics.DragObject(spawnedObject);
        isSpawning = false;
    }
}
