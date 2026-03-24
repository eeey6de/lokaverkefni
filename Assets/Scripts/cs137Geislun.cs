using UnityEngine;

public class cs137Geislun : MonoBehaviour
{
    private float activityBq = 3200000000000; //3,2 * 10^12 
    private float rays = 3200000000000; //3,2 * 10^12 
    [SerializeField] public float grams;
    private float intensityAt01f = ;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void getCounts(Vector3 position)
    {
        float distance = Vector3.Distance(position, transform.position);

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
