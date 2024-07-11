using System;
using UnityEngine;

public class Moveable : MonoBehaviour
{
    public float Speed { get; private set; }

    public Vector3 Movement { get; set; }
    public Quaternion Rotation { get; set; }

    private void Start()
    {
        Rotation = transform.rotation;
    }

    public void Setup(float speed)
    {
        this.Speed = speed;
    }

    private void Update()
    {
        transform.Translate(Movement * (Speed * Time.deltaTime), Space.World);
        transform.rotation = Rotation;
    }
}
