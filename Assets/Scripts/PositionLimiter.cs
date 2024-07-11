using System;
using UnityEngine;
using UnityEngine.Serialization;

public class PositionLimiter : MonoBehaviour
{
    [SerializeField] private float _xMin;
    [SerializeField] private float _xMax;
    [SerializeField] private float _zMin;
    [SerializeField] private float _zMax;

    private void LateUpdate()
    {
        var x = Mathf.Clamp(transform.position.x, _xMin, _xMax);
        var z = Mathf.Clamp(transform.position.z, _zMin, _zMax);
        transform.position = new Vector3(x, 0, z);
    }
}
