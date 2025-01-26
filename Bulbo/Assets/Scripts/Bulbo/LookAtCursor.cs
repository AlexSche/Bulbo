using UnityEngine;

public class LookAtCursor : MonoBehaviour
{
    private new Camera camera;
    [SerializeField]
    private LayerMask layerMask;
    public Vector3 mousePos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, layerMask))
        {
            if (raycastHit.collider.tag != "Player")
            {
                mousePos = raycastHit.point;
            }
        }
        if (mousePos != null)
        {
            transform.LookAt(mousePos);
        }
    }
}
