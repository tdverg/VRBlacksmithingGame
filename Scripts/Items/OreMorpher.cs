using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Jacob Bellamy, Ian Stamper, Terrell Vergith
    September 16th, 2021
    CIS 293: Advanced Technologies
    VR Blacksmithing Game: Forge and create the 5 relic blades to spawn the void sword and win.

    Filename: OreMorpher.cs
*/

public class OreMorpher : MonoBehaviour
{
    [SerializeField] private GameObject ingotToBecome;

    public GameObject GetIngot()
    {
        return ingotToBecome;
    }
}
