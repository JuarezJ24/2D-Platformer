using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //check to make sure the door instance is present and is so create a starting value of ow many collectables the player has/
        if (Door.instance != null)
        {
            Door.instance.collectiblesCount++;
        }
    }
    
    
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            Destroy(gameObject);
            if (Door.instance != null)
            {
                Door.instance.DecrementCollectibles();
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
