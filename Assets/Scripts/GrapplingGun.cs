using UnityEngine;

public class GrapplingGun : MonoBehaviour {

    Animator animator;
    [Header("Joint")]
    public LayerMask whatIsGrappleable;
    [SerializeField]
    private float rayDistance = 10f;
    [SerializeField]
    private float jointMaxDistance = 0.8f;
    [SerializeField]
    private float jointMinDistance = 0.25f;
    [SerializeField]
    private float jointSpring = 4.5f;
    [SerializeField]
    private float jointDamper = 7f;
    [SerializeField]
    private float jointMassScale = 4.5f;

      private SpringJoint joint;
    private LineRenderer lr;
    private Vector3 grapplePoint;
    
    [Header("References")]
    public Transform gunTip;
    public Transform camera;
    public Transform player;


    
    
    

    void Awake() {
        lr = GetComponent<LineRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            StartGrapple();
        }
        else if (Input.GetMouseButtonUp(0)) {
            StopGrapple();
        }
        animator.SetBool("isHooked",IsGrappling());
    }

    //Called after Update
    void LateUpdate() {
        DrawRope();
    }

    /// <summary>
    /// Call whenever we want to start a grapple
    /// </summary>
    void StartGrapple() {
        RaycastHit hit;
        if (Physics.Raycast(camera.position, camera.forward, out hit, rayDistance, whatIsGrappleable)) {
            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

            //The distance grapple will try to keep from grapple point. 
            joint.maxDistance = distanceFromPoint * jointMaxDistance;
            joint.minDistance = distanceFromPoint * jointMinDistance;

            //Adjust these values to fit your game.
            joint.spring = jointSpring;
            joint.damper = jointDamper;
            joint.massScale = jointMassScale;

            lr.positionCount = 2;
            currentGrapplePosition = gunTip.position;
        }
    }


    /// <summary>
    /// Call whenever we want to stop a grapple
    /// </summary>
    void StopGrapple() {
        lr.positionCount = 0;
        Destroy(joint);
    }

    private Vector3 currentGrapplePosition;
    
    void DrawRope() {
        //If not grappling, don't draw rope
        if (!joint) return;

        currentGrapplePosition = Vector3.Lerp(currentGrapplePosition, grapplePoint, Time.deltaTime * 8f);
        
        lr.SetPosition(0, gunTip.position);
        lr.SetPosition(1, currentGrapplePosition);
    }

    public bool IsGrappling() {
        return joint != null;
    }

    public Vector3 GetGrapplePoint() {
        return grapplePoint;
    }
}
