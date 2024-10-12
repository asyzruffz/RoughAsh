using TMPro;
using UnityEngine;

namespace RoughAsh
{
    public class Speedometer : MonoBehaviour
    {
        [SerializeField]
        Rigidbody2D body;

        void Start()
        {
            if (body == null)
            {
                Debug.LogError("Speedometer: Body is null");
                return;
            }
        }

        void FixedUpdate()
        {
            float speed = body.linearVelocity.magnitude;

            var display = GetComponent<TMP_Text>();
            if (display)
            {
                display.text = speed.ToString("G");
            }
        }
    }
}
