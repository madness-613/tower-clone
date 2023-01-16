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
  private Vector2 statsUp;
  private Vector2 statsDown;
  private GameObject upgradeUi;
  private Vector2 upgradeUp;
  private Vector2 upgradeDown;
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
      statsUp = new Vector2(0 , statsUi.transform.localScale.y/2 + upgradeUi.transform.localScale.y/2);
      statsDown = new Vector2(0 , statsUi.transform.localScale.y/2);
      upgradeUp = new Vector2(0 , upgradeUi.transform.localScale.y/2);
      upgradeDown = new Vector2(0 , -upgradeUi.transform.localScale.y/2);
      rangeUpgradeText.text = "" + stats.GetRange();
      damageUpgradeText.text = "" + stats.GetDamage();
      hpUpgradeText.text = "" + stats.GetMaxHp();
      hpRegenUpgradeText.text = "" + stats.GetHpRegen();
    }

    public void UpgradeRange()
    {
      stats.SetRange(stats.GetRange() + rangeUpgradeAmount);
      rangeUpgradeText.text = "" + stats.GetRange();
    }

    public void UpgradDamage()
    {
      stats.SetDamage(stats.GetDamage() + damageUpgradeAmount);
      damageUpgradeText.text = "" + stats.GetDamage();
    }

    public void UpgradeHp()
    {
      stats.SetMaxHp(stats.GetMaxHp() + hpUpgradeAmount);
      hpUpgradeText.text = "" + stats.GetMaxHp();
    }

    public void UpgradeHpRegen()
    {
      stats.SetHpRegen(stats.GetHpRegen() + hpRegenUpgradeAmount);
      hpRegenUpgradeText.text = "" + stats.GetHpRegen();
    }

    public void AdjustUi()
    {
      uiOpen = !uiOpen;
      if(uiOpen){
        statsUi.transform.position = statsUp;
        upgradeUi.transform.position = upgradeUp;
      }else{
        statsUi.transform.position = statsDown;
        upgradeUi.transform.position = upgradeDown;
      }
    }
}
