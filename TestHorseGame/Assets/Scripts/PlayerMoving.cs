using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    public GameObject nine_field;
    public GameObject seven_field;
    public GameObject five_field;
    private int level = 5;
    private bool isMoving = false;
    private Vector2 currentPos, targetPos, fieldY;
    private Vector4 currentFied;

    void Start()
    {
        nine_field = GameObject.FindGameObjectWithTag("NineField");
        seven_field = GameObject.FindGameObjectWithTag("SevenField");
        five_field = GameObject.FindGameObjectWithTag("FiveField");
        currentPos = transform.position;
        fieldY = new Vector2(Screen.height/2+Screen.width/2, Screen.height/2-Screen.width/2);
        // Debug.Log(fieldY);
    }

    [System.Obsolete]
    void Update()
    {
        
        currentPos = transform.position;
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
            float cellBoard = Screen.width/(2*level);
            currentFied = new Vector4(currentPos.x - cellBoard, currentPos.x + cellBoard, currentPos.y + cellBoard, currentPos.y - cellBoard); // cell borders
            if(targetPos.y < fieldY.x && targetPos.y > fieldY.y && (targetPos.x > currentFied.y || targetPos.x < currentFied.x) && (targetPos.y > currentFied.z || targetPos.y < currentFied.w))
                Debug.Log("Norm");
            else
            {
                Debug.Log("Bad");
            }
            // Debug.Log(Input.mousePosition);
            // Debug.Log(Screen.width +"s"+ Screen.height);
        }
    }
}
