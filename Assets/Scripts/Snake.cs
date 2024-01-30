using System;
using System.Collections;
using System.Collections.Generic; 
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField] private GameObject bodyPrefab;
    [SerializeField] private int initialBodies;
    [SerializeField] private float speed;
    
    List<GameObject> bodies = new List<GameObject>();
    private Vector3 direction;
    private float timer;
    private bool eaten;
    
    void Start()
    {
        eaten = false;
        float positionX = transform.position.x + transform.localScale.x;
        for (int i = 0; i < initialBodies; i++)
        {
            GameObject o = CreateNewBody(new Vector3(positionX, transform.position.y, 0.0f));
            positionX += transform.position.x + transform.localScale.x;
            bodies.Add(o);
        }
        direction = Vector3.left;
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        
        if (timer > 1 / speed)
        {
            timer = 0.0f;
            
            //Destrueix la cua
            if (!eaten)
            {
                Destroy((bodies[bodies.Count - 1]));
                bodies.RemoveAt(bodies.Count - 1);    
            }
            else
            {
                eaten = false;
            }
            
            
            //Crean un de nou en el lloc del cap
            GameObject o = CreateNewBody(transform.position);
            o.transform.position = transform.position;
            bodies.Insert(0,o);
            
            //Mou el cap segons direcció
            transform.position += direction * transform.localScale.x;
            
        }

        timer += Time.deltaTime;
    }
    
    
    private void HandleInput()
    {
        if (Input.GetAxis("Horizontal") < 0 && direction != Vector3.right)
        {
            direction = Vector3.left;
        }
        else if (Input.GetAxis("Horizontal") > 0 && direction != Vector3.left)
        {
            direction = Vector3.right;
        }
        
        if (Input.GetAxis("Vertical") < 0 && direction != Vector3.up)
        {
            direction = Vector3.down;
        }
        else if (Input.GetAxis("Vertical") > 0 && direction != Vector3.down)
        {
            direction = Vector3.up;
        }
    }
    
    private GameObject CreateNewBody(Vector3 pos)
    {
        GameObject o = GameObject.Instantiate(bodyPrefab);
        o.transform.localScale = transform.localScale;
        o.transform.position = pos;
        o.transform.parent = transform.parent;
        return o;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            Destroy(other.gameObject);
            eaten = true;
        }
    }
}
