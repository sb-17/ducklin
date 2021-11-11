using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateArena : MonoBehaviour
{
    public RectTransform floor1;
    public RectTransform floor2;
    public RectTransform floor3;
    public RectTransform floor4;
    public RectTransform floor5;

    public GameObject duckSpawn1;
    public GameObject duckSpawn2;
    public GameObject duckSpawn3;
    public GameObject duckSpawn4;
    public GameObject duckSpawn5;

    public Transform parentPos;

    public Image duck;

    public static int pos1;
    public static int pos2;
    public static int pos3;
    public static int pos4;

    List<int> spawns;

    void Start()
    {
        spawns = new List<int>{1, 2, 3, 4, 5, 6, 7, 8};

        int x = Random.Range(-681, 1119);
        pos1 = x;
        floor1.anchoredPosition = new Vector3(x, floor1.anchoredPosition.y, 0);

        x = Random.Range(-681, 1119);
        pos2 = x;
        floor2.anchoredPosition = new Vector3(x, floor2.anchoredPosition.y, 0);

        x = Random.Range(-681, 1119);
        pos3 = x;
        floor3.anchoredPosition = new Vector3(x, floor3.anchoredPosition.y, 0);

        x = Random.Range(-681, 1119);
        pos4 = x;
        floor4.anchoredPosition = new Vector3(x, floor4.anchoredPosition.y, 0);

        x = Random.Range(-681, 1119);
        floor5.anchoredPosition = new Vector3(x, floor5.anchoredPosition.y, 0);

        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        Instantiate(duck, duckSpawn1.transform.position, Quaternion.identity, parentPos);
        yield return new WaitForSeconds(0.5f);
        Instantiate(duck, duckSpawn2.transform.position, Quaternion.identity, parentPos);
        yield return new WaitForSeconds(0.5f);
        Instantiate(duck, duckSpawn3.transform.position, Quaternion.identity, parentPos);
        yield return new WaitForSeconds(0.5f);
        Instantiate(duck, duckSpawn4.transform.position, Quaternion.identity, parentPos);
        yield return new WaitForSeconds(0.5f);
        Instantiate(duck, duckSpawn5.transform.position, Quaternion.identity, parentPos);
    }
}
