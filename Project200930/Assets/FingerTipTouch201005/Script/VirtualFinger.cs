using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualFinger : MonoBehaviour
{
    int stay = 0;
    public GameObject realfinger;
    public GameObject virtualfinger;
    public GameObject tipfront;
    public GameObject vtipfront;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        virtualfinger.transform.rotation = realfinger.transform.rotation;
        if(tipfront.GetComponent<TipFront>().stay == 0)
        {
            virtualfinger.transform.position = realfinger.transform.position;
        }
        else if (stay == 0)
        {
            
            float[] distance = new float[10];
            for(int i = 0; i < distance.Length; i++)
            {
                distance[i] = 100;
            }
            int point = 0;

            Ray ray = new Ray(vtipfront.transform.position, tipfront.transform.position - vtipfront.transform.position);

            foreach (RaycastHit h in Physics.RaycastAll(ray))
            {
                if (h.collider)
                {
                    
                    if (h.collider.tag.Equals("target"))
                    {
                        distance[point] = h.distance;
                        point++;
                    }
                }
            }
            Debug.DrawRay(ray.origin, ray.direction * 10.0f, Color.red);
            if (point > 0)
            {
                float dis = Min(distance);
                Vector3 vec = (tipfront.transform.position - vtipfront.transform.position).normalized * dis;
                virtualfinger.transform.position = virtualfinger.transform.position + vec;
            }

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        stay++;
    }

    private void OnTriggerStay(Collider other)
    {

    }

    private void OnTriggerExit(Collider other)
    {
        stay--;
    }

    public float Min(params float[] nums)
    {
        // 引数が渡されない場合
        if (nums.Length == 0) return 0;

        float min = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            min = min < nums[i] ? min : nums[i];
            // Minの場合は不等号を逆にすればOK
        }
        return min;
    }
}
