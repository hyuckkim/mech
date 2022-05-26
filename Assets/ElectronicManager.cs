using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ElectronicManager : MonoBehaviour
{
    public InnerBallController[] controllers;
    public LineRenderer line;
    public float colorDelta = 100, lightDelta = 50;

    public Light spotlight;
    // Start is called before the first frame update
    void Start()
    {
        line.positionCount = controllers.Length + 2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        line.SetPositions(
            new Vector3[] { new Vector3(26.6f, 0f, -28.6f) }
            .Concat(controllers.Select(com => com.transform.position + Vector3.back)).Append(
                new Vector3(-29.6f, 0f, -34.9f)).ToArray());

        float elec = controllers.Aggregate(0.0f, (acc, com) => acc + com.elec);
        Debug.Log(elec * colorDelta);
        Color elecColor = Color.white * elec * colorDelta + Color.black;
        line.startColor = elecColor;
        line.endColor = elecColor;

        spotlight.intensity = elec * elec * lightDelta;
    }
}
