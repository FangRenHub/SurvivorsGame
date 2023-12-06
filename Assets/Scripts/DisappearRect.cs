using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearRect : MonoBehaviour
{
    public Transform cameraRect;
    public float RectSize;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale += new Vector3(RectSize, RectSize, RectSize);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }


}
