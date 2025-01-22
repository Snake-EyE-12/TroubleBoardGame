using System;
using UnityEngine;

public class Destinator : MonoBehaviour
{
    private Vector3 currentDestination;
    private bool moving;
    [SerializeField] private float speed;

    public void Move(Vector3 position)
    {
        currentDestination = position;
        moving = true;
    }

    private void Update()
    {
        if (moving)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentDestination, speed * Time.deltaTime);
            if (transform.position == currentDestination)
            {
                moving = false;
            }
            
        }
    }
}
