using UnityEngine;

public class EnemyView : ContextView<EnemyData>
{
    [SerializeField]
    private MeshRenderer m_Renderer;

    [SerializeField]
    private Animator m_Animator;

    public override void UpdateView()
    {
        
    }
}