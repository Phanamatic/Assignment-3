using System.Collections;
using UnityEngine;

public class Worker : MonoBehaviour
{
    public float energy;
    public Transform workersBase;
    public Animal targetAnimal;
    public GameObject destination; // Worker's destination
    public float speed = 2.0f; // Speed of the worker
    private bool isTaskCompleted = false; // A flag to indicate if the task is completed
    private bool returningToBase = false; // A flag to indicate if the worker is returning to base
    public WaitForSeconds taskCompletionDelay = new WaitForSeconds(2); // 2 seconds to complete a task
    


    public TaskManager.Task currentTask;

    void Start()
    {
        energy = 100;
        destination = workersBase.gameObject;
    }

    bool IsCloseTo(Vector3 targetPosition, float tolerance = 0.5f)
    {
    return Vector3.Distance(transform.position, targetPosition) < tolerance;
    }

void Update()
{
    // If returning to base, move towards base
    if (returningToBase)
    {
        MoveTo(workersBase.position);
        if (IsCloseTo(workersBase.position))
        {
            returningToBase = false;
        }
    }
    else if (energy > 0 && targetAnimal != null)
    {
        MoveTo(targetAnimal.transform.position);

        // If the worker reached its destination and task is not yet started, start the task
        if (IsCloseTo(targetAnimal.transform.position) && !isTaskCompleted)
        {
            StartCoroutine(PerformTask());
            isTaskCompleted = true; // Set flag to prevent starting the task again
        }
    }
    else if (targetAnimal == null)
    {
        // If there's no target animal and not returning to base, stay at base
        MoveTo(workersBase.position);
    }
}


    void MoveTo(Vector3 targetPosition)
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
    }

    IEnumerator PerformTask()
    {
    isTaskCompleted = true;
    

    // Use TaskManager to perform the task
    TaskManager.Instance.ExecuteTask(this, targetAnimal, currentTask);

    // Wait for task to be completed
    yield return taskCompletionDelay;

    // Task is finished, clear target and task
    targetAnimal = null;
    currentTask = TaskManager.Task.None;
    isTaskCompleted = false;

    // Set flag to return to base
    returningToBase = true;
    }

}


