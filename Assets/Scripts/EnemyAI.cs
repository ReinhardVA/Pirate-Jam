using UnityEngine;
using Pathfinding;
using System;

public class EnemyAI : MonoBehaviour
{

    public Transform target;
    public float speed = 200f;
    public float nextWayPointDistance = 3f;
    private Path path;
    private int currentWayPoint = 0;
    private bool reachedEndOfPath = false;
    private Seeker seeker;
    private Rigidbody2D rb;
    private void Start(){
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }
    private void FixedUpdate(){
        if(path == null){
            return;
        }
        if(currentWayPoint >= path.vectorPath.Count){
            reachedEndOfPath = true;
            return;
        }
        else{
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWayPoint] - rb.position).normalized;

        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]);

        if(distance < nextWayPointDistance){
            currentWayPoint++;
        }
    }

    private void OnPathComplete(Path p)
    {
        if(!p.error){
            path = p;
            currentWayPoint = 0;
        }
    }
    
    void UpdatePath(){
        if(seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }


}
