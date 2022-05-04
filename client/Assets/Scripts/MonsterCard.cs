using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCard : AnimateLayoutItem
{
    public bool isSleep = false;
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

    public void setSleep(bool isSleep)
    {
        if (this.isSleep == isSleep)
        {
            return;
        }
        transform.GetComponent<Animator>().SetBool("sleep", true);
        this.isSleep = isSleep;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
