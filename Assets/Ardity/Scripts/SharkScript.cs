using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkScript : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 target;
    GameObject player;
    void Start()
    {
        //Find player in world
        player = GameObject.Find("Boat");
    }

    // Update is called once per frame
    void Update()
    {
        //Get player position
        target = player.transform.position;
        //Attack if within the range of the player's light
        float rangeToPlayer = Vector3.Distance(target, transform.position);
        float playerLightRange = player.GetComponentInChildren<Light>().range;
        if(rangeToPlayer < playerLightRange) {
            transform.position = Vector3.Lerp(transform.position, target, 0.005f);
        }
    }
}
