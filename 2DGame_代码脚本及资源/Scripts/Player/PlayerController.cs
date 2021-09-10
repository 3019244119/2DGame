using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using settings;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    private void Awake()
    {
        instance=this;
    }

    public HP hp;


    public GameObject Player;
    public GameObject AI;
    public GameObject Black;
    public CharacterType EnableCharacter;
    public CameraController cc;

    public Text Sparknumber;
    public int spark;
    private bool timein;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        hp = GameObject.FindGameObjectWithTag("hp").GetComponent<HP>();
        cc = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>();
        Sparknumber=GameObject.Find("Canvas/Sparknumber").GetComponent<Text>();
        timer=0f;
        //Player = GetComponentInChildren<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
        if (Input.GetKeyDown(KeyCode.W) && EnableCharacter != CharacterType.nothing && timein)
        {
            ChangeCharacter(EnableCharacter);
            timein=false;
            timer=1f;
        }



        
        /*if(SaveManager.instance.Saved)
        {
            SaveManager.instance.activeSave.newposition=Player.transform.position;
            SaveManager.instance.Saved=false;
        }

        if(SaveManager.instance.Loaded)
        {
            Player.transform.position=SaveManager.instance.activeSave.newposition;

            spark=SaveManager.instance.activeSave.spark;
            Sparknumber.text=spark.ToString();

            hp.newhp=SaveManager.instance.activeSave.hp;

            SaveManager.instance.Loaded=false;
        }*/
        

    }

    public void ChangeCharacter(CharacterType type)
    {

        //Transform now = GetComponentInChildren<Transform>();
        //Vector3 CreatePiont = now.position;
        transform.position = transform.GetChild(0).position + new Vector3(0, 0.5f, 0);
        
        Destroy(transform.GetChild(0).gameObject);
        switch (type)
        {
            case CharacterType.AI:
                Player = Instantiate(AI, transform, false) as GameObject;
                EnableCharacter = CharacterType.Black;
                break;
            case CharacterType.Black:
                Player = Instantiate(Black, transform, false) as GameObject;
                EnableCharacter = CharacterType.AI;
                break;
        }
        Player.layer = LayerMask.NameToLayer("Player");
        Player.tag = "Player";
        cc.player = Player.transform;


    }

    public void sparknumber()
    {
        spark++;
        SaveManager.instance.activeSave.spark=spark;
        Sparknumber.text=spark.ToString();

        /*if(SaveManager.instance.Saved)
        {
            Debug.Log("qqqqqqqqqqqqqqqqqqqq");
            SaveManager.instance.activeSave.spark=spark;
            SaveManager.instance.Saved=false;
        }
        if(SaveManager.instance.Loaded)
        {
            spark=SaveManager.instance.activeSave.spark;
            Sparknumber.text=spark.ToString();
            SaveManager.instance.Loaded=false;
        }*/
    }

    public void Timer()
    {
        if(timer>0)
        {
            timer-=Time.deltaTime;
        }
        else{
            timein=true;
        }
    }
}
