using UnityEngine;

namespace RoughAsh
{
    [RequireComponent (typeof(Health))]
    public class DamageOnCollision2D : MonoBehaviour
    {
        Health health;

        void Start()
        {
            health = GetComponent<Health>();
        }

        void OnCollisionEnter2D(Collision2D collision)
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
