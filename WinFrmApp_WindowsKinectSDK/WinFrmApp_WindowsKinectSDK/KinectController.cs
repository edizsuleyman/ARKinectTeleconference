using Microsoft.Kinect;
using WinFrmApp_WindowsKinectSDK;

public class KinectController
{
    private frmKinect form;
    private KinectSensorResult ksResult;

    public KinectSensorResult KsResult 
    {
        get { return this.ksResult; }
        set { this.ksResult = value; }
    }

    public KinectController(frmKinect form)
    {
        KinectSensor.KinectSensors.StatusChanged += KinectSensors_StatusChanged;
        this.form = form;
        this.ksResult = this.Init();
    }

    void KinectSensors_StatusChanged(object sender, StatusChangedEventArgs e)
    {
        switch (e.Status)
        {
            case KinectStatus.Connected:
                this.InitValues(this.form, true, e.Status, e.Sensor.DeviceConnectionId);
                break;
            case KinectStatus.DeviceNotGenuine:
            case KinectStatus.DeviceNotSupported:
            case KinectStatus.Disconnected:
            case KinectStatus.Initializing:
            case KinectStatus.Error:
            case KinectStatus.NotPowered:
            case KinectStatus.NotReady:
            case KinectStatus.Undefined:
            case KinectStatus.InsufficientBandwidth:
                this.InitValues(this.form, false, e.Status, string.Empty);
                break;
            default:
                this.InitValues(this.form, false, e.Status, string.Empty);
                break;
        }
    }

    public void InitValues(frmKinect form, bool isActive, KinectStatus status, string deviceConnId)
    {
        if (isActive)
        {
            this.ksResult = this.Init();
            form.btnStream.Enabled = true;
            form.lblStatus.Text = status.ToString();
            form.lblConnectionID.Text = deviceConnId;
        }
        else
        {
            ksResult.KSensor.Dispose();
            form.btnStream.Enabled = false;
            form.lblStatus.Text = status.ToString();
            form.lblConnectionID.Text = deviceConnId;
        }
    }

    public KinectSensorResult Init()
    {
        KinectSensorResult ksResult = new KinectSensorResult();

        if (KinectSensor.KinectSensors.Count > 0)
        {
            ksResult.KSensor = KinectSensor.KinectSensors[0];
            ksResult.IsExist = true;
        }
        else
        {
            ksResult.KSensor = null;
            ksResult.IsExist = false;
        }

        return ksResult;
    }

    public static ColorImagePoint GetColorImagePointFromSkeletonPoint(KinectSensor kSensor, Skeleton skeletonToTrack, JointType jointTpe) 
    {
        CoordinateMapper coordinateMapper = new CoordinateMapper(kSensor);
        SkeletonPoint pos = skeletonToTrack.Joints[jointTpe].Position;
        return coordinateMapper.MapSkeletonPointToColorPoint(pos, ColorImageFormat.RgbResolution1280x960Fps12);             
    }
}