using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsSphereView : SphereView
{

    [SerializeField]
    private float radius;

    public override GameObject[] GetObjectsInSphere()
    {
        Collider2D[] collisions = Physics2D.OverlapCircleAll(transform.position, radius);
        GameObject[] objects = new GameObject[collisions.Length];
        for (int i = 0; i < collisions.Length; i++)
        {
            objects[i] = collisions[i].gameObject;
        }
        return objects;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
