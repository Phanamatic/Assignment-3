using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    public AnimalStatsUI animalStatsUI; // Assign in inspector
    public WorkerstatsUI workerStatsUI; // Assign in inspector
    public TaskManager taskManager; // Assign in inspector
    public bool isAnimal; // Set this to true for animals and false for workers

    void OnMouseDown() // This method is called when the object is clicked
{
    Debug.Log("Clicked on: " + gameObject.name);

    if (taskManager.currentTask == TaskManager.Task.None)
    {
        if (isAnimal)
        {
            Animal animal = GetComponent<Animal>();
            animalStatsUI.DisplayStats(animal);
        }
        else
        {
            Worker worker = GetComponent<Worker>();
            workerStatsUI.DisplayStats(worker);
            taskManager.currentWorker = worker;
            taskManager.taskPanel.SetActive(true); // Show task panel
        }
    }
    else
    {
        if (isAnimal)
        {
            Debug.Log("Setting currentAnimal to: " + gameObject.name);
            taskManager.currentAnimal = GetComponent<Animal>();
            taskManager.ExecuteTask(); // Execute task
        }
    }
}
}


