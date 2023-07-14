using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public Rigidbody2D rd;
    public GameObject playerPrefab;
    public GameObject playerSplitPrefab;
    public float speed =1f;
    public Sprite facingLeft;
    public SpriteRenderer sr;
    public Sprite facingRight;
    public Sprite facingDown;
    public Sprite facingUp;
    public Animator walking;
    private bool isClick;
    private int count;
    public Enemy en; 


    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        

    }

    private void OnMouseDown()
    {
        count++;
        if(count%2 ==1)
        {
            isClick = true;
            print("can move now");
        }
        else
        {
            isClick = false;
            walking.SetBool("Sleeping", true);
            print("can't move");
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        if(isClick)
        {
            walking.SetBool("Sleeping", false);
            DetectPlayerMove();
        }
        growFunction();
        SplitFunction();
        
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
    public void growFunction()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rd.transform.localScale *= 1.5f;
        }
    }
    void OnTriggerEnter2D(Collider2D cd)
    {
        if (cd.tag == "EatenThings")
        {
            rd.transform.localScale *= 1.1f;
            Destroy(cd.gameObject);
        }
        if(cd.tag == "PlayerSplit")
        {
            rd.transform.localScale *= 1f;
            cd.gameObject.SetActive(false);
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
    void SplitFunction()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(SplitCoroutine());
        }

    }
    IEnumerator SplitCoroutine()
    {
        walking.SetBool("Split", true);
        yield return new WaitForSeconds(1f);

        //walking.SetBool("Split", false);

        SpriteRenderer spriteRenderer = playerPrefab.GetComponent<SpriteRenderer>();
        
        Vector3 currentPosition = transform.position;
        Vector3 currentScale = transform.localScale;

        Vector3 smallerScale = currentScale;
        float offset = 0.7f;

        GameObject player1 = Instantiate(playerPrefab, currentPosition + new Vector3(offset, 0f, 0f), Quaternion.identity);
        GameObject player2 = Instantiate(playerSplitPrefab, currentPosition + new Vector3(-offset, 0f, 0f), Quaternion.identity);

        player1.transform.localScale = smallerScale;
        en.player = player1.transform;
        player2.transform.localScale = smallerScale;
        Destroy(gameObject);
    }

}
