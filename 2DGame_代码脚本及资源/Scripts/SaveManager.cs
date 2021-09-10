using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine.UI;
using System.Threading;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    public SaveData activeSave;
    public bool Loaded = false;
    public bool Saved = false;
    public HP jiahp;
   // public GameObject HelpC;

    
    public GameObject[] sparkobj;



    void Start()
    {
        jiahp = GameObject.FindGameObjectWithTag("hp").GetComponent<HP>();
        activeSave.hp=jiahp.newhp;              
        sparkobj = new GameObject[4];
        activeSave.booll=new bool[4];
        Save();
    }

    private void Awake()
    {
        instance= this;
        //Load();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
           Save();
        }
        if(Input.GetKeyDown(KeyCode.L))
        {
            Load();
       }

    }

    public void Save()
    {
        //Saved=true;

        activeSave.newposition=PlayerController.instance.Player.transform.position;

        string dataPath=Application.persistentDataPath;
        var serializer= new XmlSerializer(typeof(SaveData));
        var stream= new FileStream(dataPath + "/2DGame.save", FileMode.Create);
        serializer.Serialize(stream, activeSave);
        stream.Close();
        Debug.Log("Saved");
       // HelpC.SetActive(false);
       // Time.timeScale =1;

    }

    public void Load()
    {
        string dataPath=Application.persistentDataPath;
        // HelpC.SetActive(false);
        // Time.timeScale =1;
        if(System.IO.File.Exists(dataPath + "/2DGame.save"))
        { 
            //Loaded=true ;
            //Thread.Sleep(1000);
        
            var serializer= new XmlSerializer(typeof(SaveData));
            var stream= new FileStream(dataPath + "/2DGame.save", FileMode.Open);
            activeSave= serializer.Deserialize(stream) as SaveData;
            stream.Close();
            
            PlayerController.instance.Player.transform.position=activeSave.newposition;
            PlayerController.instance.spark=activeSave.spark;
            PlayerController.instance.Sparknumber.text=PlayerController.instance.spark.ToString();
            PlayerController.instance.hp.newhp=activeSave.hp;

            for(int i=0; i<=3; i++)
            {
                if(!SaveManager.instance.activeSave.booll[i])
                {
                    SaveManager.instance.sparkobj[i].SetActive(true); 
                }
            }

            Debug.Log("Loaded"); 
        }
        

    }
}

[System.Serializable]
public class SaveData
{
    public Vector3 newposition;
    public int spark;
    public float hp;
    public int i=0;
    public bool[] booll;
}
