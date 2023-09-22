using UnityEngine;

public class Multiplication : MonoBehaviour
{
    [SerializeField] Transform l_1;
    [SerializeField] Transform l_2;

    Vector3 l_1p;
    Vector3 l_2p;
    Vector3 l_3p;
    // Start is called before the first frame update
    void Start()
    {




    }

    // Update is called once per frame
    void Update()
    {
        l_1p = l_1.up * 2;
        l_2p = l_2.up;

        l_3p = new Vector3(l_1p.x / l_2p.x, l_1p.y / l_2p.y, l_1p.y / l_2p.y);

        Debug.Log(l_3p);


    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, l_1p * 5);

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, l_2p * 5);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, l_3p * 100);

    }
}
