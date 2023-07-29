using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Flight : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool holdingButton;
    public bool isFlyig;
    float holdTimer;
    public float requiredTime;
    public InputHandle handle;
    public AnimationBird anim;
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        holdingButton = true;
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        holdingButton = false;
        handle.Fly = false;
        handle.JumpHold = false;
        handle.Jump = false;
        holdTimer = 0;
    }


    void Update()
    {
        if(holdingButton)
        {
            if (anim.isGrounded)
            {
                handle.Vertical = 1;
                holdTimer += Time.deltaTime;

                if (holdTimer >= requiredTime)
                {
                    handle.Fly = true;
                    handle.JumpHold = true;
                    handle.Jump = true;
                    handle.Vertical = 0;
                }
            }
            else
            {
                handle.Fly = true;
                handle.Jump = true;
            }

            
        }
    }
}
