using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class AnimateLayout : MonoBehaviour
{
    public GameObject slots;
    public GameObject cards;

    public List<GameObject> cardList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Add(GameObject card, bool animation = true)
    {
        card.transform.SetParent(cards.transform, true);
        cardList.Add(card);
        setBelong(card);
        resetCardsPos(animation ? null : card);
    }

    public void Insert(GameObject card, int index, bool animation = true)
    {
        card.transform.SetParent(cards.transform, true);
        cardList.Insert(index, card);
        setBelong(card);
        resetCardsPos(animation ? null : card);
    }

    public void Remove(GameObject card)
    {
        cardList.Remove(card);
        resetCardsPos();
    }

    void setBelong(GameObject card)
    {
        var item = card.GetComponent<AnimateLayoutItem>();
        if (item != null)
        {
            item.setBelongTo(this);
        }
    }

    void resetCardsPos(GameObject notAnimationItem = null)
    {
        ajustSlots();
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
                Destroy(slots.transform.GetChild(i).gameObject);
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
                card.transform.localRotation = Quaternion.identity;
                card.transform.localScale = Vector3.one;
            }
            else
            {
                card.transform.DOMove(slot.position, 0.5f);
                card.transform.DOLocalRotate(Vector3.zero, 0.5f);
                card.transform.DOScale(Vector3.one, 0.5f);

            }
        }
    }



    // Update is called once per frame
    void Update()
    {

    }
}
