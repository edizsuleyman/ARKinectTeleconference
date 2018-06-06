using Microsoft.Kinect;

public class KinectSensorResult
{
    private KinectSensor kSensor;
    private bool isExist;

    public KinectSensor KSensor
    {
        get
        {
            return this.kSensor;
        }
        set
        {
            this.kSensor = value;
        }
    }

    public bool IsExist
    {
        get
        {
            return this.isExist;
        }
        set
        {
            this.isExist = value;
        }
    }

    public KinectSensorResult() 
    {
        this.kSensor = null;
        this.isExist = false;
    }

    public KinectSensorResult(KinectSensor kSensor, bool isExist = true)
    {
        this.kSensor = kSensor;
        this.isExist = isExist;
    }
}

