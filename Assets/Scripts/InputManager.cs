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
    private List<GameObject> itemList;

    //private Transform itemTrans;
    
    // Start is called before the first frame update
    void Start()
    {
        itemList = new List<GameObject>();
        itemList.Add(item);
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
            //tweener.AddTween(item.GetComponent<Transform>(), item.GetComponent<Transform>().position, new Vector3(-2.0f, 0.5f, 0.0f), 1.5f);
            addTweener(new Vector3(-2.0f, 0.5f, 0.0f), 1.5f);
            keyText.text = "A";
            keyTime = 0;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Moving Right");
            //tweener.AddTween(item.GetComponent<Transform>(), item.GetComponent<Transform>().position, new Vector3(2.0f, 0.5f, 0.0f), 1.5f);
            addTweener(new Vector3(2.0f, 0.5f, 0.0f), 1.5f);
            keyText.text = "D";
            keyTime = 0;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Moving Down");
            //tweener.AddTween(item.GetComponent<Transform>(), item.GetComponent<Transform>().position, new Vector3(0.0f, 0.5f, -2.0f), 1.5f);
            addTweener(new Vector3(0.0f, 0.5f, -2.0f), 1.5f);
            keyText.text = "S";
            keyTime = 0;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Moving Up");
            //tweener.AddTween(item.GetComponent<Transform>(), item.GetComponent<Transform>().position, new Vector3(0.0f, 0.5f, 2.0f), 1.5f);
            addTweener(new Vector3(0.0f, 0.5f, 2.0f), 1.5f);
            keyText.text = "W"; 
            keyTime = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Adding new box");
            GameObject itemClone = Instantiate(item, new Vector3(0.0f, 0.5f, 0.0f), item.transform.rotation);
            itemList.Add(itemClone);
            keyText.text = "Space";
            keyTime = 0;
        }
        //AddTween(Transform targetObject, Vector3 startPos, Vector3 endPos, float duration)

    }

    private void addTweener(Vector3 endPos, float duration)
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            if (tweener.AddTween(itemList[i].GetComponent<Transform>(), itemList[i].GetComponent<Transform>().position, endPos, duration))// if AddTween returns true
            {
                //Debug.Log("supposely a tween should be added successfully");
                i = itemList.Count;
                //break;
            }
            //Debug.Log(i + " and itemList count is " + itemList.Count);
            // else, do nothing if AddTween returns false
        }
                        
    }


}
