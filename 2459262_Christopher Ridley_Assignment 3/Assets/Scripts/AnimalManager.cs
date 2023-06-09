using System.Collections.Generic;
using UnityEngine;

public class AnimalManager : MonoBehaviour
{
    public List<Animal> animals;

    void Start()
    {
        foreach (var animal in animals)
        {
            //checks each animal to see if they are null or their warnign image is null, if not then the warning image is hidden
            if (animal != null && animal.warningImage != null)
            {
                animal.warningImage.enabled = false;
            }
        }
    }

    void Update()
    {
        //checks each animal each frame to see if the warning must be shown
        foreach (var animal in animals)
        {
            UpdateWarningStatus(animal);
        }
    }

    void UpdateWarningStatus(Animal animal)
    {
        // Checks animals stats and if any stat has passed the given threshold then it activates the warning image
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
