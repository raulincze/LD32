using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour 
{
    public static HUDManager Instance { get; private set; }
    public Transform Menu;
    public Transform ActionMenu;
    public Transform ActionMenuContainer;
    public GameObject actionButton;
    public bool IsShowingUI { get { return panelStack > 0; } }
    int panelStack = 0;
    void Awake()
    {
        Instance = this;
    }

    public void ShowActionMenu(Agent target)
    {
        GameManager.Instance.PauseGame();
        panelStack++;
        ActionMenu.gameObject.SetActive(true); 
        for (int i = 0; i < ActionMenuContainer.childCount; i++)
        {
            Destroy(ActionMenuContainer.GetChild(i).gameObject);
        }

        foreach(var b in target.possibleBehaviours)
        {
            ActionButton btn = Instantiate(actionButton).GetComponent<ActionButton>();
            btn.agent = target;
            btn.behav = b;
            btn.DisplayText();
            btn.transform.parent = ActionMenuContainer;
        }
    }

    internal void HideActionMenu()
    {
        if(panelStack>0) panelStack--;
        ActionMenu.gameObject.SetActive(false);
        GameManager.Instance.ResumeGame();
    }

    public void ShowMenu()
    {
        panelStack++;
        Menu.gameObject.SetActive(true);
        GameManager.Instance.PauseGame();
    }

    public void HideMenu()
    {
        if (panelStack > 0) panelStack--;
        Menu.gameObject.SetActive(false);
        GameManager.Instance.ResumeGame();
    }

    public void HideAllPanels()
    {
        panelStack = 0;
        HideActionMenu();
        HideMenu();
    }
}
