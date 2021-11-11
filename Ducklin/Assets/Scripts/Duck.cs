using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Duck : MonoBehaviour
{
    public Image image;
    public Sprite duck1;
    public Sprite duck2;

    public Image egg;
    public GameObject eggSpawn;
    Transform eggParent;

    public RectTransform rt;
    public Rigidbody2D rb;

    Scene currentScene;

    bool Grounded;

    void Start()
    {
        StartCoroutine(UpDown());

        currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "Game")
        {
            eggParent = GameObject.Find("EggsInGame").GetComponentInChildren<Transform>();
            StartCoroutine(Logic());
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "floor5")
        {
            rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, 275);
        }
    }

    IEnumerator Logic()
    {
        while(true)
        {
            float wait = Random.Range(1f, 6f);
            yield return new WaitForSeconds(wait);

            int move = Random.Range(1, 4);
            switch(move)
            {
                case 1:
                    rb.AddForce(Vector2.right * 15000);
                    rt.transform.rotation = Quaternion.Euler(0, 0, 0);
                    if (rt.anchoredPosition.x > 907)
                    {
                        rb.AddForce(Vector2.left * 15000);
                        rt.transform.rotation = Quaternion.Euler(0, 180, 0);
                    }
                    break;
                case 2:
                    rb.AddForce(Vector2.left * 15000);
                    rt.transform.rotation = Quaternion.Euler(0, 180, 0);
                    if (rt.anchoredPosition.x < -361)
                    {
                        rb.AddForce(Vector2.right * 15000);
                        rt.transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                    break;
                case 3:
                    rb.AddForce(Vector2.up * 30000);
                    int move1 = Random.Range(1, 3);
                    if(move1 == 1)
                    {
                        rb.AddForce(Vector2.right * 12000);
                        rt.transform.rotation = Quaternion.Euler(0, 0, 0);
                        if (rt.anchoredPosition.x > 907)
                        {
                            rb.AddForce(Vector2.left * 15000);
                            rt.transform.rotation = Quaternion.Euler(0, 180, 0);
                        }
                    }
                    else if(move1 == 2)
                    {
                        rb.AddForce(Vector2.left * 12000);
                        rt.transform.rotation = Quaternion.Euler(0, 180, 0);
                        if (rt.anchoredPosition.x < -361)
                        {
                            rb.AddForce(Vector2.right * 15000);
                            rt.transform.rotation = Quaternion.Euler(0, 0, 0);
                        }
                    }
                    break;
            }

            int spawnEgg = Random.Range(1, 6);
            if(spawnEgg == 1)
            {
                if(Grounded)
                {
                    Instantiate(egg, eggSpawn.transform.position, Quaternion.identity, eggParent);
                }
            }
        }
    }

    void OnCollisionStay2D(Collision2D collider)
    {
        CheckIfGrounded();
    }

    void OnCollisionExit2D(Collision2D collider)
    {
        Grounded = false;
    }

    private void CheckIfGrounded()
    {
        RaycastHit2D[] hits;

        Vector2 positionToCheck = transform.position;
        hits = Physics2D.RaycastAll(positionToCheck, new Vector2(0, -1), 0.01f);

        if (hits.Length > 0)
        {
            Grounded = true;
        }
    }

    IEnumerator UpDown()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.5f);
            if (image.sprite == duck1)
            {
                image.sprite = duck2;
            }
            else if (image.sprite == duck2)
            {
                image.sprite = duck1;
            }
        }
    }
}
