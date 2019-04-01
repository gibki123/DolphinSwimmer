using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ButtonHandler : MonoBehaviour
{

    public delegate void StartButton();
    public static StartButton OnClickStartButton;
    public RectTransform gameName;
    public RectTransform gameButtons;
    public RectTransform shopWindow;
    public DolphinMovement movementScript;
    public Rigidbody dolphinRig;


    void Awake()
    {
        OnClickStartButton += MoveObjects;
        OnClickStartButton += EnableMoveScript;
    }

    public void ClickStartButton()
    {
        OnClickStartButton.Invoke();
    }

    void MoveObjects()
    {
        gameButtons.DOLocalMoveY(-225f, 1f);
        gameName.DOLocalMoveY(325f, 1f);
    }

    void ShopClick()
    {
        //TODO end click functions
       // shopWindow.DOLocalMoveX();
      //  gameButtons.DOLocalMoveX();
    }
    
    void EnableMoveScript()
    {
        dolphinRig.useGravity = true;
        movementScript.enabled = true;
    }
}
