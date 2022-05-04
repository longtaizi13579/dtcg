using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimateLayoutItem : MonoBehaviour
{
    public AnimateLayout belongTo = null;
    public void setBelongTo(AnimateLayout belongTo)
    {
        if (this.belongTo == belongTo)
        {
            return;
        }
        if (this.belongTo != null)
        {
            this.belongTo.Remove(this.gameObject);
        }
        this.belongTo = belongTo;
        onBelongToChange(belongTo);
    }

    public virtual void onBelongToChange(AnimateLayout belongTo)
    {
    }
}
