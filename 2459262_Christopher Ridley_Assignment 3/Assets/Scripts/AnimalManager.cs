using System.Collections.Generic;
using UnityEngine;

public class AnimalManager : MonoBehaviour
{
    public List<Animal> animals;

    void Start()
    {
        foreach (var animal in animals)
        {
            if (animal != null && animal.warningImage != null)
            {
                animal.warningImage.enabled = false;
            }
        }
    }

    void Update()
    {
        foreach (var animal in animals)
        {
            UpdateWarningStatus(animal);
        }
    }

    void UpdateWarningStatus(Animal animal)
    {
        if (animal.hunger > 70 || animal.cleanliness < 30 || animal.attention < 30 || animal.energy < 30)
        {
            if (animal.warningImage != null)
            {
                animal.warningImage.enabled = true;
            }
        }
        else
        {
            if (animal.warningImage != null)
            {
                animal.warningImage.enabled = false;
            }
        }
    }
}
