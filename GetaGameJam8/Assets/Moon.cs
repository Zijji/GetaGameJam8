using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    private SpriteRenderer getSprRen;
    private GameObject dreamstatecont = null;

    public Sprite nightmareMoon = null;
    public Sprite daydreamMoon = null;


    // Start is called before the first frame update
    void Start()
    {
        getSprRen = GetComponent<SpriteRenderer>();
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
            getSprRen.sprite = nightmareMoon;
        }
        else if (dreamState == 1)
        {
            getSprRen.sprite = daydreamMoon;
        }
    }
}
