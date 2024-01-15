using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine.UI;
//using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.AI;

public class MyCharacter : MonoBehaviour
{
    //a variable to hold the current destination of the character
    Vector3 _Destination;
    private UnityEngine.AI.NavMeshPath _path;
    List<Vector3> _simplePath = new List<Vector3>();
    public CapsuleCollider _Collider;

    public static float destroyTime = 0.25f;
    public static bool scoreCoroutineStarted = false;
    public static bool healthCoroutineStarted = false;
    public FootstepController footstepController;
    public SprayController sprayController;
    public SqueakController squeakController;
    public AttackController attackController;
    public GameObject PlayerSprayBottle;
    public static bool SprayBottleActiveBool = false;
    public static bool SprayBottleFirstDisableBool = false;

    // Start is called before the first frame update
    void Start()
    {
        SprayBottleActiveBool = false;
        SprayBottleFirstDisableBool = false;
        //when we start, set the destination to whatever the current position is
        _Destination = transform.position;
        _path = new UnityEngine.AI.NavMeshPath();
    }
    //a function to set the target desitnation of the character
    public void SetTarget(Vector3 TargetPos)
    {
        _Destination = TargetPos;
        //find a path to the destination from our current position
        bool foundPath = UnityEngine.AI.NavMesh.CalculatePath(transform.position, TargetPos, UnityEngine.AI.NavMesh.AllAreas, _path);
        _simplePath.Clear();
        for (int i = 0; i < _path.corners.Length; i++)
        {
            _simplePath.Add(_path.corners[i]);
        }

        footstepController.StartWalking();
    }

    // Update is called once per frame
    void Update()
    {
        if (!NavMesh.SamplePosition(transform.position, out NavMeshHit hit, 0.1f, 1 << NavMesh.GetAreaFromName("Walkable")))
        {
            NavMeshHit correctedNavHit;
            if (NavMesh.SamplePosition(transform.position, out correctedNavHit, 3.0f, 1 << NavMesh.GetAreaFromName("Walkable")))
            {
                transform.position = correctedNavHit.position;
            }
        }

        //when updating, work out the direction we need to move in

        Vector3 MoveDirection = Vector3.zero;
        if (_simplePath.Count > 0)
        {

            //remove any parts of our path that we are really close to
            Vector3 RelNodePos = (transform.position - _simplePath[0]);
            RelNodePos.y = 0.0f;
            while (_simplePath.Count > 0 && RelNodePos.magnitude < 0.5f)
            {
                _simplePath.RemoveAt(0);
                if (_simplePath.Count > 0)
                {
                    RelNodePos = (transform.position - _simplePath[0]);
                }
            }
        }
        //if there is still path to travel, calculate the direction
        if (_simplePath.Count > 0)
        {
            MoveDirection = _simplePath[0] - transform.position;
        }
        if (_simplePath.Count == 0 || VictoryDefeat.winLoseScreenActive == true || gameObject.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.ToString().Contains("Spray"))
        {
            footstepController.StopWalking();
        }

        //if the destination is a reasonable distance away, update the characters rotation to point in this direction
        MoveDirection.y = 0.0f;
        if (MoveDirection.magnitude > 0.5f)
        {
            MoveDirection.Normalize();
            //ensure the character always points upwards.
            //we do this be removing any upward components from the move direction
            //this is called "projecting"
            Vector3 ProjectedMoveDirection = MoveDirection - (Vector3.up * Vector3.Dot(Vector3.up, MoveDirection));
            transform.rotation = Quaternion.LookRotation(ProjectedMoveDirection, Vector3.up);

            //set a variable in the animation controller
            GetComponent<Animator>().SetFloat("WalkSpeed", 2.0f, 5.0f, 1.0f);
        }
        else
        {

            //set a variable in the animation controller
            GetComponent<Animator>().SetFloat("WalkSpeed", 0.0f, 5.0f, 1.0f);

        }
        //move the character down a bit (sort of simple gravity)
        transform.position = transform.position + new Vector3(0.0f, -0.01f, 0.0f);
        //character controller collsion (dont use physics directly, only collision tests)
        //we do this because we only want character to depenatrate vertically when colliding with the floor
        //this type of collision is usually called a "character controller"
        //great trick to manually calculate object collisions!
        Collider[] coliders = Physics.OverlapBox(transform.position, _Collider.bounds.extents);
        for (int i = 0; i < coliders.Length; i++)
        {

            if (coliders[i] != _Collider)
            {
                Vector3 hitDirection;
                float hitDistance;
                if (Physics.ComputePenetration(coliders[i], coliders[i].transform.position, coliders[i].transform.rotation, _Collider,
               _Collider.transform.position, _Collider.transform.rotation, out hitDirection, out hitDistance))
                {
                    //make the hit direction relative to the character
                    hitDirection *= -1.0f;
                    //we only want to depenatrate in the vertically direction if its a floor
                    float MinFloorDot = 0.7f;
                    if (Vector3.Dot(hitDirection, Vector3.up) > MinFloorDot)
                    {
                        Vector3 depenatrationDir = Vector3.up;
                        //increase the penatration depth accordingly
                        float denominator = Mathf.Abs(Vector3.Dot(depenatrationDir, hitDirection));
                        if (denominator > 0.0f)
                        {
                            transform.position += depenatrationDir * (hitDistance / denominator);
                        }
                    }
                    else
                    {
                        //its not the floor, depenatrate in the natural direction
                        transform.position += hitDirection * hitDistance;
                    }

                    if (coliders[i].gameObject.layer == 3 && PlayerSprayBottle.activeInHierarchy && !VictoryDefeat.winLoseScreenActive && (ScoreManager.scoreCount < 10 || ScoreManager2.scoreCount < 15))
                    {
                        if (scoreCoroutineStarted == false)
                        {
                            GetComponent<Animator>().CrossFadeInFixedTime("Spray", 0.25f);
                            sprayController.StartSpraying();
                            squeakController.StartSqueaking();
                            Destroy(coliders[i].gameObject, destroyTime + 1.42f);
                            StartCoroutine(IncreaseScore(destroyTime));
                            scoreCoroutineStarted = true;
                        }
                    }

                    if (coliders[i].gameObject.CompareTag("NPC"))
                    {
                        coliders[i].gameObject.GetComponent<Animator>().CrossFadeInFixedTime("Idle", 0.25f);
                        coliders[i].gameObject.GetComponent<NavMeshAgent>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
                        coliders[i].gameObject.transform.rotation = Quaternion.LookRotation(-transform.forward);
                    }

                    if (coliders[i].gameObject.layer == 6 && !SprayBottleActiveBool)
                    {
                        Destroy(coliders[i].gameObject);
                        PickUpSprayBottle();
                        break;
                    }

                    if (coliders[i].gameObject.CompareTag("ChasingRat") && !VictoryDefeat.winLoseScreenActive && HealthManager.healthCount > 0)
                    {
                        if (healthCoroutineStarted == false)
                        {
                            attackController.StartAttacking();
                            StartCoroutine(DecreaseHealth());
                            healthCoroutineStarted = true;
                        }
                    }
                }
            }
        }

        if (SprayBottleActiveBool && !SprayBottleFirstDisableBool)
        {
            if (ScoreManager2.scoreCount == 5)
            {
                PlayerSprayBottle.SetActive(false);
                SprayBottleActiveBool = false;
                SprayBottleFirstDisableBool = true;
            }
        }

        {
            if (SprayBottleActiveBool && SprayBottleFirstDisableBool)

                if (ScoreManager2.scoreCount == 10)
                {
                    PlayerSprayBottle.SetActive(false);
                    SprayBottleActiveBool = false;
                    SprayBottleFirstDisableBool = false;
                }
        }
    }

    void PickUpSprayBottle()
    {
        PlayerSprayBottle.SetActive(true);
        SprayBottleActiveBool = true;
    }

    IEnumerator IncreaseScore(float destroyTime)
    {
        yield return new WaitForSeconds(destroyTime + 1.42f);
        if (UnityEngine.SceneManagement.SceneManager.GetSceneByBuildIndex(2).isLoaded)
        {
            ScoreManager.scoreCount += 1;
        }
        if (UnityEngine.SceneManagement.SceneManager.GetSceneByBuildIndex(4).isLoaded)
        {
            ScoreManager2.scoreCount += 1;
        }
        if (UnityEngine.SceneManagement.SceneManager.GetSceneByBuildIndex(8).isLoaded)
        {
            FreeScoreManager.scoreCount += 1;
        }

        scoreCoroutineStarted = false;
        sprayController.StopSpraying();
        squeakController.StopSqueaking();
    }

    IEnumerator DecreaseHealth()
    {
        yield return new WaitForSeconds(0.3f);
        HealthManager.healthCount -= 1;
        healthCoroutineStarted = false;
        attackController.StopAttacking();
    }
}