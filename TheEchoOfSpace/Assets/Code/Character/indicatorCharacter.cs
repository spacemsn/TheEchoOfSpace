using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class indicatorCharacter : MonoBehaviour
{
    [Header("ѕоказаьели персонажа")]
    [SerializeField] int lvlPlayer;
    [SerializeField] float experiencePlayer = 0;

    [SerializeField] float health;
    [SerializeField] float batery;
    [SerializeField] private float healthMax;
    [SerializeField] private float bateryMax;

    [SerializeField] Slider healthBar;
    [SerializeField] Slider bateryBar;
    [SerializeField] Button lvlvButton;
    [SerializeField] TMP_Text lvlText;

    public MusicController musicController;

    [Header("Ќенужные переменные")]
    public float time;

    public float Health
    {
        get { return health; }
        set
        {
            health = value;

            if (value > healthMax)
            {
                value = healthMax;
            }
            else if(value <= 0)
            {
                // смерть персонажа
            }
        }
    }

    public float Batery
    {
        get { return batery; }
        set
        {
            batery = value;

            if (value > bateryMax)
            {
                value = bateryMax;
            }
            else if (value <= 0)
            {
                // будет отниматьс€ зар€д
                StartCoroutine(BateryDamage(time));
            }
        }
    }

    public float ExperiencePlayer
    {
        get { return experiencePlayer; }
        set
        {
            experiencePlayer = value;

            if (experiencePlayer >= 1000)
            {
                lvlPlayer++; experiencePlayer = 0;
                SoundEffect();
            }
            else if (experiencePlayer <= 0)
            {
                experiencePlayer = 0;
            }
        }
    }

    public void SetHealth(float bonushealth)
    {
        Health += bonushealth;
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
    }

    public void TakeHungry(float amount)
    {
        Batery -= amount;
    }

    public void SetHungry(float bonushungry)
    {
        Batery += bonushungry;

        StartCoroutine(TimeBatery(time));
    }

    IEnumerator BateryDamage(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            TakeDamage(5);

            if(Health <= 0)
            {
                Health = 0;
                yield break;
            }
        }
    }

    IEnumerator TimeBatery(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            TakeHungry(5);

            if (Batery <= 0)
            {
                Batery = 0;
                yield break;
            }
        }
    }

    public void lvlButton()
    {
        // будет открыватьс€ меню дл€ прокачки талантов

        ExperiencePlayer += 500;
    }

    public void SoundEffect()
    {
        musicController.EffectSours[1].Play();
    }

    private void Awake()
    {
        musicController = MusicController.instance;
    }

    private void Start()
    {
        Health = health;
        Batery = batery;
        lvlText = lvlvButton.GetComponentInChildren<TMP_Text>(); 
        lvlText.text = lvlPlayer.ToString();

        StartCoroutine(TimeBatery(time));
    }

    private void LateUpdate()
    {
        healthBar.value = Health;
        bateryBar.value = Batery;
        lvlText.text = lvlPlayer.ToString();
    }
}
