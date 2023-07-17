using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public Rigidbody2D rd;
    public float speed =1f;
    public Sprite facingLeft;
    public SpriteRenderer sr;
    public Sprite facingRight;
    public Sprite facingDown;
    public Sprite facingUp;
    public Animator walking;
    private bool isClick;
    private int count;
    public Vector3 playerPosition;
    public Vector3 playerScale;
    public GameObject playerPrefab;
    public Gamem gm;



    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        WakeUp();
        

    }


    // Update is called once per frame
    void Update()
    {
        playerPosition = transform.position;
        playerScale = transform.localScale;
        DetectPlayerMove();
        
        //growFunction();
      
        
    }


    public void DetectPlayerMove()
    {
       
        if (Input.GetKey("w"))
        {
            rd.AddForce(Vector2.up * speed, ForceMode2D.Force);
            sr.sprite = facingUp;
            walking.SetBool("TurnD", false);
            walking.SetBool("TurnR", false);

        }
        else if (Input.GetKey("s"))
        {
            rd.AddForce(Vector2.down * speed , ForceMode2D.Force);
            sr.sprite = facingDown;
            walking.SetBool("TurnD", true);
            walking.SetBool("TurnR", false);
        }
        else if (Input.GetKey("d"))
        {
            rd.AddForce(Vector2.right * speed, ForceMode2D.Force);
            sr.sprite = facingRight;
            walking.SetBool("TurnD", false);
            walking.SetBool("TurnR", true);
        }
        else if (Input.GetKey("a"))
        {
            rd.AddForce(Vector2.left * speed, ForceMode2D.Force);
            sr.sprite = facingLeft;
            walking.SetBool("TurnD", false);
            walking.SetBool("TurnR", false);
        }
        else
        {
            rd.velocity = Vector2.zero; 
            walking.SetBool("TurnD", false);
            walking.SetBool("TurnR", false);
        }


    }
    /*
    public void growFunction()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rd.transform.localScale *= 1.5f;
        }
    }*/
    void OnTriggerEnter2D(Collider2D cd)
    {
        if (cd.tag == "EatenThings")
        {
            rd.transform.localScale *= 1.1f;
            Destroy(cd.gameObject);
        }
        if(cd.tag == "Player")
        {
            rd.transform.localScale *= 1f;
            Vector3 newPosition = (rd.transform.position + cd.transform.position) / 2f;
            Quaternion newRotation = rd.transform.rotation;
            gm.playerGameObjects.Remove(cd.gameObject);
            cd.gameObject.SetActive(false);
            
            GameObject largerSmile = Instantiate(playerPrefab, newPosition, newRotation);
            gm.playerGameObjects.Add(largerSmile);
            gm.haveNewObj(largerSmile);
            largerSmile.transform.localScale *= 1f;
            gm.SwitchBetweenPlayer();
        }
        if(cd.tag =="Floor")
        {
            gameObject.SetActive(false);
        }
        /*
        if(cd.tag =="Bug")
        {
            Destroy(cd.gameObject);
                
        }*/
    }

    public void GotoSleep()
    {
        walking.SetBool("Sleeping", true);
    }
    public void WakeUp()
    {
        walking.SetBool("Sleeping", false);
    }


}
