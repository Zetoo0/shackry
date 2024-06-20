/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class IKfrommybrain : MonoBehaviour
{
    [SerializeField] int chainLength;

    [SerializeField] Transform target;
    [SerializeField] Transform pole;

    protected float[] BonesLength;
    protected float CompleteLength;
    protected Transform[] Bones;
    protected Vector3[] Positions;
    protected Vector3[] StartDirectionSucc;
    protected Quaternion[] StartRotationBone;
    protected Quaternion StartRotationTarget;
    protected Quaternion StartRotationRoot;

    [SerializeField] int iterations;
    public float delta = 0.001f;
    public float SnapBackStrength = 1.0f;
    private void Awake()
    {
        InitMain();
    }



    void InitMain()
    {
        //init the arrays
        Bones = new Transform[chainLength + 1];
        Positions = new Vector3[chainLength + 1];
        BonesLength = new float[chainLength];
        StartDirectionSucc = new Vector3[chainLength + 1];
        StartRotationBone = new Quaternion[chainLength + 1];

        StartRotationTarget = target.rotation;

        var current = transform;
        CompleteLength = 0;

        for (var i = Bones.Length - 1; i >= 0; i--)
        {
            Bones[i] = current;
            StartRotationBone[i] = current.rotation;
            if(i == Bones.Length - 1)
            {
                //leaf
                StartDirectionSucc[i] = target.position - current.position;
            }
            else
            {
                //mid
                StartDirectionSucc[i] = Bones[i + 1].position - current.position;
                BonesLength[i] = StartDirectionSucc[i].magnitude;
                CompleteLength += BonesLength[i];
                print("initializing...");
            }
            current = current.parent;
        }
        print("finished initializing...");
    }

    private void LateUpdate()
    {
        ResolveIK();
    }

    void ResolveIK()
    {
        if(target == null)
        {
            return;
        }

        if(BonesLength.Length != chainLength)
        {
            InitMain();
        }

        //get position
        for (int i = 0; i < Bones.Length; i++)
        {
            Positions[i] = Bones[i].position;
        }

        var RootRot = (Bones[0].parent != null) ? Bones[0].parent.rotation : Quaternion.identity;
        var RootRotaDifference = RootRot * Quaternion.Inverse(StartRotationRoot);

        //calculation, 1st is possible to reach?
        if ((target.position - Bones[0].position).sqrMagnitude >= CompleteLength * CompleteLength)
        {
            //stretching
            var direction = (target.position - Positions[0]).normalized;
            //settin everything after root
            for(int i = 1; i < Positions.Length; i++)
            {
                Positions[i] = Positions[i - 1] + direction * BonesLength[i - 1];
            }
        }
        else
        {
            for(int i = 0; i < Positions.Length - 1; i++)
            {
                Positions[i + 1] = Vector3.Lerp(Positions[i + 1], Positions[i] + RootRotaDifference * StartDirectionSucc[i], SnapBackStrength);
            }
            for(int iteration = 0; iteration < iterations; iteration++)
            {
                //back
                for(int i = Positions.Length - 1; i > 0; i--)
                {
                    if (i == Positions.Length - 1)
                        Positions[i] = target.position; // set it to target
                    else
                        Positions[i] = Positions[i + 1] + (Positions[i] - Positions[i + 1]).normalized * BonesLength[i];//set in line on distance
                }

                //forward
                for (int i = 1; i < Positions.Length; i++)
                {
                    Positions[i] = Positions[i - 1] + (Positions[i] - Positions[i - 1]).normalized * BonesLength[i - 1];
                }

                //if close enough, stop
                if ((Positions[Positions.Length - 1] - target.position).sqrMagnitude < delta * delta)
                {
                    break;
                }


            }
        }

        //move towards pole
        if(pole != null)
        {
            for(int i = 1; i < Positions.Length - 1; i++)
            {
                var plane = new Plane(Positions[i + 1] - Positions[i - 1], Positions[i - 1]);
                var projectPole = plane.ClosestPointOnPlane(pole.position);
                var projectBone = plane.ClosestPointOnPlane(Positions[i]);
                var angle = Vector3.SignedAngle(projectBone - Positions[i - 1], projectPole - Positions[i - 1], plane.normal);
                Positions[i] = Quaternion.AngleAxis(angle, plane.normal) * (Positions[i] - Positions[i - 1]) + Positions[i - 1];
            }
        }
        //set position and rot
        for (int i = 0; i < Positions.Length; i++)
        {
            if(i == Positions.Length - 1)
            {
                Bones[i].rotation = Quaternion.Inverse(target.rotation) * StartRotationTarget * Quaternion.Inverse(StartRotationBone[i]);
            }
            else
            {
                Bones[i].rotation = Quaternion.FromToRotation(StartDirectionSucc[i], Positions[i + 1] - Positions[i]) * StartRotationBone[i];
            }
            Positions[i] = Bones[i].position;
        }

    }

    float square(float num)
    {
        return num * num;
    }





    void OnDrawGizmos()
    {
        var current = this.transform;
        for(int i = 0; i < chainLength && current != null && current.parent != null; i++)
        {
            var scale = Vector3.Distance(current.position, current.parent.position) * 0.1f;
            Handles.matrix = Matrix4x4.TRS(current.position, Quaternion.FromToRotation(Vector3.up, current.parent.position - current.position), new Vector3(scale, Vector3.Distance(current.parent.position, current.position), scale));
            Gizmos.color = Color.blue;
            Handles.DrawWireCube(Vector3.up * 0.5f, Vector3.one);
            current = current.parent;
        }
    }
}
*/