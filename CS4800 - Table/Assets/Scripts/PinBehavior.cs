using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinBehavior : MonoBehaviour
{
    ParticleSystem parts;
    Rigidbody rb;
    Renderer renderer;
    Vector3 collisionVector;
    bool rotate = false;
    bool shrink = true;
    bool game = true;

    // Start is called before the first frame update
    void Start()
    {
        parts = GetComponentInChildren<ParticleSystem>();
        rb = GetComponent<Rigidbody>();
        parts.Stop();
        renderer = GetComponent<Renderer>();
        StartCoroutine(ColorSwap());
    }
    
    // Update is called once per frame
    void Update()
    {
        if (rotate)
        {
            transform.Rotate(collisionVector);
        }
        else
        {
            transform.Rotate(0, 5, 0);
            if (shrink)
            {
                transform.localScale = new Vector3(transform.localScale.x - .1f, transform.localScale.y - .1f, transform.localScale.z - .1f);
                if (transform.localScale.x <= 1)
                {
                    shrink = false;
                }
            }
            else
            {
                transform.localScale = new Vector3(transform.localScale.x + .1f, transform.localScale.y + .1f, transform.localScale.z + .1f);
                if (transform.localScale.x >= 10)
                {
                    shrink = true;
                }
            }

        }

        
    }

    //void OnTriggerEnter(Collider coll)
    //{
    //    if (coll.gameObject.layer == 8)
    //    {
    //        parts.Play();
    //        collisionVector = (transform.position - coll.transform.position).normalized;           
    //        rb.AddForce(collisionVector * 10, ForceMode.Impulse);
    //        rotate = true;
    //    }
    //}

    IEnumerator ColorSwap()
    {
        while (game)
        {
            renderer.material.color = Random.ColorHSV(0, 1, 1, 1, .5f, 1);
            yield return new WaitForSeconds(.5f);
        }
    }
}
