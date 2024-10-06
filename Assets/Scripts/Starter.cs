using RoughAsh.Recording;
using UnityEngine;
using UnityEngine.Events;

namespace RoughAsh
{
    public class Starter : MonoBehaviour
    {
        [SerializeField]
        VideoRecordingManager recording;

        [Space]
        [SerializeField]
        UnityEvent onStart;

        void Start()
        {
            if (recording == null)
            {
                Debug.LogError("Starter: Recording is null");
                return;
            }

            Invoke("StartRecording", 1f);
        }

        void StartRecording()
        {
            recording?.StartRecording();
            Simulate();
        }

        void Simulate()
        {
            onStart?.Invoke();
        }
    }
}
