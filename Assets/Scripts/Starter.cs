using UnityEngine;

namespace RoughAsh
{
    public class Starter : MonoBehaviour
    {
        [SerializeField]
        Ball ball;

        void Start()
        {
            if (ball == null)
            {
                Debug.LogError("Starter: Ball is null");
                return;
            }
        }

        public void StartSimulating()
        {
            ball.StartMoving();
        }
    }
}
