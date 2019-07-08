using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChange : MonoBehaviour
{
    private GameObject dreamstatecont = null;
    private int dreamState = -1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dreamstatecont != null)
        {
            dreamState = dreamstatecont.GetComponent<DreamStateController>().GetDreamState();
        }


        
        if (dreamState == 0)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255f, 0f, 0f);

        }
        else if (dreamState == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f);
        }
    }
    
}
