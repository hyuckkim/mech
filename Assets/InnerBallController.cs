using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerBallController : MonoBehaviour
{
    public GameObject ball, origin;
    public Vector3 endL = new Vector3(-1.334f, 0, 0), endR = new Vector3(1.334f, 0, 0);
    public LineRenderer electronic;
    float line = 0.5f;
    public float delta = 0.01f, colorDelta = 5;

    private void FixedUpdate()
    {
        line -= Mathf.Sin(origin.transform.eulerAngles.z * Mathf.Deg2Rad) * delta;
        float extra = 0;
        if (line > 1) { extra = line - 1; line = 1; }
        else if (line < 0) { extra = -line; line = 0; }

        ball.transform.localPosition = Vector3.Lerp(endL, endR, line);

        Color elecColor = Color.yellow * extra * colorDelta + Color.black;
        electronic.startColor = elecColor;
        electronic.endColor = elecColor;

        electronic.SetPosition(0, origin.transform.position);
        electronic.SetPosition(1, new Vector3(origin.transform.position.x, 5, origin.transform.position.z));
    }

}
