using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class MainMenuController : MonoBehaviour {

    // public gameobjects
    public ProductController pc;
    public SyncDatabase syncDatabase;
    public GameObject ARCamera;

    // buttons
    private Button freezeBtn;
    private Button syncBtn;
    private Button okBtn;

    // panels
    private GameObject freezePanel;
    private GameObject syncDBPanel;
    private bool freezing = false;

    private Text syncText;

    // Use this for initialization
    void Start ()
    {
        freezeBtn     = this.transform.Find("MenuBottom/Freeze").GetComponent<Button>();
        syncBtn       = this.transform.Find("MenuBottom/Sync").GetComponent<Button>();

        okBtn = this.transform.Find("SyncDBPanel/OK").GetComponent<Button>();

        freezePanel   = this.transform.Find("FreezePanel").gameObject;
        freezePanel.SetActive(false);

        syncDBPanel = this.transform.Find("SyncDBPanel").gameObject;
        syncDBPanel.SetActive(false);

        syncText = syncDBPanel.transform.Find("Text").GetComponent<Text>();

        freezeBtn.onClick.AddListener(FreezeButtonClicked);
        syncBtn.onClick.AddListener(SyncButtonClicked);
        okBtn.onClick.AddListener(OKButtonClicked);
        okBtn.gameObject.SetActive(false);

        Screen.orientation = ScreenOrientation.Portrait;
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// This will activate feedback, when user syncs the database.
    /// </summary>
    public void ActivateSyncPanel()
    {
        okBtn.gameObject.SetActive(true);
        syncText.color = new Color(1, 1, 1, 1);
        syncText.text = "Datenbank wurde erfolgreich aktualisiert. Aktuallisiere Produkte....";

        pc.UpdateProducts();

        syncText.color = new Color(0, 1, 0, 1);
        syncText.text = "Produkte wurden erfolgreich aktualisiert!";
    }

    /// <summary>
    /// This will display a given error message on db sync panel.
    /// </summary>
    /// <param name="errorMessage"></param>
    public void ShowErrorMessage(string errorMessage)
    {
        syncText.text = errorMessage;
        syncDBPanel.SetActive(true);
        syncText.color = new Color(1, 0, 0, 1);
        okBtn.gameObject.SetActive(true);
    }

    /// <summary>
    /// Action, when ok in sync db panel was pressed.
    /// </summary>
    public void OKButtonClicked()
    {
        Debug.Log("OK Button clicked");
        syncDBPanel.SetActive(false);
    }

    /// <summary>
    /// When user hits the sync button. This will lead to sync the database.
    /// </summary>
    public void SyncButtonClicked()
    {
        syncDBPanel.SetActive(true);
        syncText.text = "Datenbank wird synchronisiert ...";
        syncText.color = new Color(1, 1, 1, 1);

        syncDatabase.SynchronizeDatabase();
    }

    /// <summary>
    /// if user hits the freeze button. This leeds to stopping camera service.
    /// </summary>
    public void FreezeButtonClicked()
    {
        Debug.Log("FreezeButton clicked");
        freezing = !freezing;
        VuforiaRenderer.Instance.Pause(freezing);
        freezePanel.SetActive(freezing);
    }
}
