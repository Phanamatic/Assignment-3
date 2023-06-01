using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animal : MonoBehaviour
{
    public float cleanliness;
    public float energy;
    public float hunger;
    public float attention;
    public float health;
    public float rand1;
    public float rand2;
    public float rand3;
    public float rand4;
    private float elapsedTime = 0f;
    public string status = "Alive";
    public SpriteRenderer spriteRenderer;
    public Sprite graveSprite;
    private bool isDead = false;
    public Image warningImage;


    void Start()
{
    cleanliness = 100;
    energy = 100;
    hunger = 0;
    attention = 100;
    health = 100;

    rand1 = Random.Range(1,3);
    rand2 = Random.Range(1,3);
    rand3 = Random.Range(1,3);
    rand4 = Random.Range(1,3);
}


  
        
    void Update()
{
    // health equation 
    health = (cleanliness + energy + (100 - hunger) + attention) / 4;

    // Condition to check if any of the stats are at their limit
    if (cleanliness <= 0 || energy <= 0 || hunger >= 100 || attention <= 0) 
    {
        status = "Dead";
        health = 0;
    }

    // Accumulate elapsed time
    elapsedTime += Time.deltaTime;

    // The stats decrease by 1 every 5 in-game seconds (300 real-time seconds)
    if (elapsedTime >= 3f)
    {
        hunger += rand1;
        attention -= rand2;
        cleanliness -= rand3;
        energy -= rand4;

        // If any stat hits 0, reduce health by 10
        if (hunger >= 100 || cleanliness <= 0 || attention <= 0 || energy <= 0)
        {
            health -= 10;
        }

        // The stats are kept within a minimum and maximum value (0 and 100 for example)
        hunger = Mathf.Clamp(hunger, 0, 100);
        attention = Mathf.Clamp(attention, 0, 100);
        cleanliness = Mathf.Clamp(cleanliness, 0, 100);
        energy = Mathf.Clamp(energy, 0, 100);

        // Reset elapsed time
        elapsedTime = 0f;
    }

    if (status == "Dead" && !isDead)
    {
        Die();
        isDead = true; // Set the flag to avoid calling Die() repeatedly
    }
}


public void Die()
    {
    spriteRenderer.sprite = graveSprite; // Change sprite to grave

    // Make unclickable by disabling the script itself
    this.enabled = false;
    }

}
