using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float runSpeed = 2;
    public float jumpSpeed = 3;
    Rigidbody2D rb2D;

    public bool betterJump = false;

    public float fallMultiplier = 0.5f;

    public float lowJumpMultiplier = 1f;

    public bool derecha=true;

    public SpriteRenderer spriteRenderer;

    public ProyectileBehaviour ProyectilePrefab;
    public Transform LaunchOffset;
    public int cantfruta = 0;
    public int recuentofinal = 0;
    public Text ScoreFruit;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        /*if (Input.GetKey("d")|| Input.GetKey("right"))
        {
            rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = false;
            derecha = true;
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX=true;
            derecha = false;
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
        }
        if(Input.GetKey("space") && CheckGround.isGrounded)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
        }
        if (betterJump)
        {
            if(rb2D.velocity.y<0)
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
            }
            if(rb2D.velocity.y>0 && !Input.GetKey("space"))
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
            }
        }*/

        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * runSpeed;

        if (!Mathf.Approximately(0, movement))
        {
            transform.rotation = movement > 0 ? Quaternion.Euler(0,180,0) : Quaternion.identity;
        }

        if (Input.GetKey(KeyCode.Space) && Mathf.Abs(rb2D.velocity.y)<0.001f)
        {
            rb2D.AddForce(new Vector2(0,jumpSpeed),ForceMode2D.Impulse);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if(cantfruta > 0)
            {
                Instantiate(ProyectilePrefab, LaunchOffset.position, transform.rotation);
                RestarFruta();
                recuentofinal++;
            }
        }
        ScoreFruit.text = cantfruta.ToString();
    }

    public void SumarFruta()
    {
        cantfruta += 1;
    }

    public void RestarFruta()
    {
        cantfruta -= 1;
    }
}
