using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public float releaseTime = .15f;
    public Rigidbody2D rb;
    private bool isPressed = false;
    public Rigidbody2D hook;
    public float maxDragDistance = 2f;
    public GameObject nextBall;
    private void Update()
    {
        if(isPressed)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector3.Distance(mousePos, hook.position) > maxDragDistance)
            {
                rb.position = hook.position + (mousePos - hook.position).normalized * maxDragDistance;
            }
            else
            {
                rb.position = mousePos;
            }
             
        }
    }


    private void OnMouseDown()
    {
        isPressed = true;
        rb.isKinematic = true;

    }

    private void OnMouseUp()
    {
        isPressed = false;
        rb.isKinematic = false;
       StartCoroutine(Release());
    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseTime);
        GetComponent<SpringJoint2D>().enabled = false;
        this.enabled = false;

        yield return new WaitForSeconds(2f);

        if (nextBall != null)
        {
            nextBall.SetActive(true);
        }
        else
        {
          //  Enemy.EnemiesAlive = 0;
            SceneManager.LoadScene("GameOver");
        }
       
    }
}
