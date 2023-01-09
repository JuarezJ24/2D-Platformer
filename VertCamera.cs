using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertCamera : MonoBehaviour
{

    private Transform player;

    //public float minX, maxX;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && GameObject.Find("Player").GetComponent<PlayerScript22>().isAlive)
        {
            Vector4 tempy = transform.position;
            tempy.y = player.position.y;
            transform.position = tempy;
            Vector3 tempx = transform.position;
            tempx.x = player.position.x;
            transform.position = tempx;
        }
    }
}
