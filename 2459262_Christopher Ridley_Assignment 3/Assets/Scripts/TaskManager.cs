using UnityEngine;
using TMPro;

public class TaskManager : MonoBehaviour
{
    public static TaskManager Instance;
    public enum Task { None, Cleaning, BedTime, Feeding, Playing }

    public Task currentTask = Task.None;
    public Worker currentWorker;
    public Animal currentAnimal;

    public GameObject taskPanel;
    public WorkerstatsUI workerStatsUI;

    public TextMeshProUGUI taskUpdateText;

    private void Awake()
    {
        if (Instance == null)                      // Makes sure there is only one instance in the scene, used to handle multiple tasks beign given
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void SelectTask(int task)
    {
        currentTask = (Task)task;                   //sets the current task
        taskPanel.SetActive(false);                 //hides the task selector
    }

    public void ExecuteTask(Worker worker, Animal animal, Task task)
    {
        if (worker.energy < 10)                 //check to see if worker ahs enough energy
        {
            ResetTask();
            return;
        }

        worker.targetAnimal = animal;           //sets animal to perform task

        string taskResult = "";                 //sets the task result text to nothing

        switch (task)                           
        {                                       //Holds all the tasks. Updates animal stats. Sets task. Updates the task Result Text.
            case Task.Cleaning:                 
                animal.cleanliness += 8;
                worker.currentTask = Task.Cleaning;
                taskResult = $"{worker.name} Cleaned {animal.name}";
                break;
            case Task.BedTime:
                animal.energy += 2;
                worker.currentTask = Task.BedTime;
                taskResult = $"{worker.name} Put {animal.name} to Bed";
                break;
            case Task.Feeding:
                animal.hunger -= 6;
                worker.currentTask = Task.Feeding;
                taskResult = $"{worker.name} Fed {animal.name}";
                break;
            case Task.Playing:
                animal.attention += 3;
                worker.currentTask = Task.Playing;
                taskResult = $"{worker.name} Played with {animal.name}";
                break;
        }

        taskUpdateText.text = taskResult;                //Shows the task done in the text

        worker.energy -= 10;                            //expend the workers energy
        workerStatsUI.DisplayStats(worker);

        ResetTask();                                    //Resets current task and animal
    }

    public void ResetTask()
    {
        currentTask = Task.None;
      //  currentWorker = null;  // Created errors when multiple workers were given tasks
        currentAnimal = null;
    }
}
