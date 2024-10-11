using UnityEngine;

namespace RoughAsh
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Ball : MonoBehaviour
    {
        [SerializeField]
        float speed = 1.0f;

        Rigidbody2D body;
        float gravity;

        void Start()
        {
            body = GetComponent<Rigidbody2D>();
            gravity = body.gravityScale;
            body.gravityScale = 0;
        }

        public void StartMoving()
        {
            body.gravityScale = gravity;
            //Vector2 direction = (new Vector2(1, -1)).normalized;
            Vector2 direction = Random.insideUnitCircle.normalized;
            MoveTowards(direction);
        }

        void MoveTowards(Vector2 direction)
        {
            body.AddForce(direction * speed, ForceMode2D.Impulse);
        }

        public void BoostSpeed(float percent)
        {
            Vector2 direction = body.linearVelocity.normalized;
            MoveTowards(direction * percent);
        }
    }
}
