using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{

    [Header("Line Of Sight")]
    [SerializeField, Range(0, 360)] private float viewAngle = 90;
    [SerializeField] private float viewRadius = 30;
    [SerializeField] private float instantSpotRadius = 5;

    [Header("Objects")]
    [SerializeField] private LayerMask target;

    [Header("Gizmos")]
    [SerializeField] private bool drawGizmos = false;
    [SerializeField] private bool drawLines = true;
    [SerializeField] private bool drawSphere = false; 
    [SerializeField] private bool drawInstantSpotSphere = false;

    public float ViewRadius { get { return viewRadius; } set { viewRadius = value; } }
    public float ViewAngle { get { return viewAngle; } set { viewAngle = value; } }

    public GameObject[] GetObjectsInView()
    {
        var objectsInRange = Physics2D.OverlapCircleAll(transform.localPosition, viewRadius, target);
        List<GameObject> objectsInView = new List<GameObject>();

        foreach (var colliderInrange in objectsInRange)
        {
            GameObject objectInRange = colliderInrange.gameObject;
            if (IsObjectInView(objectInRange))
            {
                objectsInView.Add(objectInRange);
            }
        }

        return objectsInView.ToArray();

    }

    public bool IsObjectInView(GameObject obj)
    {
        return IsObjectInRange(obj, instantSpotRadius) || 
               IsObjectInRange(obj, viewRadius) && IsObjectInAngle(obj) && IsObjectInLayer(obj);
    }

    private bool IsObjectInRange(GameObject obj, float range)
    {
        return (obj.transform.position - transform.position).magnitude < range;
    }

    private bool IsObjectInAngle(GameObject obj)
    {
        var dir = obj.transform.position - transform.position;
        return Vector3.Angle(dir, transform.up) < viewAngle / 2;
    }

    private bool IsObjectInLayer(GameObject obj)
    {
        return target == (target | (1 << obj.gameObject.layer));
    }

    private void OnDrawGizmos()
    {
        if (!drawGizmos)
            return;

        if (drawSphere)
            Gizmos.DrawWireSphere(transform.position, viewRadius);

        if(drawInstantSpotSphere)
            Gizmos.DrawWireSphere(transform.position, instantSpotRadius);

        if (!drawLines)
            return;


        var right = (Quaternion.Euler(0, 0, -viewAngle / 2) * transform.up);
        var left = (Quaternion.Euler(0, 0, viewAngle / 2) * transform.up);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + left, transform.position + left + left.normalized * (viewRadius - 1));
        Gizmos.DrawLine(transform.position + right, transform.position + right + right.normalized * (viewRadius - 1));

    }

    public void SetTargetMask(LayerMask mask)
    {
        target = mask;
    }

}