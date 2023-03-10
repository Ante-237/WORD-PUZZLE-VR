using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;
public class puzzleManager : MonoBehaviour
{

    public static puzzleManager Instance;
    // Start is called before the first frame update

    public UnityEvent backgroundSoundEvent;
    public UnityEvent victorySound;

    public bool[] completeLetter = new bool[13];


    [Header("Puzzle Material")]
    private Material m_PuzzleCompleted;


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
    public void changeMaterialCompleted(GameObject[] letter_objects)
    {
        foreach(GameObject obj in letter_objects)
        {
            obj.GetComponentInChildren<MeshRenderer>().material = m_PuzzleCompleted;
        }
    }


    //play victory sound when a puzzle word is complted.
    public void playVictorySoundOne()
    {
        victorySound.Invoke();
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
