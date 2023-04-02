using UnityEngine;
using System.Collections.Generic;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
#if UNITY_EDITOR
    [Separator]
#endif
    [Header("Set the Maximum FPS")]
    public FPSSelect fpsSelect;
    public GPU_CPU gpuCpu;
    public DefaultTexture defaultTexture;
    public SkipTutorial ManualSkipTutorial;

    /*private Animator gaugeLight1Anim_;
    private Animator gaugeLight2Anim_;*/

    [Header("HeliAttitude")]
    public static bool keyOn_ = false;
    public static bool startingEngine_ = true;
    public static bool batteryOn_ = false;
    public static bool fuelOn_ = false;
    public static bool engineOn_ = false;
    public static bool collectiveOn_ = false;
    public static bool pedalOn_ = false;
    public static bool cyclicOn_ = false;
    public static bool autoHoverOn_ = false;
    public static bool RMP100On_ = false;
    public static bool cargoOn_ = false;
    public static bool hookOn_ = false;
    public static bool freeFlight_ = false;
    public static bool skipTutorial = true;

    public List<Animator> instrucmentAnimList;

    public Animator batteryAnim;
    //public Animator batteryAnim2;
    public GameObject hook;

    public static float Fuel = 75f;


    public enum FPSSelect
    {
        FPS_72,
        FPS_80,
        FPS_90
    }

    public enum GPU_CPU
    {
        Max,
        Min,
    }

    public enum DefaultTexture
    {
        Off,
        Low,
        Medium,
        High,
        HighTop,
        Max,

    }
    public enum SkipTutorial
    {
        Yes,
        No,
    }

    [Space]
#if UNITY_EDITOR
    [Separator]
#endif
    [Header("Test")]
    
    public float floattest;
    
    // Start is called before the first frame update
    void Start()
    {
        /* GameObject gauagePlates_new = GameObject.Find("gauagePlates_new"); 
         gaugeLight1Anim_ = gauagePlates_new.GetComponent<Animator>();
         GameObject HeadingDial_new = GameObject.Find("HeadingDial_new");
         gaugeLight2Anim_ = HeadingDial_new.GetComponent<Animator>();*/



        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        switch (fpsSelect)     //select max fps base on selection on enum inspector
        {
            case FPSSelect.FPS_72:
                break;
            case FPSSelect.FPS_80:
                OVRPlugin.systemDisplayFrequency = 80.0f;
                break;
            case FPSSelect.FPS_90:
                OVRPlugin.systemDisplayFrequency = 90.0f;
                break;
        }

        switch (gpuCpu)
        {
            case GPU_CPU.Max:
                OVRManager.suggestedGpuPerfLevel = OVRManager.ProcessorPerformanceLevel.Boost;
                OVRManager.suggestedCpuPerfLevel = OVRManager.ProcessorPerformanceLevel.Boost;
                break;
            case GPU_CPU.Min:
                break;
        }

        switch (defaultTexture)
        {
            case DefaultTexture.HighTop:
                OVRManager.foveatedRenderingLevel = OVRManager.FoveatedRenderingLevel.HighTop;
                break;
            case DefaultTexture.High:
                OVRManager.foveatedRenderingLevel = OVRManager.FoveatedRenderingLevel.High;
                break;
            case DefaultTexture.Medium:
                OVRManager.foveatedRenderingLevel = OVRManager.FoveatedRenderingLevel.Medium;
                break;
            case DefaultTexture.Low:
                OVRManager.foveatedRenderingLevel = OVRManager.FoveatedRenderingLevel.Low;
                break;
            case DefaultTexture.Off:
                OVRManager.foveatedRenderingLevel = OVRManager.FoveatedRenderingLevel.Off;
                break;
            case DefaultTexture.Max:
                QualitySettings.masterTextureLimit = 0;
                Debug.Log(QualitySettings.masterTextureLimit);
                break;

        }

        switch (ManualSkipTutorial)
        {
            case SkipTutorial.Yes: skipTutorial = true;
                break;
            case SkipTutorial.No: skipTutorial = false;
                break;
        }
    }
    private void FixedUpdate()
    {
        if (batteryOn_)
        {
            foreach (Animator animator in instrucmentAnimList)
            {
                animator.SetBool("BatteryOn", true);
            }
        }
        else
        {
            foreach (Animator animator in instrucmentAnimList)
            {
                animator.SetBool("BatteryOn", false);
            }
        }
        //hook.SetActive(hookOn_);
    }

    /*private void ChangeEmissionIntensity(float targetIntensity, float duration)
    {
        float emissionIntensity = panelMaterial.GetColor("_EmissionColor").r;
        float currentLerpTime = 0.0f;

        if (emissionIntensity < targetIntensity)
        {
            currentLerpTime += Time.deltaTime;
            emissionIntensity = Mathf.Lerp(0.0f, targetIntensity, currentLerpTime / duration);
            panelMaterial.SetColor("_EmissionColor", new Color(emissionIntensity, emissionIntensity, emissionIntensity));
        }
    }*/
    // Update is called once per frame
    public void EventTrigger( string eventType)
    {
        if (eventType == "NextDialogue")
        {

        }
    }
    void OnGUI()
    {
        Event currentEvent = Event.current;
        HandleKeyboardInput(currentEvent);
    }
    void HandleKeyboardInput(Event currentEvent)
    {
        switch (currentEvent.keyCode)
        {
            case KeyCode.Q :
                batteryOn_ = true;
                break;
            case KeyCode.W:
                fuelOn_ = true;
                break;
            case KeyCode.E:
                engineOn_ = true;
                break;
            case KeyCode.R:
                collectiveOn_ = true;
                break;
            case KeyCode.T:
                pedalOn_ = true;
                break;
            case KeyCode.Y:
                cyclicOn_ = true;
                break;
            case KeyCode.U:
                autoHoverOn_ = true;
                break;
            case KeyCode.I:
                RMP100On_ = true;
                break;
            case KeyCode.O:
                break;
            case KeyCode.P:
                break;

        }
    }


}
