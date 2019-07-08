using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeOpener : MonoBehaviour
{
    private GameObject dreamstatecont = null;
    private int dreamState = -1;
    public Sprite wokeSprite = null;
    public Sprite sleepSprite = null;
    private SpriteRenderer getSprRen;
    // Start is called before the first frame update
    void Start()
    {
        dreamstatecont = GameObject.Find("DreamStateController");
        getSprRen = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Dreamstate controller
        if (dreamstatecont != null)
        {
            dreamState = dreamstatecont.GetComponent<DreamStateController>().GetDreamState();
        }

        if (dreamState == 0)
        {
            getSprRen.sprite = wokeSprite;
        }
        else if (dreamState == 1)
        {
            getSprRen.sprite = sleepSprite;
        }
    }
}

