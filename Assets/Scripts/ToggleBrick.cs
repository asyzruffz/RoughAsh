using UnityEngine;

namespace RoughAsh
{
    [RequireComponent(typeof(Collider2D))]
    public class ToggleBrick : MonoBehaviour
    {
        [SerializeField]
        Team team;

        Collider2D body;

        void Start()
        {
            body = GetComponent<BoxCollider2D>();

            var color = GetComponent<ToggleColor>();
            color?.SetColour(team == Team.One);

            UpdateBrick();
        }

        public void SetTeam(bool isTeam1)
        {
            team = isTeam1 ? Team.One : Team.Two;
            UpdateBrick();

            var color = GetComponent<ToggleColor>();
            color?.SetColour(isTeam1);
        }

        public void Toggle()
        {
            team = team == Team.One ? Team.Two : Team.One;
            UpdateBrick();

            var color = GetComponent<ToggleColor>();
            color?.Toggle();
        }

        void UpdateBrick()
        {
            if (body == null) body = GetComponent<BoxCollider2D>();
            body.excludeLayers = LayerMask.GetMask(team == Team.One ? "Team 2" : "Team 1");
        }

        public enum Team { One, Two }
    }
}
