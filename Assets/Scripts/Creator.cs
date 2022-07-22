using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

[Serializable]
public class Creator
{
    [SerializeField] private GameObject CardPrefab;
    [SerializeField] private Transform CardContainer, LastObject;
    [SerializeField] private CardData[] CardDatas;
    private List<GameCard> Cards = new List<GameCard>();

    [Serializable]
    public struct CardData
    {
        public Sprite Sprite;
        public string Name, NowPoints, AllPoints;
        public int Level;
    }

    public List<GameCard> CreateCards(ViewController viewController)
    {
        foreach (Transform t in CardContainer)
            if (t != LastObject)
                Object.Destroy(t.gameObject);

        Cards.Clear();

        foreach (var data in CardDatas)
        {
            var go = Object.Instantiate(CardPrefab, CardContainer);
            var card = go.GetComponent<GameCard>();
            card.Init(viewController, data.Sprite, data.Name, data.NowPoints, data.AllPoints, data.Level);
            Cards.Add(card);
        }

        LastObject.SetAsLastSibling();
        return Cards;
    }
}