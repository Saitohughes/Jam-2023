using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacle : MonoBehaviour
{
    [SerializeField]
    int lenght;
    [SerializeField]
    private LineRenderer myTail;
    [SerializeField] private Vector3[] SegmentPoses;
     private Vector3[] SegmentsV;

    public Transform targetDir;
    public float targetDist;
    public float smoothSpeed;
    // Start is called before the first frame update
    void Start()
    {
        myTail.positionCount = lenght;
        SegmentPoses = new Vector3[lenght];
        SegmentsV = new Vector3[lenght];
    
    }

    // Update is called once per frame
    void Update()
    {
        SegmentPoses[0] = targetDir.position;

        for (int i = 1; i < SegmentPoses.Length; i++)
        {
            SegmentPoses[i] = Vector3.SmoothDamp(SegmentPoses[i], SegmentPoses[i - 1] + targetDir.right * targetDist, ref SegmentsV[i], smoothSpeed);
        }
        myTail.SetPositions(SegmentPoses);
    }
}
