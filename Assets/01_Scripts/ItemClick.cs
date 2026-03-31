using UnityEngine;

public class ItemClick : MonoBehaviour
{
    public void ClickItem(int index)
    {
        if(MoneyManager.instance.money > index)
        {
            Debug.Log("click");
             MoneyManager.instance.SpendMoney(index);
            PlayerManager.instance.haveParts[index] = 1;
        }
    }
}
