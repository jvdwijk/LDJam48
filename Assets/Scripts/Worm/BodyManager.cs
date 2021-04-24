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

    // Should be called on
    public void CheckParts(float health)
    {
        int chunks = (int) health / healthChunk;
        int neededParts = chunks - middleParts.Count;
        if (isCheckingParts || neededParts == 0) return;

        IEnumerator coroutine;
        if (neededParts > 0)
        {
            if (health % healthChunk < chunkyWait)
                neededParts -= 1;
            coroutine = AddParts(neededParts);
        }
        else
        {
            coroutine = RemoveParts(Mathf.Abs(neededParts));
        }

        StartCoroutine(coroutine);
    }

    
    private IEnumerator AddParts(int parts)
    {
        isCheckingParts = true;
        
        for (int i = 0; i < parts; i++)
        {
            BodyMovement part = Instantiate(partPrefab, tail.transform.position, Quaternion.identity).GetComponent<BodyMovement>();
            if(middleParts.Count == 0)
                part.SetUpFollow(head.transform);
            else
                part.SetUpFollow(middleParts[middleParts.Count -1].transform);
            tail.SetUpFollow(part.transform);
            middleParts.Add(part);
            part.transform.SetParent(gameObject.transform);

            yield return new WaitForSeconds(waitTime);
        }
        isCheckingParts = false;
    }

    private IEnumerator RemoveParts(int parts)
    {
        print("hello");
        isCheckingParts = true;
        for (int i = 0; i < parts; i++)
        {
            if (middleParts.Count > 1)
                tail.SetUpFollow(middleParts[middleParts.Count - 2].transform);
            else
                tail.SetUpFollow(head.transform);

            BodyMovement removedPart = middleParts[middleParts.Count - 1];
            middleParts.Remove(middleParts[middleParts.Count - 1]);
            Destroy(removedPart.gameObject);

            yield return new WaitForSeconds(waitTime);
        }
        isCheckingParts = false;
    }

}
