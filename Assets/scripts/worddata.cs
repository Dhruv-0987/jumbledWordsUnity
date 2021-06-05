using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class worddata : MonoBehaviour
{
    public static worddata instance;
    public Text wordtext;
    [HideInInspector] char charvalue;
    public Button buttonobj;
    
    // Start is called before the first frame update

    public char getcharvalue()
    {
        return charvalue;
    }
    private void Awake()
    {
        buttonobj = GetComponent<Button>();
        if (buttonobj)
        {
            buttonobj.onClick.AddListener(() => WordSelected());
        }
        
    }

   
    public void SetWord(char value)
    {
        wordtext.text = value.ToString();
        charvalue = value;
    }
    
    public void WordSelected()
    {
        control.instance.setselectedoption(this);
    }
    
}
