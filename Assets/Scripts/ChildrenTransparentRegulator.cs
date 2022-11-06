using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ChildrenTransparentRegulator : MonoBehaviour
{
    [Range(0,1)] [SerializeField] private float _transparentness = .3f;


    private void OnValidate()
    {
      //  WithForeachLoop();
        WithForLoop();
    }


    void WithForeachLoop()
    {
        int i = 0;
        foreach (Transform child in transform)
        {
            if(child.TryGetComponent(out SpriteRenderer renderer))
            {
                print("For loop: " + i + " " + child);
                i++;
                var modifiyedColour = renderer.color;
                modifiyedColour.a = _transparentness;
                renderer.color = modifiyedColour;
            }
        }
            
    }

    void WithForLoop()
    {
        Transform[] allRendrerers = transform.GetComponentsInChildren<Transform>();

        for (int i = 0; i < allRendrerers.Length - 1;i ++)
        {
            if (allRendrerers[i] == null) continue;
            if (allRendrerers[i].TryGetComponent(out SpriteRenderer renderer))
            {
                print("For loop: " + i + " " + allRendrerers[i]);
                var modifiyedColour = renderer.color;
                modifiyedColour.a = _transparentness;
                renderer.color = modifiyedColour;
            }
        }
            //0.3
    }
}
