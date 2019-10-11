using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMoving : MonoBehaviour
{
    public GameObject nine_field, seven_field, five_field;
    private int level = 5;
    private static bool isMoving;
    private Vector2 currentPos, targetPos, fieldY, moveXY, startPos;
    private Vector4 currentFied;
    private float speed = 250f;
    public LevelSwitcher levelSwitcher;

    void Start()
    {
        // nine_field = GameObject.FindGameObjectWithTag("NineField");
        // seven_field = GameObject.FindGameObjectWithTag("SevenField");
        // five_field = GameObject.FindGameObjectWithTag("FiveField");
        currentPos = transform.position;
        fieldY = new Vector2(Screen.height/2+Screen.width/2, Screen.height/2-Screen.width/2);
        startPos = transform.position;
        isMoving = false;
    }

    public bool GetIsMoving()
    {
        return isMoving;
    }

    [System.Obsolete]
    void Update()
    {
        currentPos = transform.position;
        startPos = levelSwitcher.GetStartPos(level);
        
        if(five_field.active)
        {
            level = 5;
        }
        else if(seven_field.active)
        {
            level = 7;
        }
        else
        {
            level = 9;
        }

        if (Input.GetMouseButtonDown(0) && !isMoving) {
            targetPos = Input.mousePosition;
            float cellBoard = Screen.width/(2*level);
            currentFied = new Vector4(currentPos.x - cellBoard, currentPos.x + cellBoard, currentPos.y + cellBoard, currentPos.y - cellBoard); // cell borders
            if(targetPos.y < fieldY.x && targetPos.y > fieldY.y && (targetPos.x > currentFied.y || targetPos.x < currentFied.x) && (targetPos.y > currentFied.z || targetPos.y < currentFied.w))
            {
                moveXY.x = (float)(cellBoard*2*Math.Truncate(targetPos.x/(cellBoard*2)))+startPos.x;
                moveXY.y = (float)(cellBoard*2*Math.Truncate((targetPos.y-Screen.width/2)/(cellBoard*2)))+(Screen.height - startPos.y);
                isMoving = true;
                StartCoroutine(MoveCoroutineX(moveXY.x));
            }
        }
    }
    
    IEnumerator MoveCoroutineX(float moveTo)
    {
        while (transform.position.x != moveTo)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(moveXY.x, transform.position.y), speed * Time.deltaTime);
            yield return null;
        }

        StartCoroutine(MoveCoroutineY(moveXY.y));

    }
    
    IEnumerator MoveCoroutineY(float moveTo)
    {
        while (transform.position.y != moveTo)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, moveXY.y), speed * Time.deltaTime);
            yield return null;
        }
        isMoving = false;
    }
}
