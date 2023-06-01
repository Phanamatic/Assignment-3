using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerManager : MonoBehaviour
{
    public Worker[] workers;
    public Animal[] animals;
    
    void Update()
    {
        foreach (Worker worker in workers)
        {
            if (worker.energy > 0 && worker.targetAnimal == null)
            {
                foreach (Animal animal in animals)
                {
                    if (animal.cleanliness < 50)
                    {
                        worker.targetAnimal = animal;
                        worker.currentTask = TaskManager.Task.Cleaning;
                        break;
                    }
                    else if (animal.hunger > 50)
                    {
                        worker.targetAnimal = animal;
                        worker.currentTask = TaskManager.Task.Feeding;
                        break;
                    }
                    else if (animal.attention < 50)
                    {
                        worker.targetAnimal = animal;
                        worker.currentTask = TaskManager.Task.Playing;
                        break;
                    }
                }
            }
        }
    }
}

