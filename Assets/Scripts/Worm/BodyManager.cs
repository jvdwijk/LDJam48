using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyManager : MonoBehaviour
{
    [SerializeField]
    private GameObject partPrefab;

    [SerializeField]
    private int healthChunk = 20;

    [SerializeField, Header("Snake Parts")]
    private GameObject head;
    [SerializeField]
    private BodyMovement tail;
    [SerializeField]
    private List<BodyMovement> middleParts = new List<BodyMovement>();

    // Should be called on
    public void CheckParts(float health)
    {
        print(health);
        int chunks = (int) health / healthChunk;
        int neededParts = chunks - middleParts.Count;
        if (neededParts == 0) return;
        if (neededParts > 0) AddParts(neededParts);
        else RemoveParts(Mathf.Abs(neededParts));
    }

    
    private void AddParts(int parts)
    {
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
        }
    }

    private void RemoveParts(int parts)
    {
        for (int i = 0; i < parts; i++)
        {
            if (middleParts.Count > 1)
                tail.SetUpFollow(middleParts[middleParts.Count - 2].transform);
            else
                tail.SetUpFollow(head.transform);

            BodyMovement removedPart = middleParts[middleParts.Count - 1];
            middleParts.Remove(middleParts[middleParts.Count - 1]);
            Destroy(removedPart.gameObject);
        }
    }

}
