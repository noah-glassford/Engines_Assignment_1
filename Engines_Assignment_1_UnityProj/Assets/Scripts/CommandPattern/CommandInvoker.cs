using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=I1BocNFIkwI
//This and the other command design pattern scripts were taken from this video
//The placing scripts themselves were modified for the instantiation we are using



public class CommandInvoker : MonoBehaviour
{
    static Queue<ICommand> commandBuffer;

    static List<ICommand> commandHistory;
    static int counter;

    private void Awake()
    {
        commandBuffer = new Queue<ICommand>();
        commandHistory = new List<ICommand>();
    }

    public static void AddCommand(ICommand command)
    {
        if (counter < commandHistory.Count)
        {
            while (commandHistory.Count > counter)
            {
                commandHistory.RemoveAt(counter);
            }
        }

        commandBuffer.Enqueue(command);
    }

    // Update is called once per frame
    void Update()
    {
       if (commandBuffer.Count > 0)
        {
            ICommand c = commandBuffer.Dequeue();
            c.Execute();

            commandHistory.Add(c);
            counter++;
        }
       else
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Debug.Log("Undo");

                if (counter > 0)
                {
                    counter--;
                    commandHistory[counter].Undo();
                }
            }
            else if(Input.GetKeyDown(KeyCode.X))
            {
                if (counter < commandHistory.Count)
                {
                    commandHistory[counter].Execute();
                    counter++;
                }
            }
        }
    }
}
