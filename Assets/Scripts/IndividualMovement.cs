using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndividualMovement : MonoBehaviour {

    private GameObject orb;

	// Use this for initialization
	void Start () {
        orb = GameObject.Find("Orb");
    }
	
	// Update is called once per frame
	void Update () {
        if (gameObject.GetComponent<Rigidbody2D>().isKinematic) {

        }
        else {
            gameObject.transform.position = Vector3.MoveTowards(transform.position, orb.gameObject.transform.position, 1f * Time.deltaTime);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        Debug.Log("Collided" + gameObject.GetComponent<Rigidbody2D>().velocity);
    }
}
