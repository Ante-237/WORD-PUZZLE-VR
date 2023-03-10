using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lettersChecker : MonoBehaviour
{
    

    private Dictionary<int, string> _letters = new Dictionary<int, string>();


    private void Start()
    {
        
    }













    void createDisctionary()
    {
        _letters.Add(1, "CATALYST");
        _letters.Add(2, "INCISION");
        _letters.Add(3, "MILLION");
        _letters.Add(4, "PRECISE");
        _letters.Add(5, "DETER");
        _letters.Add(6, "LUMPS");
        _letters.Add(7, "SMILE");
        _letters.Add(8, "DRUGS");
        _letters.Add(9, "CREAM");
        _letters.Add(10, "PEARL");
        _letters.Add(11, "BEADS");
        _letters.Add(12, "CONVICT");
    }
}
