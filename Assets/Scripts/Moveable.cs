using UnityEngine;

public class Moveable : MonoBehaviour
{
    private float Speed { get; set; }
    public Vector3 Movement { get; set; }
    public Quaternion Rotation { get; set; }

    private void Start()
    {
        Rotation = transform.rotation;
    }

    public void Setup(float speed)
    {
        Speed = speed;
    }

    private void Update()
    {
        transform.Translate(Movement * (Speed * Time.deltaTime), Space.World);
        transform.rotation = Rotation;
    }
}
