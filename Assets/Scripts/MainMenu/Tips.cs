using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // ƒобавл€ем пространство имен дл€ TextMesh Pro
using System; // ƒобавл€ем пространство имен дл€ использовани€ Action

public class Tips : MonoBehaviour
{
    public static Action<string> displayTipEvent;
    public static Action disableTipEvent;
    [SerializeField] private TMP_Text messageText;
    private Animator anim;
    private int ActiveTips;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        displayTipEvent += displayTip;
        disableTipEvent += disableTip;
    }

    private void OnDisable()
    {
        displayTipEvent -= displayTip;
        disableTipEvent -= disableTip;
    }

    private void displayTip(string message)
    {
        messageText.text = message;
        anim.SetInteger("state", ++ActiveTips);
    }

    private void disableTip()
    {
        anim.SetInteger("state", --ActiveTips);
    }
}
