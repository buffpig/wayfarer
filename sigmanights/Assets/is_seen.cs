using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class is_seen : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> cameras = new List<GameObject>();
    public int cameracount = 1;
    public GameObject Camera;
    public GameObject camerac;
    public GameObject camer;
    private void Awake()
    {
        camerac = FindObjectOfType<cams>().gameObject;


        if (camerac.GetComponent<cams>().cam[0] != null)
        {
            Camera = camerac.GetComponent<cams>().cam[0];
        }
        if (camerac.GetComponent<cams>().cam[0] == null)
        {
            Instantiate(camer, transform.position, Quaternion.identity);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera != null)
        {
            camerac.GetComponent<cams>().cam.Remove(Camera);
        }
        if (cameras.Count > 0) {
            if(Camera.transform.position != cameras[0].transform.position)
            {
                Camera.transform.position = Vector2.MoveTowards(Camera.transform.position, cameras[0].transform.position, 5 * Time.deltaTime);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "camera")
        {
            cameras.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "camera")
        {
            cameras.Remove(collision.gameObject);
        }
    }
}
