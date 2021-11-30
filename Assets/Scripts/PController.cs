using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PController : MonoBehaviour
{
    public GameObject bullet;
    public GameObject wall;
    private float trackertime = 0.5f;
    public GameObject tracker;
    public float HP = 4.0f;
    private bool invulnerable = false;
    private float invulTime = 1.0f;
    private SpriteRenderer pSprite;

    private void Start()
    {
        pSprite = GameObject.Find("Icon").GetComponent<SpriteRenderer>();

    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.Translate(Vector3.up * 5f * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.Translate(Vector3.down * 5f * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Translate(Vector3.right * 5f * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Translate(Vector3.left * 5f * Time.deltaTime, 0);
        }

        if (trackertime > 0)
        {
            trackertime -= Time.deltaTime;
        }
        if (trackertime <= 0)
        {
            FixPos();
            trackertime = 0.5f;
        }

        if (invulnerable == true)
        {
            invulTime -= Time.deltaTime;
            pSprite.enabled = !pSprite.enabled;

        }
        if (invulTime <= 0)
        {
            invulTime = 1.0f;
            invulnerable = false;
            pSprite.enabled = true;
        }

    }

    void FixPos()
    {
        tracker.transform.position = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet" && invulnerable == false)
        {
            HP -= 1.0f;
            //GameObject.Find("HP").GetComponent<TextMesh>().text = ("HP: " + HP);
            invulnerable = true;
            Destroy(collision.gameObject);

            if (HP <= 0)
            {
                Debug.Log("You died...");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

}
