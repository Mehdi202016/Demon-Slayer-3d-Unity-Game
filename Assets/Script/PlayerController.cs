using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public FixedJoystick Joystick;
    Animator anim;
    public Button ButtonAttackSword;
    public float SmothRotationTime=0.25f;
    float currentVelocity;
    public float MoveSpeed = 3f;
    float currentSpeed;
    float SpeedVelocity;
    Transform cameraTransform;
    public bool enableMobileInputs = false;
    public float Health = 1;
    public BoxCollider SwordCollider;
    public Image AmountHealth;
    private Vector2 inputDir;
    public static PlayerController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        ButtonAttackSword.onClick.AddListener(buttSwordAttack);
        anim = GetComponent<Animator>();

        //enemyAnimator = GameObject.FindGameObjectWithTag("enemy1").GetComponent<Animator>();
    }

    void Update()
    {
        Vector2 input = Vector2.zero;

        if (enableMobileInputs)
        {
            input = new Vector2(Joystick.input.x, Joystick.input.y);
            //input = new Vector2(Joystick.Horizontal, Joystick.Vertical);
        }
        else
        {
            input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }

        inputDir = input.normalized;

        if (inputDir != Vector2.zero)
        {
            float rotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y,rotation,ref currentVelocity, SmothRotationTime);
        }
        float TargetSpeed = MoveSpeed * input.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed,TargetSpeed,ref SpeedVelocity,0.12f);
        transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);

        /*------Animation------*/
        if (inputDir.magnitude == 0)
        {
            anim.SetBool("isRun", false);
        }
        else
        {
            anim.SetBool("isRun", true);
        }
    }

    public void buttSwordAttack()
    {
        anim.SetTrigger("AttackSword");

    }

    public void ShowSwordCollider()
    {
        SwordCollider.enabled = true;
    }
    public void HideSwordCollider()
    {
        SwordCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HitPlayer"))
        {
            anim.SetTrigger("Hit");
            Health -=  0.1f;
            AmountHealth.fillAmount = Health;

          if (Health <= 0)
          {
                anim.SetTrigger("Death");
                MoveSpeed = 0;
                StartCoroutine(Roald());
          }
        }
    }

    IEnumerator Roald()
    {
        yield return new WaitForSeconds(5f);
        AdsManager.instance.ShowInterstitial();
        SceneManager.LoadScene(0);
    }
}
