using UnityEditor.Recorder;
using UnityEngine;

namespace RoughAsh.Recording
{
    public class VideoRecordingManager : MonoBehaviour
    {
        [SerializeField]
        bool disabled = false;
        [SerializeField]
        Recording settings;
        [SerializeField]
        bool isShorts = false;
        [SerializeField]
        bool recordOnStart = false;

        RecorderController recorder;

        void Start()
        {
            if (disabled) return;
            if (settings == null)
            {
                Debug.LogError("VideoRecordingManager: Settings is null");
                return;
            }

            Initialize();

            if (recordOnStart)
            {
                StartRecording();
            }
        }

        void Initialize()
        {
            settings.IsShorts = isShorts;
            settings.Initialize();
            recorder = new RecorderController(settings.ControllerSettings);
        }

        public void StartRecording()
        {
            if (disabled) return;
            recorder.PrepareRecording();
            recorder.StartRecording();
        }

        public void StopRecording()
        {
            if (disabled) return;
            recorder.StopRecording();
        }

        void OnDisable()
        {
            if (recorder != null && recorder.IsRecording())
            {
                StopRecording();
            }
        }
    }
}
