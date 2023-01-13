using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tower_stats : MonoBehaviour
{
  [SerializeField] private GameObject tower;
  private float maxHp = 10;
  private float hp = 10;
  private float hpRegen = 0;
  [SerializeField] private Text hpText;
  [SerializeField] private Text hpRegenText;
  private float damage = 1;
  [SerializeField] private Text damageText;
  private float range = 5;
  [SerializeField] private GameObject rangeMarker;
  [SerializeField] private Slider hpBar;
  [SerializeField] private Camera playerCamera;
  [SerializeField] private float zoomSpeed;
  private bool regening;

    // Start is called before the first frame update
    void Start()
    {
      rangeMarker.transform.parent = null;
      UpdateHp();
      UpdateHpRegen();
      UpdateDamage();
      UpdateRange();
    }

    void Update()
    {
      if(!regening) StartCoroutine(Regen());
    }

    public float GetMaxHp(){return maxHp;}
    public float GetHp(){return hp;}
    public float GetHpRegen(){return hpRegen;}
    public float GetDamage(){return damage;}
    public float GetRange(){return range;}
    public void SetMaxHp(float input){maxHp = input; UpdateHp();}
    public void SetHp(float input){hp = input; UpdateHp();}
    public void SetHpRegen(float input){hpRegen = input; UpdateHpRegen();}
    public void SetDamage(float input){damage = input; UpdateDamage();}
    public void SetRange(float input){range = input; UpdateRange();}

    void UpdateHp()
    {
      if(hp > maxHp) hp = maxHp;
      hpText.text = hp + ":" + maxHp;
      hpBar.maxValue = maxHp;
      hpBar.value = hp;
    }

    void UpdateHpRegen()
    {
      hpRegenText.text = "" + hpRegen;
    }

    void UpdateDamage()
    {
      damageText.text = "" + damage;
    }

    void UpdateRange()
    {
      StartCoroutine(Zoom());
      rangeMarker.transform.localScale = new Vector3(range, range, 1);
    }

    IEnumerator Zoom()
    {
      while(playerCamera.orthographicSize < range){
        playerCamera.orthographicSize+=zoomSpeed;
        if(playerCamera.orthographicSize > range) playerCamera.orthographicSize = range;
        yield return new WaitForSeconds(0.1f);
      }
    }

    IEnumerator Regen()
    {
      regening = true;
      if(hp != maxHp){
        hp += hpRegen/10;
        UpdateHp();
        yield return new WaitForSeconds(0.1f);
      }
      regening = false;
    }
}
