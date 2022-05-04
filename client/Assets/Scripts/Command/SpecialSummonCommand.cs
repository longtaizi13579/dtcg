using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;



public class SpecialSummonCommand : Command
{
    public SpecialSummonCommand(Game game) : base(game)
    {

    }
    public override async void Execute()
    {
        if (game.hand1.cardList.Count > 0)
        {
            var monster = game.monster1.GetComponent<AnimateLayout>().cardList[0];

            var card = game.hand1.GetComponent<AnimateLayout>().cardList[0];
            monster.GetComponent<AnimateLayout>().Add(card);
            await Task.Delay(500);
        }
        else
        {

        }
        ExecuteNext();
    }
}
