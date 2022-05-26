using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerBallController : MonoBehaviour
{
    public GameObject ball, origin;
    public Vector3 endL = new Vector3(-1.334f, 0, 0), endR = new Vector3(1.334f, 0, 0);
    float line = 0.5f;
    public float delta = 0.01f, colorDelta = 5;

    public float elec = 0;
    private void FixedUpdate()
    {
        line -= Mathf.Sin(origin.transform.eulerAngles.z * Mathf.Deg2Rad) * delta;
        elec = 0;
        if (line > 1) { elec = line - 1; line = 1; }
        else if (line < 0) { elec = -line; line = 0; }

        ball.transform.localPosition = Vector3.Lerp(endL, endR, line);
    }

}
