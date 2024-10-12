using RoughAsh.Recording;
using System.Collections;
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

            StartCoroutine(StartRecording());
        }

        IEnumerator StartRecording()
        {
            yield return new WaitForSeconds(1f);
            recording?.StartRecording();
            Simulate();
        }

        void Simulate()
        {
            onStart?.Invoke();
        }
    }
}
