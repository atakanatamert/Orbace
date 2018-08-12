using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SpaceshipMovement : MonoBehaviour {

    float left = Screen.width / 3;
    float right = Screen.width - (Screen.width / 3);
    float top = Screen.height - (Screen.height / 3);
    float bottom = Screen.height / 3;
    bool isCollided = false;

    public Text score;


    // Use this for initialization
    void Start () {
        score.text = PlayerPrefs.GetInt("TempScore").ToString();
        GameObject.Find("Orb").transform.position = Random.insideUnitCircle * 3;
        GameObject.Find("Top").GetComponent<ParticleSystem>().Stop();
        GameObject.Find("Bottom").GetComponent<ParticleSystem>().Stop();
        GameObject.Find("Right").GetComponent<ParticleSystem>().Stop();
        GameObject.Find("Left").GetComponent<ParticleSystem>().Stop();
    }
	
	// Update is called once per frame
	void Update () {
        if (isCollided) {
            gameObject.GetComponentInChildren<Rigidbody2D>().transform.position = gameObject.transform.position;
            gameObject.GetComponentInChildren<Rigidbody2D>().transform.rotation = gameObject.transform.rotation;
        }

        if (Input.GetMouseButtonDown(0)) {

            //Upper Check
            if(Input.mousePosition.y < Screen.height && Input.mousePosition.y > top && Input.mousePosition.x < Screen.width && Input.mousePosition.x > right) {
                //  Debug.Log("Upper Right");
                GameObject.Find("Top").GetComponent<ParticleSystem>().Play();
                GameObject.Find("Right").GetComponent<ParticleSystem>().Play();
                GameObject.Find("Bottom").GetComponent<ParticleSystem>().Stop();
                GameObject.Find("Left").GetComponent<ParticleSystem>().Stop();
                gameObject.transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1, -1),ForceMode2D.Impulse);
            }
            if (Input.mousePosition.y < Screen.height && Input.mousePosition.y > top && Input.mousePosition.x > left && Input.mousePosition.x < right) {
                //  Debug.Log("Upper Middle");
               GameObject.Find("Top").GetComponent<ParticleSystem>().Play();
                GameObject.Find("Bottom").GetComponent<ParticleSystem>().Stop();
                GameObject.Find("Left").GetComponent<ParticleSystem>().Stop();
                GameObject.Find("Right").GetComponent<ParticleSystem>().Stop();
                gameObject.transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -1), ForceMode2D.Impulse);
            }
            if (Input.mousePosition.y < Screen.height && Input.mousePosition.y > top && Input.mousePosition.x < left && Input.mousePosition.x > 0) {
                //  Debug.Log("Upper Left");
                GameObject.Find("Top").GetComponent<ParticleSystem>().Play();
                GameObject.Find("Left").GetComponent<ParticleSystem>().Play();
                GameObject.Find("Right").GetComponent<ParticleSystem>().Stop();
                GameObject.Find("Bottom").GetComponent<ParticleSystem>().Stop();
                gameObject.transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, -1), ForceMode2D.Impulse);
            }

            //Middle Check
            if (Input.mousePosition.y < top && Input.mousePosition.y > bottom && Input.mousePosition.x < Screen.width && Input.mousePosition.x > right) {
                //     Debug.Log("Middle Right");
                GameObject.Find("Right").GetComponent<ParticleSystem>().Play();
                GameObject.Find("Left").GetComponent<ParticleSystem>().Stop();
                GameObject.Find("Bottom").GetComponent<ParticleSystem>().Stop();
                GameObject.Find("Top").GetComponent<ParticleSystem>().Stop();
                gameObject.transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1, 0), ForceMode2D.Impulse);
            }
            if (Input.mousePosition.y < top && Input.mousePosition.y > bottom && Input.mousePosition.x > left && Input.mousePosition.x < right) {
             //   Debug.Log("Center");
                gameObject.transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0), ForceMode2D.Impulse);
                GameObject.Find("Top").GetComponent<ParticleSystem>().Stop();
                GameObject.Find("Bottom").GetComponent<ParticleSystem>().Stop();
                GameObject.Find("Right").GetComponent<ParticleSystem>().Stop();
                GameObject.Find("Left").GetComponent<ParticleSystem>().Stop();
            }
            if (Input.mousePosition.y < top && Input.mousePosition.y > bottom && Input.mousePosition.x < left && Input.mousePosition.x > 0) {
                //     Debug.Log("Middle Left");
                GameObject.Find("Left").GetComponent<ParticleSystem>().Play();
                GameObject.Find("Right").GetComponent<ParticleSystem>().Stop();
                GameObject.Find("Top").GetComponent<ParticleSystem>().Stop();
                GameObject.Find("Bottom").GetComponent<ParticleSystem>().Stop();
                gameObject.transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 0), ForceMode2D.Impulse);
            }

            //Bottom Check
            if (Input.mousePosition.y < bottom && Input.mousePosition.y > 0 && Input.mousePosition.x < Screen.width && Input.mousePosition.x > right) {
                //    Debug.Log("Lower Right");
                GameObject.Find("Bottom").GetComponent<ParticleSystem>().Play();
                GameObject.Find("Right").GetComponent<ParticleSystem>().Play();
                GameObject.Find("Left").GetComponent<ParticleSystem>().Stop();
                GameObject.Find("Top").GetComponent<ParticleSystem>().Stop();
                gameObject.transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1, 1), ForceMode2D.Impulse);
            }
            if (Input.mousePosition.y < bottom && Input.mousePosition.y > 0 && Input.mousePosition.x > left && Input.mousePosition.x < right) {
                //   Debug.Log("Lower Middle");
                GameObject.Find("Bottom").GetComponent<ParticleSystem>().Play();
                GameObject.Find("Right").GetComponent<ParticleSystem>().Stop();
                GameObject.Find("Top").GetComponent<ParticleSystem>().Stop();
                GameObject.Find("Left").GetComponent<ParticleSystem>().Stop();
                gameObject.transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1), ForceMode2D.Impulse);
            }
            if (Input.mousePosition.y < bottom && Input.mousePosition.y > 0 && Input.mousePosition.x < left && Input.mousePosition.x > 0) {
                //   Debug.Log("Lower Left");
                GameObject.Find("Bottom").GetComponent<ParticleSystem>().Play();
                GameObject.Find("Left").GetComponent<ParticleSystem>().Play();
                GameObject.Find("Right").GetComponent<ParticleSystem>().Stop();
                GameObject.Find("Top").GetComponent<ParticleSystem>().Stop();
                gameObject.transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 1), ForceMode2D.Impulse);
            }

        }
            
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.name != "Orb") {
            Debug.Log("Game Over!");
            PlayerPrefs.SetInt("TempScore", 0);
            PlayerPrefs.SetFloat("Difficulty", 0);
            SceneManager.LoadScene("GameOver");
        }
        else {
            isCollided = true;
            Debug.Log("Sticking it");
            collision.gameObject.transform.position = gameObject.transform.position;
            collision.gameObject.transform.rotation = gameObject.transform.rotation;
            collision.gameObject.transform.SetParent(gameObject.transform);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(gameObject.transform.childCount > 4) {
            Debug.Log("Congratz!");
            PlayerPrefs.SetInt("TempScore", PlayerPrefs.GetInt("TempScore") + 1);
            if (PlayerPrefs.GetInt("HighScore") < PlayerPrefs.GetInt("TempScore")) {
                PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("TempScore"));
            }
            PlayerPrefs.SetFloat("Difficulty", PlayerPrefs.GetFloat("Difficulty") + 0.15f);
            SceneManager.LoadScene("Orbace");
        }
        else {
            Debug.Log("GameOver");
            PlayerPrefs.SetInt("TempScore", 0);
            PlayerPrefs.SetFloat("Difficulty", 0);
            SceneManager.LoadScene("GameOver");
        }
    }

}
