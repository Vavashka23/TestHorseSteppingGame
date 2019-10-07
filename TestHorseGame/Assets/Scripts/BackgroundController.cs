using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundController : MonoBehaviour
{
    private Image _image;
    private RectTransform _panel;
    private Sprite destSprite;
    private int screenSizeY;

    void Start()
    {
        _image = gameObject.GetComponent<Image>();
        _panel = gameObject.GetComponent<RectTransform>();
        screenSizeY = (Screen.height - 2048);
        Debug.Log(Screen.height);
        Debug.Log(screenSizeY*4.5f);
        if(Screen.height > 2048)
        {
            _panel.sizeDelta = new Vector2(_panel.sizeDelta.x, _panel.sizeDelta.y + (screenSizeY*4.5f));
        }
    }
}
