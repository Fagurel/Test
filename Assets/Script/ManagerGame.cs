using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerGame : MonoBehaviour
{
    public static ManagerGame Instance;
    public List<GameObject> Objects = new List<GameObject>();
    public Material materialObjects;
    public float
        limitPosX,
        limitPosY;

    [SerializeField] private float
        timeSpown;

    private float rColorValue, gColorValue, bColorValue;

    void Awake()
    {
        Instance = this;
    }

    void OnGUI()
    {
        GUI.Box(new Rect(0,0, 120, 80),"");

        GUI.Box(new Rect(0,0, 20, 20), "R");
        rColorValue = GUI.HorizontalSlider(new Rect(20, 5, 100, 30), rColorValue, 0.0f, 256.0f);

        GUI.Box(new Rect(0,25, 20, 20), "G");
        gColorValue = GUI.HorizontalSlider(new Rect(20, 30, 100, 30), gColorValue, 0.0f, 256.0f);

        GUI.Box(new Rect(0,50, 20, 20), "B");
        bColorValue = GUI.HorizontalSlider(new Rect(20, 55, 100, 30), bColorValue, 0.0f, 256.0f);
        materialObjects.color = new Color(rColorValue, gColorValue, bColorValue);
    }


    void Start()
    {
        StartCoroutine(InstantiateObj());
        Invoke("TestInstantiateObj", 2);
    }

    private void TestInstantiateObj()
    {
        GameObject ob = Instantiate(Objects[Mathf.FloorToInt(Randoms(0, Objects.Count))],
            new Vector2(0,0), Quaternion.identity) as GameObject;
        ob.SetActive(true);
    }

    IEnumerator InstantiateObj()
    {
        while (true)
        {
           GameObject ob = Instantiate(Objects[Mathf.FloorToInt(Randoms(0, Objects.Count))],
                new Vector2(Randoms(-limitPosX, limitPosX), Randoms(-limitPosY, limitPosY)), Quaternion.identity) as GameObject;
            ob.SetActive(true);
            yield return new WaitForSeconds(timeSpown);
        }
    }

    private float Randoms(float min, float max)
    {
        float random = Random.Range(min, max);
        return random;
    }
}
