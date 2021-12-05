using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBehavior : MonoBehaviour
{
    public int noteType;
    private GameManager.judges judge;
    private KeyCode keyCode;

    // Start is called before the first frame update
    void Start()
    {
        if (noteType == 1) keyCode = KeyCode.UpArrow;
        else if (noteType == 2) keyCode = KeyCode.DownArrow;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * GameManager.instance.noteSpeed);
        //사용자가 노트 키를 입력한 경우
        if (Input.GetKey(keyCode))
        {
            //해당 노트에 대한 판정 진행
            Debug.Log(judge);
            //노트가 판정 선에 닿기 시작한 이후로는 해당 노트를 제거.
            if (judge != GameManager.judges.NONE) Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "bad Line")
        {
            judge = GameManager.judges.BAD;
        }
        else if (other.gameObject.tag == "Good Line")
        {
            judge = GameManager.judges.GOOD;
        }
        else if (other.gameObject.tag == "Perfect Line")
        {
            judge = GameManager.judges.PERFECT;
        }
        else if (other.gameObject.tag == "Miss Line")
        {
            judge = GameManager.judges.MISS;
            Destroy(gameObject);
        }
        Debug.Log(judge);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bad Line")
        {
            judge = GameManager.judges.BAD;
        }
        else if (other.gameObject.tag == "Good Line")
        {
            judge = GameManager.judges.GOOD;
        }
        else if (other.gameObject.tag == "Perfect Line")
        {
            judge = GameManager.judges.PERFECT;
        }
        else if (other.gameObject.tag == "Miss Line")
        {
            judge = GameManager.judges.MISS;
            Destroy(gameObject);
        }
    }
}
