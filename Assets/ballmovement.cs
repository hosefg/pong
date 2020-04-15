using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ballmovement : MonoBehaviour
{

    //public int speed = 30;
    // Start is called before the first frame update

    public Rigidbody2D sesuatu;

    public Animator animator;


    void Start()
    {
        int x = Random.Range(0,2) * 2 - 1;
        int y = Random.Range(0,2) * 2 - 1;
        int speed = Random.Range(20,26);
        sesuatu.velocity = new Vector2(x,y) * speed;
        sesuatu.GetComponent<Transform>().position = Vector2.zero;
        animator.SetBool("isMove",true);
    }

    // Update is called once per frame
    void Update()
    {
        if(sesuatu.velocity.x > 0){ // bola bergerak
            sesuatu.GetComponent<Transform>().localScale = new Vector3(1,1,1);
        }else{
            sesuatu.GetComponent<Transform>().localScale = new Vector3(-1,1,1);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if(other.collider.name == "dindingKanan" || other.collider.name == "dindingKiri"){
            StartCoroutine(hitungMundur());
            
            
        }
    }

    IEnumerator hitungMundur()
    {
        sesuatu.velocity = Vector2.zero;
        animator.SetBool("isMove",false);
        sesuatu.GetComponent<Transform>().position = Vector2.zero;
        yield return new WaitForSeconds(1);
        int x = Random.Range(0,2) * 2 - 1;
        int y = Random.Range(0,2) * 2 - 1;
        int speed = Random.Range(20,26);
        sesuatu.velocity = new Vector2(x,y ) * speed;
        animator.SetBool("isMove",true);
        
        
    }
}
