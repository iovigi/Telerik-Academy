namespace Microsoft._3DTools
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Media3D;

    public class TrackballDecorator : Viewport3DDecorator
    {
        private readonly Border eventSource;
        private readonly AxisAngleRotation3D rotation = new AxisAngleRotation3D();
        private readonly ScaleTransform3D scale = new ScaleTransform3D();
        private readonly Transform3DGroup transform;

        private Point previousPosition2D;
        private Vector3D previousPosition3D = new Vector3D(0, 0, 1);

        public TrackballDecorator()
        {
            // the transform that will be applied to the viewport 3d's camera
            this.transform = new Transform3DGroup();
            this.transform.Children.Add(this.scale);
            this.transform.Children.Add(new RotateTransform3D(this.rotation));

            // used so that we always get events while activity occurs within
            // the viewport3D
            this.eventSource = new Border();
            this.eventSource.Background = Brushes.Transparent;

            this.PreViewportChildren.Add(this.eventSource);
        }

        /// <summary>
        ///     A transform to move the camera or scene to the trackball's
        ///     current orientation and scale.
        /// </summary>
        public Transform3D Transform
        {
            get { return this.transform; }
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);

            this.previousPosition2D = e.GetPosition(this);
            this.previousPosition3D = this.ProjectToTrackball(this.ActualWidth, this.ActualHeight, this.previousPosition2D);

            if (Mouse.Captured == null)
            {
                Mouse.Capture(this, CaptureMode.Element);
            }
        }

        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            base.OnMouseUp(e);

            if (this.IsMouseCaptured)
            {
                Mouse.Capture(this, CaptureMode.None);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (this.IsMouseCaptured)
            {
                var currentPosition = e.GetPosition(this);

                // avoid any zero axis conditions
                if (currentPosition == this.previousPosition2D)
                {
                    return;
                }

                // Prefer tracking to zooming if both buttons are pressed.
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    this.Track(currentPosition);
                }
                else if (e.RightButton == MouseButtonState.Pressed)
                {
                    this.Zoom(currentPosition);
                }

                this.previousPosition2D = currentPosition;

                var viewport3D = Viewport3D;
                if (viewport3D != null)
                {
                    if (viewport3D.Camera != null)
                    {
                        if (viewport3D.Camera.IsFrozen)
                        {
                            viewport3D.Camera = viewport3D.Camera.Clone();
                        }

                        if (viewport3D.Camera.Transform != this.transform)
                        {
                            viewport3D.Camera.Transform = this.transform;
                        }
                    }
                }
            }
        }

        private void Track(Point currentPosition)
        {
            var currentPosition3D = this.ProjectToTrackball(ActualWidth, ActualHeight, currentPosition);

            var axis = Vector3D.CrossProduct(this.previousPosition3D, currentPosition3D);
            var angle = Vector3D.AngleBetween(this.previousPosition3D, currentPosition3D);

            // quaterion will throw if this happens - sometimes we can get 3D positions that
            // are very similar, so we avoid the throw by doing this check and just ignoring
            // the event 
            if (axis.Length == 0)
            {
                return;
            }

            var delta = new Quaternion(axis, -angle);

            // Get the current orientantion from the RotateTransform3D
            var r = this.rotation;
            var q = new Quaternion(this.rotation.Axis, this.rotation.Angle);

            // Compose the delta with the previous orientation
            q *= delta;

            // Write the new orientation back to the Rotation3D
            this.rotation.Axis = q.Axis;
            this.rotation.Angle = q.Angle;

            this.previousPosition3D = currentPosition3D;
        }

        private Vector3D ProjectToTrackball(double width, double height, Point point)
        {
            var x = point.X / (width / 2); // Scale so bounds map to [0,0] - [2,2]
            var y = point.Y / (height / 2);

            x = x - 1; // Translate 0,0 to the center
            y = 1 - y; // Flip so +Y is up instead of down

            var z2 = 1 - (x * x) - (y * y); // z^2 = 1 - x^2 - y^2
            var z = z2 > 0 ? Math.Sqrt(z2) : 0;

            return new Vector3D(x, y, z);
        }

        private void Zoom(Point currentPosition)
        {
            var delta = currentPosition.Y - this.previousPosition2D.Y;

            var scale = Math.Exp(delta / 100); // e^(yDelta/100) is fairly arbitrary.

            this.scale.ScaleX *= scale;
            this.scale.ScaleY *= scale;
            this.scale.ScaleZ *= scale;
        }
    }
}