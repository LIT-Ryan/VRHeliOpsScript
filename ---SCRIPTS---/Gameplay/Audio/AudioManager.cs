using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField]
    public List<AudioClip> trainingDialogue = new List<AudioClip>(); //Training
    [SerializeField]
    public List<AudioClip> miscDialogue = new List<AudioClip>(); //Misc_Dialogue
    [SerializeField]
    public List<AudioClip> trainingCargoDialogue = new List<AudioClip>(); //Training_Cargo
    [SerializeField]
    public List<AudioClip> helicopter = new List<AudioClip>(); //Helicopter

    public AudioClip collectClip;

    
    private int currentTraningDialogue = 0;
    //private int currentMiscDialogue = 0;
    private int currentTrainingCargoDialogue = 0;
    private int currentHelicopterAudio2 = 0;
    private int currentHelicopterAudio3 = 0;


    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public AudioSource audioSource3;

    

    // Start is called before the first frame update
    void Awake()
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
        
        AudioClip[] audioClipsTraining = Resources.LoadAll<AudioClip>("Audio/Dialogue/Training");
        AudioClip[] audioClipsMisc = Resources.LoadAll<AudioClip>("Audio/Dialogue/Misc_Dialogue");
        AudioClip[] audioClipsTraningCargo = Resources.LoadAll<AudioClip>("Audio/Dialogue/Training_Cargo");
        AudioClip[] audioClipsHelicopter = Resources.LoadAll<AudioClip>("Audio/Helicopter");
        



        foreach (AudioClip clip in audioClipsTraining)
        {
            trainingDialogue.Add(clip);
        }
        foreach (AudioClip clip in audioClipsMisc)
        {
            miscDialogue.Add(clip);
        }
        foreach (AudioClip clip in audioClipsTraningCargo)
        {
            trainingCargoDialogue.Add(clip);
        }
        foreach (AudioClip clip in audioClipsHelicopter)
        {
            helicopter.Add(clip);
        }

        Debug.Log(audioClipsHelicopter);
    }

    void Start()
    {

        audioSource1 = gameObject.AddComponent<AudioSource>();
        audioSource2 = gameObject.AddComponent<AudioSource>();
        audioSource3 = gameObject.AddComponent<AudioSource>();
        audioSource1.enabled = true;
        audioSource2.enabled = true;  // optimize
        audioSource3.enabled = true;

        collectClip = Resources.Load<AudioClip>("Audio/CollectSound");


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (audioSource1.isPlaying)
        {
            audioSource2.volume = 0.2f;
        }
    }

    public void PlayAudio()
    {

    }
    public void NextTrainingDialogue()
    {
        if (currentTraningDialogue+1 < trainingDialogue.Count)
        {
            audioSource1.clip = trainingDialogue[currentTraningDialogue];
            audioSource1.Play();
            currentTraningDialogue++;
        }
        else
        {
            return;
        }

    }
    public void NextTrainingCargoDialogue()
    {
        if (currentTrainingCargoDialogue + 1 < trainingCargoDialogue.Count)
        {
            audioSource1.clip = trainingCargoDialogue[currentTrainingCargoDialogue];
            audioSource1.Play();
            currentTrainingCargoDialogue++;
        }
        else
        {
            return;
        }
    }

    public void PlaySpecificTrainingDialogue( int selectedDialogue)
    {
        currentTraningDialogue = selectedDialogue - 1;
        audioSource1.clip = trainingDialogue[currentTraningDialogue];
        audioSource1.Play();
        currentTraningDialogue++;
    }

    public void PlaySpecificCargoTrainingDialogue(int selectedDialogue)
    {
        currentTrainingCargoDialogue = selectedDialogue - 1;
        audioSource1.clip = trainingCargoDialogue[currentTrainingCargoDialogue];
        audioSource1.Play();
        currentTrainingCargoDialogue++;
    }

    public void NextMiscDialogue()
    {

    }

 

    public void NextHelicopterAudio( int selectedAudio , AudioSource selectedAudioSource )
    {
        if (selectedAudioSource == null)
        {
            
        }
    }

    public void PlayHelicopterAudio(int selectedAudio)
    {
        currentHelicopterAudio2 = selectedAudio - 1;
        audioSource2.clip = helicopter[currentHelicopterAudio2];
        audioSource2.Play();
        currentHelicopterAudio2++;
    }

    public void PlayHelicopterAudioOnce(int selectedAudio)
    {
        currentHelicopterAudio3 = selectedAudio - 1;       
        if (!audioSource3.isPlaying)
        {
            audioSource3.clip = helicopter[currentHelicopterAudio3];
            audioSource3.Play();
            currentHelicopterAudio3++;
        }
        else
        {
            AudioSource additionalAudioSource = gameObject.AddComponent<AudioSource>();
            additionalAudioSource.clip = helicopter[currentHelicopterAudio3];
            additionalAudioSource.Play();
            currentHelicopterAudio3++;
            Destroy(additionalAudioSource, additionalAudioSource.clip.length);

        }
    }

    public void PlayHelicopterAudioOnceLow(int selectedAudio)
    {
        currentHelicopterAudio3 = selectedAudio - 1;
        if (!audioSource3.isPlaying)
        {
            audioSource3.clip = helicopter[currentHelicopterAudio3];
            audioSource3.volume = 0.1f;
            audioSource3.Play();         
            currentHelicopterAudio3++;
        }
        else
        {
            AudioSource additionalAudioSource = gameObject.AddComponent<AudioSource>();
            additionalAudioSource.clip = helicopter[currentHelicopterAudio3];
            additionalAudioSource.volume = 0.1f;
            additionalAudioSource.Play();
            currentHelicopterAudio3++;
            Destroy(additionalAudioSource, additionalAudioSource.clip.length);

        }
    }

    public void PlayCollectSound()
    {
        audioSource3.clip = collectClip;
        audioSource3.Play();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            PlaySpecificTrainingDialogue(5);
        }
    }
}
