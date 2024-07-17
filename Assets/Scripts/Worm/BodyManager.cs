using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyManager : MonoBehaviour
{
    [SerializeField]
    private GameObject partPrefab;

    [SerializeField]
    private int healthChunk = 20;
    [SerializeField]
    private float waitTime = 1f;
    [SerializeField]
    private float chunkyWait = 3f;

    [SerializeField, Header("Snake Parts")]
    private GameObject head;
    [SerializeField]
    private BodyMovement tail;
    [SerializeField]
    private List<BodyMovement> middleParts = new List<BodyMovement>();

    private bool isCheckingParts = false;

    public event Action<GameObject> OnMiddlePartAdded;

    public List<BodyMovement> MiddleParts => middleParts;

    public void CheckParts(float health)
    {
        if (isCheckingParts) return;
        
        IEnumerator coroutine = PartsCheck(health);
        StartCoroutine(coroutine);       
    }

    private IEnumerator PartsCheck(float health)
    {
       isCheckingParts = true;
       int chunks = (int)health / healthChunk;
       int neededParts = chunks - middleParts.Count;

        while(neededParts != 0)
        {
            if (neededParts > 0)
            {
                AddPart();
                neededParts -= 1;
            }
            else
            {
                DamageFeedback.Instance.Damage();
                neededParts += 1;
                RemovePart();

                yield return new WaitForSeconds(0.35f);
                DamageFeedback.Instance.Damage(true);
            }

            chunks = (int)health / healthChunk;
            neededParts = chunks - middleParts.Count;
            yield return neededParts == 0 ? null : new WaitForSeconds(waitTime);
        }
        isCheckingParts = false;
    }

    private void AddPart()
    {
        BodyMovement part = Instantiate(partPrefab, tail.transform.position, Quaternion.identity).GetComponent<BodyMovement>();
        part.SetUpFollow(middleParts.Count == 0 ? 
            head.transform : middleParts[middleParts.Count - 1].transform);

        tail.SetUpFollow(part.transform);
        middleParts.Add(part);
        part.transform.SetParent(gameObject.transform);
        OnMiddlePartAdded?.Invoke(part.gameObject);
    }

    private void RemovePart()
    {
        tail.SetUpFollow(middleParts.Count > 1 ? 
            middleParts[middleParts.Count - 2].transform : head.transform);

        if (middleParts.Count < 1)
        {
            return;
        }
        BodyMovement removedPart = middleParts[middleParts.Count - 1];
        middleParts.Remove(middleParts[middleParts.Count - 1]);
        Destroy(removedPart.gameObject);
    }
}
