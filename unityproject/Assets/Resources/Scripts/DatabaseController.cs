using System.Collections.Generic;
using Mono.Data.SqliteClient;
using System.Data;
using System.IO;
using UnityEngine;

/// <summary>
/// This class will handle all actions for database access.
/// </summary>
internal class DatabaseController
{
    private static DatabaseController instance; // singleton pattern
    private string db_name = "transkoll.db";
    private string db_connection_path;
    private IDbConnection db_connection;
    private IDbCommand db_command;
    private IDataReader db_reader;
    private Dictionary<string, string> association; // vuforia/transkoll db association dictionary

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    /// <summary>
    /// Private singleton Constructor
    /// </summary>
    private DatabaseController()
    {
        /// ---------------------------------------------------------------- ///
        /// DEFINE ASSOSIATION BETWEEN VUFORIA AND TRANSKOLL DB HERE         ///
        /// ---------------------------------------------------------------- /// 
        association = new Dictionary<string, string>();
        association.Add("widgital_example",      "1-Produkt_1");
        association.Add("koelln_muesli_knusper", "1-Kölln_Müsli_Knusper_Honig-Nuss");
        association.Add("koelln_muesli_schoko",  "1-Kölln_Müsli_Schoko");
    }

    /// <summary>
    /// Returns the association dictionary (between vuforia and transkoll web database)
    /// </summary>
    /// <returns></returns>
    public Dictionary<string, string> GetAssociation()
    {
        return association;
    }

    /// <summary>
    /// Singleton getInstance() method. Returns the instance of DatabaseController.
    /// </summary>
    /// <returns></returns>
    public static DatabaseController getInstance()
    {
        if (instance == null)
        {
            instance = new DatabaseController();
        }
        return instance;
    }

    /// <summary>
    /// Execute a SQL Query on Database.
    /// </summary>
    /// <param name="sql"></param>
    /// <returns></returns>
    public IDataReader ExecuteSQLQuery(string sql)
    {
        // Open DB
        OpenDB();

        db_command = db_connection.CreateCommand();
        db_command.CommandText = sql;
        db_reader = db_command.ExecuteReader();
        return db_reader;
    }

    /// <summary>
    /// Call this method, if you want to make a connection with an android device.
    /// </summary>
    /// <param name="p"></param>
    public void MakeAndroidConnection()
    {
        // check if file exists in Application.persistentDataPath
        string filepath = Application.persistentDataPath + "/" + db_name;
        if (!File.Exists(filepath))
        {
            // if it doesn't ->
            // open StreamingAssets directory and load the db -> 
            WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/" + db_name);
            while (!loadDB.isDone) { }
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDB.bytes);
        }

        //open db connection
        db_connection_path = "URI=file:" + filepath;
        db_connection = new SqliteConnection(db_connection_path);
        db_connection.Open();
    }


    /// <summary>
    /// Call this method if you want to make a connection with a windows device.
    /// </summary>
    /// <param name="p"></param>
    public void MakeWindowsConnection()
    {
        string databasePath = "URI=file:" + Application.dataPath + "/StreamingAssets/" + db_name;
        db_connection = new SqliteConnection(databasePath);
        db_connection.Open();
    }

    /// <summary>
    /// Open database.
    /// </summary>
    public void OpenDB()
    {

        if (Application.platform == RuntimePlatform.Android)
        {
            MakeAndroidConnection();
        }
        else if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            MakeWindowsConnection();
        }
    }


    /// <summary>
    /// Close database.
    /// </summary>
    public void CloseDB()
    {
        db_reader.Close(); // clean everything up
        db_reader = null;
        db_command.Dispose();
        db_command = null;
        db_connection.Close();
        db_connection = null;
    }
}