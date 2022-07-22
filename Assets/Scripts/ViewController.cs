using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ViewController : MonoBehaviour
{
    [Header("Levels")] [SerializeField] private Creator _creator = new Creator();
    private List<GameCard> currentCards;

    [Header("Counter")] [SerializeField] private AnimationCurve animCurve;
    [SerializeField] private TextMeshProUGUI counterText, secondCounterText;
    [SerializeField] private RectTransform Star;
    private int currentCount;

    void Awake()
    {
        currentCards = _creator?.CreateCards(this);
    }

    public void UpdateCount(int points)
    {
        StartCoroutine(UpdateCountRoutine(points));
    }

    IEnumerator UpdateCountRoutine(int points)
    {
        var start = currentCount;
        var end = currentCount + points;
        var startRotation = Star.rotation.eulerAngles;
        var endRotation = startRotation + new Vector3(0, 0, 360);
        float lerpPos = 0f, lerpTime = 0f;
        while (lerpPos <= 0.99f)
        {
            counterText.text = ((int) Mathf.Lerp(start, end, lerpPos)).ToString();
            secondCounterText.text = counterText.text;
            Star.rotation = Quaternion.Euler(Vector3.Lerp(startRotation, endRotation, lerpPos));
            lerpPos = Mathf.Lerp(0, 1, animCurve.Evaluate(lerpTime));
            lerpTime += Time.deltaTime / 2;
            yield return new WaitForEndOfFrame();
        }

        currentCount += points;
    }
}