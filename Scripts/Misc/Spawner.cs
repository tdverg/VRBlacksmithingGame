using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Jacob Bellamy, Ian Stamper, Terrell Vergith
    September 16th, 2021
    CIS 293: Advanced Technologies
    VR Blacksmithing Game: Forge and create the 5 relic blades to spawn the void sword and win.

    Filename: Spawner.cs
*/

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject itemToSpawn;
    private GameObject newGameObject;

    private void Awake()
    {
        newGameObject = Instantiate(itemToSpawn, transform.position, transform.rotation);
        newGameObject.transform.SetParent(this.gameObject.transform, true);
    }
    private void Update()
    {
        if (!GetComponentInChildren<Temperature>())
        {
            SpawnNewItem();
        }
    }

    private void SpawnNewItem()
    {
        newGameObject = Instantiate(itemToSpawn, transform.position, transform.rotation);
        newGameObject.transform.SetParent(this.gameObject.transform, true);
    }
}
