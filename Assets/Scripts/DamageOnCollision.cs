using UnityEngine;

namespace RoughAsh
{
    [RequireComponent (typeof(Health))]
    public class DamageOnCollision : MonoBehaviour
    {
        Health health;

        void Start()
        {
            health = GetComponent<Health>();
        }

        public void OnCollision(GameObject other)
        {
            health.TakeDamage(1);

            var capsule = GetComponent<Capsule>();
            capsule?.FadeColour(health.Unit());

            var audio = GetComponent<AudioSource>();
            if (audio && audio.enabled)
            {
                audio.Play();
            }
        }
    }
}
