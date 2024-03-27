using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float speed = 2;

    int index = 0;

    public bool canMove;

    public List<Transform> waypoints;

    public GameObject vfxGoal;

    public GameObject vfxLap;

    private void Awake()
    {
        canMove = true;
    }

    private void Update()
    {
        if (!canMove) return;

        Vector3 destination = waypoints[index].transform.position;
        Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        transform.position = newPos;

        float distance = Vector3.Distance(transform.position, destination);
        if (distance <= 0.05)
        {
            if (index < waypoints.Count - 1)
            {
                index++;
            }
            else
            {
                index = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.CompareTag("Goal"))
        {
            GameObject vfx = Instantiate(vfxGoal, transform.position, Quaternion.identity) as GameObject;

            Destroy(vfx, 1f);

            GameManager.Instance.coin += 1;
        }

        if (collision != null && collision.CompareTag("Lap"))
        {
            GameObject vfx = Instantiate(vfxLap, transform.position, Quaternion.identity) as GameObject;

            Destroy(vfx, 1f);

            GameManager.Instance.coin += 5;
        }
    }

}