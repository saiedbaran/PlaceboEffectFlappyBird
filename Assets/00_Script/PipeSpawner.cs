using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private float spawnInterval = 1.5f;
    [SerializeField] private float heightRange = 0.45f;
    
    private float _timer;
    void Start()
    {
        SpawnPipe();
    }

    void Update()
    {
        if(_timer > spawnInterval)
        {
            SpawnPipe();
            _timer = 0;
        }
        
        _timer += Time.deltaTime;
    }

    private void SpawnPipe()
    {
        Vector3 spawnPos = transform.position + Vector3.up * Random.Range(-heightRange, heightRange); 
        GameObject pipe = Instantiate(pipePrefab, spawnPos, Quaternion.identity);
        
        Destroy(pipe, 10f);
    }
}
