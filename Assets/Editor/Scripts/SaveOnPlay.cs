using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace RoughAsh
{
    [InitializeOnLoad]
    public class SaveOnPlay
    {
        // static constructor
        static SaveOnPlay()
        {
            EditorApplication.playModeStateChanged += SaveScene;
        }

        static void SaveScene(PlayModeStateChange state)
        {
            if (state == PlayModeStateChange.ExitingEditMode)
            {
                //Debug.Log("Auto-Saving scene before entering Play mode: " + EditorSceneManager.GetActiveScene().name);

                EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
                AssetDatabase.SaveAssets();
            }
        }
    }
}
