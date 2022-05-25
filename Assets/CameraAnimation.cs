using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimation : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    int range;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            range += 1;
            if (range > 1) range = 1;
            animator.SetInteger("range", range);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            range -= 1;
            if (range < -1) range = -1;
            animator.SetInteger("range", range);
        }
    }
}
