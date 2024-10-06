using UnityEngine;

namespace RoughAsh
{
    [ExecuteInEditMode]
    public class Capsule : MonoBehaviour
    {
        public Color Colour = Color.white;
        [SerializeField]
        float length = 2f;

        bool needUpdate = false;

        void Start()
        {
            Resize();
        }

        void LateUpdate()
        {
            if (needUpdate) Resize();
        }

        void OnValidate()
        {
            needUpdate = true;
        }

        public void FadeColour(float t)
        {
            var sprite = GetComponent<SpriteRenderer>();
            if (sprite)
            {
                sprite.color = Color.Lerp(new Color(0f, 0f, 0f, 0f), Colour, t);
            }
        }

        public void Resize(float size)
        {
            length = size;
            Resize();
        }

        void Resize()
        {
            var sprite = GetComponent<SpriteRenderer>();
            if (sprite)
            {
                sprite.size = new Vector2(1, length);
                sprite.color = Colour;
            }

            var collider = GetComponent<CapsuleCollider2D>();
            if (collider)
            {
                collider.size = new Vector2(1, length);
            }

            needUpdate = false;
        }
    }
}
