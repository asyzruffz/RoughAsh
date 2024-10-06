using UnityEngine;
using UnityEngine.Events;

namespace RoughAsh
{
    public class Health : MonoBehaviour
    {
        [SerializeField]
        int max = 1;
        [SerializeField]
        int value = 1;

        [Space]
        [SerializeField]
        UnityEvent onDeath;

        public void SetMax(int amount)
        {
            max = amount;
            value = max;
        }

        public void TakeDamage(int amount)
        {
            if (value <= 0) return;
            value = Mathf.Clamp(value - amount, 0, max);
            if (value <= 0)
            {
                onDeath?.Invoke();
            }
        }

        public float Unit()
        {
            if (max == 0) return 0f;
            return (float)value / max;
        }
    }
}
