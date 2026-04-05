using UnityEngine;

public class ItemClick : MonoBehaviour
{
    public int price;
    public void ClickItem(int index)
    {
        if(MoneyManager.instance.money > index)
        {
            Debug.Log("click");
             MoneyManager.instance.SpendMoney(price);
            PlayerManager.instance.haveParts[index] = 1;
        }
    }
}