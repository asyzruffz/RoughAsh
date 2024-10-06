using UnityEditor;
using UnityEditor.Recorder;
using UnityEngine;

namespace RoughAsh.Recording
{
    [CreateAssetMenu(fileName = "Recording", menuName = "Video Recording/Recording")]
    public class Recording : ScriptableObject
    {
        public RecorderControllerSettings ControllerSettings;

        [Space]
        [SerializeField]
        bool isShorts = false;
        public MovieRecorderSettings VideoRecorderSettings;
        public MovieRecorderSettings ShortsRecorderSettings;

        [Space]
        [SerializeField]
        bool verbose = false;

        public bool IsShorts
        {
            get { return isShorts; }
            set
            {
                isShorts = value;

                VideoRecorderSettings.Enabled = !isShorts;
                ShortsRecorderSettings.Enabled = isShorts;
                MainRecorderSettings = isShorts ? ShortsRecorderSettings : VideoRecorderSettings;
            }
        }

        static MovieRecorderSettings MainRecorderSettings;

        void OnEnable()
        {
            IsShorts = isShorts;
        }

        public void Initialize()
        {
            ControllerSettings.AddRecorderSettings(MainRecorderSettings);
            RecorderOptions.VerboseMode = verbose;
        }

        [ContextMenu("Create Settings")]
        void CreateSettingsAsset()
        {
            ControllerSettings = CreateInstance<RecorderControllerSettings>();
            AssetDatabase.CreateAsset(ControllerSettings, "Assets/Settings/Recording/RecorderControllerSettings.asset");

            VideoRecorderSettings = CreateInstance<MovieRecorderSettings>();
            AssetDatabase.CreateAsset(VideoRecorderSettings, "Assets/Settings/Recording/VideoRecorderSettings.asset");
            ShortsRecorderSettings = CreateInstance<MovieRecorderSettings>();
            AssetDatabase.CreateAsset(VideoRecorderSettings, "Assets/Settings/Recording/ShortsRecorderSettings.asset");
            MainRecorderSettings = IsShorts ? ShortsRecorderSettings : VideoRecorderSettings;

            AssetDatabase.SaveAssets();
        }

        [ContextMenu("Reset Takes")]
        public static void ResetTakes()
        {
            MainRecorderSettings.Take = 1;
        }
    }
}
