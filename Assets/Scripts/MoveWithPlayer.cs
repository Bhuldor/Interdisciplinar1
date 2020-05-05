using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithPlayer : MonoBehaviour
{
    public GameObject player;
    public float distanceY = 22;
    public float distanceZ = 12;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + distanceY, player.transform.position.z - 12f);
    }
}
