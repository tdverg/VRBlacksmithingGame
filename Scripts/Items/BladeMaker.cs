using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Jacob Bellamy, Ian Stamper, Terrell Vergith
    September 16th, 2021
    CIS 293: Advanced Technologies
    VR Blacksmithing Game: Forge and create the 5 relic blades to spawn the void sword and win.

    Filename: BladeMaker.cs
*/

public class BladeMaker : MonoBehaviour
{
    [SerializeField] private List<GameObject> edgePrefabs;

    private bool onAnvil;
    private bool isAttached = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<DaggerHilt>())
        {
            BecomeWeapon(other.gameObject);
        }
    }

    public void SetOnAnvil(bool b)
    {
        onAnvil = b;
    }

    public bool GetOnAnvil()
    {
        return onAnvil;
    }

    public List<GameObject> GetEdgePrefabs()
    {
        return edgePrefabs;
    }

    public void BecomeBlade()
    {
        GameObject newIngot = Instantiate(edgePrefabs[Random.Range(Mathf.Min(0, edgePrefabs.Count), Mathf.Max(0, edgePrefabs.Count))],
                                        transform.position, transform.rotation) as GameObject;
        this.gameObject.transform.position = transform.position * 5;
        Destroy(gameObject);
    }

    public void BecomeWeapon(GameObject gameObject)
    {
        if (!isAttached)
        {
            if (!gameObject.GetComponent<DaggerHilt>().GetIsAttached())
            {
                this.GetComponent<MeshRenderer>().transform.SetParent(gameObject.GetComponentInChildren<MeshContainer>().transform, false);
                gameObject.GetComponent<DaggerHilt>().SetIsAttached(true);
                isAttached = true;
            }
        }
    }
}
