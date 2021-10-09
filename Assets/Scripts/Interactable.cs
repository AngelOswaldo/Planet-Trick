using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Interactable : MonoBehaviour, IPointerClickHandler
{
    public enum objectType
    {
        LEVER,
        TIMER,
        GEAR,
        MOVE
    }

    [Header("OBJECT TYPE")]
    public objectType type;
    public GameObject target;
    [Header("TIMER TYPE")]
    public float Timer;
    private bool runningTime = false;
    [Header("GEAR TYPE")]
    public float angle;
    public Vector3 angleRotation;
    public int clicks;
    private int actualClicks = 0;
    [Header("MOVE TYPE")]
    public Transform newPosition;
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(GameManager.instance.coinPicked!=true)
            Effect();
    }


    public void Effect()
    {
        switch(type)
        {
            //ACTIVAMOS O DESACTIVAMOS EL TARGET
            case objectType.LEVER:
                if (target.activeSelf)
                {
                    target.SetActive(false);
                }
                else
                {
                    target.SetActive(true);
                }
                break;

            //DESACTIVAMOS CIERTA CANTIDAD DE TIEMPO EL OBJETO TARGET Y LUEGO SE VUELVE ACTIVAR
            case objectType.TIMER:
                if(!runningTime)
                {
                    target.SetActive(false);
                    runningTime = true;
                    Invoke("Active", Timer);
                }
                break;

            //ROTAMOS EL OBJETO X CANTIDAD DE VECES PARA DESACTIVAR EL OBJETO TARGET
            case objectType.GEAR:
                if (actualClicks<clicks)
                {
                    transform.Rotate(angleRotation, angle);
                    actualClicks += 1;
                }
                else if (actualClicks>=clicks)
                {
                    target.SetActive(false);
                }
                break;


            //INTERCAMBIAMOS LA POSICION DEL OBJETO DEL PUNTO INICIAL AL PUNTO B Y VICEVERSA
            case objectType.MOVE:
                if (transform.position != newPosition.position)
                {
                    transform.position = newPosition.position;

                }
                else
                {
                    transform.position = startPosition;
                }
                break;
        }

    }

    private void Active()
    {
        target.SetActive(true);
        runningTime = false;
    }



}
