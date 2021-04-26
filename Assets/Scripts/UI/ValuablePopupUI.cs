using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValuablePopupUI : MonoBehaviour
{
    [SerializeField]
    private ValuableKeeper keeper;

    [SerializeField]
    private ValuablePopupAnimator animator;

    private Queue<ValuableStats> valuables = new Queue<ValuableStats>();

    private void Start()
    {
        keeper.OnValuableAdded += (valuable) =>
        {
            if (animator.IsAnimating) {
                valuables.Enqueue(valuable);
                return;
            }

            animator.ShowPopup(valuable, Next);
        };
    }

    public void Next()
    {
        if (valuables.Count == 0)
            return;

        ValuableStats valuable = valuables.Dequeue();
        animator.ShowPopup(valuable, Next);
    }

}
