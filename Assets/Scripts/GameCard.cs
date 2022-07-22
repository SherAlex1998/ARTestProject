using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameCard : MonoBehaviour
{
    [SerializeField] private Image Icon;
    [SerializeField] private TextMeshProUGUI Name, SecondName, NowPoints, AllPoints;
    private int _currentLevel;
    private ViewController _viewController;

    public void Init(
        ViewController viewController,
        Sprite icon,
        string name,
        string nowPoints,
        string allPoints,
        int currentLevel)
    {
        Icon.sprite = icon;
        Name.text = name;
        SecondName.text = name;
        NowPoints.text = nowPoints;
        AllPoints.text = allPoints;
        _currentLevel = currentLevel;
        _viewController = viewController;
    }

    public void SetLevel()
    {
        var point = int.Parse(NowPoints.text) + 1;
        if (point > int.Parse(AllPoints.text)) return;
        var pointsToCounter = Random.Range(2, 15);
        Debug.Log("Level " + _currentLevel + " is installed and added " + pointsToCounter + " points");
        _viewController.UpdateCount(pointsToCounter);
        NowPoints.text = point.ToString();
    }
}