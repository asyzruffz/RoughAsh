using UnityEngine;
using UnityEngine.Events;

namespace RoughAsh
{
    [RequireComponent(typeof(Collider2D))]
    public class Trigger : MonoBehaviour
    {
        [SerializeField]
        bool verbose = false;

        public UnityEvent<GameObject> OnEnter;
        public UnityEvent<GameObject> OnExit;

        Collider2D body;

        void Start()
        {
            body = GetComponent<CapsuleCollider2D>();
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            if (verbose) Debug.Log("Trigger entered");
            OnEnter?.Invoke(collider.gameObject);
        }

        void OnTriggerExit2D(Collider2D collider)
        {
            if (verbose) Debug.Log("Trigger exited");
            OnExit?.Invoke(collider.gameObject);
        }

        void OnTriggerEnter(Collider collider)
        {
            if (verbose) Debug.Log("Trigger entered");
            OnEnter?.Invoke(collider.gameObject);
        }

        void OnTriggerExit(Collider collider)
        {
            if (verbose) Debug.Log("Trigger exited");
            OnExit?.Invoke(collider.gameObject);
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
