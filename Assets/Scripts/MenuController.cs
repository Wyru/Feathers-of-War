using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public Animator canvasAnimator;

    public void ShowControls(){
        canvasAnimator.SetBool("Controls", true);
    }

    public void ShowCredits(){
        canvasAnimator.SetBool("Credits", true);
    }

    public void ShowMenu(){
        canvasAnimator.SetBool("Controls", false);
        canvasAnimator.SetBool("Credits", false);
    }
}
