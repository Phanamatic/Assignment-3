using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    public AnimalStatsUI animalStatsUI; 
    public WorkerstatsUI workerStatsUI; 
    public TaskManager taskManager; 
    public bool isAnimal;

    // This method is called when the object which the script is attached to is clicked
    void OnMouseDown() 
    {
        //logs the object that is clicked
        Debug.Log("Clicked on: " + gameObject.name);

        //checks to see if animal or worker and if animal sets teh necessary methods
        if (isAnimal)
        {
            Animal animal = GetComponent<Animal>();
            if (animal.status == "Dead")
            {
                Debug.Log("This animal is dead and cannot be selected.");
                return;
            }
            animalStatsUI.DisplayStats(animal);
        }

        //If there is no task then it displays the animals stats, if not an animal then displays the workers stats and the task panel
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
                taskManager.taskPanel.SetActive(true); // Shows the task panel
            }
        }
        else
        {
            //This code handles the selection of animal to execute a task on
            if (isAnimal)
            {
                if(taskManager.currentWorker != null)
                {
                Debug.Log("Setting currentAnimal to: " + gameObject.name);
                taskManager.currentAnimal = GetComponent<Animal>();
                taskManager.ExecuteTask(taskManager.currentWorker, taskManager.currentAnimal, taskManager.currentTask);
                }
                else 
                {
                    Debug.Log("Current worker is null.");
                }
            }
        }
    }
}


