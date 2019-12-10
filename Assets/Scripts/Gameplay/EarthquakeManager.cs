using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Events;
using UnityEngine;
using UnityEngine.Events;

public class EarthquakeManager : MonoBehaviour
{
    public static EarthquakeManager Instance;

    private List<Earthquake> Earthquakes = new List<Earthquake>();

    private Dictionary<EarthquakeType, EarthquakeInfo> Dictionary = new Dictionary<EarthquakeType, EarthquakeInfo>();

    #region Fields

    [HideInInspector]
    public bool IsSimulating = false;
    [HideInInspector]
    public bool IsPaused = false;
    [HideInInspector]
    public EarthquakeType CurrentType;

    [Space]
    [Header("Current Info")]
    [SerializeField]
    private EarthquakeInfo _currentInfo;

    [Space]
    [Header("Platform Info")]
    public GameObject Platform;
    private Rigidbody _rb;
    private Vector3 _initialPosition;
    [HideInInspector]
    public Vector3 CurrentAcceleration;

    #endregion

    [Space]
    [Header("Events Info")]
    //Change
    public UnityEvent OnEarthquakeChange;
    //Start
    public UnityEvent OnEarthquakeStart;
    //Pause
    public UnityEvent OnEarthquakePause;
    //Continue
    public UnityEvent OnEarthquakeContinue;
    //Stop
    public UnityEvent OnEarthquakeStop;

    private int i = 0;

    #region BuiltIn Functions

    private void Awake()
    {
        Instance = this;

        _initialPosition = Platform.transform.position;

        _rb = Platform.GetComponent<Rigidbody>();
        Earthquakes = Resources.LoadAll<Earthquake>("Data/Earthquake/Data").ToList();
        
        #region Dictionary

        if (Earthquakes != null && Earthquakes.Count > 0)
        {
            for (int i = 0; i < Earthquakes.Count; i++)
            {
                // to read and write only once =>
                if (Earthquakes[i].Info.XAxis.Acceleration.Length == 0 ||
                    Earthquakes[i].Info.XAxis.Seconds.Length == 0 ||
                    Earthquakes[i].Info.ZAxis.Acceleration.Length == 0 ||
                    Earthquakes[i].Info.ZAxis.Seconds.Length == 0
                    )
                {
 
                    //get axes
                    Earthquakes[i].Info = ReadFromTXT.ReturnEarthquakeInfo(
                        Earthquakes[i].X,
                        Earthquakes[i].Z
                    );

                    //set seconds
                    Earthquakes[i].Info.MaxSeconds = Earthquakes[i].Info.XAxis.Seconds[
                        Earthquakes[i].Info.XAxis.Seconds.Length - 1
                    ];

                    //calculate average acceleration

                    float xAverage = Earthquakes[i].Info.XAxis.Acceleration.Average();
                    float zAverage = Earthquakes[i].Info.ZAxis.Acceleration.Average();

                    Earthquakes[i].Info.AverageAcceleration = new Vector3(xAverage, 0, zAverage);

                    //add to dictionary

                    
                }
                else
                {
                    Debug.Log("No empty data detected. Using the pre-filled ones ...");
                }
                if (Earthquakes[i] != null)
                {
                    Dictionary.Add(Earthquakes[i].Type, Earthquakes[i].Info);
                }

            }
        }

        #endregion

        #region Events And Actions

        //change
        OnEarthquakeChange.AddListener(
            delegate { OnEQChange(); }
            );
        //start
        OnEarthquakeStart.AddListener(
            delegate { OnEQStart(); }
            );
        //Pause
        OnEarthquakePause.AddListener(
            delegate { OnEQPause(); }
            );
        //Continue
        OnEarthquakeContinue.AddListener(
            delegate { OnEQContinue(); }
            );
        //stop
        OnEarthquakeStop.AddListener(
            delegate { OnEQStop(); }
            );

        #endregion

    }

    private void Start()
    {
        //DEFAULTS
        SetEarthquake(EarthquakeType.Light);
    }

    private void FixedUpdate()
    {
        if (IsSimulating)
        {
            if (i < _currentInfo.XAxis.Seconds.Length - 1)
            {
                i++;
                Debug.Log("Simulating..");
                Vector3 acceleration = new Vector3(_currentInfo.XAxis.Acceleration[i],
                    0, _currentInfo.ZAxis.Acceleration[i]);

                _rb.AddForce(acceleration, ForceMode.Acceleration);
                CurrentAcceleration = acceleration;

            }
            else
            {
                Debug.Log("Earthquake Finished Simulating..");
                StopEarthquake();
            }
        }

    }

    #endregion

    #region Custom Functions
   
    public void SetEarthquake(EarthquakeType type)
    {
        CurrentType = type;
        OnEarthquakeChange.Invoke();
    }

    private void OnEQChange()
    {
        if (IsSimulating)
        {
            Debug.LogWarning("Earthquake type changed during simulation . Simulation stopped !! !!");
            StopEarthquake();
        }

        _currentInfo = ReturnCurrentEarthquakeInfo();
        Debug.Log("Earthquake type changed..");
    }

    private void OnEQStart()
    {
        Debug.Log("Earthquake Started..");
        IsSimulating = true;
        IsPaused = false;
    }

    private void OnEQPause()
    {
        Debug.Log("Earthquake Paused..");
        IsSimulating = false;
        IsPaused = true;
    }

    private void OnEQContinue()
    {
        Debug.Log("Earthquake Continuing..");
        IsSimulating = true;
    }

    private void OnEQStop()
    {
        Debug.Log("Earthquake Stopped");
        IsSimulating = false;
        _rb.velocity = Vector3.zero;
        i = 0;
        Platform.transform.position = _initialPosition;
    }

    public void StartEarthquake()
    {
        OnEarthquakeStart.Invoke();
    }

    public void PauseEarthquake()
    {
        OnEarthquakePause.Invoke();
    }

    public void ContinueEarthquake()
    {
        OnEarthquakeContinue.Invoke();
    }

    public void StopEarthquake()
    {
        OnEarthquakeStop.Invoke();
    }

    public EarthquakeInfo ReturnCurrentEarthquakeInfo()
    {
        return Dictionary[CurrentType];
    }
   
    #endregion

}
