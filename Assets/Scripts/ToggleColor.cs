using UnityEngine;

namespace RoughAsh
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class ToggleColor : MonoBehaviour
    {
        [SerializeField]
        Color color1 = Color.white;
        [SerializeField]
        Color color2 = Color.black;

        SpriteRenderer sprite;

        void Start()
        {
            sprite = GetComponent<SpriteRenderer>();
            sprite.color = color1;
        }

        public void Toggle()
        {
            sprite.color = sprite.color == color1 ? color2 : color1;
        }

        public void SetColour(bool isColor1)
        {
            if (sprite == null) sprite = GetComponent<SpriteRenderer>();
            sprite.color = isColor1 ? color1 : color2;
        }
    }
}
