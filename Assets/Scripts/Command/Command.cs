using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Command
{
    public Game game;
    public static Queue<Command> commands = new Queue<Command>();
    public static bool isPlaying = false;
    public virtual void AddToQueue()
    {
        commands.Enqueue(this);
        if (!isPlaying)
        {
            ExecuteNext();
        }
    }
    public Command(Game game){
        this.game = game;
        AddToQueue();
    }

    public static void ExecuteNext()
    {
        isPlaying = true;
        if (commands.Count > 0)
        {
            commands.Dequeue().Execute();
        }
        else
        {
            isPlaying = false;
        }
    }
    public virtual void Execute()
    {
    }

}
