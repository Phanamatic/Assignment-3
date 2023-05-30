using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public enum Task { None, Wash, BedTime, Feed, Play }

    public Task currentTask = Task.None;
    public Worker currentWorker;
    public Animal currentAnimal;

    public GameObject taskPanel;
    public WorkerstatsUI workerStatsUI;

    public void SelectTask(int task)
    {
        currentTask = (Task)task;
        taskPanel.SetActive(false);
    }

    public void ExecuteTask()
    {
        if (currentWorker.energy < 10)
        {
            ResetTask();
            return;
        }

        currentWorker.targetAnimal = currentAnimal;

        switch (currentTask)
        {
            case Task.Wash:
                currentAnimal.cleanliness += 20;
                currentWorker.currentTask = Worker.TaskType.Cleaning;
                break;
            case Task.BedTime:
                currentAnimal.energy += 20;
                currentWorker.currentTask = Worker.TaskType.BedTime;
                break;
            case Task.Feed:
                currentAnimal.hunger += 20;
                currentWorker.currentTask = Worker.TaskType.Feeding;
                break;
            case Task.Play:
                currentAnimal.attention += 20;
                currentWorker.currentTask = Worker.TaskType.Playing;
                break;
        }

        currentWorker.energy -= 10;
        workerStatsUI.DisplayStats(currentWorker);

        ResetTask();
    }

    public void ResetTask()
    {
        currentTask = Task.None;
        currentWorker = null;
        currentAnimal = null;
    }
}

