using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweener : MonoBehaviour
{

    private Tween activeTween;
    private float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (activeTween != null)
        {
            timer += Time.deltaTime;
            if (Vector3.Distance(activeTween.Target.position, activeTween.EndPos) > 0.1f)
            {
                //Debug.Log("First Condition");
                activeTween.Target.position = Vector3.Lerp(activeTween.StartPos, activeTween.EndPos, timer / activeTween.Duration);
                // Relative distance will be (current distance away from starting point ) / (total distance)
                /*
                activeTween.Target.position = Vector3.Lerp(
                    activeTween.StartPos,
                    activeTween.EndPos,
                    Vector3.Distance(activeTween.Target.position, activeTween.StartPos) / Vector3.Distance(activeTween.StartPos, activeTween.EndPos)
                    );
                */
            }
            else if (Vector3.Distance(activeTween.Target.position, activeTween.EndPos) <= 0.1f)
            {
                //Debug.Log("Second Condition");
                activeTween.Target.position = activeTween.EndPos;
                activeTween = null;
                timer = 0;
            }
        }
        
    }

    public void AddTween(Transform targetObject, Vector3 startPos, Vector3 endPos, float duration)
    {
        if (activeTween == null) activeTween = new Tween(targetObject, startPos, endPos, Time.time, duration);
    }
}
