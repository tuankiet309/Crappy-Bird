using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float distanceToDesTroy;
    private Vector2 Intaciate;
    void Start()
    {
        Intaciate = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(moveSpeed*Time.deltaTime,0,0);
        if(Vector2.Distance(transform.position,Intaciate) >= distanceToDesTroy)
        {
            Destroy(transform.gameObject);
        }
    }
}
