using UnityEngine;

namespace RoughAsh
{
    public class Rotator2D : MonoBehaviour
    {
        [SerializeField]
        float speed = 1f;

        void Update()
        {
            transform.Rotate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
