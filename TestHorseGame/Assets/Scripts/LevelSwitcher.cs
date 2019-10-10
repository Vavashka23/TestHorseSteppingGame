using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSwitcher : MonoBehaviour
{
    public GameObject nine_field;
    public GameObject seven_field;
    public GameObject five_field;


    void Start()
    {
        nine_field = GameObject.FindGameObjectWithTag("NineField");
        seven_field = GameObject.FindGameObjectWithTag("SevenField");
        five_field = GameObject.FindGameObjectWithTag("FiveField");
        FiveClick();
    }

    public void NineClick()
    {
        nine_field.SetActive(true);
        seven_field.SetActive(false);
        five_field.SetActive(false);
    }

    public void SevenClick()
    {
        nine_field.SetActive(false);
        seven_field.SetActive(true);
        five_field.SetActive(false);
    }

    public void FiveClick()
    {
        nine_field.SetActive(false);
        seven_field.SetActive(false);
        five_field.SetActive(true);
    }
}
