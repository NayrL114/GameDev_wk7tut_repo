using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{

    [SerializeField] private GameObject item;
    private Tweener tweener;
    public Text keyText;
    private int keyTime;

    //private Transform itemTrans;
    
    // Start is called before the first frame update
    void Start()
    {
        tweener = GetComponent<Tweener>();
    }

    // Update is called once per frame
    void Update()
    {

        // UI
        keyTime++;
        if (keyTime == 300)
        {
            keyText.text = " ";
            keyTime = 0;
        }
            
        // Inputs
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Moving Left");
            tweener.AddTween(item.GetComponent<Transform>(), item.GetComponent<Transform>().position, new Vector3(-2.0f, 0.5f, 0.0f), 1.5f);
            keyText.text = "A";
            keyTime = 0;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Moving Right");
            tweener.AddTween(item.GetComponent<Transform>(), item.GetComponent<Transform>().position, new Vector3(2.0f, 0.5f, 0.0f), 1.5f);
            keyText.text = "D";
            keyTime = 0;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Moving Down");
            tweener.AddTween(item.GetComponent<Transform>(), item.GetComponent<Transform>().position, new Vector3(0.0f, 0.5f, -2.0f), 1.5f);
            keyText.text = "S";
            keyTime = 0;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Moving Up");
            tweener.AddTween(item.GetComponent<Transform>(), item.GetComponent<Transform>().position, new Vector3(0.0f, 0.5f, 2.0f), 1.5f);
            keyText.text = "W"; 
            keyTime = 0;
        }
        //AddTween(Transform targetObject, Vector3 startPos, Vector3 endPos, float duration)

    }


}
