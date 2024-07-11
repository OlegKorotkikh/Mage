using System;
using UnityEngine;

public class PositionLimiter : MonoBehaviour
{
    [SerializeField] private float XMin;
    [SerializeField] private float XMax;
    [SerializeField] private float ZMin;
    [SerializeField] private float ZMax;

    private void LateUpdate()
    {
        var x = Mathf.Clamp(transform.position.x, XMin, XMax);
        var z = Mathf.Clamp(transform.position.z, ZMin, ZMax);
        transform.position = new Vector3(x, 0, z);
    }
}
