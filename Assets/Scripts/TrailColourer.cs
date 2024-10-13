using UnityEngine;

namespace RoughAsh
{
    [RequireComponent(typeof(TrailRenderer))]
    public class TrailColourer : MonoBehaviour
    {
        [SerializeField]
        SpriteRenderer source;

        TrailRenderer trail;

        void Start()
        {
            trail = GetComponent<TrailRenderer>();

            if (source)
            {
                trail.startColor = source.color;
            }
        }
    }
}
