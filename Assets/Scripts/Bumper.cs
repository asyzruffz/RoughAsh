using UnityEngine;
using UnityEngine.Events;

namespace RoughAsh
{
    public class Bumper : MonoBehaviour
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
                Debug.LogError("Bumper: No collider component found");
                return;
            }
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (verbose) Debug.Log("Bumper entered");
            OnEnter?.Invoke(collision.gameObject);
        }

        void OnCollisionExit2D(Collision2D collision)
        {
            if (verbose) Debug.Log("Bumper exited");
            OnExit?.Invoke(collision.gameObject);
        }

        void OnCollisionEnter(Collision collision)
        {
            if (verbose) Debug.Log("Bumper entered");
            OnEnter?.Invoke(collision.gameObject);
        }

        void OnCollisionExit(Collision collision)
        {
            if (verbose) Debug.Log("Bumper exited");
            OnExit?.Invoke(collision.gameObject);
        }
    }
}
