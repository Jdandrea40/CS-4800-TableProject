using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinBehavior2 : MonoBehaviour
{
    ParticleSystem parts;
    Rigidbody rb;
    Vector3 collisionVector;
    bool rotate = false;
    bool shrink = true;
    [SerializeField]
    float scaleFactor = 2;

    // Start is called before the first frame update
    void Start()
    {
        parts = GetComponentInChildren<ParticleSystem>();
        rb = GetComponent<Rigidbody>();
        parts.Stop();
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
                transform.localScale = new Vector3(transform.localScale.x - scaleFactor, transform.localScale.y - scaleFactor, transform.localScale.z - scaleFactor);
                if (transform.localScale.x <= 10)
                {
                    shrink = false;
                }
            }
            else
            {
                transform.localScale = new Vector3(transform.localScale.x + scaleFactor, transform.localScale.y + scaleFactor, transform.localScale.z + scaleFactor);
                if (transform.localScale.x >= 100)
                {
                    shrink = true;
                }
            }
            //StartCoroutine(Scale());
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.layer == 8)
        {
            parts.Play();
            collisionVector = (transform.position - coll.transform.position).normalized;           
            rb.AddForce(collisionVector * 10, ForceMode.Impulse);
            rotate = true;
        }
    }

    //IEnumerator Scale()
    //{
    //    bool shrink = true;
    //    while (!rotate)
    //    {
    //        if (shrink)
    //        {
    //            while (shrink)
    //            {
    //                transform.localScale = new Vector3(transform.localScale.x - 1, transform.localScale.y - 1, transform.localScale.z - 1);
    //                yield return new WaitForSeconds(1);
    //                if (transform.localScale.x == 1)
    //                {
    //                    shrink = false;
    //                    Debug.Log("Ling");
    //                }
    //            }
    //        }
    //        else if (!shrink)
    //        {
    //            while (!shrink)
    //            {
    //                transform.localScale = new Vector3(transform.localScale.x + 1, transform.localScale.y + 1, transform.localScale.z + 1);
    //                yield return new WaitForSeconds(1);
    //                if (transform.localScale.x == 10)
    //                {
    //                    Debug.Log("Biing");
    //                    shrink = true;
    //                }
    //            }
    //        }
    //    }
        
    //}

}
