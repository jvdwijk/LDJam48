using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValuablePopupAnimator : MonoBehaviour
{
    private const float LERP_APPROX_ZERO = 0.01f;

    public bool IsAnimating { get; private set; } = false;

    [SerializeField]
    private Image icon;

    [SerializeField]
    private TMPro.TextMeshProUGUI title, price;

    [SerializeField]
    private float lerpSpeed = 10;

    public void ShowPopup(ValuableStats valuable, Action onPopupReady = null)
    {
        IsAnimating = true;
        icon.sprite = valuable.icon;

        title.text = valuable.name;
        price.text = $"{valuable.price} $";

        StartCoroutine(AnimatePopup(onPopupReady));
    }

    private IEnumerator AnimatePopup(Action onPopupReady)
    {
        yield return StartCoroutine(AnimatePivot(1));
        yield return new WaitForSeconds(2);
        yield return StartCoroutine(AnimatePivot(0));
        IsAnimating = false;
        onPopupReady?.Invoke();
    }

    private IEnumerator AnimatePivot(float target)
    {
        RectTransform rTransform = transform as RectTransform;

        while(Mathf.Abs(rTransform.pivot.x - target) > LERP_APPROX_ZERO)
        {
            rTransform.pivot = new Vector2( 
                Mathf.Lerp(rTransform.pivot.x, target, lerpSpeed * Time.deltaTime),
                rTransform.pivot.y
            );
            yield return null;
        }
    }

}
