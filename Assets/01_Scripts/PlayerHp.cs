using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHp : HpScript
{
    public GameObject gameOver;
    public Image playerHpBar;
    public TextMeshProUGUI playerHpText;

    void Start()
    {
        curHp = maxHp;
        playerHpText.text = $"PlayerHp:{maxHp}";
    }
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        playerHpBar.fillAmount = curHp / maxHp;
        playerHpText.text = $"PlayerHp:{curHp}";
        this.gameObject.AddComponent<Attacked>();
        if (curHp == 0)
            Time.timeScale = 0;
    }
    public override void Heal(float amount)
    {
        base .Heal(amount);
        playerHpBar.fillAmount = curHp / maxHp;
        playerHpText.text = $"PlayerHp:{curHp}";
    }
}
 