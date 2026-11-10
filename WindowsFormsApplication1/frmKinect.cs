using System;
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
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;

namespace WindowsFormsApplication1
{
    public partial class frmKinect : Form
    {

        private KinectSensor kSensor;


        public frmKinect()
        {

            

            InitializeComponent();
            KinectSensor.KinectSensors.StatusChanged += KinectSensors_StatusChanged;

        }

        //part 1 init sensor
        private void btnStream_Click(object sender, EventArgs e)
        {
            if (btnStream.Text == "Stream")
            {
                if (KinectSensor.KinectSensors.Count > 0)

                {
                    this.btnStream.Text = "Stop";
                    kSensor = KinectSensor.KinectSensors[0];
                    KinectSensor.KinectSensors.StatusChanged += KinectSensors_StatusChanged;
                }
                kSensor.Start();
                this.lblConnectionID.Text = kSensor.DeviceConnectionId;
                kSensor.ColorStream.Enable(ColorImageFormat.RgbResolution640x480Fps30);
                kSensor.DepthStream.Enable(DepthImageFormat.Resolution320x240Fps30);
                kSensor.SkeletonStream.Enable();



                kSensor.ColorFrameReady += KSensor_ColorFrameReady;
                kSensor.DepthFrameReady += KSensor_DepthFrameReady;
                kSensor.SkeletonFrameReady += KSensor_SkeletonFrameReady;
                this.lblStatus.Text = kSensor.Status.ToString();

            }
            else
            {
                if (kSensor != null && kSensor.IsRunning)
                {
                    kSensor.Stop();
                    this.btnStream.Text = "Stream";
                    this.pbStream.Image = null;
                    this.pbDepthStream.Image = null;
                    this.pbSkeleton.Image = null;
                    this.lblStatus.Text = "Sensor stopped.";
                }
            }

        }


        private Skeleton[] skeletons;
        //skeleton
        private void KSensor_SkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            using (SkeletonFrame skeletonFrame = e.OpenSkeletonFrame())
            {
                if (skeletonFrame != null)
                {
                    // Clear the previous drawing
                    Graphics g = pbSkeleton.CreateGraphics();
                    g.Clear(System.Drawing.Color.Black);

                    // Get the skeleton data and store it in the class-level skeletons array
                    skeletons = new Skeleton[skeletonFrame.SkeletonArrayLength];
                    skeletonFrame.CopySkeletonDataTo(skeletons);

                    // Create a green pen
                    using (System.Drawing.Pen greenPen = new System.Drawing.Pen(System.Drawing.Color.Green, 3))
                    {
                        foreach (Skeleton skeleton in skeletons)
                        {
                            if (skeleton.TrackingState == SkeletonTrackingState.Tracked)
                            {
                                // Draw skeleton lines
                                DrawSkeletonLines(skeleton, g, greenPen);
                            }
                        }
                    }
                }
            }
        }

        private void DrawSkeletonLines(Skeleton skeleton, Graphics g, System.Drawing.Pen pen)
        {
            // Define joint connections using a dictionary
            Dictionary<JointType, JointType> jointConnections = new Dictionary<JointType, JointType>()
{
    { JointType.Head, JointType.ShoulderCenter },
    { JointType.ShoulderCenter, JointType.Spine },
    { JointType.Spine, JointType.HipCenter },
    { JointType.ShoulderLeft, JointType.ElbowLeft },
    { JointType.ElbowLeft, JointType.WristLeft },
    { JointType.ShoulderRight, JointType.ElbowRight },
    { JointType.ElbowRight, JointType.WristRight },
};

            // Draw lines between connected joints
            foreach (var connection in jointConnections)
            {
                JointType jointType = connection.Key;
                JointType nextJointType = connection.Value;

                Joint joint = skeleton.Joints[jointType];
                Joint nextJoint = skeleton.Joints[nextJointType];

                if (joint.TrackingState == JointTrackingState.Tracked && nextJoint.TrackingState == JointTrackingState.Tracked)
                {
                    System.Drawing.Point point = GetJointPoint(joint);
                    System.Drawing.Point nextPoint = GetJointPoint(nextJoint);
                    g.DrawLine(pen, point, nextPoint);

                }
            }
            DrawHandCircle(skeleton.Joints[JointType.HandLeft], g, pen, System.Drawing.Brushes.Red,true);
            DrawHandCircle(skeleton.Joints[JointType.HandRight], g, pen, System.Drawing.Brushes.Blue,true);
        }
        private float xCoordinateValueRight;
        private float yCoordinateValueRight;
        private float xCoordinateValueLeft;
        private float yCoordinateValueLeft;
        private float zCoordinateValueLeft;
        private float zCoordinateValueRight;
        //draw circles around hands in skeleton 
        private void DrawHandCircle(Joint handJoint, Graphics g, System.Drawing.Pen pen, System.Drawing.Brush brush, bool isSkeleton)
{
    if (handJoint.TrackingState == JointTrackingState.Tracked)
    {
                float x = handJoint.Position.X;
                float y = handJoint.Position.Y;
                float z = handJoint.Position.Z;
                if (handJoint.JointType == JointType.HandRight)
                {
                    xCoordinateValueRight = x;
                    yCoordinateValueRight = y;
                    zCoordinateValueRight=z;
                }
                else if (handJoint.JointType == JointType.HandLeft)
                {
                    xCoordinateValueLeft = x;
                    yCoordinateValueLeft = y;
                    zCoordinateValueLeft = z;
                }

                // Update the text of your label to display the X and Y coordinates
                xlabel.Text = "Left Hand X Coordinate: " + xCoordinateValueLeft.ToString("0.00");
                ylabel.Text = "Left Hand Y Coordinate: " + yCoordinateValueLeft.ToString("0.00");
                xlabel2.Text = "Right Hand X Coordinate: " + xCoordinateValueRight.ToString("0.00");
                ylabel2.Text = "Right Hand Y Coordinate: " + yCoordinateValueRight.ToString("0.00");
                zlabel.Text = "Left Hand Z Coordinate: " + zCoordinateValueLeft.ToString("0.00");
                zlabel2.Text = "Right Hand Z Coordinate: " + zCoordinateValueRight.ToString("0.00");


                if (isSkeleton)
        {
            // Map the joint position from skeleton space to screen space
            System.Drawing.Point point = GetJointPoint(handJoint);

            // Draw the circle on the skeleton image
            int circleSize = 50; // Adjust the circle size as needed
            g.FillEllipse(brush, point.X - circleSize / 2, point.Y - circleSize / 2, circleSize, circleSize);
        }
        else
        {
            // Map the joint position from skeleton space to color space
            ColorImagePoint colorPoint = kSensor.CoordinateMapper.MapSkeletonPointToColorPoint(handJoint.Position, ColorImageFormat.RgbResolution640x480Fps30);

            // Draw the circle on the RGB image
            int circleSize = 50; // Adjust the circle size as needed
            g.FillEllipse(brush, colorPoint.X - circleSize / 2, colorPoint.Y - circleSize / 2, circleSize, circleSize);
        }
    }
}



        //draw circles around hands in skeleton end
        //adjust skeleton
        private System.Drawing.Point GetJointPoint(Joint joint)
        {
            // Adjust the scaling factor and offset as needed
            float scaleX = 1.0f;
            float scaleY = 2.0f;

            int offsetX = 100;
            return new System.Drawing.Point(
                (int)Math.Round(joint.Position.X * pbSkeleton.Width * scaleX + offsetX),
                (int)Math.Round((-joint.Position.Y * pbSkeleton.Height * scaleY) + offsetX));
        }

        //adjust skeleton
        //end skeleton
        
            //text in status
        private void KinectSensors_StatusChanged(object sender, StatusChangedEventArgs e)
        {
            StringBuilder statusText = new StringBuilder();

            // Iterate through all connected sensors
            foreach (var sensor in KinectSensor.KinectSensors)
            {
                statusText.AppendLine($"Sensor {sensor.DeviceConnectionId} is {sensor.Status}");
            }

            // Update the status label
            this.lblStatus.Text = statusText.ToString();
        }

        // end text in status

    
    //part 1 done




    // part 2 depth&rgb
    //rgb
    private void KSensor_ColorFrameReady(object sender, ColorImageFrameReadyEventArgs e)
        {
            using (var frame = e.OpenColorImageFrame())
            {
                if (frame != null)
                {
                    Bitmap colorBitmap = CreateBitmapSensor(frame);
                    // Detect and draw circles around hands
                    using (Graphics g = Graphics.FromImage(colorBitmap))
                    {
                        if (skeletons != null)
                        {
                            foreach (var skeleton in skeletons)
                            {
                                if (skeleton != null && skeleton.TrackingState == SkeletonTrackingState.Tracked)
                                {
                                    DrawHandCircle(skeleton.Joints[JointType.HandLeft], g, Pens.Red, System.Drawing.Brushes.Red,false);
                                    DrawHandCircle(skeleton.Joints[JointType.HandRight], g, Pens.Blue, System.Drawing.Brushes.Blue,false);
                                }
                            }
                        }
                    }

                    pbStream.Image = colorBitmap;
                }
            }
        }





        private Bitmap CreateBitmapSensor(ColorImageFrame frame)
        {
            var pixelData = new byte[frame.PixelDataLength];
            frame.CopyPixelDataTo(pixelData);



            return pixelData.ToBitmap(frame.Width, frame.Height);
        }
        //rgb done

        // depth
        private void KSensor_DepthFrameReady(object sender, DepthImageFrameReadyEventArgs e)
        {
            using (var frame = e.OpenDepthImageFrame())
            {
                if (frame != null)
                {
                    Bitmap depthBitmap = CreateBitmapDepth(frame);
                    // Assuming pbDepthStream is a PictureBox control for displaying depth frames
                    if (pbDepthStream.InvokeRequired)
                    {
                        pbDepthStream.Invoke(new Action(() =>
                        {
                            pbDepthStream.Image = depthBitmap;
                        }));
                    }
                    else
                    {
                        pbDepthStream.Image = depthBitmap;
                    }
                }
            }
        }

        // Function to create a Bitmap from a DepthImageFrame
        private Bitmap CreateBitmapDepth(DepthImageFrame frame)
        {
            var pixelData = new short[frame.PixelDataLength];
            frame.CopyPixelDataTo(pixelData);

            return ConvertDepthToBitmap(pixelData, frame.Width, frame.Height);
        }


        private Bitmap ConvertDepthToBitmap(short[] pixelData, int width, int height)
        {
            // Assuming the depth data is in a range (e.g., 0-4095)
            int depthRange = 4096; // You should adjust this based on the range of your actual depth data

            Bitmap bmp = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, bmp.PixelFormat);
            IntPtr ptr = bmpData.Scan0;

            byte[] pixels = new byte[pixelData.Length * 4]; // 4 bytes per pixel for Format32bppRgb

            for (int i = 0; i < pixelData.Length; i++)
            {
                byte intensity = (byte)(pixelData[i] / (double)depthRange * 255); // Convert depth to intensity
                pixels[i * 4] = intensity; // Blue channel
                pixels[i * 4 + 1] = intensity; // Green channel
                pixels[i * 4 + 2] = intensity; // Red channel
                pixels[i * 4 + 3] = 255; // Alpha channel (fully opaque)
            }

            Marshal.Copy(pixels, 0, ptr, pixels.Length);
            bmp.UnlockBits(bmpData);

            return bmp;
        }
        //depth done

            //display x y z 
        private void xlabel_Click(object sender, EventArgs e)
        {
            this.xlabel.Text = this.xlabel.Text = "XL Coordinate Value: " + xCoordinateValueLeft.ToString("0.00");
        }

        private void ylabel_Click(object sender, EventArgs e)
        {
            this.ylabel.Text = this.ylabel.Text = "YL Coordinate Value: " + yCoordinateValueLeft.ToString("0.00");
        }

        private void xlabel2_Click(object sender, EventArgs e)
        {
            this.xlabel2.Text = this.xlabel2.Text = "XR Coordinate Value: " + xCoordinateValueRight.ToString("0.00");
        }

        private void ylabel2_Click(object sender, EventArgs e)
        {
            this.ylabel2.Text = this.ylabel2.Text = "YR Coordinate Value: " + yCoordinateValueRight.ToString("0.00");
        }

        private void zlabel_Click(object sender, EventArgs e)
        {
            this.zlabel.Text = this.zlabel.Text = "ZL Coordinate Value: " + zCoordinateValueLeft.ToString("0.00");
        }
        private void zlabel2_Click(object sender, EventArgs e)
        {
            this.zlabel2.Text = this.zlabel2.Text = "ZR Coordinate Value: " + zCoordinateValueRight.ToString("0.00");
        }

      
    }
    //end display x y z 




}