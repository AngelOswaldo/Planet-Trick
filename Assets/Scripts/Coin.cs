using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Coin : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if(GameManager.instance.coinPicked!=true)
        {
            GameManager.instance.PickCoin();
            gameObject.SetActive(false);
        }
    }



}
