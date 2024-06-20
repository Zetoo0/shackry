using UnityEngine;
using UnityEditor;

/*
public class SpawnCheckerCollider : MonoBehaviour
{
    [SerializeField] public MeshRenderer mesh;
    [SerializeField] public MeshCollider meshCollider;
}

[CustomEditor(typeof(SpawnCheckerCollider))]

public class SpawnCheckerColliderEditor : Editor
{
    float s = 1.0f;
    public void OnSceneGUI()
    {
        var t_Target = target as SpawnCheckerCollider;
        var  t_Transform = t_Target.transform;
        SphereCollider coll = t_Target.GetComponent<SphereCollider>();
        var m_Mesh = t_Target.mesh;
        var m_MeshColl = t_Target.meshCollider;
        Handles.color = Handles.xAxisColor;
        Handles.ArrowHandleCap(0, t_Target.transform.position + new Vector3(1.0f, 0.0f, 0.0f), t_Target.transform.rotation * Quaternion.LookRotation(Vector3.right), s, EventType.Repaint);
        
        Handles.color = Handles.yAxisColor;
        Handles.ArrowHandleCap(0, t_Target.transform.position + new Vector3(0.0f, 1.0f, 0.0f), t_Target.transform.rotation * Quaternion.LookRotation(Vector3.up), s, EventType.Repaint);

        Handles.color = Handles.zAxisColor;
        Handles.ArrowHandleCap(0, t_Target.transform.position + new Vector3(0.0f, 0.0f, 1.0f), t_Target.transform.rotation * Quaternion.LookRotation(Vector3.forward), s, EventType.Repaint);

        Handles.DrawLine(coll.ClosestPoint(m_Mesh.transform.position), m_MeshColl.ClosestPoint(t_Transform.position));//TODO Find the closest mesh, shoot a ray and check the rayhit collider

        RaycastHit _rHit;
       
        if(Physics.Raycast(t_Transform.position, Vector3.down.normalized, out _rHit, 10000.0f, LayerMask.GetMask("Spawnable"))){
            Debug.Log("Spawbable");
            Debug.Log(_rHit.distance);
            Handles.SphereHandleCap(0, _rHit.collider.ClosestPoint(t_Transform.position), _rHit.transform.rotation, 1.0f, EventType.Repaint);
        }

        if (Physics.Raycast(t_Transform.position, Vector3.up.normalized, out _rHit, 10000.0f, LayerMask.GetMask("Spawnable")))
        {
            Debug.Log("Spawbable");
            Debug.Log(_rHit.distance);
            Handles.SphereHandleCap(0, _rHit.collider.ClosestPoint(t_Transform.position), _rHit.transform.rotation, 1.0f, EventType.Repaint);
        }



        //HandleUtility.PlaceObject(Event.current.mousePosition, out t_Transform.position, out t_Transform.position.normalized);


    }
}
*/
