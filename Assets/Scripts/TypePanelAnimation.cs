using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypePanelAnimation : MonoBehaviour
{
      [Header("PanelAnimator")]
      public Animator animator;
      [Header("Type of animation")]
      public int animationType;
      
      
      //Function called when the panel has been active
      public void OnEnable()
      {
            animator.SetBool("IsActive", true);
            animator.SetInteger("AnimationType", animationType);

      }
      
      // Button OnClick Function to close the panel;
      public void ClosePanel()
      {
            animator.SetBool("IsActive", false);
      }
      
      // Function called after the closing animation finish;
      public void CloseAfterAnimation()
      {
            
            transform.parent.gameObject.SetActive(false);
      }
}      
