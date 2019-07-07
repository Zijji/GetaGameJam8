using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    private Vector3 targetPrevPos;
    // Start is called before the first frame update
    void Start()
    {
        targetPrevPos = target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            if (targetPrevPos != target.transform.position)
            {
                transform.position = new Vector3(target.transform.position.x, transform.position.y, transform.position.z);
                targetPrevPos = target.transform.position;
            }
        }
    }
}
