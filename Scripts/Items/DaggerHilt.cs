using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Jacob Bellamy, Ian Stamper, Terrell Vergith
    September 16th, 2021
    CIS 293: Advanced Technologies
    VR Blacksmithing Game: Forge and create the 5 relic blades to spawn the void sword and win.

    Filename: DaggerHilt.cs
*/

public class DaggerHilt : MonoBehaviour
{
    private bool isAttached = false;

    public void SetIsAttached(bool b)
    {
        isAttached = b;
    }

    public bool GetIsAttached()
    {
        return isAttached;
    }
}
