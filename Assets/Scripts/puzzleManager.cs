using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class puzzleManager : MonoBehaviour
{

    public static puzzleManager Instance;
    // Start is called before the first frame update


    void Start()
    {
        // play background sound
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void backgroundSound()
    {

    }

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
