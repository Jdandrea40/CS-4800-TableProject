using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullForce : MonoBehaviour
{
    [SerializeField] float Zstart;
    Vector3 startPos;
    SpringJoint sj;
    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        sj = GetComponent<SpringJoint>();
        startPos = transform.position;
        Zstart = transform.position.z;
    }
    private void Start()
    {
        
        
    }

    private void OnMouseDrag()
    {

        Vector3 mousePosition = new Vector3(Input.mousePosition.x,Input.mousePosition.y,15);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        transform.position = objPosition;

    }

    IEnumerator ResetGrav()
    {
        yield return new WaitForSeconds(3);
        rb.mass = 1;
        rb.useGravity = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            transform.position = startPos;
            rb.mass = 0;
            rb.useGravity = false;
            StartCoroutine(ResetGrav());
        }
    }
}
