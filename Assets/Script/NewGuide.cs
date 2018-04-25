using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewGuide : MonoBehaviour {
    //新手引导。判断是否第一次打开。
    int isFirstTime = 0;
    public GameObject guidePrefab;
    public GameObject bgObject;
    CanvasGroup canvasGroup;
    GameObject guideObject;
    Button guidBtn;
    // Use this for initialization
    void Start () {
        isFirstTime=PlayerPrefs.GetInt("isFirstTime", 0);
        canvasGroup = bgObject.GetComponent<CanvasGroup>();
        if (isFirstTime == 0)
        {
            canvasGroup.blocksRaycasts = true;
            canvasGroup.alpha = 0.38f;
            guideObject = Instantiate<GameObject>(guidePrefab, transform);
            guidBtn = guideObject.transform.GetComponentInChildren<Button>();
            guidBtn.onClick.AddListener(OnGuidClick);
           
        }
        else {
            canvasGroup.blocksRaycasts = true;
        }
       
    }

    private void OnGuidClick()
    {
        Debug.Log("新手引导点击完毕，回复正常");
        isFirstTime = 1;
        PlayerPrefs.SetInt("isFirstTime", isFirstTime);
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        if (guideObject != null) {
            Destroy(guideObject);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
