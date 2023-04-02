using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    [Header("Dialogue TXT File")]
    public TextAsset tutorialTextAsset;
    [Space]
    [Space]
    public List<string> dialogueTutorial; //dialogue for tutorial
    [Space]
    public List<string> otherDialogue = new List<string>();
    public string displayText;

    private int currentListDisplay= 0;

    
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
        tutorialTextAsset = Resources.Load<TextAsset>("Dialogue/TutorialDialogue");
        string contents = tutorialTextAsset.text;
        string[] lines = contents.Split('\n');
        dialogueTutorial = new List<string>();
        foreach (string line in lines)
        {
            dialogueTutorial.Add(line.Trim());
        }
        displayText = dialogueTutorial[currentListDisplay];

    }

    public void NextDialogue()
    {
        if (currentListDisplay +1 < dialogueTutorial.Count)
        {
            currentListDisplay++;
            displayText = dialogueTutorial[currentListDisplay];
        }      
        else
        {
            return;
        }
    }
}
