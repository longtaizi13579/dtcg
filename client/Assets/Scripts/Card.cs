using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Card : AnimateLayoutItem
{
    public int id;
    public bool isEgg = false;
    bool isInHand
    {
        get
        {
            var game = GameObject.Find("Game").GetComponent<Game>();
            return belongTo == game.hand1;
        }
    }
    public GameObject img;
    Sprite faceUpSprite;
    Sprite cardBgEgg;
    Sprite cardBg;

    bool isFaceUp = false;

    void Awake()
    {
        cardBg = Resources.Load<Sprite>("img/card-bg");
        faceUpSprite = Resources.Load<Sprite>("cardImage/BT1-027");
        cardBgEgg = Resources.Load<Sprite>("img/card-bg-egg");
    }

    // Start is called before the first frame update
    void Start()
    {
    }
    int preIndex;
    void OnMouseEnter()
    {
        if (!isInHand)
        {
            return;
        }
        transform.GetComponent<Animator>().SetBool("hover", true);
    }

    void OnMouseExit()
    {
        if (!isInHand)
        {
            return;
        }
        transform.GetComponent<Animator>().SetBool("hover", false);
    }

    public void setFaceUp(bool isFaceUp)
    {
        if (this.isFaceUp == isFaceUp)
        {
            return;
        }
        this.isFaceUp = isFaceUp;
        this.GetComponent<Animator>().SetBool("isFaceUp", isFaceUp);
    }

    // Update is called once per frame
    void Update()
    {
        var y = img.transform.eulerAngles.y;
        var showBg = 90 <= y && y <= 270;
        if (showBg)
        {
            if (isEgg)
            {
                img.GetComponent<Image>().sprite = cardBgEgg;
            }
            else
            {
                img.GetComponent<Image>().sprite = cardBg;
            }
        }
        else
        {
            img.GetComponent<Image>().sprite = faceUpSprite;
        }
    }
}
