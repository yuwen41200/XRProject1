using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyController))]
public class EnemyMobile : MonoBehaviour
{

    // public Animator animator;
    // [Tooltip("Fraction of the enemy's attack range at which it will stop moving towards target while attacking")]
    // [Range(0f, 1f)]
    public float attackStopDistanceRatio = 0.5f;
    [Tooltip("The random hit damage effects")]
    public ParticleSystem[] randomHitSparks;
    public ParticleSystem[] onDetectVFX;
    public AudioClip onDetectSFX;

    [Header("Sound")]
    public AudioClip MovementSound;
    public MinMaxFloat PitchDistortionMovementSpeed;

    public GameObject target_obj;  
    EnemyController m_EnemyController;
    AudioSource m_AudioSource;

    const string k_AnimMoveSpeedParameter = "MoveSpeed";
    const string k_AnimAttackParameter = "Attack";
    const string k_AnimAlertedParameter = "Alerted";
    const string k_AnimOnDamagedParameter = "OnDamaged";

    void Start()
    {
        m_EnemyController = GetComponent<EnemyController>();
        DebugUtility.HandleErrorIfNullGetComponent<EnemyController, EnemyMobile>(m_EnemyController, this, gameObject);

        m_EnemyController.onAttack += OnAttack;
        m_EnemyController.onDetectedTarget += OnDetectedTarget;
        m_EnemyController.onLostTarget += OnLostTarget;
        m_EnemyController.SetPathDestinationToClosestNode();
        m_EnemyController.onDamaged += OnDamaged;

        // Start patrolling
     

        // adding a audio source to play the movement sound on it
        m_AudioSource = GetComponent<AudioSource>();
        DebugUtility.HandleErrorIfNullGetComponent<AudioSource, EnemyMobile>(m_AudioSource, this, gameObject);
        m_AudioSource.clip = MovementSound;
        m_AudioSource.Play();
    }

    void Update()
    {
        // UpdateAIStateTransitions();
        // UpdateCurrentAIState();
        m_EnemyController.SetNavDestination(target_obj.transform.position);
        float moveSpeed = m_EnemyController.m_NavMeshAgent.velocity.magnitude;

        // Update animator speed parameter
       

        // changing the pitch of the movement sound depending on the movement speed
        m_AudioSource.pitch = Mathf.Lerp(PitchDistortionMovementSpeed.min, PitchDistortionMovementSpeed.max, moveSpeed / m_EnemyController.m_NavMeshAgent.speed);
    }

    void UpdateAIStateTransitions()
    {
        
        // Handle transitions 
      
    }

    void UpdateCurrentAIState()
    {
        // Handle logic 
        
    }

    void OnAttack()
    {
        
    }

    void OnDetectedTarget()
    {
        
    }

    void OnLostTarget()
    {
       
    }

    void OnDamaged()
    {
        if (randomHitSparks.Length > 0)
        {
            int n = Random.Range(0, randomHitSparks.Length - 1);
            randomHitSparks[n].Play();
        }

       
    }
}
