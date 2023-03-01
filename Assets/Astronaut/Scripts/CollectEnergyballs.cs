using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CollectEnergyballs : MonoBehaviour
{
    public static int Collected = 0;
    private TextMeshProUGUI EnergyBalls;
    // Start is called before the first frame update
    void Start()
    {
        EnergyBalls = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        EnergyBalls.text = " " +  Collected;
    }
}
