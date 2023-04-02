using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CheckBoxManager : MonoBehaviour
{
    public static CheckBoxManager instance;
    [Header("Dialogue TXT File")]
    public TextAsset tutorialCheckAsset;
    [Space]
    [Space]
    private string[] lines;
    public List<string> checkTutorial; //checkbox dialogue for tutorial
    public Dictionary<string, List<string>> chapters = new Dictionary<string, List<string>>();

    [Space]
    public string displayText;
    private string currentChapter = "";
    private int currentListDisplay = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        LoadTutorialText();
    }

    // Update is called once per frame
    void LoadTutorialText()
    {
        tutorialCheckAsset = Resources.Load<TextAsset>("Dialogue/TutorialCheckbox");
        string contents = tutorialCheckAsset.text;
        string[] lines = contents.Split('\n');
        checkTutorial = new List<string>();
        foreach (string line in lines)
        {
            if (line.StartsWith("CASE "))
            {
                currentChapter = line.Trim();
                if (!chapters.ContainsKey(currentChapter))
                {
                    chapters.Add(currentChapter, new List<string>());
                }
            }
            else
            {
                if (currentChapter != "" && chapters.ContainsKey(currentChapter))
                {
                    chapters[currentChapter].Add(line);
                }
            }
        }
        displayText = checkTutorial[currentListDisplay];

    }
}
