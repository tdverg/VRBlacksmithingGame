using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Jacob Bellamy, Ian Stamper, Terrell Vergith
    September 16th, 2021
    CIS 293: Advanced Technologies
    VR Blacksmithing Game: Forge and create the 5 relic blades to spawn the void sword and win.

    Filename: VoidSword.cs
*/

public class VoidSword : MonoBehaviour
{
    [SerializeField] List<GameObject> gameObjects;
    [SerializeField] private GameObject voidSword;
    [SerializeField] private Vector3 spawnLocation;
    [SerializeField] private AudioSource _as;
    [SerializeField] private AudioClip voidSpawnSound;

    private int spawnCounter = 0;
    private bool isSpawned = false;

    // Update is called once per frame
    void Update()
    {
        spawnCounter = 0;

        // Goes through all objects in list populated through editor
        for (int i = 0; i < gameObjects.Count; i++)
        {
            // If isOnShelf on the shelf assigned to the list element in the editor is set to true increase spawnCounter else reduce it
            if (gameObjects[i].GetComponent<CrystalShelf>().GetIsOnShelf())
            {
                spawnCounter++;
            } else
            {
                spawnCounter--;
            }
        }

        // If statement to spawn the void sword once
        if (spawnCounter == gameObjects.Count && !isSpawned)
        {
            GameObject spawnedVoidSword = Instantiate(voidSword, spawnLocation, transform.rotation) as GameObject;
            isSpawned = true;
            _as.PlayOneShot(voidSpawnSound);
        }
    }
}
