using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject rock;
    public GameObject shark;
    public float size = 30;
    public int rockAmount = 80;
    public int sharkAmount = 20;
    void Start()
    {
        for(int i = 0; i < rockAmount; i++) {
            Instantiate(rock, Random.insideUnitCircle * size, transform.rotation);
        }
        for(int i = 0; i < sharkAmount; i++) {
            Instantiate(shark, Random.insideUnitCircle * size, transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
