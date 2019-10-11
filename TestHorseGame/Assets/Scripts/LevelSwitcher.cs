using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSwitcher : MonoBehaviour
{
    public GameObject nine_field, seven_field, five_field;
    public GameObject player;
    private Vector4 posFive, posSeven, posNine;
    private int level = 5;
    private bool isMoving = false;
    public PlayerMoving _pl;

    public Vector2 GetStartPos(int _level)
    {
        switch (_level)
        {
            case 5:
            return new Vector2(posFive.x, posFive.y);
            case 7:
            return new Vector2(posSeven.x, posSeven.y);
            case 9:
            return new Vector2(posNine.x, posNine.y);
            default:
            break;
        }
        return new Vector2(posFive.x, posFive.y);
    }


    void Start()
    {
        nine_field = GameObject.FindGameObjectWithTag("NineField");
        seven_field = GameObject.FindGameObjectWithTag("SevenField");
        five_field = GameObject.FindGameObjectWithTag("FiveField");
        player = GameObject.FindGameObjectWithTag("Horse");
        posFive = new Vector4(Screen.width/(5*2), Screen.height/2+Screen.width/2 - Screen.width/(2*5), 1f, 1f);
        posSeven = new Vector4(Screen.width/(7*2), Screen.height/2+Screen.width/2 - Screen.width/(2*7), 1f, 1f);
        posNine = new Vector4(Screen.width/(9*2), Screen.height/2+Screen.width/2 - Screen.width/(2*9), 1f, 1f);
        FiveClick();
    }

    private void Update() {
        isMoving = _pl.GetIsMoving();
    }

    public void NineClick()
    {
        if(!isMoving)
        {
            nine_field.SetActive(true);
            seven_field.SetActive(false);
            five_field.SetActive(false);
            level = 9;
            player.transform.position = new Vector2(posNine.x, posNine.y);
            player.transform.localScale = new Vector3(0.6f, 0.6f, 1f);
        }
    }

    public void SevenClick()
    {
        if(!isMoving)
        {
            nine_field.SetActive(false);
            seven_field.SetActive(true);
            five_field.SetActive(false);
            level = 7;
            player.transform.position = new Vector2(posSeven.x, posSeven.y);
            player.transform.localScale = new Vector3(0.7f, 0.7f, 1f);
        }
    }

    public void FiveClick()
    {
        if(!isMoving)
        {
            nine_field.SetActive(false);
            seven_field.SetActive(false);
            five_field.SetActive(true);
            level = 5;
            player.transform.position = new Vector2(posFive.x, posFive.y);
            player.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
