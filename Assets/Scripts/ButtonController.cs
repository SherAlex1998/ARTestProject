using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonController : MonoBehaviour
{
    [SerializeField] private ScrollRect _scrollRect;
    [SerializeField, Range(-0.6f, 1.6f)] private float HidePositon, Trashhold;
    [SerializeField, Range(-2f, 2f)] private float MoveSize;
    [SerializeField] private AnimationCurve _animationCurve;
    [SerializeField] private GameObject arrow;

    private Button button;
    private float temp, tempTrashhold;
    private bool trashholdChanged;

    void Awake()
    {
        button = GetComponent<Button>();
    }

    void OnEnable()
    {
        trashholdChanged = false;
    }

    public void ChangePositionOfScrollRect()
    {
        StopCoroutine(Routine());
        StartCoroutine(Routine());
    }

    IEnumerator Routine()
    {
        var changePos = 0.01f;
        var moveSize = MoveSize / (_scrollRect.content.childCount + 2);
        var startPos = _scrollRect.horizontalNormalizedPosition;
        while (changePos <= 0.99f)
        {
            _scrollRect.horizontalNormalizedPosition = 
                startPos + Mathf.Lerp(0, moveSize, _animationCurve.Evaluate(changePos));
            changePos += Time.deltaTime * 2;
            yield return new WaitForEndOfFrame();
        }
    }

    void Update()
    {
        if (!trashholdChanged)
        {
            trashholdChanged = true;
            tempTrashhold = Trashhold / _scrollRect.content.childCount + 0.2f;
        }

        temp = Math.Abs(_scrollRect.horizontalNormalizedPosition - HidePositon);
        if (temp > tempTrashhold)
        {
            if (!button.interactable)
            {
                button.interactable = true;
                arrow.SetActive(true);
            }
        }
        else
        {
            if (button.interactable) button.interactable = false;
            {
                arrow.SetActive(false);
            }
        }
    }
}