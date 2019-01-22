using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ControlesSave
{
    public string p1_Up;
    public string p1_Down;
    public string p1_Left;
    public string p1_Right;
    public string p1_Action;

    public string p2_Up;
    public string p2_Down;
    public string p2_Left;
    public string p2_Right;
    public string p2_Action;

    public string p3_Up;
    public string p3_Down;
    public string p3_Left;
    public string p3_Right;
    public string p3_Action;

    public string p4_Up;
    public string p4_Down;
    public string p4_Left;
    public string p4_Right;
    public string p4_Action;

    public ControlesSave(GameManager gameManager)
    {
        p1_Up = gameManager.p1_Up;
        p1_Down = gameManager.p1_Down;
        p1_Left = gameManager.p1_Left;
        p1_Right = gameManager.p1_Right;
        p1_Action = gameManager.p1_Action;

        p2_Up = gameManager.p2_Up;
        p2_Down = gameManager.p2_Down;
        p2_Left = gameManager.p2_Left;
        p2_Right = gameManager.p2_Right;
        p2_Action = gameManager.p2_Action;

        p3_Up = gameManager.p3_Up;
        p3_Down = gameManager.p3_Down;
        p3_Left = gameManager.p3_Left;
        p3_Right = gameManager.p3_Right;
        p3_Action = gameManager.p3_Action;

        p4_Up = gameManager.p4_Up;
        p4_Down = gameManager.p4_Down;
        p4_Left = gameManager.p4_Left;
        p4_Right = gameManager.p4_Right;
        p4_Action = gameManager.p4_Action;
    }
}
