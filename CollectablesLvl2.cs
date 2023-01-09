using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesLvl2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //check to make sure the door instance is present and is so create a starting value of ow many collectables the player has/
        if (Door1.instance != null)
        {
            Door1.instance.collectiblesCount++;
        }
    }


    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            Destroy(gameObject);
            if (Door1.instance != null)
            {
                Door1.instance.DecrementCollectibles();
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
