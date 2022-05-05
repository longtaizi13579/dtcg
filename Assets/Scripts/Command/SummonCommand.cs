using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;



public class SummonCommand : Command
{
    public SummonCommand(Game game) : base(game)
    {

    }
    public override async void Execute()
    {
        if (game.hand1.cardList.Count > 0)
        {
            var monster = game.CreateMonster();
            game.monster1.GetComponent<AnimateLayout>().Add(monster, false);

            var card = game.hand1.GetComponent<AnimateLayout>().cardList[0];
            monster.GetComponent<AnimateLayout>().Insert(card, 0);
            await Task.Delay(500);
        }
        else
        {

        }
        ExecuteNext();
    }
}
