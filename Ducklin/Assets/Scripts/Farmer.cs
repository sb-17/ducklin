using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Farmer : MonoBehaviour
{
    public Image angerImage;
    public Sprite happy;
    public Sprite medium;
    public Sprite angry;
    public Text angerText;

    public Image self;
    public Sprite self1;
    public Sprite self2;
    public Sprite stand;

    public RectTransform chase;
    public RectTransform rt;
    public Rigidbody2D rb;

    public Slider tpSlider;
    public GameObject tpSlider1;

    public static int anger;
    float speed;
    public static bool canMove = true;
    int floor;
    int myFloor;
    int lastFloor;

    public RectTransform[] floor1;
    public RectTransform[] floor2;
    public RectTransform[] floor3;
    public RectTransform[] floor4;

    RectTransform to;

    void Start()
    {
        angerImage.sprite = happy;
        angerText.text = "0%";
        anger = 0;

        StartCoroutine(UpDown());
        StartCoroutine(Calm());
        StartCoroutine(Logic());

        canMove = true;

        floor = Ducklin.CheckFloor();

        myFloor = CheckMyFloor();

        speed = 0.6f;
    }

    void Update()
    {
        floor = Ducklin.CheckFloor();
        myFloor = CheckMyFloor();

        angerText.text = anger.ToString() + "%";

        if(anger <= 7)
        {
            speed = 1.7f;
        }
        else if(anger <= 18 && anger > 7)
        {
            speed = 1.8f;
        }
        else if (anger <= 30 && anger > 18)
        {
            speed = 1.9f;
        }
        else if (anger <= 40 && anger > 30)
        {
            speed = 2f;
        }
        else if (anger <= 55 && anger > 40)
        {
            speed = 2.1f;
        }
        else if (anger <= 70 && anger > 55)
        {
            speed = 2.2f;
        }
        else if (anger <= 85 && anger > 70)
        {
            speed = 2.3f;
        }
        else if (anger <= 90 && anger > 85)
        {
            speed = 2.4f;
        }
        else if (anger <= 95 && anger > 90)
        {
            speed = 2.5f;
        }
        else if (anger <= 100 && anger > 95)
        {
            speed = 2.6f;
        }
    }

    int CheckMyFloor()
    {
        if (rt.anchoredPosition.y <= 340 && rt.anchoredPosition.y >= 225)
        {
            return 5;
        }
        else if (rt.anchoredPosition.y <= 165 && rt.anchoredPosition.y >= 49)
        {
            return 4;
        }
        else if (rt.anchoredPosition.y <= -16 && rt.anchoredPosition.y >= -129)
        {
            return 3;
        }
        else if (rt.anchoredPosition.y <= -191 && rt.anchoredPosition.y >= -308)
        {
            return 2;
        }
        else if (rt.anchoredPosition.y <= -370 && rt.anchoredPosition.y >= -504)
        {
            return 1;
        }
        return 0;
    }

    IEnumerator Logic()
    {
        while(true)
        {
            if(canMove)
            {
                floor = Ducklin.CheckFloor();
                myFloor = CheckMyFloor();
                
                if (chase.anchoredPosition.y > rt.anchoredPosition.y)
                {
                    tpSlider.value = 0;

                    tpSlider1.SetActive(true);

                    for (int i = 0; i < 101; i++)
                    {
                        tpSlider.value = i;
                        yield return new WaitForSeconds(0.01f);
                    }

                    if (myFloor == 1)
                    {
                        rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, -249);
                    }
                    else if (myFloor == 2)
                    {
                        rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, -73);
                    }
                    else if (myFloor == 3)
                    {
                        rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, 101);
                    }
                    else if (myFloor == 4)
                    {
                        rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, 275);
                    }

                    if (chase.anchoredPosition.x < rt.anchoredPosition.x)
                    {
                        rb.AddForce(Vector2.left * 15000);
                        rt.transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                    else
                    {
                        rb.AddForce(Vector2.right * 15000);
                        rt.transform.rotation = Quaternion.Euler(0, 0, 0);
                    }

                    tpSlider1.SetActive(false);
                }

                if (myFloor == floor)
                {
                    if (chase.anchoredPosition.x < rt.anchoredPosition.x)
                    {
                        rt.anchoredPosition += new Vector2(-speed * Time.deltaTime, 0);
                        rt.transform.rotation = Quaternion.Euler(0, 180, 0);
                        if (rt.anchoredPosition.x < -361)
                            rt.anchoredPosition -= new Vector2(-speed * Time.deltaTime, 0);
                    }
                    else if(chase.anchoredPosition.x > rt.anchoredPosition.x)
                    {
                        rt.anchoredPosition += new Vector2(speed * Time.deltaTime, 0);
                        rt.transform.rotation = Quaternion.Euler(0, 0, 0);
                        if (rt.anchoredPosition.x > 907)
                            rt.anchoredPosition -= new Vector2(speed * Time.deltaTime, 0);
                    }
                }
                else if(myFloor > floor)
                {
                    int i = 0;
                    if(myFloor == 5)
                    {
                        i = GenerateArena.pos1;
                        to = GetToClosestHole(floor1);
                        lastFloor = 5;
                    }
                    else if (myFloor == 4)
                    {
                        i = GenerateArena.pos2;
                        to = GetToClosestHole(floor2);
                        lastFloor = 4;
                    }
                    else if (myFloor == 3)
                    {
                        i = GenerateArena.pos3;
                        to = GetToClosestHole(floor3);
                        lastFloor = 3;
                    }
                    else if (myFloor == 2)
                    {
                        i = GenerateArena.pos4;
                        to = GetToClosestHole(floor4);
                        lastFloor = 2;
                    }

                    while(myFloor == lastFloor)
                    {
                        if (to.anchoredPosition.x + i < -361)
                        {
                            rt.anchoredPosition += new Vector2(speed, 0);
                            rt.transform.rotation = Quaternion.Euler(0, 0, 0);
                            if (rt.anchoredPosition.x < -361)
                                rt.anchoredPosition -= new Vector2(speed, 0);
                        }
                        else if (to.anchoredPosition.x + i > 907)
                        {
                            rt.anchoredPosition -= new Vector2(speed, 0);
                            rt.transform.rotation = Quaternion.Euler(0, 180, 0);
                            if (rt.anchoredPosition.x > 907)
                                rt.anchoredPosition += new Vector2(speed, 0);
                        }
                        else if (to.anchoredPosition.x + i < rt.anchoredPosition.x)
                        {
                            rt.anchoredPosition -= new Vector2(speed, 0);
                            rt.transform.rotation = Quaternion.Euler(0, 180, 0);
                            if (rt.anchoredPosition.x > 907)
                                rt.anchoredPosition += new Vector2(speed, 0);
                        }
                        else if (to.anchoredPosition.x + i > rt.anchoredPosition.x)
                        {
                            rt.anchoredPosition += new Vector2(speed, 0);
                            rt.transform.rotation = Quaternion.Euler(0, 0, 0);
                            if (rt.anchoredPosition.x < -361)
                                rt.anchoredPosition -= new Vector2(speed, 0);
                        }
                        yield return new WaitForSeconds(0.01f);
                    }
                }
                yield return new WaitForSeconds(0.01f);
            }
        }
    }

    RectTransform GetToClosestHole(RectTransform[] holes)
    {
        RectTransform tMin = null;
        float minDist = Mathf.Infinity;
        Vector2 currentPos = rt.anchoredPosition;
        foreach(RectTransform t in holes)
        {
            float dist = Vector2.Distance(t.anchoredPosition, currentPos);
            if(dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }

        return tMin;
    }

    IEnumerator UpDown()
    {
        while(true)
        {
            if(canMove)
            {
                yield return new WaitForSeconds(0.3f);
                if(self.sprite == self1 || self.sprite == stand)
                {
                    self.sprite = self2;
                }
                else if(self.sprite == self2)
                {
                    self.sprite = self1;
                }
            }
        }
    }

    IEnumerator Calm()
    {
        while(true)
        {
            if(anger > 0)
            {
                anger -= 1;
                if(anger >= 33 && anger < 66)
                {
                    angerImage.sprite = medium;
                }
                else if(anger < 33)
                {
                    angerImage.sprite = happy;
                }
                else if (anger >= 66)
                {
                    angerImage.sprite = angry;
                }
            }
            yield return new WaitForSeconds(12f);
        }
    }
}
