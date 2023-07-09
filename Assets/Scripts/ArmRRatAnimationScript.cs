using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRRatAnimationScript : MonoBehaviour
{

    private Animator ArmAnimator;
    RatController rC;
    // Start is called before the first frame update
    void Start()
    {
        ArmAnimator = FindObjectOfType<Animator>();
        rC = FindObjectOfType<RatController>();
    }

    // Update is called once per frame
    void Update()
    {
//        Debug.Log(rC.charCon.velocity.magnitude);
        ArmAnimator.SetFloat("Speed", rC.charCon.velocity.magnitude);
    }
}
