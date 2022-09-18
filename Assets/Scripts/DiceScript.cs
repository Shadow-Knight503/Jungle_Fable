using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiceScript : MonoBehaviour {
    public Rigidbody Rb;
    public bool Thrown;
    public bool Landed;
    public Vector3 InitPos;
    public int DiceVal;
    public DiceCheck[] DiceVals;
    public TextMeshProUGUI DiceTxt;
    

    // Start is called before the first frame update
    void Start() {
        InitPos = transform.position;
        Rb.useGravity = false;
    }

    // Update is called once per frame
    void Update() {
        if (Rb.IsSleeping() && !Landed && Thrown) {
            Landed = true;
            Rb.useGravity = false; 
        } else if (Rb.IsSleeping() && Landed && DiceTxt.text == "0") {
            ResetDice();
            RollDice();
        }
    }

    public void RollDice() {
        DiceTxt.text = "0"; 
        if (!Thrown && !Landed) {
            Thrown = true; 
            Rb.useGravity = true;
            Rb.AddTorque(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));
            Rb.AddForce(Random.Range(0, 500), Random.Range(0, 5), Random.Range(0, 500));
        } else if (Thrown && Landed) {
            ResetDice();
            RollDice();
        }
    }

    public void ResetDice () {
        transform.position = InitPos;
        Thrown = false;
        Landed = false;
        Rb.useGravity = false;
    }
}
