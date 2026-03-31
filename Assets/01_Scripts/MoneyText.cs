using TMPro;
using UnityEngine;

public class MoneyText : MonoBehaviour
{
    public TextMeshProUGUI moneyText;

    private void Start()
    {
        moneyText = gameObject.GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        moneyText.text = "$" + MoneyManager.instance.money.ToString();
    }
}
