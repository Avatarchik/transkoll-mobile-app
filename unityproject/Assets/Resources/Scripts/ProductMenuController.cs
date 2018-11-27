using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;
using System.Data;
using LitJson;

public class ProductMenuController : MonoBehaviour {

    // references
    private ProductController pc;

    // product information
    private string productID;
    private Text productName;

    // panels
    private GameObject mainPanel;
    private GameObject topPanel;
    private GameObject errorPanel;
    private Transform productContentPanel;

    // Use this for initialization
    void Start ()
    {
        pc = this.transform.parent.GetComponent<ProductController>();
        pc.RegisterProduct(this);

        productContentPanel = transform.Find("Canvas/Main/ScrollView/Viewport/Content");
        productName = transform.Find("Canvas/Top/Text").GetComponent<Text>();

        mainPanel   = transform.Find("Canvas/Main").gameObject;
        topPanel    = transform.Find("Canvas/Top").gameObject;
        errorPanel  = transform.Find("Canvas/Error").gameObject;

        mainPanel.SetActive(false);
        topPanel.SetActive(false);
        errorPanel.SetActive(false);

        InitProductMenuGUI();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Reset previous data.
    /// </summary>
    public void ResetLayer()
    {
        foreach (Transform child in productContentPanel)
        {
            GameObject.Destroy(child.gameObject);
        }
        Debug.Log("Removed old Objects");
    }

    /// <summary>
    /// Load the product menu. Check prefix and load and fill data from database.
    /// </summary>
    public void InitProductMenuGUI()
    {
        ResetLayer();

        ImageTargetBehaviour imageTargetBeh = this.GetComponent<ImageTargetBehaviour>();
        DatabaseController dbc = DatabaseController.getInstance();

        if (dbc.GetAssociation().ContainsKey(imageTargetBeh.ImageTarget.Name))
        {
            productID = dbc.GetAssociation()[imageTargetBeh.ImageTarget.Name];
        }
        else
        {
            Debug.LogError("Schlüssel '" + imageTargetBeh.ImageTarget.Name + "' für Produkt nicht im der Assiziationstabelle vorhanden!");
            errorPanel.SetActive(true);
            return;
        }

        mainPanel.SetActive(true);
        topPanel.SetActive(true);

        IDataReader sqlData = dbc.ExecuteSQLQuery("Select json FROM products where product_id='" + productID + "';");
        string json = "";

        // Konvert Data into an list
        while (sqlData.Read())
        {
            json = sqlData.GetString(0);
        }

        if (json.Equals(""))
        {
            Debug.LogError("Error! Could not find Prodcut with id '"+ productID + "'.");
            return;
        }

        JsonReader jsonReader = new JsonReader(json);
        JsonData jsonData = JsonMapper.ToObject(jsonReader);
        productName.text = (string)jsonData["Name"];

        sqlData = dbc.ExecuteSQLQuery("Select json FROM unas where product_id='" + productID + "';");

        json = "";
        // Konvert Data into an list
        while (sqlData.Read())
        {
            json = sqlData.GetString(0);
        }

        if (json.Equals(""))
        {
            Debug.LogWarning("Warning! Could not find UNAS for Products with id '" + productID + "'.");
            return;
        }

        jsonReader = new JsonReader(json);
        jsonData = JsonMapper.ToObject(jsonReader);


        JsonData dimensionen = jsonData["Nachhaltigskeitsdimensionen"];

        // bastel JSON data um, in dic, um die keys rauzszufinden, da wigital das gewünschte format nicht umsetzen konnte... rip
        IDictionary dimensionDic = dimensionen as IDictionary;
        List<string> dimensionNames = (List<string>)dimensionDic.Keys;

        foreach (string dimensionName in dimensionNames)
        {
            loadGUIPrefab("Layer1", productContentPanel, dimensionName);
            JsonData unas = dimensionen[dimensionName];

            for (int k = 0; k < unas.Count; k++)
            {
                string unaName = (string)unas[k]["UNA_Name"];
                loadGUIPrefab("Layer2", productContentPanel, unaName);
                JsonData massnahmen = unas[k]["Massnahme"];

                for (int l = 0; l < massnahmen.Count; l++)
                {
                    string massnahme = (string)massnahmen[l];
                    loadGUIPrefab("Layer3", productContentPanel, massnahme);

                }
            }
        }
    }

    /// <summary>
    /// This method will instantiate a gameobject and will set its transform to the parent
    /// </summary>
    /// <param name="prefabName"></param>
    /// <param name="parentObject"></param>
    /// <returns></returns>
    public static GameObject loadGUIPrefab(string prefabName, Transform parentObject, string layerText)
    {

        string path = "Prefabs/" + prefabName;

        //Debug.Log(path);

        // Instantiate prefab
        GameObject go = UnityEngine.Object.Instantiate(Resources.Load(path)) as GameObject;

        Text txt = go.transform.GetComponentInChildren<Text>();
        txt.text = layerText;

        // Change to the correct place
        go.transform.SetParent(parentObject, false);

        return go;
    }
}
