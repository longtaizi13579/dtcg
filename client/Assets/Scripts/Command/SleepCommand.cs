using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;



public class SleepCommand : Command
{
    public SleepCommand(Game game) : base(game) { }
    public override async void Execute()
    {
        Debug.Log("SleepCommand");
        game.monster1.cardList[0].GetComponent<MonsterCard>().setSleep(true);
        await Task.Delay(500);
        ExecuteNext();
    }
}
