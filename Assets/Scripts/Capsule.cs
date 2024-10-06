using UnityEngine;

namespace RoughAsh
{
    [ExecuteInEditMode]
    public class Capsule : MonoBehaviour
    {
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
