using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public delegate void AjustSlotCallback(GameObject slots);

public class AnimateLayout : MonoBehaviour
{
    public GameObject slots;
    public GameObject cards;

    public AjustSlotCallback ajustSlotCallback;

    public List<GameObject> cardList = new List<GameObject>();

    public void Add(GameObject card, bool animation = true)
    {
        removeFromBelong(card);
        card.transform.SetParent(cards.transform, true);
        cardList.Add(card);
        resetCardsPos(animation ? null : card);
    }

    public void Insert(GameObject card, int index, bool animation = true)
    {
        removeFromBelong(card);
        card.transform.SetParent(cards.transform, true);
        cardList.Insert(index, card);
        resetCardsPos(animation ? null : card);
    }

    public void Remove(GameObject card)
    {
        cardList.Remove(card);
        resetCardsPos();
    }

    void removeFromBelong(GameObject card)
    {
        var belongTo = getBelongTo(card);
        if(belongTo){
            belongTo.Remove(card);
        }
    }


    public void resetCardsPos(GameObject notAnimationItem = null)
    {
        ajustSlots();
        if (ajustSlotCallback != null)
        {
            ajustSlotCallback(slots);
        }
        Canvas.ForceUpdateCanvases();
        moveCards(notAnimationItem);
    }

    void createSlot(Transform parent)
    {
        var slot = new GameObject("slot");
        slot.AddComponent<RectTransform>();
        slot.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
        slot.transform.SetParent(slots.transform, false);
        slot.transform.localScale = Vector3.one;
        slot.transform.localPosition = Vector3.zero;
    }
    void ajustSlots()
    {
        var count = cardList.Count;
        var slotCount = slots.transform.childCount;
        var biggerCount = slotCount > count ? slotCount : count;
        for (var i = 0; i < biggerCount; i++)
        {
            if (i > slotCount - 1)
            {
                createSlot(slots.transform);
            };
            if (i > count - 1)
            {
                DestroyImmediate(slots.transform.GetChild(i).gameObject);
            };
        }
    }
    void moveCards(GameObject notAnimationItem = null)
    {
        var count = cardList.Count;
        for (var i = 0; i < count; i++)
        {
            var card = cardList[i];
            var slot = slots.transform.GetChild(i);
            card.transform.SetSiblingIndex(i);
            if (notAnimationItem == card)
            {
                card.transform.position = slot.position;
                card.transform.localRotation = slot.localRotation;
                card.transform.localScale = slot.localScale;
            }
            else
            {
                card.transform.DOMove(slot.position, 0.5f);
                card.transform.DOLocalRotate(slot.localEulerAngles, 0.5f);
                card.transform.DOScale(slot.localScale, 0.5f);

            }
        }
    }

    AnimateLayout getBelongTo(GameObject card)
    {
        return card.transform.parent?.parent?.GetComponent<AnimateLayout>();
    }
}
