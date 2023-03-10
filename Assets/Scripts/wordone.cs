using Oculus.Interaction;
using System.Threading;
using UnityEngine;

public class wordone : MonoBehaviour
{
    // word for catalyst

    private bool[] catalyst = new bool[4];
    [SerializeField] private string[] missingLetters = new string[4] {"c", "t", "l", "m"};
    [SerializeField] private MeshRenderer[] lettersAdded = new MeshRenderer[4];
    [SerializeField] private Grabbable[] grabbingObjects = new Grabbable[4];

    private puzzleManager p;

    int count = 0;

    [SerializeField] private voiceControl vc;
    

    
    private void Start()
    {
        setFalseAll();
        p = puzzleManager.Instance;
    }
    

    // when right letter in the right place added and remained
    private void OnTriggerEnter(Collider other)
    {

        for(int i = 0; i < missingLetters.Length; i++)
        {
            if (other.gameObject.CompareTag(missingLetters[i]))
            {
                catalyst[i] = true;
                count += 1;
                playshot();
                Debug.LogError("the letter" + missingLetters[i] + " is found");
                grabbingObjects[i] = other.gameObject.GetComponent<Grabbable>();
               
            }
        }

        Debug.LogError(" Executing as Expected. ");

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

 
        Debug.Log("Ante count for catalyst is :" + count.ToString());

        if(count >= 4)
        {
            Debug.Log("Ante , everything is okay, word completed");
            // start by stopping the letters from being transfered again when picked up
            // p.stopOnSecondGrab(lettersAdded);
            // let the puzzle manager know letter one is completed
            p.setCompleteLetter(0, true);
            // change the material of letter one. 
            // p.changeMaterialCompleted(lettersAdded);
            // play a victory sound for letter one 
            // update the score board if victory is met
            p.updateScoreBoard();
            stopMoving();

            vc.SetActivation(true);



        }
    }

    void stopMoving()
    {
        foreach(Grabbable grab in grabbingObjects)
        {
            grab.TransferOnSecondSelection = false;
        }
    }


    void playshot()
    {
        p.playVictorySoundOne();
    }
}
