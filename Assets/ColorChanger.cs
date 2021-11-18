 using System;
 using UnityEngine;
 using UnityEngine.UI;
 public class ColorChanger : MonoBehaviour
 {
     public Text miText;
     /// <summary>
     /// Sets the color of the specified transform.
     /// </summary>
     /// <param name="trans"></param>
     /// <param name="color"></param>
     private void SetColor(Transform trans, Color color)
     {
         trans.GetComponent<Renderer>().material.color = color;
     }

     /// <summary>
     /// Updates the color of GameObject with the names specified in the input values.
     /// </summary>
     /// <param name="values"></param>
     public void UpdateColor(string[] values)
     {
         print(values.Length);
         var shapeString = values[1];
         print(shapeString);
         var colorString = values[2];
         print(colorString);   

        miText.text=shapeString+"   "+colorString;
        
         if (!ColorUtility.TryParseHtmlString(colorString, out var color)) return;
         if (string.IsNullOrEmpty(shapeString)) return;

         foreach (Transform child in transform) // iterate through all children of the gameObject.
         {
             if (child.name.IndexOf(shapeString, StringComparison.OrdinalIgnoreCase) != -1) // if the name exists
             {
                 SetColor(child, color);
                 return;
             }
         }
     }
 }
