using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SauceDrip : MonoBehaviour
{
    [SerializeField]
    private GameObject sauceDripType;
    private GameObject[] sauceDrips;
    [SerializeField]
    private GameObject cursor;
    [SerializeField]
    private float secondsBeforeDrip, secondsBetweenDrips, spawnHeight;
    [SerializeField]
    private int numberOfPreloadedObjects;

    [SerializeField]
    private AudioClip sauceSound;
    [SerializeField]
    private float timeBetweenSounds;
    private AudioManager audioManager;

    private int arrayIndex;
    private bool shouldDrip;
    private bool isSpawning;
    private bool shouldFollowCursor;

    private float dragDistanceForSpawnY = 100f;
    private Vector3 dragDestination;

    private Vector3 startingModelPosition;
    private Quaternion startingModelRotation;

    private void Awake()
    {
        startingModelPosition = gameObject.transform.position;
        startingModelRotation = gameObject.transform.rotation;
        arrayIndex = 0;
        isSpawning = false;
        shouldDrip = false;
        sauceDrips = new GameObject[numberOfPreloadedObjects];
        for (int i = 0; i < sauceDrips.Length; i++)
        {
            sauceDrips[i] = Instantiate(sauceDripType);
            sauceDrips[i].SetActive(false);
        }
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void Update()
    {
        if (isSpawning && Input.mousePosition.y > dragDestination.y)
        {
            cursor.SetActive(true);
            StartCoroutine(MomentBeforeDrip());
            isSpawning = false;
            shouldFollowCursor = true;
        }

        if (shouldFollowCursor)
        {
            ModelFollowCursor();
        }

        if (Input.GetMouseButtonUp(0))
        {
            shouldDrip = false;
            shouldFollowCursor = false;
            ResetModel();
            cursor.SetActive(false);
        }
    }

    public void InitializeDrip()
    {
        isSpawning = true;
        dragDestination = Input.mousePosition + Vector3.up * dragDistanceForSpawnY;
    }

    private IEnumerator MomentBeforeDrip()
    {
        yield return new WaitForSeconds(secondsBeforeDrip);
        shouldDrip = true;
        StartCoroutine(SpawnSauceDrip());
        StartCoroutine(ProduceSound());
    }

    private IEnumerator ProduceSound()
    {
        while (shouldDrip)
        {
            audioManager.PlaySFX(sauceSound);
            yield return new WaitForSeconds(timeBetweenSounds);
        }
    }

    private IEnumerator SpawnSauceDrip()
    {
        while (shouldDrip)
        {
            yield return new WaitForSeconds(secondsBetweenDrips);
            GameObject sauce = sauceDrips[arrayIndex];
            if (!sauce.activeSelf)
                sauce.SetActive(true);
            sauce.transform.position = new Vector3(cursor.transform.position.x, spawnHeight, cursor.transform.position.z);
            if (arrayIndex < sauceDrips.Length - 1)
                arrayIndex++;
            else
                arrayIndex = 0;
        }
    }

    private void ModelFollowCursor()
    {
        gameObject.transform.position = cursor.transform.position + Vector3.up * 10f;
        gameObject.transform.rotation = Quaternion.Euler(180f, 0f, 0f);
    }

    private void ResetModel()
    {
        gameObject.transform.position = startingModelPosition;
        gameObject.transform.rotation = startingModelRotation;
    }
}
