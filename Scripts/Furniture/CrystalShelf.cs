using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Jacob Bellamy, Ian Stamper, Terrell Vergith
    September 16th, 2021
    CIS 293: Advanced Technologies
    VR Blacksmithing Game: Forge and create the 5 relic blades to spawn the void sword and win.

    Filename: CrystalShelf.cs
*/

public class CrystalShelf : MonoBehaviour
{
    // Fields to be populated in the editor
    [SerializeField] private GameObject hilt;
    [SerializeField] private AudioSource _as;
    [SerializeField] private AudioClip crystalHiltSound;

    // Checks if the hilt is on the shelf
    private bool isOnShelf;

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponentInParent<DaggerHilt>())
        {
            if (hilt.gameObject.GetComponent<DaggerHilt>())
            {
                if (hilt.GetComponentInChildren<DaggerHilt>().GetIsAttached())
                {
                    if (!isOnShelf)
                    {
                        _as.PlayOneShot(crystalHiltSound);
                    }
                    isOnShelf = true;
                }
            }
            else
            {
                if (hilt.GetComponent<DaggerHilt>().GetIsAttached())
                {
                    isOnShelf = false;
                }
            }
        }
    }

    public bool GetIsOnShelf()
    {
        return isOnShelf;
    }
}
