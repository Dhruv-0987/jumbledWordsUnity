using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class draggable : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public static draggable instance;
    public Transform parenttoreturn = null;
    public  Vector3 startposition;
    bool move = true;
    CanvasGroup canvasgroup;
    public Text draggertext;
    private void Awake()
    {
        
        canvasgroup = GetComponent<CanvasGroup>();
        draggertext = GetComponent<Text>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        move = true;
        if (move) { 
        startposition = this.transform.parent.transform.position;
            move = false;
        }
       
        canvasgroup.blocksRaycasts = false;
        Debug.Log("dragon" + startposition);
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
        this.transform.position = startposition;
        canvasgroup.blocksRaycasts = true;
        Debug.Log("end drag");
    }

   
}
