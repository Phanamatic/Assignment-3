using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class WorkerstatsUI : MonoBehaviour
{
    public GameObject workerStatsPanel;
    public TextMeshProUGUI nameText;
    public Slider energySlider;

    public void DisplayStats(Worker worker)
    {
        nameText.text = worker.gameObject.name;
        energySlider.value = worker.energy;
        
        workerStatsPanel.SetActive(true);
    }

    public void HideStats()
    {
        workerStatsPanel.SetActive(false);
    }
}
