using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    public float Jump;
    bool isJumping = false;
    public GameObject RestartBO;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && isJumping == false) {
            rb.AddForce(Vector2.up * Jump);
            isJumping = true;
            anim.SetBool("IsJumping", true);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Ground") {
            isJumping = false;
            anim.SetBool("IsJumping", false);

        }
        if (collision.gameObject.tag=="Enemy") {
            anim.SetBool("Dead", true);
            Time.timeScale = 0;
            RestartBO.SetActive(true);

        }
    }
    public void Restart() {
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1;
    }
}
