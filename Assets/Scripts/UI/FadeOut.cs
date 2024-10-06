using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace RoughAsh
{
    public class FadeOut : MonoBehaviour
    {
        [SerializeField]
        Image img;
        [SerializeField]
        float duration = 1f;
        [Space]
        [SerializeField]
        UnityEvent onDone;

        Color startColor;
        Color transparent;
        bool done = false;

        void Start()
        {
            if (img == null)
            {
                Debug.LogError("FadeOut: Img is null");
                return;
            }

            startColor = img.color;
            transparent = startColor;
            transparent.a = 0;
        }

        void Update()
        {
            if (done) return;

            if (duration <= 0)
            {
                done = true;
                onDone?.Invoke();
            }

            img.color = Color.Lerp(transparent, startColor, duration);
            duration -= Time.deltaTime;
        }
    }
}
