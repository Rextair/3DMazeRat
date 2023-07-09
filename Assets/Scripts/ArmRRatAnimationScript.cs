using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRRatAnimationScript : MonoBehaviour
{

    public Animator ArmRAnimator;
    RatController rC;
    // Start is called before the first frame update
    void Start()
    {
        //ArmRAnimator = FindObjectOfType<Animator>();
        Debug.Log("ArmR: "+ArmRAnimator);
        rC = FindObjectOfType<RatController>();
    }

    // Update is called once per frame
    void Update()
    {
//        Debug.Log(rC.charCon.velocity.magnitude);
        ArmRAnimator.SetFloat("Speed", rC.charCon.velocity.magnitude);
    }
}
