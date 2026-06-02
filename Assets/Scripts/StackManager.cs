using UnityEngine;

public class StackManager : MonoBehaviour
{
    public Transform player;
    public Transform[] boxes;

    public Vector3 baseOffset = new Vector3(0f, 0.8f, 0f);
    public float boxHeight = 0.5f;
    public float tiltAmount = 25f;

    public bool isPhase2 = false;
    public float failTiltAngle = 40f;

    public GameObject failMessage;

    private bool failed = false;

    void Start()
    {
        SetupBoxes();
    }

    void Update()
    {
        if (failed)
            return;

        FollowPlayer();
        CheckFailCondition();
    }

    void SetupBoxes()
    {
        for (int i = 0; i < boxes.Length; i++)
        {
            if (isPhase2)
            {
                boxes[i].gameObject.SetActive(true);
            }
            else
            {
                boxes[i].gameObject.SetActive(i == 0);
            }
        }
    }

    void FollowPlayer()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        for (int i = 0; i < boxes.Length; i++)
        {
            if (!boxes[i].gameObject.activeSelf)
                continue;

            Vector3 offset = baseOffset + new Vector3(0f, i * boxHeight, 0f);

            boxes[i].position = player.position + offset;

            float rotation = -horizontal * tiltAmount * (i + 1);

            boxes[i].rotation = Quaternion.Euler(0f, 0f, rotation);
        }
    }

    void CheckFailCondition()
    {
        if (!isPhase2)
            return;

        Transform topBox = boxes[boxes.Length - 1];

        float zRotation = Mathf.Abs(Mathf.DeltaAngle(0f, topBox.eulerAngles.z));

        if (zRotation >= failTiltAngle)
        {
            failed = true;

            if (failMessage != null)
                failMessage.SetActive(true);

            Invoke(nameof(RestartScene), 1.5f);
        }
    }

    void RestartScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
        );
    }

    public bool HasFailed()
    {
        return failed;
    }
}