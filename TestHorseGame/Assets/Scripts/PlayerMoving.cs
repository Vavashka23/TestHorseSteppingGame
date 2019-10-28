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
    private float speed = Screen.width/2.5f;
    public LevelSwitcher levelSwitcher;
    private List<Vector2> movingList= new List<Vector2>();

    void Start()
    {
        currentPos = transform.position;
        fieldY = new Vector2(Screen.height/2+Screen.width/2, Screen.height/2-Screen.width/2);
        // Debug.Log("field - " + fieldY);
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

        if (Input.GetMouseButtonDown(0)) {
            targetPos = Input.mousePosition;
            // Debug.Log("Mouse - " + targetPos);
            float cellBoard = Screen.width/(2*level);
            currentFied = new Vector4(currentPos.x - cellBoard, currentPos.x + cellBoard, currentPos.y + cellBoard, currentPos.y - cellBoard); // cell borders

            if(targetPos.y < fieldY.x && targetPos.y > fieldY.y && ((targetPos.x > currentFied.y || targetPos.x < currentFied.x) || (targetPos.y > currentFied.z || targetPos.y < currentFied.w)))
            {
                moveXY.x = (float)(cellBoard*2*Math.Truncate(targetPos.x/(cellBoard*2)))+startPos.x;
                moveXY.y = (float)(cellBoard*2*Math.Truncate((targetPos.y-(Screen.height - Screen.width)/2)/(cellBoard*2)))+(Screen.height - startPos.y);
                // Debug.Log(moveXY);
                // Debug.Log(Math.Truncate((targetPos.y-(Screen.height - Screen.width)/2)/(cellBoard*2)) +"kk"+ (targetPos.y-(Screen.height - Screen.width)/2)/(cellBoard*2));
                if(movingList.Count == 0)
                {
                    movingList.Add(moveXY);
                }else {
                    if(movingList[movingList.Count-1] != moveXY)
                    {
                        movingList.Add(moveXY);
                    }
                }
                // foreach(Vector2 vec in movingList)
                // {
                //     Debug.Log(vec);
                // }
                // Debug.Log("END of LIST");
                if(!isMoving){
                    isMoving = true;
                    StartCoroutine(MoveCoroutineX(movingList[0].x));
                }
            }
        }
        if(movingList.Count != 0)
        {
            if(!isMoving){
                    isMoving = true;
                    StartCoroutine(MoveCoroutineX(movingList[0].x));
                }
        }
    }
    
    IEnumerator MoveCoroutineX(float moveTo)
    {
        while (transform.position.x != moveTo)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(movingList[0].x, transform.position.y), speed * Time.deltaTime);
            yield return null;
        }

        StartCoroutine(MoveCoroutineY(movingList[0].y));

    }
    
    IEnumerator MoveCoroutineY(float moveTo)
    {
        while (transform.position.y != moveTo)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, movingList[0].y), speed * Time.deltaTime);
            yield return null;
        }
        movingList.RemoveAt(0);
        isMoving = false;
    }
}
