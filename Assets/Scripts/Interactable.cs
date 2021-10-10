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
    [Header("Tagets")]
    public List<GameObject> water;
    public List<GameObject> dirt;
    [Header("Next Puzzle")]
    public Interactable puzzle;
    [Header("TIMER TYPE")]
    public GameObject target;
    public float Timer;
    private bool runningTime = false;
    [Header("GEAR TYPE")]
    public Vector3 newRotation;
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
                ActiveList(water, true);
                if (puzzle != null)
                    puzzle.enabled = true;
                ActiveList(dirt, false);
                gameObject.SetActive(false);
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
                transform.rotation = Quaternion.Euler(newRotation);
                ActiveList(water, true);
                if(puzzle!=null)
                    puzzle.enabled = true;
                ActiveList(dirt, false);
                break;


            //INTERCAMBIAMOS LA POSICION DEL OBJETO DEL PUNTO INICIAL AL PUNTO B Y VICEVERSA
            case objectType.MOVE:
                if(newPosition!=null)
                {
                    transform.position = newPosition.position;
                    ActiveList(water, true);
                    ActiveList(dirt, false);
                    if (puzzle != null)
                        puzzle.enabled = true;
                    this.enabled = false;
                }

                break;
        }

    }

    private void Active()
    {
        target.SetActive(true);
        runningTime = false;
    }

    private void ActiveList(List<GameObject> objects, bool state)
    {
        for (int i = 0; i < objects.Count; i++)
        {
            objects[i].SetActive(state);
        }
    }

}
