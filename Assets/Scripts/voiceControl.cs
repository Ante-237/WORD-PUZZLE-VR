using Meta.WitAi.Json;
using Meta.WitAi;
using Oculus.Voice;
using UnityEngine;
using TMPro;


public class voiceControl : MonoBehaviour
{
    [Header("Default States"), Multiline]
    [SerializeField] private string freshStateText = "Try pressing the Activate button and saying \"Make the cube red\"";

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI textArea;
    [SerializeField] private bool showJson;

    [Header("Voice")]
    [SerializeField] private AppVoiceExperience appVoiceExperience;

    // Whether voice is activated
    public bool IsActive => _active;
    private bool _active = false;


    // creating a particle effect 
    [Header(" Particle Effect")]
    [SerializeField] private GameObject particleEffect;

    // Add delegates
    private void OnEnable()
    {
        textArea.text = freshStateText;
        appVoiceExperience.events.OnRequestCreated.AddListener(OnRequestStarted);
        appVoiceExperience.events.OnPartialTranscription.AddListener(OnRequestTranscript);
        appVoiceExperience.events.OnFullTranscription.AddListener(OnRequestTranscript);
        appVoiceExperience.events.OnStartListening.AddListener(OnListenStart);
        appVoiceExperience.events.OnStoppedListening.AddListener(OnListenStop);
        appVoiceExperience.events.OnStoppedListeningDueToDeactivation.AddListener(OnListenForcedStop);
        appVoiceExperience.events.OnStoppedListeningDueToInactivity.AddListener(OnListenForcedStop);
        appVoiceExperience.events.OnResponse.AddListener(OnRequestResponse);
        appVoiceExperience.events.OnError.AddListener(OnRequestError);
    }
    // Remove delegates
    private void OnDisable()
    {
        appVoiceExperience.events.OnRequestCreated.RemoveListener(OnRequestStarted);
        appVoiceExperience.events.OnPartialTranscription.RemoveListener(OnRequestTranscript);
        appVoiceExperience.events.OnFullTranscription.RemoveListener(OnRequestTranscript);
        appVoiceExperience.events.OnStartListening.RemoveListener(OnListenStart);
        appVoiceExperience.events.OnStoppedListening.RemoveListener(OnListenStop);
        appVoiceExperience.events.OnStoppedListeningDueToDeactivation.RemoveListener(OnListenForcedStop);
        appVoiceExperience.events.OnStoppedListeningDueToInactivity.RemoveListener(OnListenForcedStop);
        appVoiceExperience.events.OnResponse.RemoveListener(OnRequestResponse);
        appVoiceExperience.events.OnError.RemoveListener(OnRequestError);
    }

    // Request began
    private void OnRequestStarted(WitRequest r)
    {
        // Store json on completion
        if (showJson) r.onRawResponse = (response) => textArea.text = response;
        // Begin
        _active = true;
    }
    // Request transcript
    private void OnRequestTranscript(string transcript)
    {
        textArea.text = transcript;
    }
    // Listen start
    private void OnListenStart()
    {
        textArea.text = "Listening...";
    }
    // Listen stop
    private void OnListenStop()
    {
        textArea.text = "Processing...";
    }
    // Listen stop
    private void OnListenForcedStop()
    {
        if (!showJson)
        {
            textArea.text = freshStateText;
        }
        OnRequestComplete();
    }
    // Request response
    private void OnRequestResponse(WitResponseNode response)
    {
        if (!showJson)
        {
            if (!string.IsNullOrEmpty(response["text"]))
            {
                textArea.text = "I heard: " + response["text"];
            }
            else
            {
                textArea.text = freshStateText;
            }
        }
        OnRequestComplete();
    }
    // Request error
    private void OnRequestError(string error, string message)
    {
        if (!showJson)
        {
            textArea.text = $"<color=\"red\">Error: {error}\n\n{message}</color>";
        }
        OnRequestComplete();
    }
    // Deactivate
    private void OnRequestComplete()
    {
        _active = false;
    }

    // Toggle activation
    public void ToggleActivation()
    {
        SetActivation(!_active);
    }
    // Set activation
    public void SetActivation(bool toActivated)
    {
        if (_active != toActivated)
        {
            _active = toActivated;
            if (_active)
            {
                appVoiceExperience.Activate();
            }
            else
            {
                appVoiceExperience.Deactivate();
            }
        }
    }


    public void firstword()
    {
        /// instantiate a particle effect. 
    }
}

