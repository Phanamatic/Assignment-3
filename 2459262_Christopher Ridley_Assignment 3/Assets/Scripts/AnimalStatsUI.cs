using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class AnimalStatsUI : MonoBehaviour
{
    public GameObject animalStatsPanel;
    public TextMeshProUGUI nameText;
    public Slider cleanlinessSlider;
    public Slider energySlider;
    public Slider hungerSlider;
    public Slider attentionSlider;
    public TextMeshProUGUI healthText;

    public void DisplayStats(Animal animal)
    {
        nameText.text = animal.gameObject.name;
        cleanlinessSlider.value = animal.cleanliness;
        energySlider.value = animal.energy;
        hungerSlider.value = animal.hunger;
        attentionSlider.value = animal.attention;
        healthText.text = "Health: " + animal.health.ToString("0");
        
        animalStatsPanel.SetActive(true);
    }

    public void HideStats()
    {
        animalStatsPanel.SetActive(false);
    }
}
