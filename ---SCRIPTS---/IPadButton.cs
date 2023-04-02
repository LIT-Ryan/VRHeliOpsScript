using UnityEngine;
using UnityEngine.SceneManagement;
using UltimateXR.Avatar;

public class IPadButton : MonoBehaviour
{
    public TriggerAction actionOnTrigger;
    public static float triggerDelay = 0.6f;
    public static float lastTimeTrigger = 0f;

    public static GameObject selectedContract;

    public bool chooseContract_ = false;

    public enum TriggerAction
    {
        StartTutorial,
        FreeFlight,
        Restart,
        Quit,
        MainMenu,
        HomeScreen,
        ContractHomePage,
        Contract,
        ContractAccept,
        Finance,
        Map,
        MarketPlace,
        Setting,
        DoNothing,
        RestartMisson,
        QuitMission,


    }

    public void Update()
    {
        lastTimeTrigger += Time.deltaTime;
    }
    private void Start()
    {
        UxrAvatar myAvatar = UxrAvatar.LocalAvatar;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finger" && lastTimeTrigger >= triggerDelay)
        {
            lastTimeTrigger = 0f;
            UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UltimateXR.Core.UxrHandSide.Right, UltimateXR.Haptics.UxrHapticClipType.Click, 1f);
            
            switch (actionOnTrigger)
            {
                
                //copy content
                //IPadManager.instance.currentPage = IPadManager.Page.;

                case TriggerAction.StartTutorial:
                    IPadManager.instance.currentPage = IPadManager.Page.FlightTraningPage1;
                    TutorialScript.tutorialOn_ = true;
                    break;
                case TriggerAction.FreeFlight:
                    GameManager.freeFlight_ = true;
                    IPadManager.instance.currentPage = IPadManager.Page.MainMenu;
                    break;
                case TriggerAction.Restart:
                    int sceneIndex = SceneManager.GetActiveScene().buildIndex;
                    SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
                    break;
                case TriggerAction.Quit:
                    Quit();
                    break;
                case TriggerAction.MainMenu:
                    IPadManager.instance.currentPage = IPadManager.Page.MainMenu;
                    break;
                case TriggerAction.HomeScreen:
                    IPadManager.instance.currentPage = IPadManager.Page.HomeScreen;
                    //6 icon
                    break;
                case TriggerAction.ContractHomePage:
                    IPadManager.instance.currentPage = IPadManager.Page.ContractHomePage;
                    // comntarct homepage with 3 place holder
                    break;
                case TriggerAction.Contract:
                    IPadManager.instance.currentPage = IPadManager.Page.Contract;
                    // enable contract detail
                    break;
                case TriggerAction.Finance:
                    IPadManager.instance.currentPage = IPadManager.Page.Finance;
                    //enable finance
                    break;
                case TriggerAction.Map:
                    IPadManager.instance.currentPage = IPadManager.Page.Map;
                    //enable map
                    break;
                case TriggerAction.MarketPlace:
                    IPadManager.instance.currentPage = IPadManager.Page.MarketPlace;
                    break;

                case TriggerAction.ContractAccept:
                    IPadManager.instance.currentPage = IPadManager.Page.ContractFailed;
                    break;
                case TriggerAction.QuitMission:
                    break;
                case TriggerAction.RestartMisson:
                    break;
                case TriggerAction.Setting:
                    break;
                case TriggerAction.DoNothing:
                    break;


            }
            IPadManager.instance.ChangePage();

            

            /* COPY
             case TriggerAction.:
                    break;
            */


        }
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void Restart()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

#else
        
#endif
    }



}
