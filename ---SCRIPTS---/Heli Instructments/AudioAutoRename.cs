#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Linq;


public class AudioAutoRename : MonoBehaviour
{
    [MenuItem("Tools/Rename Audio Files")]
    static void RenameAudio()
    {
        string path = "Assets/Resources/Audio/Helicopter"; // Replace with the path of your target folder
        string[] files = Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly); // Search for all files in the folder

        int highestNumber = FindHighestNumber(files); // Find the highest number used in the existing audio file names

        int count = highestNumber + 1; // Start counting from the next number

        foreach (string file in files)
        {
            string extension = Path.GetExtension(file).ToLower();
            if (extension == ".meta") continue; // Skip meta files
            if (!IsAudioFile(extension)) continue; // Only process audio files

            string oldName = Path.GetFileNameWithoutExtension(file);

            int underscoreIndex = oldName.IndexOf("_");
            if (underscoreIndex != -1 && int.TryParse(oldName.Substring(0, underscoreIndex), out int number))
            {
                // The audio file name already contains a number, skip it
                continue;
            }

            string newName = count.ToString() + "_" + oldName + extension;
            AssetDatabase.RenameAsset(file, newName);
            count++;
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    static bool IsAudioFile(string extension)
    {
        return extension == ".wav" || extension == ".mp3" || extension == ".ogg" || extension == ".aiff" || extension == ".aac" || extension == ".m4a";
    }

    static int FindHighestNumber(string[] files)
    {
        int highestNumber = 0;

        foreach (string file in files)
        {
            string extension = Path.GetExtension(file).ToLower();
            if (extension == ".meta") continue; // Skip meta files
            if (!IsAudioFile(extension)) continue; // Only process audio files

            string oldName = Path.GetFileNameWithoutExtension(file);

            int underscoreIndex = oldName.IndexOf("_");
            if (underscoreIndex == -1 || !int.TryParse(oldName.Substring(0, underscoreIndex), out int number))
            {
                // The audio file name does not contain a number, skip it
                continue;
            }

            highestNumber = Mathf.Max(highestNumber, number);
        }

        return highestNumber;
    }
}
#endif