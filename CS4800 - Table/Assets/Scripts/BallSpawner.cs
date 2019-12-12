using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Instantiate(ball,new Vector3(transform.position.x + Random.Range(-1, 2), transform.position.y, transform.position.z + Random.Range(-1, 2)),Quaternion.identity);
        }
    }
}
