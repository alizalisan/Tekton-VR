
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class VRButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{ 

    void Start()
    {
       
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        OnHoverEnter();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnHoverExit();
    }

  

    public void OnHoverEnter()
    {
        print("Success!");
        Material mat = new Material(Shader.Find("Standard"));

        mat.color = Color.red;
        Renderer rend = gameObject.GetComponent<Renderer>();
        rend.material = mat;
    }

    public void OnHoverExit()
    {
        print("Success11!");
        Material mat = new Material(Shader.Find("Standard"));

        mat.color = Color.blue;
        Renderer rend = gameObject.GetComponent<Renderer>();
        rend.material = mat;
    }

   

}
