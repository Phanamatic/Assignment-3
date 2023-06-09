using System.Collections;
using UnityEngine;

public class Worker : MonoBehaviour
{
    public float energy;
    public Transform workersBase;
    public Animal targetAnimal;
    public GameObject destination; 
    public float speed = 2.0f; 
    private bool isTaskCompleted = false; 
    private bool returningToBase = false; 
    public WaitForSeconds taskCompletionDelay = new WaitForSeconds(2); 
    


    public TaskManager.Task currentTask;

    void Start()
    {
        //sets workers energy and the base they will return to after tasks
        energy = 100;
        destination = workersBase.gameObject;
    }

    //checks to see when the worker is clsoe to the target
    bool IsCloseTo(Vector3 targetPosition, float tolerance = 0.5f)
    {
    return Vector3.Distance(transform.position, targetPosition) < tolerance;
    }

void Update()
{
    // If the working is set to returnign to abse then it will move towards the base, else it moves towards the set animal
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

        // If the worker has reached its destination and the task is not yet started then this starts the task
        if (IsCloseTo(targetAnimal.transform.position) && !isTaskCompleted)
        {
            StartCoroutine(PerformTask());
            isTaskCompleted = true; // To prevent starting the task again
        }
    }
    else if (targetAnimal == null)
    {
        // If there's no target animal and the workmign isn't set to return to base then stay at base
        MoveTo(workersBase.position);
    }
}

    //gets the targets position and moves the worker towards it
    void MoveTo(Vector3 targetPosition)
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
    }

    IEnumerator PerformTask()
    {
    isTaskCompleted = true;
    
    //Taskmanager performs the task
    TaskManager.Instance.ExecuteTask(this, targetAnimal, currentTask);

    //Waits for the task to be completed
    yield return taskCompletionDelay;

    //When the task is completed the targets and task are cleared
    targetAnimal = null;
    currentTask = TaskManager.Task.None;
    isTaskCompleted = false;

    //sets the worker to return to base
    returningToBase = true;
    }

}


