using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class MessageBoxMessage
{
    public string message;
    public float duration;
    public string Message { get { return message; } set { message = value; } }
    public float Duration { get { return duration; } set { duration = value; } }
}

public class HUDManager : MonoBehaviour 
{
    public static HUDManager Instance { get; private set; }
    public Transform Menu;
    public Transform ActionMenu;
    public Transform ActionMenuContainer;
    public GameObject actionButton;
    public bool IsShowingUI { get { return panelStack > 0; } }
    public Transform book;
    public Transform messageBox;
    public Text textMessageBox;
    public Queue<MessageBoxMessage> queuedMessages;

    public string allTheText = "";
    
    int panelStack = 0;
    void Awake()
    {
        Instance = this;
        allTheText = "It's like it has always been there... The book... Tied to his hands...\n\n";
        queuedMessages = new Queue<MessageBoxMessage>();
    }

    public void ShowMessage(MessageBoxMessage msg, bool flushQueue = false)
    {
        if (flushQueue)
        {
            queuedMessages = new Queue<MessageBoxMessage>();
            StopAllCoroutines();
        }

        queuedMessages.Enqueue(msg);

        if(queuedMessages.Count == 1)
        {
           StartCoroutine(ShowMessages());
        }
    }
    
    IEnumerator ShowMessages()
    {
        messageBox.gameObject.SetActive(true);
        while(queuedMessages.Count > 0)
        {
            MessageBoxMessage msg = queuedMessages.Peek();
            textMessageBox.text = msg.Message;
            allTheText += " " + msg.Message;
            yield return new WaitForSeconds(msg.Duration);
            queuedMessages.Dequeue();
        }
        messageBox.gameObject.SetActive(false);
    }

    public void OpenBook(Agent target)
    {
        StartCoroutine(WaitOpenBook(target));
    }

    IEnumerator WaitOpenBook(Agent target)
    {
        Animation anims = book.GetComponent<Animation>();
        anims["LookAtBook"].normalizedSpeed = 1f;
        anims.Play("LookAtBook");
        yield return new WaitForSeconds(anims["LookAtBook"].length);
        if (target != null)
        {
            ShowActionMenu(target);
        }
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
        Animation anims = book.GetComponent<Animation>();
        anims["LookAtBook"].normalizedSpeed = -1f;
        anims.Play("LookAtBook");
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
