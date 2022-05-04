using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCard : AnimateLayoutItem
{
    bool _isSleep = false;

    public bool isSleep
    {
        get
        {
            return _isSleep;
        }
        set
        {
            if (_isSleep == value)
            {
                return;
            }
            _isSleep = value;
            GetComponent<AnimateLayout>().resetCardsPos();
        }
    }
    void Awake()
    {
        GetComponent<AnimateLayout>().ajustSlotCallback = (GameObject slots) =>
            {
                for (var i = 0; i < slots.transform.childCount; i++)
                {
                    var slot = slots.transform.GetChild(i);
                    if (i == slots.transform.childCount - 1 && isSleep)
                    {
                        slot.localRotation = Quaternion.Euler(0, 0, 90);
                    }
                    else
                    {
                        slot.localRotation = Quaternion.identity;
                    }
                }
            };
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnMouseEnter()
    {

        transform.GetComponent<Animator>().SetBool("hover", true);
    }

    void OnMouseExit()
    {
        transform.GetComponent<Animator>().SetBool("hover", false);
    }


    // Update is called once per frame
    void Update()
    {

    }
}
