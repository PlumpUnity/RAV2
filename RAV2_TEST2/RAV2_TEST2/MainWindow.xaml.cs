using System;
using System.Windows;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;
using System.Windows.Input;

namespace RAV2_TEST2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //provides functionality to 3d models
        Model3DGroup RA = new Model3DGroup();
        Model3D link1 = null;
        Model3D link2 = null;
        Model3D link3 = null;
        Model3D link4 = null;
        Model3D link5 = null;

        //provides render to model3d objects
        ModelVisual3D RoboticArm = new ModelVisual3D();

        //directroy of all stl files
        private const string MODEL_PATH1 = "j0_j1_link.stl";
        private const string MODEL_PATH2 = "j1_j2_link.stl";
        private const string MODEL_PATH3 = "j2_j3_link.stl";
        private const string MODEL_PATH4 = "j3_j4_link.stl";
        private const string MODEL_PATH5 = "j4_j5_link.stl";

        RotateTransform3D R = new RotateTransform3D();
        TranslateTransform3D T = new TranslateTransform3D();


       

        public MainWindow()
        {
            InitializeComponent();
            RoboticArm.Content = Initialize_Environment(MODEL_PATH1, MODEL_PATH2,MODEL_PATH3, MODEL_PATH4, MODEL_PATH5);
            viewPort3d.Children.Add(RoboticArm);
            
        }

        private Model3DGroup Initialize_Environment(string model1, string model2, string model3, string model4, string model5)
        {

            try
            {

                

                viewPort3d.RotateGesture = new MouseGesture(MouseAction.LeftClick);
                ModelImporter import = new ModelImporter();
                link1 = import.Load(model1);
                link2 = import.Load(model2);
                link3 = import.Load(model3);
                link4 = import.Load(model4);
                link5 = import.Load(model5);

                Transform3DGroup F1 = new Transform3DGroup();
                Transform3DGroup F2 = new Transform3DGroup();
                Transform3DGroup F3 = new Transform3DGroup();
                Transform3DGroup F4 = new Transform3DGroup();
                Transform3DGroup F5 = new Transform3DGroup();

                R = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 0, 1), joint1.Value), new Point3D(0, 0, 0));
                F1.Children.Add(R);

                T = new TranslateTransform3D(0, 0, 9.5);
                R = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 0, 1), joint2.Value), new Point3D(0, 0, 0));
                F2.Children.Add(F1);
                F2.Children.Add(T);
                F2.Children.Add(R);

                T = new TranslateTransform3D(15,0,0);
                R = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 0, 1), joint3.Value), new Point3D(0, 0, 0));
                F3.Children.Add(F2);
                F3.Children.Add(T);
                F3.Children.Add(R);


                T = new TranslateTransform3D(6.7, 0,0);
                R = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 0, 1), joint4.Value), new Point3D(0, 0, 0));
                F4.Children.Add(F3);
                F4.Children.Add(T);
                F4.Children.Add(R);

                T = new TranslateTransform3D(5.35, 0, 0);
                R = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 0, 1), joint5.Value), new Point3D(0, 0, 0));
                F5.Children.Add(F4);
                F5.Children.Add(T);
                F5.Children.Add(R);

                link1.Transform = F1;
                link2.Transform = F2;
                link3.Transform = F3;
                link4.Transform = F4;
                link5.Transform = F5;

                RA.Children.Add(link1);
                RA.Children.Add(link2);
                RA.Children.Add(link3);
                RA.Children.Add(link4);
                RA.Children.Add(link5);
                
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception Error:" + e.StackTrace);
            }
            return RA;
        }



        private void joint1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
          execute_fk();
        }

        private void joint2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            execute_fk();
        }

        private void joint3_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            execute_fk();
        }

        private void joint4_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            execute_fk();
        }

        private void joint5_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            execute_fk();
        }

        private void execute_fk()
        {
            Transform3DGroup F1 = new Transform3DGroup();
            Transform3DGroup F2 = new Transform3DGroup();
            Transform3DGroup F3 = new Transform3DGroup();
            Transform3DGroup F4 = new Transform3DGroup();
            Transform3DGroup F5 = new Transform3DGroup();

            R = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 0, 1), joint1.Value), new Point3D(0, 0, 0));
            F1.Children.Add(R);

            T = new TranslateTransform3D(0, 0, 9.5);
            R = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 1, 0), joint2.Value), new Point3D(0, 0, 9.5));
            F2.Children.Add(T);
            F2.Children.Add(R);
            F2.Children.Add(F1);


            T = new TranslateTransform3D(15, 0, 0);
            R = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 1, 0), joint3.Value), new Point3D(15, 0, 0));
            F3.Children.Add(T);
            F3.Children.Add(R);
            F3.Children.Add(F2);

            T = new TranslateTransform3D(6.7, 0, 0);
            R = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 1, 0), joint4.Value), new Point3D(6.7, 0, 0));
            F4.Children.Add(T);
            F4.Children.Add(R);
            F4.Children.Add(F3);

            T = new TranslateTransform3D(5.35, 0, 0);
            R = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(1, 0, 0), joint5.Value), new Point3D(5.35, 0, 0));
            F5.Children.Add(T);
            F5.Children.Add(R);
            F5.Children.Add(F4);

            link1.Transform = F1;
            link2.Transform = F2;
            link3.Transform = F3;
            link4.Transform = F4;
            link5.Transform = F5;
        }
    }
}
