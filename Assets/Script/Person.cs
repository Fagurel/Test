using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    private float duration=100;

    [SerializeField] private GameObject shot;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(transform.position,ray.direction*duration);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0)&& Physics.Raycast(ray,out hit))
        {
            GameObject ob = Instantiate(shot, hit.collider.transform.position, Quaternion.identity) as GameObject;
            ob.SetActive(true);
        }

        if (Input.GetKey(KeyCode.LeftArrow)&&transform.position.x >- ManagerGame.Instance.limitPosX)
            transform.Translate(Vector3.left);
        if (Input.GetKey(KeyCode.RightArrow)&&transform.position.x < ManagerGame.Instance.limitPosX)
             transform.Translate(Vector3.right);
    }
}