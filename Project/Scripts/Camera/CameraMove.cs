using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [Header("Control View")]
    [SerializeField] private float dumping = 4f;
    [SerializeField] private float heightY = .6f;
    [SerializeField] private float distanceX = .7f;

    [Header("Borders")]
    [SerializeField] private float distanceLeft;
    [SerializeField] private float distanceRight;
    [SerializeField] private float distanceTop;
    [SerializeField] private float distanceBottom;

    private Transform player;
    private PlayerMove playerMove;

    private void Start()
    {
        playerMove = FindObjectOfType<PlayerMove>();
        player = playerMove.GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        Vector3 target = new Vector3(
            player.position.x + distanceX,
            player.position.y + heightY,
            transform.position.z);

        Vector3 currentPosition = Vector3.Lerp(
            transform.position,
            target,
            dumping * Time.deltaTime);

        transform.position = currentPosition;

        float x_ = Mathf.Clamp(transform.position.x, distanceLeft, distanceRight);
        float y_ = Mathf.Clamp(transform.position.y, distanceBottom, distanceTop);

        transform.position = new Vector3(x_, y_, transform.position.z);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        float left = distanceLeft;
        float right = distanceRight;
        float up = distanceTop;
        float bottom = distanceBottom;

        Gizmos.DrawLine(new Vector2(left, up), new Vector2(right, up));
        Gizmos.DrawLine(new Vector2(left, bottom), new Vector2(right, bottom));
        Gizmos.DrawLine(new Vector2(left, up), new Vector2(left, bottom));
        Gizmos.DrawLine(new Vector2(right, up), new Vector2(right, bottom));
    }
}
