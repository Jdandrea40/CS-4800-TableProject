using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinBehavior2 : MonoBehaviour
{
    ParticleSystem parts;
    AudioSource audio;
    [SerializeField]
    AudioClip explode;
    Rigidbody rb;
    Vector3 collisionVector;
    bool rotate = false;

    [SerializeField]
    GameObject[] shatterPieces = new GameObject[10];
    Rigidbody[] shatterPiecesRB = new Rigidbody[10];
    Renderer[] shatterRenders = new Renderer[10];
    
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        for (int i = 0; i < shatterPieces.Length; i++)
        {
            //shatterPieces[i] = GetComponent<GameObject>();
            shatterPiecesRB[i] = shatterPieces[i].GetComponentInChildren<Rigidbody>();
            shatterRenders[i] = shatterPieces[i].GetComponentInChildren<Renderer>();
            
        }
        parts = GetComponentInChildren<ParticleSystem>();
        rb = GetComponent<Rigidbody>();
        parts.Stop();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (rotate)
        {
            for (int i = 0; i < shatterPieces.Length; i++)
            {               
                shatterPieces[i].transform.Rotate(collisionVector);
            }           
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            ExplodeAll();
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.layer == 8)
        {
            collisionVector = (transform.position - coll.transform.position).normalized;
            for (int i = 0; i < shatterPiecesRB.Length; i++)
            {
                
                shatterPiecesRB[i].AddForce(new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), Random.Range(-50, 50)), ForceMode.Impulse);
                gameObject.GetComponent<BoxCollider>().enabled = false;
            }
            parts.Play();
            audio.PlayOneShot(explode);
            rotate = true;
        }
    }

    void ExplodeAll()
    {
        for (int i = 0; i < shatterPiecesRB.Length; i++)
        {
            parts.Play();
            audio.PlayOneShot(explode);
            shatterPiecesRB[i].AddForce(new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), Random.Range(-50, 50)), ForceMode.Impulse);
            
            gameObject.GetComponent<BoxCollider>().enabled = false;
            collisionVector = new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), Random.Range(-50, 50));
        }
        rotate = true;
        
    }
}
