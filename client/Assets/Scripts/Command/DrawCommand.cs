using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;



public class DrawCommand : Command
{
    public DrawCommand(Game game) : base(game) { }
    public override async void Execute()
    {
        Debug.Log("DrawCommand");
        if (game.deck1.cardList.Count > 0)
        {
            var card = game.deck1.cardList[0].GetComponent<Card>();
            card.setFaceUp(true);
            game.hand1.Add(card.gameObject);
            await Task.Delay(500);
        }
        else
        {

        }
        ExecuteNext();
    }
}
