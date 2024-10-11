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
        bool started = false;
        bool done = false;
        float timer;

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
            if (!started || done) return;

            if (timer <= 0)
            {
                done = true;
                timer = 0;
                onDone?.Invoke();
            }

            img.color = Color.Lerp(transparent, startColor, timer / duration);
            timer -= Time.deltaTime;
        }

        public void StartFade()
        {
            timer = duration;
            started = true;
            done = false;
        }
    }
}
