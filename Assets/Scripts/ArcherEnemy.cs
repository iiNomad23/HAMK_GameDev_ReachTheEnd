using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherEnemy : MonoBehaviour
{

    [SerializeField]
    private Transform player;
    [SerializeField]
    private float speed = 1.0f;
    [SerializeField]
    private float minDistance = 1.0f;
    [SerializeField]
    private Animator animator;

    // Update is called once per frame
    void Update()
    {

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        animator.SetFloat("Distance", distanceToPlayer);

        if (distanceToPlayer >= minDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }

        if (transform.position.x < player.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        } else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
