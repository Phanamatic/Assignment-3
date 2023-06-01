using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameClock : MonoBehaviour
{
    public float time;
    public TextMeshProUGUI timeDisplay;
    public Worker[] workers;
    public Animal[] animals;
    public Image sunMoonImage;
    public Sprite sunSprite;
    public Sprite moonSprite;
    public GameObject sleepImagePrefab; // Prefab for the sleep image
    public Sprite sleepImage;


    private int dayCount = 1;
    public TextMeshProUGUI dayCountText;

    void Start()
    {
        time = 5f; // Start the time at 5:00
    }

    void Update()
    {
        time += Time.deltaTime * 0.1f;

        if (time >= 24f)
        {
            time = 0f;
            dayCount++; // Increment day count
            dayCountText.text = "Day " + dayCount; // Update day count text
        }

        if ((int)time == 6) // Beginning of work hours
        {
            sunMoonImage.sprite = sunSprite; // Show the sun
          //  WakeUp(); // Wake up workers and animals
        }
        else if ((int)time == 20) // End of work hours
        {
            sunMoonImage.sprite = moonSprite; // Show the moon
         //   GoToSleep(); // Put workers and animals to sleep
        }

        DisplayTime();
    }

    void DisplayTime()
    {
        int hours = Mathf.FloorToInt(time);
        int minutes = Mathf.FloorToInt((time % 1) * 60);

        string timeString = string.Format("{0:D2}:{1:D2}", hours, minutes);
        timeDisplay.text = timeString;
    }

//    void WakeUp()
//    {
//        foreach (Worker worker in workers)
//        {
//            worker.energy = 100; // Reset energy
//            Destroy(worker.gameObject.transform.GetChild(0).gameObject);
//        }
//        foreach (Animal animal in animals)
//        {
//            animal.energy = 100; // Reset energy
//            Destroy(animal.gameObject.transform.GetChild(0).gameObject);
//        }
//    }

//    void GoToSleep()
//    {
//        foreach (Worker worker in workers)
//       {
//            GameObject sleepImage = Instantiate(sleepImagePrefab, worker.gameObject.transform, false); // Add sleep image
//        }
//       foreach (Animal animal in animals)
//        {
//            GameObject sleepImage = Instantiate(sleepImagePrefab, animal.gameObject.transform, false); // Add sleep image
//        }
//    }
}
