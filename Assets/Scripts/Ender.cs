using UnityEditor;
using UnityEngine;

namespace RoughAsh
{
    public class Ender : MonoBehaviour
    {
        [SerializeField]
        float waitTime = 1f;

        public void Exit()
        {
            Invoke("StopPlaying", waitTime);
        }

        void StopPlaying()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
