using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public static TaskManager Instance;
    public enum Task { None, Cleaning, BedTime, Feeding, Playing }

    public Task currentTask = Task.None;
    public Worker currentWorker;
    public Animal currentAnimal;

    public GameObject taskPanel;
    public WorkerstatsUI workerStatsUI;

    private void Awake()
    {
        // Ensure there's only one instance of TaskManager
        if (Instance == null)
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
        currentTask = (Task)task;
        taskPanel.SetActive(false);
    }

    public void ExecuteTask(Worker worker, Animal animal, Task task)
    {
        if (worker.energy < 10)
        {
            ResetTask();
            return;
        }

        worker.targetAnimal = animal;

        switch (task)
        {
            case Task.Cleaning:
                animal.cleanliness += 8;
                worker.currentTask = Task.Cleaning;
                break;
            case Task.BedTime:
                animal.energy += 2;
                worker.currentTask = Task.BedTime;
                break;
            case Task.Feeding:
                animal.hunger -= 6;
                worker.currentTask = Task.Feeding;
                break;
            case Task.Playing:
                animal.attention += 3;
                worker.currentTask = Task.Playing;
                break;
        }

        worker.energy -= 10;
        workerStatsUI.DisplayStats(worker);

        ResetTask();
    }

    public void ResetTask()
    {
        currentTask = Task.None;
      //  currentWorker = null;
        currentAnimal = null;
    }
}
