using System.Threading;
using UnityEngine;

public class wordone : MonoBehaviour
{

    private bool[] catalyst = new bool[4];
    private string[] missingLetters = new string[4] { "c", "t", "l", "m" };
    private GameObject[] lettersAdded = new GameObject[4];

    private puzzleManager p;


    private void Start()
    {
        setFalseAll();
        p = puzzleManager.Instance;
    }


    // when right letter in the right place added and remained
    private void OnTriggerStay(Collider other)
    {

        for(int i = 0; i < missingLetters.Length; i++)
        {
            if (other.gameObject.CompareTag(missingLetters[i]))
            {
                catalyst[i] = true;
            }
        }

        // call check all after any letter is added
        checkAll();
    }

    // when the letter is removed fromm that position. 
    private void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < missingLetters.Length; i++)
        {
            if (other.gameObject.CompareTag(missingLetters[i]))
            {
                catalyst[i] = false;
                lettersAdded[i] = other.gameObject;
            }
        }
    }


    // setting all to false 
    void setFalseAll()
    {
        for(int i = 0; i < catalyst.Length; i++)
        {
            catalyst[i] = false;
        }
    }



    // TODO 
    // this method will later on be called by the voice command when it matches an utterance. 
    void checkAll()
    {
        int count = 0;
        foreach(bool value in catalyst)
        {
            if (value)
            {
                count += 1;
            }
        }

        if(count == 4)
        {
            p.setCompleteLetter(0, true);
        }
    }


    // change material of all gameobjects.
}
