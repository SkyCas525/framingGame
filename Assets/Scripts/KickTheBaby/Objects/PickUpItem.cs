using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    
    Transform Player;
    [SerializeField] float speed = 5f;
    [SerializeField] float pickUpDistance = 1.5f;
    [SerializeField] float ttl = 10f;

    private void Awake()
    {
        Player = GameManager.Instance.player.transform;
    }

    private void Update()
    {
        ttl -= Time.deltaTime;
        if (ttl<0) { Destroy(gameObject); }

        float distance = Vector3.Distance(transform.position, Player.position);

        if (distance> pickUpDistance)
        {
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);

        if (distance< 0.1f)
        {
            Destroy(gameObject);
        }
    }
}
