using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private Alteruna.Avatar _avatar;
    public float speed;
    public float moveh;
    public float movev;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        _avatar = GetComponent<Alteruna.Avatar>();

        if (!_avatar.IsMe)
            return;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_avatar.IsMe)
            return;
        moveh = Input.GetAxisRaw("Horizontal");
        movev = Input.GetAxisRaw("Vertical");
        transform.Translate(Vector2.right * speed * moveh * Time.deltaTime);
        transform.Translate(Vector2.up * speed * movev * Time.deltaTime);

        if(moveh != 0)
        {
            anim.Play("run");
        } else if(movev != 0)
        {
            anim.Play("run");
        }
        if(moveh == 0 && movev == 0)
        {
            anim.Play("idle");
        }
        if(moveh != 0f)
        {
            transform.localScale = new Vector2(moveh, 1f);
        }

    }
}
