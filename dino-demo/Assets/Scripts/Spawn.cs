using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float maxtime = 2f;
    float timer;
    public GameObject Cactus;
    public float speed = 20;
    GameObject newcac;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 random = new Vector2(Random.Range(9f, 12f), -3.5f);
        timer += Time.deltaTime;
        if (timer > maxtime) {
            GameObject newcac = Instantiate(Cactus, random, transform.rotation);
            timer = 0;
            Destroy(newcac, 5f);
        }
        Destroy(newcac, 4f);
    }
    
}
