using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLooksIntoPlayerScript : MonoBehaviour
{
    public GameObject Player;
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Look at player verticle and horizontaly
        transform.LookAt(target);

        //Look at player only horizontaly
        //Vector3 modifiedTarget = target.position;

    }
}
