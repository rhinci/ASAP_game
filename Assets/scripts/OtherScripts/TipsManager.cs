using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal;
using UnityEngine;

public class TipsManager : MonoBehaviour
{
    public static Action<string> displayTipEvent;
    public static Action disableTipEvent;

    public TMP_Text messageText;

    private Animator anim;

    public int activeTips;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OnEnable()
    {
        displayTipEvent += displayTip;
        disableTipEvent += disableTip;
    }

    private void OnDisable()
    {
        displayTipEvent -= displayTip;
        disableTipEvent -= disableTip;
    }
    public void displayTip(string message)
    {
        messageText.text = message;
        anim.SetInteger("state", ++activeTips);
    }

    private void disableTip()
    {
        anim.SetInteger("state", --activeTips);
    }

}
