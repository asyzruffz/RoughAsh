using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

namespace RoughAsh
{
    public class Enclosure : MonoBehaviour
    {
        [SerializeField]
        Capsule wallPrefab;
        [Space]
        [SerializeField]
        float radius = 2f;
        [SerializeField]
        float thickness = 0.2f;
        [SerializeField]
        [Range(3, 10)]
        int segment = 4;
        [SerializeField]
        int integrity = 5;
        [SerializeField]
        Color colour = Color.white;
        [SerializeField]
        AudioResource sound;

        [Space]
        [SerializeField]
        UnityEvent<GameObject> onBreached;

        void Start()
        {
            if (wallPrefab == null)
            {
                Debug.LogError("Enclosure: Wall Prefab is null");
                return;
            }

            Construct();
        }

        void Construct()
        {
            float angleSegment = 2 * Mathf.PI / segment;
            float length = 2 * radius / Mathf.Tan((Mathf.PI - angleSegment) / 2f);
            length = length / thickness + 1;

            for (int i = 0; i < segment; i++)
            {
                var wallSegment = Instantiate(wallPrefab, transform);
                wallSegment.Colour = colour;
                wallSegment.Resize(length);

                float angle = angleSegment * i;
                Vector3 scale = new Vector3(thickness, thickness, 1f);
                Vector3 position = new Vector2(radius * Mathf.Cos(angle), radius * Mathf.Sin(angle));
                Quaternion rotation = Quaternion.Euler(Vector3.forward * angle * Mathf.Rad2Deg);

                wallSegment.transform.localPosition = position;
                wallSegment.transform.localRotation = rotation;
                wallSegment.transform.localScale = scale;

                var health = wallSegment.GetComponent<Health>();
                health?.SetMax(integrity);

                var audio = wallSegment.GetComponent<AudioSource>();
                if (audio)
                {
                    audio.resource = sound;
                }

                var dmg = wallSegment.GetComponent<DamageOnCollision2D>();
                if (dmg)
                {
                    dmg.OnTriggerAfterDeath.RemoveListener(Breached);
                    dmg.OnTriggerAfterDeath.AddListener(Breached);
                }
            }
        }

        void Breached(GameObject obj)
        {
            onBreached?.Invoke(obj);
        }

        public void SelfDestruct()
        {
            Destroy(gameObject);
        }
    }
}
