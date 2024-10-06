using UnityEngine;
using UnityEngine.Events;

namespace RoughAsh
{
    public class Trigger : MonoBehaviour
    {
        [SerializeField]
        bool verbose = false;

        public UnityEvent onEnter;
        public UnityEvent onExit;

        void OnTriggerEnter2D(Collider2D collider)
        {
            if (verbose) Debug.Log("Trigger entered");
            onEnter?.Invoke();
        }

        void OnTriggerExit2D(Collider2D collider)
        {
            if (verbose) Debug.Log("Trigger exited");
            onExit?.Invoke();
        }

        void OnTriggerEnter(Collider collider)
        {
            if (verbose) Debug.Log("Trigger entered");
            onEnter?.Invoke();
        }

        void OnTriggerExit(Collider collider)
        {
            if (verbose) Debug.Log("Trigger exited");
            onExit?.Invoke();
        }
    }
}
