using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    private Vector3 targetPrevPos;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;
    // Start is called before the first frame update
    void Start()
    {
        targetPrevPos = target.transform.position;
    }

    // Update is called once per frame

    void LateUpdate()
    {
        //this code sets the boundaries in the component section of Unity flexibly.
        //for each level you can change the xMin etc. in the component.
        float x = Mathf.Clamp(target.transform.position.x, xMin, xMax);
        float y = Mathf.Clamp(target.transform.position.y, yMin, yMax);
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
    }
}
