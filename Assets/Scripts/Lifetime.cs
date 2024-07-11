using UnityEngine;
using UnityEngine.Serialization;

public class Lifetime : MonoBehaviour
{
    [SerializeField] private float _lifeTime;
    void Start()
    {
        Destroy(gameObject, _lifeTime);
    }
}
