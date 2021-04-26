using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceWorm : MonoBehaviour
{
    [SerializeField]
    private int spaceY;

    [SerializeField]
    private Skin spaceSkin;

    private void Update()
    {
        if (transform.position.y >= spaceY && SkinManager.Instance.Current.name != spaceSkin.name)
        {
            SkinManager.Instance.SetSkin(spaceSkin.name);
            SkinManager.Instance.Unlock(spaceSkin.name);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(new Vector3(transform.position.x - 10000, spaceY, 0), new Vector3(transform.position.x + 10000, spaceY, 0));
    }

}
