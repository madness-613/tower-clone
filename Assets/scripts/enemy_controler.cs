using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_controler : MonoBehaviour
{
  private GameObject enemy;
  private GameObject player;
  private enemy_stats stats;
    // Start is called before the first frame update
    void Start()
    {
      enemy = this.gameObject;
      player = GameObject.Find("tower");
      stats = this.gameObject.GetComponent<enemy_stats>();
    }

    void FixedUpdate()
    {
      var step =  stats.moveSpeed * Time.deltaTime;
      enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, player.transform.position, step);
    }
}
