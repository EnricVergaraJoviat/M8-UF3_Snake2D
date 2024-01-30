using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject foodPrefab;
    
    void Start()
    {
        GameObject o = GameObject.Instantiate(foodPrefab);
        o.transform.position = new Vector3(-10 * 0.3f, 0, 0);
        o = GameObject.Instantiate(foodPrefab);
        o.transform.position = new Vector3(-10 * 0.3f, 0.3f*10, 0);
        o = GameObject.Instantiate(foodPrefab);
        o.transform.position = new Vector3(-10 * 0.3f, -0.3f*10, 0);

    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
