using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Jacob Bellamy, Ian Stamper, Terrell Vergith
    September 16th, 2021
    CIS 293: Advanced Technologies
    VR Blacksmithing Game: Forge and create the 5 relic blades to spawn the void sword and win.

    Filename: Anvil.cs
*/

public class Anvil : MonoBehaviour
{
    // AudioSource
    [SerializeField] private AudioSource _as;
    [SerializeField] private AudioClip collisionSound;
    [SerializeField] private AudioClip destroySound;

    // What you're going to hit
    private GameObject ingotGameObject;

    // If something is to on the anvil
    private bool isOnAnvil = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Hammer>() && isOnAnvil)
        {
            if (ingotGameObject.GetComponent<Temperature>())
            {
                if (ingotGameObject.GetComponent<Temperature>().GetIsMaliable())
                {
                    _as.PlayOneShot(collisionSound);
                    ingotGameObject.GetComponent<Temperature>().SetNumberOfStrikes();
                    if (ingotGameObject.GetComponent<Temperature>().GetNumberOfStrikes() < 0)
                    {
                        _as.PlayOneShot(destroySound);
                        ingotGameObject.SendMessage("BecomeBlade");
                    }
                }
            }
        }

        if (other.GetComponent<BladeMaker>())
        {
            if (other.GetComponent<BladeMaker>().GetEdgePrefabs() != null)
            {
                isOnAnvil = true;
                other.GetComponent<BladeMaker>().SetOnAnvil(isOnAnvil);
                ingotGameObject = other.gameObject;
            }
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<BladeMaker>())
        {
            isOnAnvil = false;
            other.GetComponent<BladeMaker>().SetOnAnvil(isOnAnvil);
            ingotGameObject = null;
        }
    }
}
