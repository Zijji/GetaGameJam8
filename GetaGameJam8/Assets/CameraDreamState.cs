using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDreamState : MonoBehaviour
{
    private GameObject dreamstatecont = null;
    private int dreamState = -1;
    private Camera cameraComponent;
    // Start is called before the first frame update
    void Start()
    {
        dreamstatecont = GameObject.Find("DreamStateController");
        cameraComponent = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dreamstatecont != null)
        {
            dreamState = dreamstatecont.GetComponent<DreamStateController>().GetDreamState();
        }

        if (dreamState == 1)
        {
            cameraComponent.backgroundColor = new Color(0.1921f, 0.4745f, 0.4588f, 1.0f);

        }
        else if (dreamState == 0)
        {
            cameraComponent.backgroundColor = Color.red;
        }

    }
}
