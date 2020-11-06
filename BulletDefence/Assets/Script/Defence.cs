using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defence : MonoBehaviour
{
    public float speedModifier;
    [SerializeField] GameObject particle;
    GameObject cursor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Touch();
    }

    void Touch()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 pos;
            pos.x = Input.mousePosition.x;
            pos.y = Input.mousePosition.y;
            pos.z = 5f;

            if (Input.GetMouseButtonDown(0))
            {
                cursor = Instantiate(particle);
            }

            cursor.transform.position = Camera.main.ScreenToWorldPoint(pos);
        }
        if (Input.GetMouseButtonUp(0))
        {
            Destroy(cursor);
        }
    }
}
