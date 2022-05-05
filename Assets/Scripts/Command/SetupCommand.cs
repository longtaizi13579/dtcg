using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SetupCommand : Command
{
    public SetupCommand(Game game) : base(game)
    {

    }
    public override void Execute()
    {
        for (var i = 0; i < 50; i++)
        {
            var card = game.CreateCard();
            game.deck1.Add(card, false);
        }

        for (var i = 0; i < 50; i++)
        {
            var card = game.CreateCard();
            game.deck2.Add(card, false);
        }
        ExecuteNext();
        // for (var i = 0; i < 5; i++)
        // {
        //     new DrawCommand(game);
        // }
    }
}
