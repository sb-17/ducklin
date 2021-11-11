using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ducklin : MonoBehaviour
{
    public Image image;
    public Sprite ducklin1;
    public Sprite ducklin2;
    public RectTransform rt;
    public static RectTransform rt1;
    public Rigidbody2D rb;

    public Text eggsCount;

    public GameObject q;
    public GameObject e;
    public GameObject r;

    public RectTransform farmer;

    bool Grounded;
    float speed;
    int cooldown;
    int score;

    bool canUseQ;
    bool canUseE;
    bool canUseR;

    bool teleporting;
    bool farmerCanMove;

    int qLevel;
    int eLevel;
    int rLevel;

    Vector3 farmerPos;

    void Start()
    {
        rt1 = rt;

        StartCoroutine(UpDown());

        score = 0;

        eggsCount.text = "0";

        speed = 0.45f;

        canUseQ = true;
        canUseE = true;
        canUseR = true;

        teleporting = false;
        farmerCanMove = true;

        if(PlayerPrefs.GetInt("qLevel") == 0)
        {
            PlayerPrefs.SetInt("qLevel", 1);
        }
        if (PlayerPrefs.GetInt("eLevel") == 0)
        {
            PlayerPrefs.SetInt("eLevel", 1);
        }
        if (PlayerPrefs.GetInt("rLevel") == 0)
        {
            PlayerPrefs.SetInt("rLevel", 1);
        }

        qLevel = PlayerPrefs.GetInt("qLevel");
        eLevel = PlayerPrefs.GetInt("eLevel");
        rLevel = PlayerPrefs.GetInt("rLevel");
    }

    void Update()
    {
        if (Input.GetKey("a"))
        {
            rt.anchoredPosition += new Vector2(-speed, 0);
            rt.transform.rotation = Quaternion.Euler(0, 180, 0);
            if (rt.anchoredPosition.x < -361)
                rt.anchoredPosition -= new Vector2(-speed, 0);
        }

        if (Input.GetKey("d"))
        {
            rt.anchoredPosition += new Vector2(speed, 0);
            rt.transform.rotation = Quaternion.Euler(0, 0, 0);
            if (rt.anchoredPosition.x > 907)
                rt.anchoredPosition -= new Vector2(speed, 0);
        }

        if(Input.GetKeyDown(KeyCode.UpArrow) && teleporting)
        {
            if (CheckFloor() == 1)
            {
                rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, -249);
            }
            else if (CheckFloor() == 2)
            {
                rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, -73);
            }
            else if (CheckFloor() == 3)
            {
                rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, 101);
            }
            else if (CheckFloor() == 4)
            {
                rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, 275);
            }
        }

        if(Input.GetKeyDown(KeyCode.DownArrow) && teleporting)
        {
            if (CheckFloor() == 2)
            {
                rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, -407);
            }
            else if (CheckFloor() == 3)
            {
                rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, -249);
            }
            else if (CheckFloor() == 4)
            {
                rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, -73);
            }
            else if (CheckFloor() == 5)
            {
                rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, 101);
            }
        }

        if(Input.GetKeyDown("q"))
        {
            qPower();
        }

        if (Input.GetKeyDown("e"))
        {
            ePower();
        }

        if (Input.GetKeyDown("r"))
        {
            rPower();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(Grounded)
            {
                rb.AddForce(Vector2.up * 30000);
            }
            else if(cooldown == 0)
            {
                rb.AddForce(Vector2.up * 30000);
                cooldown = 2;
                StartCoroutine(Cooldown());
            }
        }

        if(!farmerCanMove)
        {
            farmer.anchoredPosition = farmerPos;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "egg")
        {
            PlayerPrefs.SetInt("Eggs", PlayerPrefs.GetInt("Eggs") + 1);
            score += 1;
            eggsCount.text = score.ToString();
            if(Farmer.anger < 100)
            {
                int pridat = Random.Range(1, 3);
                Farmer.anger += pridat;
            }
            Destroy(col.gameObject);
        }
        else if(col.gameObject.tag == "farmer")
        {
            PlayerPrefs.SetInt("Collected", score);
            SceneManager.LoadScene("GameOver");
        }
    }

    public static int CheckFloor()
    {
        if(rt1.anchoredPosition.y <= 340 && rt1.anchoredPosition.y >= 225)
        {
            return 5;
        }
        else if (rt1.anchoredPosition.y <= 165 && rt1.anchoredPosition.y >= 49)
        {
            return 4;
        }
        else if (rt1.anchoredPosition.y <= -16 && rt1.anchoredPosition.y >= -129)
        {
            return 3;
        }
        else if (rt1.anchoredPosition.y <= -191 && rt1.anchoredPosition.y >= -308)
        {
            return 2;
        }
        else if (rt1.anchoredPosition.y <= -370 && rt1.anchoredPosition.y >= -504)
        {
            return 1;
        }
        return 0;
    }

    public void qPower()
    {
        if(canUseQ)
        {
            if(Farmer.anger - qLevel * 10 > 0)
            {
                Farmer.anger = Farmer.anger - qLevel * 10;
            }
            else
            {
                Farmer.anger = 0;
            }

            canUseQ = false;

            q.SetActive(false);
        }
    }
    public void ePower()
    {
        if(canUseE)
        {
            StartCoroutine(Teleporting());

            canUseE = false;

            e.SetActive(false);
        }
    }
    public void rPower()
    {
        if(canUseR)
        {
            farmerPos = farmer.anchoredPosition;

            StartCoroutine(stun());

            canUseR = false;

            r.SetActive(false);
        }
    }

    IEnumerator Teleporting()
    {
        teleporting = true;
        yield return new WaitForSeconds(eLevel*2);
        teleporting = false;
    }

    IEnumerator stun()
    {
        farmerCanMove = false;
        yield return new WaitForSeconds(rLevel*2);
        farmerCanMove = true;
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

    IEnumerator Cooldown()
    {
        while(cooldown > 0)
        {
            yield return new WaitForSeconds(1f);
            cooldown -= 1;
        }
    }

    IEnumerator UpDown()
    {
        while(true)
        {
            if (image.sprite == ducklin1)
            {
                image.sprite = ducklin2;
            }
            else if (image.sprite == ducklin2)
            {
                image.sprite = ducklin1;
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
