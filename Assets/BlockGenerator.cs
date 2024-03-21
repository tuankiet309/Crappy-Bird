using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerator : MonoBehaviour
{
    [SerializeField] private Transform Min;
    [SerializeField] private Transform Max;
    [SerializeField] private float BlockSpeed;
    [SerializeField] private float GenerateTimer;
    [SerializeField] GameObject BlockToGenerate;
    private float GenerateTimerCounter;
    void Start()
    {
        GenerateTimerCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GenerateTimerCounter -= Time.deltaTime;
        if(GenerateTimerCounter < 0 )
        {
            Instantiate(BlockToGenerate, new Vector3(transform.position.x, Random.Range(Min.position.y,Max.position.y)), Quaternion.identity);
            GenerateTimerCounter = GenerateTimer;
        }
    }
}
