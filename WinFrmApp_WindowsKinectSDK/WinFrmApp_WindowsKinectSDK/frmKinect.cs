using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Kinect;
using Coding4Fun.Kinect.WinForm;
using System.Threading;
using System.Drawing.Imaging;

namespace WinFrmApp_WindowsKinectSDK
{
    public partial class frmKinect : Form
    {
        KinectController kController = null;
        Image img = Image.FromFile("meteogram.png");

        public frmKinect()
        {
            InitializeComponent();
            img = this.SetImageOpacity(img, 0.3f);

            btnStream.Enabled = false;

            kController = new KinectController(this);
            if (kController.KsResult.IsExist)
            {
                kController.InitValues(this, true, kController.KsResult.KSensor.Status, kController.KsResult.KSensor.DeviceConnectionId);
            }
            else
            {
                MessageBox.Show("Device not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                kController.InitValues(this, false, KinectStatus.Undefined, string.Empty);
            }
        }

        private void btnStream_Click(object sender, EventArgs e)
        {
            kController.KsResult.KSensor.Start();
            kController.KsResult.KSensor.ColorStream.Enable(ColorImageFormat.RgbResolution1280x960Fps12);
            kController.KsResult.KSensor.DepthStream.Enable();
            kController.KsResult.KSensor.DepthStream.Range = DepthRange.Default;
            kController.KsResult.KSensor.AllFramesReady += kSensor_AllFramesReady;
            kController.KsResult.KSensor.SkeletonStream.Enable();
            kController.KsResult.KSensor.SkeletonStream.TrackingMode = SkeletonTrackingMode.Default;
        }

        void kSensor_AllFramesReady(object sender, AllFramesReadyEventArgs e)
        {
            using (var frame = e.OpenColorImageFrame())
            {
                if (frame != null)
                    pbStream.Image = CreateBitmapFromSensor(frame);
            }

            using (var frame = e.OpenSkeletonFrame())
            {

                if (frame != null)
                {
                    var skeletons = new Skeleton[frame.SkeletonArrayLength];
                    frame.CopySkeletonDataTo(skeletons);
                    var TrackedSkeleton = skeletons.FirstOrDefault(s => s.TrackingState == SkeletonTrackingState.Tracked);

                    if (TrackedSkeleton != null)
                    {
                        ColorImagePoint leftshoulderpoint = KinectController.GetColorImagePointFromSkeletonPoint(
                            kController.KsResult.KSensor, TrackedSkeleton, JointType.ShoulderLeft
                            );

                        ColorImagePoint rightshoulderpoint = KinectController.GetColorImagePointFromSkeletonPoint(
                            kController.KsResult.KSensor, TrackedSkeleton, JointType.ShoulderRight
                            );

                        ColorImagePoint footpoint = KinectController.GetColorImagePointFromSkeletonPoint(
                            kController.KsResult.KSensor, TrackedSkeleton, JointType.FootLeft
                            );

                        ColorImagePoint headpoint = KinectController.GetColorImagePointFromSkeletonPoint(
                            kController.KsResult.KSensor, TrackedSkeleton, JointType.Head
                            );

                        ColorImagePoint rightHandPoint = KinectController.GetColorImagePointFromSkeletonPoint(
                            kController.KsResult.KSensor, TrackedSkeleton, JointType.HandRight
                            );

                        if (rightHandPoint.Y < headpoint.Y)
                        {
                            img = Image.FromFile("forecast.jpg");
                            img = this.SetImageOpacity(img, 0.3f);
                        }
                        
                        Graphics graph = this.pbStream.CreateGraphics();
                        Pen pen = new Pen(Color.Red, 3);
                        Brush b = new SolidBrush(Color.Red);
                        graph.DrawRectangle(pen, leftshoulderpoint.X - 20, headpoint.Y + 20,
                            Math.Abs(rightshoulderpoint.X - leftshoulderpoint.X),
                            Math.Abs(headpoint.Y - footpoint.Y));

                        int posx = leftshoulderpoint.X - 200;

                        if (leftshoulderpoint.X - 200 <= pbStream.Left)
                        {
                            posx = rightshoulderpoint.X;
                        }
                        if (rightshoulderpoint.X + 200 >= pbStream.Right)
                        {
                            posx = leftshoulderpoint.X - 200;
                        }

                        graph.DrawImage(img, posx, headpoint.Y, 200, 200);
                        //graph.FillRectangle(b, new Rectangle(posx, headpoint.Y, 100, 100));
                        LogFile(rightshoulderpoint, headpoint);
                    }
                }
            }
        }

        public Image SetImageOpacity(Image image, float opacity)
        {
            try
            {
                Bitmap bmp = new Bitmap(image.Width, image.Height);

                using (Graphics gfx = Graphics.FromImage(bmp))
                {
                    ColorMatrix matrix = new ColorMatrix();
                    matrix.Matrix33 = opacity;
                    ImageAttributes attributes = new ImageAttributes();
                    attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                    gfx.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
                }
                return bmp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        } 

        private Bitmap CreateBitmapFromSensor(ColorImageFrame frame)
        {
            var pixelData = new byte[frame.PixelDataLength];
            frame.CopyPixelDataTo(pixelData);
            var stride = frame.Width * frame.BytesPerPixel;
            var bmpFrame = new Bitmap(frame.Width, frame.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            var bmpData = bmpFrame.LockBits(new Rectangle(0, 0, frame.Width, frame.Height),
                System.Drawing.Imaging.ImageLockMode.WriteOnly, bmpFrame.PixelFormat);
            System.Runtime.InteropServices.Marshal.Copy(pixelData, 0, bmpData.Scan0, frame.PixelDataLength);
            bmpFrame.UnlockBits(bmpData);
            return bmpFrame;
        }

        public void LogFile(ColorImagePoint x, ColorImagePoint y)
        {
            string path = "log.txt";
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine();
                }
            }
            else
            {
                using (StreamWriter file = new StreamWriter(path, true))
                {
                    file.WriteLine(x.X.ToString() + "|" + y.Y.ToString());
                }
            }
        }

        private void btnStopStream_Click(object sender, EventArgs e)
        {
            kController.KsResult.KSensor.Stop();
            kController.KsResult.KSensor.ColorStream.Disable();
            kController.KsResult.KSensor.DepthStream.Disable();
            kController.KsResult.KSensor.SkeletonStream.Disable();
        }
    }
}
