using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDeath : MonoBehaviour
{
   public GameObject panelEnd;
   private void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.GetComponent<DragAndShoot>() != null)
      {
         panelEnd.SetActive(true);
         Time.timeScale = 0f;
      }
   }
}
