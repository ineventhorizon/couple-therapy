using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Gate : MonoBehaviour
{
    //[SerializeField] List<string> test;
    //false if negative, true if positive
    [SerializeField] GateType status;
    [SerializeField] TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        //Get text at start
        GetText();
    }

    void GetText()
    {
        text.SetText(Random.Range(1, 100).ToString());
        //TODO 
        //Get random text by affiliation
    }
}
