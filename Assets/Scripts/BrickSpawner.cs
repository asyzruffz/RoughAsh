using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.HableCurve;

namespace RoughAsh
{
    public class BrickSpawner : MonoBehaviour
    {
        [SerializeField]
        ToggleBrick brickPrefab;
        [Space]
        [SerializeField]
        int rowPerSide = 1;
        [SerializeField]
        int colPerSide = 1;

        void Start()
        {
            if (brickPrefab == null)
            {
                Debug.LogError("BrickSpawner: Brick Prefab is null");
                return;
            }

            Construct();
        }

        void Construct()
        {
            float brickWidth = 0.5f;
            float brickHeight = 1f;
            float areaHeight = rowPerSide * brickHeight;

            for (int row = 0; row < rowPerSide; row++)
            {
                for (int col = 0; col < colPerSide; col++)
                {
                    float xPos = col * brickWidth + brickWidth / 2;
                    float yPos = row * brickHeight + (brickHeight - areaHeight) / 2;
                    Vector3 pos = new Vector3(xPos, yPos, 0);

                    var brick1 = Instantiate(brickPrefab, transform);
                    brick1.SetTeam(true);
                    brick1.transform.localPosition = pos;

                    pos.Scale(new Vector3(-1f, 1f, 0f));

                    var brick2 = Instantiate(brickPrefab, transform);
                    brick2.SetTeam(false);
                    brick2.transform.localPosition = pos;
                }
            }
        }
    }
}
