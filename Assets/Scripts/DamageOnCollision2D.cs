using UnityEngine;
using UnityEngine.Events;

namespace RoughAsh
{
    [RequireComponent (typeof(Collider2D), typeof(Health))]
    public class DamageOnCollision2D : MonoBehaviour
    {
        [Space]
        public UnityEvent<GameObject> OnTriggerAfterDeath;

        Collider2D body;
        Health health;

        void Start()
        {
            body = GetComponent<CapsuleCollider2D>();
            health = GetComponent<Health>();
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            health.TakeDamage(1);

            var sprite = GetComponent<SpriteRenderer>();
            if (sprite)
            {
                sprite.color = Color.Lerp(new Color(0f, 0f, 0f, 0f), Color.white, health.Unit());
            }
        }

        void OnTriggerExit2D(Collider2D collision)
        {
            OnTriggerAfterDeath?.Invoke(collision.gameObject);
        }

        public void TurnToTrigger()
        {
            var sprite = GetComponent<SpriteRenderer>();
            if (sprite)
            {
                sprite.enabled = false;
            }

            body.isTrigger = true;
        }
    }
}
