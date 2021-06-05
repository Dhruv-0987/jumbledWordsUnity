using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class dropzine : MonoBehaviour, IDropHandler
{
   [SerializeField]private Text onit;
    //private Text temp;
    private void Awake()
    {
       // onit = GetComponent<Text>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        draggable letter = eventData.pointerDrag.GetComponent<draggable>();
        if (letter != null)
        {
            control.instance.dragsetselectedoption(letter);
            onit.text = letter.draggertext.text;
           
        }
       
        Debug.Log("drop");
    }
}
