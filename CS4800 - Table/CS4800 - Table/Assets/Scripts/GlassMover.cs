using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassMover : MonoBehaviour
{
    [SerializeField] Transform[] glassMovePoints = new Transform[2];
    Rigidbody2D rb2d;
    bool goUp = false;
    bool goDown = false;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            goDown = false;
            goUp = true;
        }
        if (Input.GetKey(KeyCode.X))
        {
            goUp = false;
            goDown = true;
        }

        if (goUp)
        {
            StartCoroutine(Spin(1));
            transform.position = Vector3.MoveTowards(transform.position, glassMovePoints[1].position, 1f);
            if (transform.position.y > glassMovePoints[1].position.y + .01)
            {
                transform.position = glassMovePoints[1].position;
            }
        }

        if (goDown)
        {
            StartCoroutine(Spin(-1));
            transform.position = Vector3.MoveTowards(transform.position, glassMovePoints[0].position, 1f);
            if (transform.position.y < glassMovePoints[0].position.y + 1)
            {
                transform.position = glassMovePoints[0].position;
                transform.rotation = glassMovePoints[0].rotation;
            }
        }
    }   
    IEnumerator Spin(int direction)
    {
        if (transform.position != glassMovePoints[0].position)
        {
            transform.Rotate(0, 5 * direction, 0) ;
        }
            yield return null;
    }
}
