using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundCounter : MonoBehaviour {
    [Header("Dynamic")]
    public int round = 1;
    private Text uiText;
    void Start() {
        uiText = GetComponent<Text>();
    }

    void Update()
    {
        uiText.text = "Current Round: " + round.ToString(); //Always starts on round 1
    }
}
