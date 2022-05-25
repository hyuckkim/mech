using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraSubSystem : MonoBehaviour
{
    public float closeModeDirection = 10f, disableWater = 5f;
    private Camera cam;

    public Transform obj;
    public MeshRenderer water;
    public GameObject cover;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        float XZD = XZDistance(transform.position, obj.position);
        if (XZD < closeModeDirection)
        {
            cover.SetActive(false);
        }
        else
        {
            cover.SetActive(true);
        }
        if (XZD < disableWater)
        {
            cam.cullingMask = 39;
        }
        else
        {
            cam.cullingMask = 2147483647;
        }
    }
    float XZDistance(Vector3 origin, Vector3 other) =>
        Mathf.Sqrt(Mathf.Pow(origin.x - other.x, 2) + Mathf.Pow(origin.z - other.z, 2));
}
