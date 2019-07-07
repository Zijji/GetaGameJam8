using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekerbeastSpawner : MonoBehaviour
{
    public enum SpawnState {ready, spawned};
    public SpawnState currentstate = SpawnState.ready;

    public GameObject spawnObject = null;

    private GameObject dreamstatecont = null;
    // Start is called before the first frame update
    void Start()
    {
        dreamstatecont = GameObject.Find("DreamStateController");
    }

    // Update is called once per frame
    void Update()
    {
        //Dreamstate controller
        if (dreamstatecont != null)
        {
            int dreamState = dreamstatecont.GetComponent<DreamStateController>().GetDreamState();

            if ((currentstate == SpawnState.ready) && (dreamState == 0))
            {
                currentstate = SpawnState.spawned;
                Instantiate(spawnObject,transform.position,transform.rotation);
            }
            if ((currentstate == SpawnState.spawned) && (dreamState == 1))
            {
                currentstate = SpawnState.ready;
            }
        }
    }
}
