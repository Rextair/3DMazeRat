using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmLRatAnimationScript : MonoBehaviour
{

    public Animator ArmLAnimator;
    RatController rC;
    // Start is called before the first frame update
    void Start()
    {
        //ArmLAnimator = FindObjectOfType<Animator>();
        Debug.Log("ArmL: "+ArmLAnimator);
        rC = FindObjectOfType<RatController>();
    }

    // Update is called once per frame
    void Update()
    {
//        Debug.Log(rC.charCon.velocity.magnitude);
        ArmLAnimator.SetFloat("Speed", rC.charCon.velocity.magnitude);
    }
}
