using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider2 : MonoBehaviour
{
    [SerializeField] float speed;

    [SerializeField] Transform[] points;
    [SerializeField] Transform spider;
    int currentPoint;
   


    void Start()
    {
        
    }

    void Update()
    {
        spider.position = Vector3.MoveTowards(spider.position, points[currentPoint].position, speed * Time.deltaTime);

        if(Vector3.Distance(spider.position, points[currentPoint].position) < .5f)
        {
            currentPoint++;

            if(currentPoint >= points.Length)
            {
                currentPoint = 0;
            }
        }
    }
}
