using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WorkerstatsUI : MonoBehaviour
{
    public GameObject workerStatsPanel;
    public TextMeshProUGUI nameText;
    public Slider energySlider;
    public Image workerImage; // The UI Image component where the worker's sprite will be displayed
    private Worker worker;

    public void DisplayStats(Worker worker)
    {
        this.worker = worker;
        nameText.text = worker.gameObject.name;
        workerImage.sprite = worker.GetComponent<SpriteRenderer>().sprite; // Get and display the worker's sprite

        workerStatsPanel.SetActive(true);
    }


    void Update()
    {
        if (workerStatsPanel.activeSelf && worker != null)
        {
            DisplayStats(worker);
            UpdateStats();
        }
    }

    public void UpdateStats()
    {
        energySlider.value = worker.energy;
    }
}

