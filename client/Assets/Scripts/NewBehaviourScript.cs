using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Game game;
    void Start()
    {
        game = GameObject.Find("Game").GetComponent<Game>();
    }

    public void onClick()
    {
        new SummonCommand(game);
    }

    public void onClick2()
    {
        new DrawCommand(game);
    }

    public void onClick3()
    {
        new SpecialSummonCommand(game);
    }

    public void onClick4()
    {
        new SleepCommand(game);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
