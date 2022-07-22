using UnityEngine;
using UnityEngine.UI;

public class ScrollToLeft : MonoBehaviour
{
    private ScrollRect ScrollRect;
    void Awake() => ScrollRect = GetComponent<ScrollRect>();
    void OnEnable() => ToLeft();
    void ToLeft() => ScrollRect.horizontalNormalizedPosition = 0;
}
