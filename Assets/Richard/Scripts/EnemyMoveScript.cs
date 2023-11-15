using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMoveScript : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 1f;
    //public float timer = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = -transform.forward * speed;
        
        // Tried to do a timer thing but it also destroys all the clones at the end, so I guess it doesn't matter for this project.
        //timer = timer - Time.deltaTime;
        /*if (timer <= 0) {
            Destroy(gameObject);
        }*/
    }
}
