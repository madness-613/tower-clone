using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class tower_upgrade : MonoBehaviour
{
  public float rangeUpgradeAmount;
  public float damageUpgradeAmount;
  public float hpUpgradeAmount;
  public float hpRegenUpgradeAmount;
  private GameObject statsUi;
  private tower_stats stats;
  private GameObject upgradeUi;
  private bool uiOpen;
  [SerializeField] private Text rangeUpgradeText;
  [SerializeField] private Text damageUpgradeText;
  [SerializeField] private Text hpUpgradeText;
  [SerializeField] private Text hpRegenUpgradeText;

    // Start is called before the first frame update
    void Start()
    {
      statsUi = GameObject.Find("stats");
      stats = statsUi.GetComponent<tower_stats>();
      upgradeUi = this.gameObject;
      rangeUpgradeText.text = "range : " + stats.GetRange();
      damageUpgradeText.text = "damage : " + stats.GetDamage();
      hpUpgradeText.text = "max Hp : " + stats.GetMaxHp();
      hpRegenUpgradeText.text = "hp regen : " + stats.GetMaxHp();
    }

    public void UpgradeRange()
    {
      stats.SetRange(stats.GetRange() + rangeUpgradeAmount);
      rangeUpgradeText.text = "range : " + stats.GetRange();
    }

    public void UpgradDamage()
    {
      stats.SetDamage(stats.GetDamage() + damageUpgradeAmount);
      damageUpgradeText.text = "damage : " + stats.GetDamage();
    }

    public void UpgradeHp()
    {
      stats.SetMaxHp(stats.GetMaxHp() + hpUpgradeAmount);
      hpUpgradeText.text = "max hp : " + stats.GetMaxHp();
    }

    public void UpgradeHpRegen()
    {
      stats.SetHpRegen(stats.GetHpRegen() + hpRegenUpgradeAmount);
      hpRegenUpgradeText.text = "hp regen : " + stats.GetHpRegen();
    }

    public void AdjustUi()
    {
      uiOpen = !uiOpen;
      if(uiOpen){
        statsUi.transform.position = new Vector2(statsUi.transform.position.x , 120);
        upgradeUi.transform.position = new Vector2(upgradeUi.transform.position.x , 50);
      }else{
        statsUi.transform.position = new Vector2(statsUi.transform.position.x , 25);
        upgradeUi.transform.position = new Vector2(upgradeUi.transform.position.x , -50);
      }
    }
}
