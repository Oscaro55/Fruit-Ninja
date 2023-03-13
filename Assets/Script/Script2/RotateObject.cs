using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateObject : MonoBehaviour
{
    public static RotateObject instance;
    public Vector3 mouse_pos;
    public Vector3 object_pos;
    public float angle;
    public bool isRotate = false;
    public bool isRotate2 = false;
    // Start is called before the first frame update
    public Vector3 delta = Vector3.zero;
    public Vector3 lastPos = Vector3.zero;
    //public List<GameObject> connect = new List<GameObject>();
    public List<GameObject> listChildSprite = new List<GameObject>();

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        for (int i = 0; i < SpliceSpriteController.instance.listChildSprite.Count; i++)
        {
            listChildSprite.Add(SpliceSpriteController.instance.listChildSprite[i]);
        }
        //for (int i = 0; i < SpliceSpriteController.instance.listChildSprite.Count; i++)
        //{
        //    if (gameObject.GetComponent<HingeJoint2D>().connectedBody
        //        == SpliceSpriteController.instance.listChildSprite[i].GetComponent<Rigidbody2D>())
        //    {
        //        connect.Add(SpliceSpriteController.instance.listChildSprite[i]);
        //        listChildSprite.RemoveAt(i);
        //    }

        //}


    }
    void Update()
    {
        angle = Mathf.Abs(transform.rotation.z * Mathf.Rad2Deg);
    }

    private void OnMouseDrag()
    {
        ShapeController.instance.SetupPerfect();

        if (Input.GetMouseButtonDown(0))
        {
            lastPos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            delta = Input.mousePosition - lastPos;
            // Do Stuff here
            if (isRotate && (delta.x != 0 || delta.y != 0))
            {
                for (int i = 0; i < listChildSprite.Count; i++)
                {
                    listChildSprite[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                }

                gameObject.GetComponent<Rigidbody2D>().velocity = delta * Time.deltaTime * 40;
                //if (connect != null)
                //{
                //    for (int i = 0; i < connect.Count; i++)
                //    {
                //        connect[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                //    }
                //}


            }
            else if (delta.x == 0 && delta.y == 0)
            {
                for (int i = 0; i < listChildSprite.Count; i++)
                {

                    listChildSprite[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                }
                //if (connect != null)
                //{
                //    for (int i = 0; i < connect.Count; i++)
                //    {
                //        connect[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                //    }
                //}
            }
            lastPos = Input.mousePosition;


        }

    }
    private void OnMouseDown()
    {
        lastPos = Input.mousePosition;
        //gameObject.GetComponent<Image>().color = Color.red;
        //if (connect != null)
        //{
        //    for (int i = 0; i < connect.Count; i++)
        //    {
        //        connect[i].constraints = RigidbodyConstraints2D.FreezeAll;
        //    }
        //}

        isRotate = true;
    }
    private void OnMouseUp()
    {
        isRotate = false;
        for (int i = 0; i < listChildSprite.Count; i++)
        {

            listChildSprite[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
        //if (connect != null)
        //{
        //    for (int i = 0; i < connect.Count; i++)
        //    {
        //        connect[i].constraints = RigidbodyConstraints2D.None;
        //    }
        //}
    }

}
