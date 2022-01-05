using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    //false if negative, true if positive
    [SerializeField] GateType status;
    // Start is called before the first frame update
    void Start()
    {
        //Get text at start
        GetText();
    }

    void GetText()
    {
        //TODO 
        //Get random text by affiliation
    }
}
