using UnityEditor;
using UnityEngine;

namespace RoughAsh
{
    public class Ender : MonoBehaviour
    {
        public void Exit()
        {
            Invoke("StopPlaying", 1f);
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
