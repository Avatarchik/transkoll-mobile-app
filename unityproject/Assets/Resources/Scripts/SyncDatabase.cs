using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using LitJson;
using System;

public class SyncDatabase : MonoBehaviour {

    public string productURL = "http://preview.transkolldb.wigital.de/webservice/?key=7PS0r8IHhFNELSlj1xQiT1XXKHhfiV0G&function=product";
    public string unaURL     = "http://preview.transkolldb.wigital.de/webservice/?key=7PS0r8IHhFNELSlj1xQiT1XXKHhfiV0G&function=una";
    public MainMenuController mmc;
    private int dbSync = 0;

    /// <summary>
    /// This method will check, weather the sync is already complete. If it is finished, then user will get visual feedback.
    /// </summary>
    public void CheckSyncStatus()
    {
        dbSync++;

        if (dbSync >= 2) {

            mmc.ActivateSyncPanel();
            dbSync = 0;
            Debug.Log("Synchronisation Complete");
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// This will start syncing the database multi threaded.
    /// </summary>
    public void SynchronizeDatabase()
    {
        StartCoroutine(SyncUNAS());
        StartCoroutine(SyncProducts());
    }

    /// <summary>
    /// This method will call the webfile to get the information in JSON format and will save the entire string in a local database.
    /// </summary>
    /// <returns></returns>
    IEnumerator SyncUNAS()
    {
        UnityWebRequest www = UnityWebRequest.Get(unaURL);
        yield
        return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            string errorMsg = www.error;
            Debug.LogError(errorMsg);
            mmc.ShowErrorMessage(errorMsg);
        }
        else
        {
            // get input from URL
            string json = www.downloadHandler.text;
            DatabaseController dbc = DatabaseController.getInstance();
            dbc.ExecuteSQLQuery("DELETE FROM unas;");

            JsonReader jsonReader = new JsonReader(json);
            JsonData jsonData = JsonMapper.ToObject(jsonReader);
            JsonData products = jsonData["products"];

            // for all products
            for (int i = 0; i < products.Count; i++)
            {
                string productJSON = products[i].ToJson();

                string productID = (string)products[i]["Produkt_ID"];

                dbc.ExecuteSQLQuery("INSERT INTO unas values ('" + productID + "', '" + productJSON + "');");
            }
            Debug.Log("Syncing Unas from Transkoll DB: DONE");
            CheckSyncStatus();
        }
    }

    /// <summary>
    /// This method will call the webfile to get the information in JSON format and will save the entire string in a local database.
    /// </summary>
    /// <returns></returns>
    IEnumerator SyncProducts()
    {
        UnityWebRequest www = UnityWebRequest.Get(productURL);
        yield
        return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            string errorMsg = www.error;
            Debug.LogError(errorMsg);
            mmc.ShowErrorMessage(errorMsg);
        }
        else
        {
            // get input from URL
            string json = www.downloadHandler.text;
            DatabaseController dbc = DatabaseController.getInstance();
            dbc.ExecuteSQLQuery("DELETE FROM products;");

            JsonReader jsonReader = new JsonReader(json);
            JsonData jsonData = JsonMapper.ToObject(jsonReader);
            JsonData products = jsonData["products"];

            // for all products
            for (int i = 0; i < products.Count; i++)
            {
                string productJSON = products[i].ToJson();

                string productID = (string)products[i]["Produkt_ID"];
                string sql = "INSERT INTO products values ('" + productID + "','" + productJSON + "');";
                dbc.ExecuteSQLQuery(sql);
            }

            Debug.Log("Syncing Products from Transkoll DB: DONE");
            CheckSyncStatus();
        }

    }
}
