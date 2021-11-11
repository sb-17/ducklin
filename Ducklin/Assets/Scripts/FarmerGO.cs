using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmerGO : MonoBehaviour
{
    public Image self;
    public Sprite self1;
    public Sprite self2;
    public Sprite stand;

    public Rigidbody2D rb;

    void Start()
    {
        StartCoroutine(UpDown());

        rb.AddForce(Vector2.right * 25000);
    }

    IEnumerator UpDown()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.3f);
            if (self.sprite == self1 || self.sprite == stand)
            {
                self.sprite = self2;
            }
            else if (self.sprite == self2)
            {
                self.sprite = self1;
            }
        }
    }
}
