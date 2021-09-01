using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using settings;

public class PlayerController : MonoBehaviour
{
    public GameObject Player;
    public GameObject AI;
    public GameObject Black;
    public CharacterType EnableCharacter;
    public CameraController cc;
    // Start is called before the first frame update
    void Start()
    {
        cc = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && EnableCharacter != CharacterType.nothing)
        {
            ChangeCharacter(EnableCharacter);
        }
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
}
