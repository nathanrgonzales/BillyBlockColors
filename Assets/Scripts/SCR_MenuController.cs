using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SCR_MenuController : MonoBehaviour
{
    public string s_SceneName;
    public int i_OptionSelected;
    public AudioClip a_SelectOption;
    public AudioClip a_EnterOption;
    private AudioSource a_Audio;
    public UnityEngine.UI.Text[] t_ListText;
    
    void Start()
    {
        i_OptionSelected = 0;
        a_Audio = GetComponent<AudioSource>();
        UpdateTextList();
    }
    
    void Update()
    {        
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            a_Audio.clip = a_SelectOption;
            a_Audio.Play();
            i_OptionSelected--;
            i_OptionSelected = i_OptionSelected < 0 ? 0 : i_OptionSelected;
            UpdateTextList();
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            a_Audio.clip = a_SelectOption;
            a_Audio.Play();
            i_OptionSelected++;
            i_OptionSelected = i_OptionSelected > (t_ListText.Length - 1) ? t_ListText.Length - 1 : i_OptionSelected;
            UpdateTextList();
        }

        if(s_SceneName == "StartGame")
        {
            if(Input.GetButtonDown("Enter"))
            {
                a_Audio.clip = a_EnterOption;
                a_Audio.Play();                
                switch (i_OptionSelected)
                {
                    case 0:
                        Time.timeScale = 1f;
                        StartCoroutine(TimePreLoader());
                        SceneManager.LoadScene("Stage01");
                        break;
                    case 1:
                        StartCoroutine(TimePreLoader());
                        SceneManager.LoadScene("Credits");
                        break;
                    case 2:
                        StartCoroutine(TimePreLoader());                        
                        #if UNITY_EDITOR
                            UnityEditor.EditorApplication.isPlaying = false;
                        #else
                            Application.Quit();
                        #endif

                        break;
                }
            }
        }
        else if(s_SceneName == "Stage01")
        {
            if(Input.GetButtonDown("Enter"))
            {
                a_Audio.clip = a_EnterOption;
                a_Audio.Play();                
                switch (i_OptionSelected)
                {
                    case 0:
                        Time.timeScale = 1f;
                        StartCoroutine(TimePreLoader());
                        SceneManager.LoadScene("Stage01");
                        break;
                    case 1:
                        StartCoroutine(TimePreLoader());
                        SceneManager.LoadScene("StartGame");
                        break;
                }
            }
        }
    }

    IEnumerator TimePreLoader()
    {
        yield return new WaitForSeconds(1.8f);
    }    

    void UpdateTextList()
    {
        int i_FontUpper = 60;
        int i_FontLower = 40;
        for(int i = 0; i < t_ListText.Length; i++)
        {
            t_ListText[i].fontStyle = i_OptionSelected == i ? UnityEngine.FontStyle.Bold : UnityEngine.FontStyle.Normal;
            t_ListText[i].fontSize  = i_OptionSelected == i ? i_FontUpper                : i_FontLower;            
        }
    }    
}
