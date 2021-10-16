using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Win Parameters")]
    public GameObject victoryPanel;
    public GameObject controls;
    public bool coinPicked = false;

    [Header("Dynamic Objects")]
    public PostProcessing negativeEffect;
    //public GameObject sun;
    public List<GameObject> negativeObjects;
    public List<GameObject> positiveObjects;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void PickCoin()
    {
        coinPicked = true;
        victoryPanel.SetActive(true);
        controls.SetActive(false);
    }

    public void SwitchLight()
    {
        if (negativeEffect.enabled == false)
        {
            negativeEffect.enabled = true;
            //sun.SetActive(false);
            SwitchObjects(negativeObjects, true);
            SwitchObjects(positiveObjects, false);
        }
        else
        {
            negativeEffect.enabled = false;
            //sun.SetActive(true);
            SwitchObjects(negativeObjects, false);
            SwitchObjects(positiveObjects, true);
        }
    }

    private void SwitchObjects(List<GameObject> objects, bool state)
    {
        for (int i = 0; i < objects.Count; i++)
        {
            objects[i].SetActive(state);
        }
    }
}
