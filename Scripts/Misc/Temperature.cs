using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

/*
    Jacob Bellamy, Ian Stamper, Terrell Vergith
    September 16th, 2021
    CIS 293: Advanced Technologies
    VR Blacksmithing Game: Forge and create the 5 relic blades to spawn the void sword and win.

    Filename: Temperature.cs
*/

public class Temperature : MonoBehaviour
{
    // Visual Effects
    [SerializeField] private GameObject _gameObjectVFX;
    
    // Temperature Values
    [SerializeField] private float temperature;
    [SerializeField] private float maliableTemp;
    [SerializeField] private float maxTemp;

    // What am I?
    [SerializeField] private bool isOre;
    [SerializeField] private bool isIngot;
    
    // Forge Stuff
    Forge forge;
    private bool isOnForge;
    private bool recentlyHeated;

    // Seconds for the temp to be increased
    [SerializeField] private float thermalConduct;
    private int numberOfStrikes;
    private bool isMaliable;

    private void Awake()
    {
        // Determine how many strikes before I become an ingot
        // * Only effective if isIngot = true
        recentlyHeated = false;
        forge = null;
        numberOfStrikes = Random.Range(2, 5);
    }

    // Update is called once per frame
    void Update()
    {
        // Every frame check the current temperature of the item
        CheckTemp();
        if (isOnForge)
        {
            if (!recentlyHeated)
            {
                StartCoroutine(RaiseTemperature());
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Forge>())
        {
            forge = other.GetComponent<Forge>();
            isOnForge = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Forge>())
        {
            isOnForge = false;
        }
    }

    /// <summary>
    /// If ore becomes ingot after maliable temp,
    /// if ingot can be "worked" after maliable temp, else will be destroyed at maximum temp
    /// </summary>
    private void CheckTemp()
    {
        // Debug.Log("Made It To Check Temp : " + temperature.ToString());
        if (temperature >= maliableTemp)
        {
            // Visual effect to show player state change of material
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);

            // Checks if gameObject is ore - ore morphs at maliable temp.
            if (isOre)
            {
                DestroySelf(2f);

            }

            // If gameObject is not ore then if temp >= maxTemp destroy self.
            if (temperature >= maxTemp)
            {
                DestroySelf(2f);
            }

            // Update maliable
            isMaliable = true;
        }
    }

    private void DestroySelf(float time)
    {
        // Visual effect to show player state change of material
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.black);

        // Plays visual effect
        GameObject spawnEffect = Instantiate(_gameObjectVFX, transform.position, transform.rotation);
        Destroy(spawnEffect, time);

        // Final isOre check
        if (isOre)
        {
            GameObject newIngot = Instantiate(GetComponent<OreMorpher>().GetIngot(),
                                    transform.position, transform.rotation);
        }

        // Move object so you don't 
        this.gameObject.transform.position = transform.position * 5;

        Destroy(gameObject);
    }

    public float GetTemperature()
    {
        return temperature;
    }

    public float GetThermalConduct()
    {
        return thermalConduct;
    }

    public float GetMaliableTemp()
    {
        return maliableTemp;
    }

    public void SetTemperature(float temp)
    {
        temperature += temp;
    }
    public int GetNumberOfStrikes()
    {
        return numberOfStrikes;
    }
    public void SetNumberOfStrikes()
    {
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
        temperature = 0;
        isMaliable = false;
        numberOfStrikes -= 1;
    }

    public bool GetIsMaliable()
    {
        return isMaliable;
    }

    public bool GetIsOre()
    {
        return isOre;
    }

    public bool GetIsIngot()
    {
        return isIngot;
    }

    public bool GetIsOnForge()
    {
        return isOnForge;
    }

    public void SetIsOnForge(bool b)
    {
        isOnForge = b;
    }

    private IEnumerator RaiseTemperature()
    {
        // Has been placed on a forge
        recentlyHeated = true;

        // Heat up
        SetTemperature(forge.GetTempControl());

        // Wait x seconds to slow process of heating
        yield return new WaitForSeconds(thermalConduct);

        // Able to be heated again
        recentlyHeated = false;
    }
}
