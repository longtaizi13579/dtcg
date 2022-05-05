using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public AnimateLayout deck1;
    public AnimateLayout deck2;
    public AnimateLayout hand1;
    public AnimateLayout hand2;

    public AnimateLayout monster1;
    public AnimateLayout monster2;
    public GameObject cardPrefab;
    public GameObject monsterPrefab;



    void Awake()
    {
    }
    void Start()
    {
        new SetupCommand(this);
    }

    public GameObject CreateCard()
    {
        return Instantiate(cardPrefab, Vector3.zero, Quaternion.identity);
    }

    public GameObject CreateMonster()
    {
        return Instantiate(monsterPrefab, Vector3.zero, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
