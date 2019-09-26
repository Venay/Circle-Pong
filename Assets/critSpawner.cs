using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class critSpawner : MonoBehaviour
{
    public circle C;
    
    void Start()
    {

        destroyed();
    }

    
    void Update()
    {
        
        if (!C.circlePositions2D.Contains((Vector2)transform.localPosition))
        {
            pong.score -= 5;
            destroyed();

        }

        

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            pong.score += 5;
            StartCoroutine(spawnCrit());
            Debug.Log("got a crit");
        }
    }




    void destroyed()
    {
        transform.localPosition = C.circlePositions2D[Random.Range(0, C.circlePositions2D.Count)];
    }


    IEnumerator spawnCrit()
    {

        yield return new WaitForSeconds(1);
        destroyed();

    }





}
