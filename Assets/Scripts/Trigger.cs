using UnityEngine;
using UnityEngine.Events;

namespace RoughAsh
{
    public class Trigger : MonoBehaviour
    {
        [SerializeField]
        bool verbose = false;

        [Space]
        public UnityEvent<GameObject> OnEnter;
        public UnityEvent<GameObject> OnExit;

        void Start()
        {
            var body2D = GetComponent<Collider2D>();
            var body3D = GetComponent<Collider>();
            if (body2D == null && body3D == null)
            {
                Debug.LogError("Trigger: No collider component found");
                return;
            }
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

            var body = GetComponent<Collider2D>();
            body.isTrigger = true;
        }
    }
}
