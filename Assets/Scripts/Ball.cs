using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace RoughAsh
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Ball : MonoBehaviour
    {
        [SerializeField]
        float speed = 1.0f;

        [Space]
        [SerializeField]
        float haltThreshold = 0.1f;
        [SerializeField]
        float haltWait = 1f;
        [Space]
        public UnityEvent OnHalted;

        Rigidbody2D body;
        float gravity;
        bool halted = true;

        void Start()
        {
            body = GetComponent<Rigidbody2D>();
            gravity = body.gravityScale;
            body.gravityScale = 0;
            halted = true;
        }

        void FixedUpdate()
        {
            if (halted) return;

            if (body.linearVelocity.magnitude <= haltThreshold)
            {
                halted = true;
                StartCoroutine(Halt());
            }
        }

        public void StartMoving()
        {
            body.gravityScale = gravity;
            //Vector2 direction = (new Vector2(1, -1)).normalized;
            Vector2 direction = Random.insideUnitCircle.normalized;
            MoveTowards(direction);
            halted = false;
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

        IEnumerator Halt()
        {
            yield return new WaitForSeconds(haltWait);
            OnHalted?.Invoke();
        }
    }
}
