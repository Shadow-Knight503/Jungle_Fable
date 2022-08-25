using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMove : MonoBehaviour {
    public Rigidbody Rb;
    public float ForwardForce = 5f;
    public float PosFor; 
    public float Delay = 2f;
    public float Speed;
    public bool Turned = false;
    public bool OnEnd = false;
    public bool Reverse = false;
    public int NoRolled; 
    public Vector3 EndPt;
    public Vector3 StrPt;
    public Vector3 CurtPos;
    public TextMeshProUGUI DiceTxt;

    // Start is called before the first frame update
    void Start() {
        StrPt = transform.position;
        EndPt = transform.position;
    }

    // Update is called once per frame
    void Update() {
        if (Speed < 1f) {
            Speed += 0.01f;
        }
        if (CurtPos == EndPt) {
            Reverse = false;
        }
        CurtPos = transform.position;
        transform.position = Vector3.Lerp(StrPt, EndPt, Speed);
    }

    public void Move(int Num) {
        NoRolled = Num;
        if (Turned) {
            NoRolled = -Num;
            if (OnEnd) {
                NoRolled = -(Num - 1);
            }
        } else if (OnEnd) {
            NoRolled = Num - 1;
        }
        if (OnEnd) {
            UpMove();
            Invoke("MoveDets", Delay);
            OnEnd = false;
        } else {
            MoveDets();
        }
    }

    void MoveDets() {
        if (Reverse) {
            NoRolled = -NoRolled;
        }
        EndPt = transform.position + new Vector3 (PosFor * NoRolled, 0, 0);
        StrPt = transform.position;
        Speed = 0;
    }

    public void UpMove() {
        if (Reverse) {
            PosFor = -PosFor;
        }
        EndPt = transform.position + new Vector3 (0, 0, PosFor);
        StrPt = transform.position;
        Speed = 0;
    }
}
