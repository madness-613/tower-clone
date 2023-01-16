using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_controler : MonoBehaviour
{
  private GameObject enemy;
  private GameObject player;
  private tower_stats playerStats;
  private enemy_stats stats;
  private bool canHit = true;
    // Start is called before the first frame update
    void Start()
    {
      enemy = this.gameObject;
      player = GameObject.Find("tower");
      playerStats = GameObject.Find("stats").GetComponent<tower_stats>();
      stats = this.gameObject.GetComponent<enemy_stats>();
    }

    void OnCollisionStay2D(Collision2D collision)
    {
      if(canHit) StartCoroutine(Damage());
    }

    IEnumerator Damage()
    {
      canHit = false;
      playerStats.SetHp(playerStats.GetHp() - stats.damage);
      yield return new WaitForSeconds(1f);
      canHit = true;
    }

    void FixedUpdate()
    {
      var step =  stats.moveSpeed * Time.deltaTime;
      enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, player.transform.position, step);
    }
}
