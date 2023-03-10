using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using Oculus.Interaction;

public class puzzleManager : MonoBehaviour
{

    public static puzzleManager Instance;
    // Start is called before the first frame update

    public UnityEvent backgroundSoundEvent;
    public UnityEvent victorySound;

    public bool[] completeLetter = new bool[13];


    [Header("Puzzle Material")]
    [SerializeField] private Material m_PuzzleCompleted;


    [Header("Score Board")]
    public TextMeshProUGUI scoreBoard;

    [Header("Word List")]
    public List<TextMeshProUGUI> wordsCancel = new List<TextMeshProUGUI>();



    void Start()
    {
        // play background sound
        setAllFalse();
        // event for starting background music. 
        backgroundSoundEvent?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // empty for now no use
    public void backgroundSound()
    {

    }


    // start default setting everything to false 
    void setAllFalse()
    {
        for(int i = 0; i < completeLetter.Length; i++)
        {
            completeLetter[i] = false;
        }
    }


    // set letters complete
    public void setCompleteLetter(int index, bool value)
    {
        completeLetter[index] = value;
    }


    // get letters complete
    public bool  getCompleteLetter(int index)
    {
        return completeLetter[index];
    }


    // loop through list of gameobjects and changed their material if the puzzle was completed. 
    public void changeMaterialCompleted(MeshRenderer[] letter_objects)
    {
        foreach(MeshRenderer obj in letter_objects)
        {
            obj.GetComponentInChildren<MeshRenderer>().material = m_PuzzleCompleted;
        }
    }

    // when the steps are completed, make the object not movable. 
    public void stopOnSecondGrab(GameObject[] object_data)
    {
       foreach(GameObject obj in object_data)
        {
            obj.GetComponent<Grabbable>().TransferOnSecondSelection = false;
        }
    }


    //play victory sound when a puzzle word is complted.
    public void playVictorySoundOne()
    {
        victorySound?.Invoke();
    }

    // update the score board for letters formed
    public void updateScoreBoard()
    {
        if(scoreBoard != null)
        {
            scoreBoard.text = "<color=yellow> SCORE : </yellow>" + getPointCount().ToString();
            cancelIfcomplete();
        }
    }

    // calculate the points by checking the number of active letters completed. 
    int getPointCount()
    {
        int score = 0;
        foreach(bool com in completeLetter)
        {
            if (com)
            {
                score += 0;
            }
        }

        return score;
    }

    // when a word is complete , crossing the word. 
    public void cancelIfcomplete()
    {
        for(int i = 0; i < completeLetter.Length; i++)
        {
            if (completeLetter[i])
            {
                string presentNow = wordsCancel[i].text;
                wordsCancel[i].text = "<color=red><s>" + presentNow + "</s></color>";
            }
        }
    }

    // singleton pattern
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
}
