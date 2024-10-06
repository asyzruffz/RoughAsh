using System.Diagnostics;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace RoughAsh.Recording
{
    public class RecordingMenu
    {
        [MenuItem("Recording/Open Recordings Folder", priority = 0)]
        static void OpenRecordingsFolder()
        {
            string folderPath = Path.Combine(Application.dataPath, "..", "Recordings");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            folderPath = folderPath.Replace(@"/", @"\");
            Process.Start("explorer.exe", folderPath);
        }

        [MenuItem("Recording/Reset Takes", priority = 20)]
        static void ResetTakes()
        {
            Recording.ResetTakes();
        }
    }
}
