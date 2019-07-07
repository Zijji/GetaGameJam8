using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallMoonPickup : MonoBehaviour
{
    private BoxCollider2D getBoxCol2D;
    private GameObject dreamstatecont = null;

    // Start is called before the first frame update
    void Start()
    {
        getBoxCol2D = GetComponent<BoxCollider2D>();
        dreamstatecont = GameObject.Find("DreamStateController");
    }

    // Update is called once per frame
    void Update()
    {

        //Dreamstate controller
        int dreamState = -1;
        if (dreamstatecont != null)
        {
            dreamState = dreamstatecont.GetComponent<DreamStateController>().GetDreamState();
        }

        if (dreamState == 0)
        {
            getBoxCol2D.enabled = true;
        }
        else if (dreamState == 1)
        {
            getBoxCol2D.enabled = false;
        }
    }
}
