using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScreenManager : MonoBehaviour
{

    private int LERP_DONE_MIN_DIFF = 7;

    [SerializeField]
    private CanvasScaler canvas;

    [SerializeField]
    private float speed = 5;

    private RectTransform rectTransform;

    private Coroutine moveRoutine;

    private void Start()
    {
        rectTransform = (RectTransform)transform;
    }

    public void SelectScreen(int screen)
    {
        if (moveRoutine != null)
            StopCoroutine(moveRoutine);

        moveRoutine = StartCoroutine(GoToTarget(screen));
    }

    private IEnumerator GoToTarget(int screen)
    {
        int current = -(int)rectTransform.anchoredPosition.x;
        int target = screen * (int)canvas.referenceResolution.x;
        while (Mathf.Abs(current - target) > LERP_DONE_MIN_DIFF)
        {
            current = Mathf.RoundToInt(Mathf.Lerp(current, target, speed * Time.deltaTime));
            SetPosition(current);
            yield return null;
        }
        SetPosition(target);
    }

    private void SetPosition(int current)
    {

        var max = rectTransform.anchoredPosition;
        max.x = -current;
        rectTransform.anchoredPosition = max;
       
    }
}
