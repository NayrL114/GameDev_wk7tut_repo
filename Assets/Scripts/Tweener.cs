using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweener : MonoBehaviour
{

    //private Tween activeTween;
    private List<Tween> activeTweens;
    //private float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        activeTweens = new List<Tween>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(activeTweens.Count);
        //if (activeTween != null)
        if (activeTweens.Count > 0)
        {
            for (int a = 0; a < activeTweens.Count; a++)// a normal for loop for convenient remove element operation
            {
                //timer += Time.deltaTime;
                if (Vector3.Distance(activeTweens[a].Target.position, activeTweens[a].EndPos) > 0.1f)
                {
                    //Debug.Log("First Condition");
                    //activeTween.Target.position = Vector3.Lerp(activeTween.StartPos, activeTween.EndPos, timer / activeTween.Duration);
                    // Relative distance will be (current distance away from starting point ) / (total distance)              

                    float fractionTime = (Time.time - activeTweens[a].StartTime) / activeTweens[a].Duration;
                    activeTweens[a].Target.position = Vector3.Lerp(activeTweens[a].StartPos, activeTweens[a].EndPos, fractionTime * fractionTime * fractionTime);
                    // Cubic easing in: function (t,b,c,d) t /= d; return c*t*t*t + b;
                    // t = current time; b = start value; c = change in value; d = duration;


                }
                else if (Vector3.Distance(activeTweens[a].Target.position, activeTweens[a].EndPos) <= 0.1f)
                {
                    activeTweens[a].Target.position = activeTweens[a].EndPos;
                    //activeTween = null;
                    activeTweens.RemoveAt(a);// remove this object from activeTweens list
                    a--;// move the iterator 1 position back to ensure the for loop will reach the correct next position
                }
            }
            
        }
        
    }

    /*
    public void AddTween(Transform targetObject, Vector3 startPos, Vector3 endPos, float duration)
    {
        if (activeTween == null) activeTween = new Tween(targetObject, startPos, endPos, Time.time, duration);
    }
    */

    public bool AddTween(Transform targetObject, Vector3 startPos, Vector3 endPos, float duration)
    {// add stuff into activeTween list
        //Debug.Log("inside AddTween()");
        if (activeTweens.Count == 0)// if the list is empty, just start put stuff in there
        {
            //Debug.Log("list if empty, adding object");
            activeTweens.Add(new Tween(targetObject, startPos, endPos, Time.time, duration));
            return true;
        }
        else if (TweenExists(targetObject))// if false, object exists in the activeTweens list
        {
            //Debug.Log("inside AddTween() first if");
            return false;
        }
        else
        {// else, put stuff into list
            //Debug.Log("inside AddTween() second if");
            activeTweens.Add(new Tween(targetObject, startPos, endPos, Time.time, duration));
            return true;
        }
    
    }

    public bool TweenExists(Transform target)
    {// loops through the activeTweens list to check if the passed in object exists in that list
        //Debug.Log("inside TweenExists()");
        for (int i = 0; i < activeTweens.Count; i++)
        {
            //Debug.Log("inside TweenExists() for loop");
            if (target == activeTweens[i].Target)
            {
                //Debug.Log("inside TweenExists() if loop");
                return true;
            }
        }
        return false;
    }

}
