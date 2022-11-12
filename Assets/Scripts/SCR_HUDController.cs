using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_HUDController : MonoBehaviour
{
    private SpriteRenderer s_Rendered;
    public UnityEngine.UI.Text t_HP;
    public Sprite s_RedSprite;
    public Sprite s_GreenSprite;
    public Sprite s_BlueSprite;
    public SCR_PlayerController s_PlayerController;    
    public SCR_HPPlayer s_HPPlayer;        
    
    void Start()
    {
        s_Rendered = GetComponent<SpriteRenderer>();
        t_HP.text = s_HPPlayer.GetHP();
    }
    
    void Update()
    {
        t_HP.text = s_HPPlayer.GetHP();
        switch (s_PlayerController.GetTypeShoot())
        {
            case 0: s_Rendered.sprite = s_RedSprite;    break;
            case 1: s_Rendered.sprite = s_GreenSprite;  break;
            case 2: s_Rendered.sprite = s_BlueSprite;   break;
        }
    }
}
