using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UltimateXR.Avatar;

public class TutorialScript : MonoBehaviour
{
    //heli tutorial attitude
    public static bool batteryButtonEnable_ = false;
    public static bool fuelButtonEnable_ = false;
    public static bool engineButtonEnable_ = false;
    public static bool collectiveInputEnable_ = false;
    public static bool pedalInputEnable_ = false;
    public static bool cyclicInputEnable = false;
    public static bool autoHoverButtonEnable = false;

    public static bool collectivePulled_ = false;
    public static bool above100ft_ = false;
    public static bool pedalUsed_ = false;
    public static bool cyclicUsed_ = false;
    public static bool backToHelipad_ = false;
    public static bool readyToFly_ = false;
    [Space]
    //
    public static bool helmetOn_ = false;
    public static bool tutorialOn_ = false;
    public static bool startCheckListOn_ = false;
    public static bool startEngineCheckOn_ = false;
    public static bool controlCheckListOn_ = false;
    public static bool cargoTutorialOn_ = false;
    public static bool overDropOffZone_ = false;
    public static bool dropSuccess_ = false;
    public static bool dropFailed_ = false;
    
    public static int dropSuccessCount_ = 0;
    public static int ringPassedCount = 0;


    private bool audioplayed1_ = false;  //should use int audioPlayed, and if (audioPlayer = x) next time
    private bool audioplayed2_ = false;
    private bool audioplayed3_ = false;
    private bool audioplayed4_ = false;
    private bool audioplayed5_ = false;
    private bool audioplayed6_ = false;
    private bool audioplayed7_ = false;
    private bool audioplayed8_ = false;
    private bool audioplayed9_ = false;
    private bool audioplayed10_ = false;
    private bool audioplayed11_ = false;
    private bool audioplayed12_ = false;
    private bool audioplayed13_ = false;
    private bool audioplayed14_ = false;
    private bool audioplayed15_ = false;
    private bool audioplayed16_ = false;
    private bool audioplayed17_ = false;
    private bool audioplayed18_ = false;

    private bool audioCPlayed1_ = false;
    private bool audioCPlayed2_ = false;
    private bool audioCPlayed3_ = false;
    private bool audioCPlayed4_ = false;
   /* private bool audioCPlayed5_ = false;
    private bool audioCPlayed6_ = false;
    private bool audioCPlayed7_ = false;
    private bool audioCPlayed8_ = false;
   */

    private bool waiting = false;
    private bool cargo1moving_ = false;
    private bool cargo2moving_ = false;
    private bool cargo3moving_ = false;
    private bool cargoComplete_ = false;

    public GameObject cargo1;
    public GameObject cargo2;
    public GameObject cargo3;

    public GameObject cargoDropOff1;
    public GameObject cargoDropOff2;
    public GameObject cargoDropOff3;

    public GameObject heli;
    public Transform spawn;
    //public TextMeshProUGUI tutorialText_;

    [Header("Toogle")]
    public GameObject collectiveT;
    public GameObject pedalT;
    public GameObject cyclicT;
    public GameObject altT;
    public GameObject AltitudeHoldTImg;
    public GameObject cargo1T;
    public GameObject cargo2T;
    public GameObject cargo3T;
    public GameObject cargoCompleteT;

    [Header("Text")]
    public TMP_Text batteryT;
    public TMP_Text fuelT;
    public TMP_Text keyT;
    public TMP_Text areaT;
    public TMP_Text engineT;
    public TMP_Text starterLightT;
    public TMP_Text lowRPMLightT;
    public TMP_Text readyFlyT;
    [Space]
    public TMP_Text ringT;

    private bool fading = false;
    private bool fadeOut = false;
    private float fadeValue = 0;
    private int currentAudio = 0;
    private bool skip = false;
    public static int ringTimer = 0;

    public Animator batteryWwitchAnim;
    public Animator fuelSwitchAnim;
    public Animator startEngineButtonAnim;
    public Animator keyAnim;
    public Animator liftStickAnim;
    public Animator cyclicStickAnim;

    // Start is called before the first frame update
    void Start()
    {
        dropSuccessCount_ = 0;
        cargo1.SetActive(false);
        cargo2.SetActive(false);
        cargo3.SetActive(false);
        cargoDropOff1.SetActive(false);
        cargoDropOff2.SetActive(false);
        cargoDropOff3.SetActive(false);
        collectiveInputEnable_ = false;
        Invoke("StartStatus", 1f);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckList();
        Debug.Log("fuel" + GameManager.fuelOn_);
        Debug.Log("battery" + GameManager.batteryOn_);
        if (GameManager.freeFlight_)
        {
            batteryButtonEnable_ = true;
            fuelButtonEnable_ = true;
            engineButtonEnable_ = true;
            collectiveInputEnable_ = true;
            pedalInputEnable_ = true;
            cyclicInputEnable = true;
            autoHoverButtonEnable = true;
        }
        if (dropSuccessCount_ == 1 && !cargo1T.activeSelf)
        {
            cargo1T.SetActive(true);
            AudioManager.instance.PlaySpecificCargoTrainingDialogue(13);
        }
        else if (dropSuccessCount_ == 2 && !cargo2T.activeSelf)
        {
            cargo2T.SetActive(true);
            AudioManager.instance.PlaySpecificCargoTrainingDialogue(14);
        }
        else if (dropSuccessCount_ == 3 && !cargo2T.activeSelf)
        {
            cargo3T.SetActive(true);
            cargoCompleteT.SetActive(true);
            AudioManager.instance.PlaySpecificCargoTrainingDialogue(15);
            IPadManager.instance.currentPage = IPadManager.Page.MainMenu;
        }
       
        if (fading)
        {
            Fade();
        }
        if (helmetOn_)
        {
            tutorialOn_ = true;
        }
        if (tutorialOn_)
        {
            //ipad dialogue check ride 
            if (!audioplayed1_)
            {
                AudioManager.instance.NextTrainingDialogue();
                audioplayed1_ = true;
                
            }
            else if (!AudioManager.instance.audioSource1.isPlaying && !audioplayed2_ )
            {
     
                AudioManager.instance.NextTrainingDialogue();
                startCheckListOn_ = true;
                audioplayed2_ = true;
            }
        }
        if (startCheckListOn_)
        {
            // toogle check list - Fuel and battery
            fuelButtonEnable_ = true;
            batteryButtonEnable_ = true;
            if (GameManager.batteryOn_ && GameManager.fuelOn_ && GameManager.keyOn_)
            {
                if (!audioplayed3_)
                {
                    
                    AudioManager.instance.NextTrainingDialogue();      
                    audioplayed3_ = true;
                }
                startEngineCheckOn_ = true;
                startCheckListOn_ = false;
            }
        }
        if (startEngineCheckOn_)
        {
            engineButtonEnable_ = true;
            if (GameManager.engineOn_)
            {
                if (!audioplayed4_)
                {
                    //tutorialText_.SetText("Wait until low RPM light goes out");
                    AudioManager.instance.NextTrainingDialogue();
                    audioplayed4_ = true;
                }
                else if (!AudioManager.instance.audioSource1.isPlaying && !audioplayed5_)
                {
                    AudioManager.instance.NextTrainingDialogue();
                    audioplayed5_ = true;
                }
                else if (GameManager.RMP100On_ && !AudioManager.instance.audioSource1.isPlaying && !audioplayed6_)
                {
                    AudioManager.instance.NextTrainingDialogue();
                    readyToFly_ = true;
                    audioplayed6_ = true;
                    controlCheckListOn_ = true;
                    startEngineCheckOn_ = false;
                }
            }
        }
        if (controlCheckListOn_)
        {

            if (!AudioManager.instance.audioSource1.isPlaying && !audioplayed7_)
            {
                IPadManager.instance.currentPage = IPadManager.Page.FlightTraningPage2;
                // ipad UI control check list enable
                collectiveInputEnable_ = true;
                // tutorialText_.SetText("Grab the collective stick with your left hand to control the height of the helicopter, pull up to go up and push down to go down");
                AudioManager.instance.NextTrainingDialogue();
                audioplayed7_ = true;
            }
            else if (!AudioManager.instance.audioSource1.isPlaying && !audioplayed8_)
            {
                AudioManager.instance.NextTrainingDialogue();
                audioplayed8_ = true;

            }
            else if (collectivePulled_ && audioplayed8_ && !audioplayed10_)
            {
                collectiveT.SetActive(true);
                // ipad collective check mark true
                //tutorialText_.SetText("Grab the collective stick with your left hand to control the height of the helicopter, pull up to go up and push down to go down");
                if (!AudioManager.instance.audioSource1.isPlaying && !audioplayed9_)
                {
                    AudioManager.instance.NextTrainingDialogue();
                    audioplayed9_ = true;
                }
                else if (!AudioManager.instance.audioSource1.isPlaying && !audioplayed10_)
                {
                    AudioManager.instance.NextTrainingDialogue();
                    audioplayed10_ = true;
                }
            }
            else if (!AudioManager.instance.audioSource1.isPlaying && collectivePulled_ && audioplayed10_ && !audioplayed12_)
            {
                if (above100ft_ && !AudioManager.instance.audioSource1.isPlaying && collectivePulled_ && !audioplayed11_ && !audioplayed12_)
                {
                    //tutorialText_.SetText("");
                    AudioManager.instance.PlaySpecificTrainingDialogue(11);
                    audioplayed11_ = true;
                }
                else if (!above100ft_ && !AudioManager.instance.audioSource1.isPlaying && collectivePulled_ && !audioplayed12_)
                {
                    // tutorialText_.SetText("Use thumbstick on your right controller to turn the helicopter left or right");
                    AudioManager.instance.PlaySpecificTrainingDialogue(12);
                    pedalInputEnable_ = true;
                    audioplayed12_ = true;
                }
            }
            else if (audioplayed12_ && pedalUsed_ && !AudioManager.instance.audioSource1.isPlaying && !audioplayed14_)
            {
                //ipad UI pedal check mark true
                pedalT.SetActive(true);
                if (!AudioManager.instance.audioSource1.isPlaying && !audioplayed13_)
                {
                    AudioManager.instance.PlaySpecificTrainingDialogue(13);
                    audioplayed13_ = true;
                }
                else if (!AudioManager.instance.audioSource1.isPlaying && !audioplayed14_)
                {
                    //tutorialText_.SetText("Grab the cyclic stick between your leg to control the helicopter flying foward, backward, left and right");
                    AudioManager.instance.PlaySpecificTrainingDialogue(14);
                    cyclicInputEnable = true;
                    audioplayed14_ = true;
                }
            }

            else if (!AudioManager.instance.audioSource1.isPlaying && audioplayed14_ && cyclicUsed_ && !audioplayed15_)
            {
                //cyclic check mark true
                cyclicT.SetActive(true);
                AudioManager.instance.PlaySpecificTrainingDialogue(15);
                audioplayed15_ = true;
                autoHoverButtonEnable = true;
                AltitudeHoldTImg.SetActive(true);

            }
            /*
            else if (!waiting && !AudioManager.instance.audioSource1.isPlaying && audioplayed15_)
            {
                
            }*/




            /* else if (!waiting && audioplayed15_ && !AudioManager.instance.audioSource1.isPlaying && !autoHoverButtonEnable && GameManager.autoHoverOn_ )
             {
                 AudioManager.instance.PlaySpecificTrainingDialogue(16);

             }
            */
            else if (autoHoverButtonEnable && GameManager.autoHoverOn_ && !AudioManager.instance.audioSource1.isPlaying && !audioplayed16_ && audioplayed15_)
            {
                AltitudeHoldTImg.SetActive(false);
                altT.SetActive(true);
                //tutorialText_.SetText("Press again to turn it off");
                AudioManager.instance.PlaySpecificTrainingDialogue(16);
                audioplayed16_ = true;
            }
            else if (autoHoverButtonEnable && !GameManager.autoHoverOn_ && !AudioManager.instance.audioSource1.isPlaying && audioplayed16_ && !audioplayed17_)
            {
                //tutorialText_.SetText("Land back to the helipad");
                AudioManager.instance.PlaySpecificTrainingDialogue(17);
                IPadManager.instance.currentPage = IPadManager.Page.FlightTraningPage3;
                audioplayed17_ = true;
                currentAudio = 17;
                //cargo1moving_ = true;
            }
            else if (!AudioManager.instance.audioSource1.isPlaying && currentAudio < 25f && audioplayed17_ && !skip && ringTimer >= 2)
            {
                ringTimer = 0;
                currentAudio += 1;
                AudioManager.instance.PlaySpecificTrainingDialogue(currentAudio);
            }
            else if (!AudioManager.instance.audioSource1.isPlaying && ringPassedCount == 26 && currentAudio == 25 && !skip)
            {
                GameManager.Fuel = 10f;
                AudioManager.instance.PlaySpecificTrainingDialogue(26);
                currentAudio = 26;
            }
            else if (!AudioManager.instance.audioSource1.isPlaying && currentAudio == 26 && !skip)
            {
                AudioManager.instance.PlaySpecificTrainingDialogue(27);
                currentAudio = 27;
            }
            else if (!AudioManager.instance.audioSource1.isPlaying && !audioCPlayed1_ && currentAudio == 27 && GameManager.Fuel > 70 && !skip)
            {
     
                //set heli and player to position
                //heli.transform.position = spawn.position;
                //heli.transform.rotation = spawn.rotation;
                //spawn 3 cargo
                // fading = true;
                cargo1.SetActive(true);
                cargo2.SetActive(true);
                cargo3.SetActive(true);
                cargoDropOff1.SetActive(true);
                cargoDropOff2.SetActive(true);
                cargoDropOff3.SetActive(true);
                IPadManager.instance.currentPage = IPadManager.Page.FlightTraningPage4;
                // ipad UI cargo training enable
                AudioManager.instance.PlaySpecificCargoTrainingDialogue(1);
                audioCPlayed1_ = true;
                currentAudio = 1;
                skip = true;
            }
            else if (!AudioManager.instance.audioSource1.isPlaying && currentAudio < 3 && currentAudio >= 1)
            {
                currentAudio += 1;
                AudioManager.instance.PlaySpecificCargoTrainingDialogue(currentAudio);
            }
            else if (!AudioManager.instance.audioSource1.isPlaying && currentAudio == 3 && Altimeter.height >= 20f)
            {
                currentAudio = 4;
                AudioManager.instance.PlaySpecificCargoTrainingDialogue(currentAudio);
            }
            else if (!AudioManager.instance.audioSource1.isPlaying && currentAudio == 4 && GameManager.hookOn_)
            {
                currentAudio = 5;
                AudioManager.instance.PlaySpecificCargoTrainingDialogue(currentAudio);
            }
            else if (!AudioManager.instance.audioSource1.isPlaying && currentAudio == 5)
            {
                currentAudio = 6;
                AudioManager.instance.PlaySpecificCargoTrainingDialogue(currentAudio);
            }
            else if (!AudioManager.instance.audioSource1.isPlaying && currentAudio == 6)
            {
                currentAudio = 7;
                AudioManager.instance.PlaySpecificCargoTrainingDialogue(currentAudio);
            }
            else if (!AudioManager.instance.audioSource1.isPlaying && GameManager.cargoOn_ && currentAudio == 7)
            {
                currentAudio = 8;
                AudioManager.instance.PlaySpecificCargoTrainingDialogue(currentAudio);
            }
            else if (!AudioManager.instance.audioSource1.isPlaying && GameManager.cargoOn_ && currentAudio == 8)
            {
                currentAudio = 9;
                AudioManager.instance.PlaySpecificCargoTrainingDialogue(currentAudio);
            }
            else if (!AudioManager.instance.audioSource1.isPlaying && dropSuccess_ && currentAudio == 9)
            {
                currentAudio = 10;
                AudioManager.instance.PlaySpecificCargoTrainingDialogue(currentAudio);
            }

            /*else if (backToHelipad_ && audioplayed17_ && !AudioManager.instance.audioSource1.isPlaying)
            {
                cargoTutorialOn_ = true;*/
            /*
            AudioManager.instance.PlaySpecificTrainingDialogue(18);
            audioplayed18_ = true;
            cargo1moving_ = true;
            */

            /*else if (audioplayed17_ && !AudioManager.instance.audioSource1.isPlaying && !waiting)
            {
                // ipad ui start cargo training
                if (!audioplayed18_)
                {
                    StartCoroutine(WaitToPlay(5, 18));
                    audioplayed18_ = true;
                }
                else
                {
                    StartCoroutine(WaitToPlay(20, 18));
                }
            
                

            }*/
        }

            
            /*
            else if (!AudioManager.instance.audioSource1.isPlaying && !audioCPlayed2_)
            {
                tutorialText_.SetText("The cargo hook is already connected to the helicopter, fly over the cargo to connect the cargo");
                AudioManager.instance.PlaySpecificCargoTrainingDialogue(2);
                audioCPlayed2_ = true;
            }
            else if (!AudioManager.instance.audioSource1.isPlaying && audioCPlayed2_ && GameManager.cargoOn_ && !audioCPlayed3_)
            {
                tutorialText_.SetText("Fly to the drop-off zone on the runway, then pulling the trigger on right controller to release the cargo");
                AudioManager.instance.PlaySpecificCargoTrainingDialogue(3);
                audioCPlayed3_ = true;
            }
            else if (!AudioManager.instance.audioSource1.isPlaying && audioCPlayed3_ /*&& overDropOffZone_* && !audioCPlayed4_)
            {
                AudioManager.instance.PlaySpecificCargoTrainingDialogue(4);
                audioCPlayed4_ = true;
            }
            else if (!AudioManager.instance.audioSource1.isPlaying && audioCPlayed4_ && !GameManager.cargoOn_ )
            {
                if (dropSuccess_ && !AudioManager.instance.audioSource1.isPlaying && cargo1moving_)
                {
                    tutorialText_.SetText("Do the same to the others");
                    AudioManager.instance.PlaySpecificCargoTrainingDialogue(5);
                    cargo1moving_ = false;
                    cargo2moving_ = true;
                    dropSuccess_ = false;
                }*/
            /*else if (dropFailed_ && !AudioManager.instance.audioSource1.isPlaying && cargo1moving_)
            {
                AudioManager.instance.PlaySpecificCargoTrainingDialogue(6);
                dropFailed_ = false;
            }
            if (dropSuccess_ && !AudioManager.instance.audioSource1.isPlaying && cargo2moving_)
            {
                AudioManager.instance.PlaySpecificCargoTrainingDialogue(7);
                cargo2moving_ = false;
                cargo3moving_ = true;
                dropSuccess_ = false;
            }
            else if (dropFailed_ && !AudioManager.instance.audioSource1.isPlaying && cargo2moving_)
            {
                AudioManager.instance.PlaySpecificCargoTrainingDialogue(6);
                dropFailed_ = false;
            }
            if (dropSuccess_ && !AudioManager.instance.audioSource1.isPlaying && cargo3moving_)
            {
                AudioManager.instance.PlaySpecificCargoTrainingDialogue(8);
                cargo3moving_ = false;
                cargoComplete_ = true;
                dropSuccess_ = false;
            }
            else if (dropFailed_ && !AudioManager.instance.audioSource1.isPlaying && cargo3moving_)
            {
                AudioManager.instance.PlaySpecificCargoTrainingDialogue(6);
                dropFailed_ = false;
            }



        }*/

        


    }

    private IEnumerator WaitToPlay( float second, int audioToPlay)
    {
        waiting = true;
        yield return new WaitForSeconds(second);
        //tutorialText_.SetText("Press the red button on the left of panel to turn on auto hover");
        AudioManager.instance.PlaySpecificTrainingDialogue(audioToPlay);
        waiting = false;


    }

    public void Fade()
    {
        UxrAvatar.LocalAvatar.CameraFade.EnableFadeColor(Color.black, fadeValue);
        
        if (fadeValue < 1.5f && !fadeOut)
        {
            fadeValue += Time.deltaTime * 1;
            
        }
        else
        {
            fadeOut = true;
            fadeValue -= Time.deltaTime * 1;
        }
        if (fadeValue <= 0)
        {
            fading = false;
        }
    }

    public void StartStatus()
    {
        if (GameManager.skipTutorial)
        {
            batteryButtonEnable_ = true;
            fuelButtonEnable_ = true;
            engineButtonEnable_ = true;
            collectiveInputEnable_ = true;
            pedalInputEnable_ = true;
            cyclicInputEnable = true;
            autoHoverButtonEnable = true;
        }
        else if (!GameManager.skipTutorial)
        {
            batteryButtonEnable_ = false;
            fuelButtonEnable_ = false;
            engineButtonEnable_ = false;
            collectiveInputEnable_ = false;
            pedalInputEnable_ = false;
            cyclicInputEnable = false;
            autoHoverButtonEnable = false;
        }
    }
    public void CheckList()
    {
        if (ringPassedCount >= 27)
        {
            ringT.text = ("RINGS           <color=green>" + ringPassedCount + "</color><color=green>/27</color>");
        }
        else
        {
            ringT.text = ("RINGS           <color=red>" + ringPassedCount + "</color><color=green>/27</color>");
        }
       

        if (GameManager.batteryOn_)
        {
            ChangeColor(batteryT);
        }
        if (GameManager.fuelOn_)
        {
            ChangeColor(fuelT);
        }
        if (GameManager.keyOn_)
        {
            ChangeColor(keyT);
        }
        if (GameManager.batteryOn_ && GameManager.fuelOn_ && GameManager.keyOn_)
        {
            ChangeColor(areaT);
        }
        if (GameManager.engineOn_)
        {
            ChangeColor(engineT);
            ChangeColor(starterLightT);
        }
        if (GameManager.RMP100On_)
        {
            ChangeColor(lowRPMLightT);
        }
        if (GameManager.fuelOn_)
        {
            ChangeColor(fuelT);
        }
        if (readyToFly_)
        {
            ChangeColor(readyFlyT);
        }

    }
    public void ChangeColor(TMP_Text textMesh)
    {
        textMesh.color = Color.green;
    }
}
