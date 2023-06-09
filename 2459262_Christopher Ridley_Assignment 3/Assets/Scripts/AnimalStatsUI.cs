using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AnimalStatsUI : MonoBehaviour
{
    public GameObject animalStatsPanel;
    public TextMeshProUGUI nameText;
    public Slider cleanlinessSlider;
    public Slider energySlider;
    public Slider hungerSlider;
    public Slider attentionSlider;
    public Slider healthSlider;
    public TextMeshProUGUI statusText;
    public Image animalImage;
    private Animal animal;
    public TextMeshProUGUI cleanlinessText;
    public TextMeshProUGUI energyText;
    public TextMeshProUGUI hungerText;
    public TextMeshProUGUI attentionText;
    public TextMeshProUGUI healthText;

    //handles displaying the animals image and stats in the stats panel
    public void DisplayStats(Animal animal)
    {
        this.animal = animal;
        nameText.text = animal.gameObject.name;
        animalImage.sprite = animal.GetComponent<SpriteRenderer>().sprite;

        animalStatsPanel.SetActive(true);
    }

    //updates and displays the stats every frame if an aniaml is selected
    void Update()
    {
        if (animalStatsPanel.activeSelf && animal != null)
        {
            DisplayStats(animal);
            UpdateStats();
        }
    }

    //Updates all the values for the animals stats in the ui stats panel
    public void UpdateStats()
    {
        cleanlinessSlider.value = animal.cleanliness;
        energySlider.value = animal.energy;
        hungerSlider.value = animal.hunger;
        attentionSlider.value = animal.attention;
        healthSlider.value = animal.health;
        statusText.text = "Status: " + animal.status;

        cleanlinessText.text = animal.cleanliness.ToString();
        energyText.text = animal.energy.ToString();
        hungerText.text = animal.hunger.ToString();
        attentionText.text = animal.attention.ToString();
        healthText.text = animal.health.ToString();

        UpdateWarningStatus();
    }

    //checks if the values of each stat is above or below a threshold, if so warninsg are called and displayed throught the text color
    private void UpdateWarningStatus()
    {
        if (animal.cleanliness < 30)
        {
            cleanlinessText.color = Color.red;
        }
        else
            cleanlinessText.color = Color.white;
        
        if (animal.energy < 30)
        {
            energyText.color = Color.red;
        }
        else
            energyText.color = Color.white;
        
        if (animal.hunger > 70)
        {
            hungerText.color = Color.red;
        }
        else
            hungerText.color = Color.white;
        
        if (animal.attention < 30)
        {
            attentionText.color = Color.red;
        }
        else
            attentionText.color = Color.white;
    }

}


