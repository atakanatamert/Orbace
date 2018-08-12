using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMotion : MonoBehaviour {

    public GameObject orb;

    public GameObject fire;
    public GameObject ice;
    public GameObject grass;
    public GameObject purple;

    float delayMax = 5;
    // Use this for initialization
    void Start () {
        RandomDelay();
    }
	
	// Update is called once per frame
	void Update () {
        // The step size is equal to speed times frame time.
        // Move our position a step closer to the target.
        //first.gameObject.transform.position = Vector3.MoveTowards(first.transform.position, second.gameObject.transform.position, step);

    }

    void RandomDelay() {
        float num = Random.Range(1, delayMax);
        if(delayMax > 2) {
            delayMax -= PlayerPrefs.GetFloat("Difficulty");
        }
        Debug.Log(num);
        StartCoroutine(Delay(num));        
    }

    IEnumerator Delay(float delayTime) {
        yield return new WaitForSeconds(delayTime);
        Spawner();
    }

     GameObject RandomElementGenerator() {
        float num = Random.Range(0, 3);
        if(num == 0) {
            return fire;
        }else if(num == 1) {
            return ice;
        }
        else if (num == 2) {
            return grass;
        }
        else{
            return purple;
        }
    }

    void Spawner() {
        Vector3 position = Random.insideUnitCircle * 6;
        if (GameObject.Find("Orb").transform.position != position && GameObject.Find("Ship").transform.position != position) {
            GameObject spawn = Instantiate(RandomElementGenerator(), Random.insideUnitCircle * 6, transform.rotation);
            spawn.AddComponent<IndividualMovement>();
        }
        else {
            Spawner();
        }
        
        RandomDelay();
    }
}
