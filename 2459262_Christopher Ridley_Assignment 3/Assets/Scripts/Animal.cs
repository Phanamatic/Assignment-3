using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public float cleanliness;
    public float energy;
    public float hunger;
    public float attention;
    public float health;

    void Start()
{
    cleanliness = 100;
    energy = 100;
    hunger = 100;
    attention = 100;
    health = 100;
}


    void Update()
    {
        // health equation 
        health = (cleanliness + energy - hunger + attention) / 4;
        
        // reduce stats over time
        cleanliness -= Time.deltaTime;
        energy -= Time.deltaTime;
        hunger += Time.deltaTime;
        attention -= Time.deltaTime;
    }
}
