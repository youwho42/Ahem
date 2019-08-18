using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScreenManager : MonoBehaviour
{
    public static UIScreenManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        foreach (GameObject g in Resources.LoadAll("Screens", typeof(GameObject)))
        {
            GameObject go = Instantiate(g.gameObject, transform.position, Quaternion.identity) as GameObject;
            go.transform.SetParent(transform);
            //go.SetActive(false);
            go.SetActive(false);
            screens.Add(go);
        }
    }
    private List<GameObject> screens = new List<GameObject>();

    private UIScreenType currentScreen = UIScreenType.None;


    public void DisplayScreen(UIScreenType screen)
    {
        foreach (var s in screens)
        {
            if(s.GetComponent<UIScreen>().GetScreenType() == screen)
            {
                //s.SetActive(true);
                s.SetActive(true);
                currentScreen = screen;
            }
            else
            {
                s.SetActive(false);
            }
        }
    }

    public void HideScreens(UIScreenType screenType)
    {
        foreach (var s in screens)
        {
            if (s.GetComponent<UIScreen>().GetScreenType() == screenType)
            {
                currentScreen = UIScreenType.None;
                s.SetActive(false);
            }
        }
    }

    public void HideAllScreens()
    {
        foreach (var s in screens)
        {
            currentScreen = UIScreenType.None;
            s.SetActive(false);
        }
    }

    public UIScreenType CurrentUIScreen()
    {
        return currentScreen;
    }
}
