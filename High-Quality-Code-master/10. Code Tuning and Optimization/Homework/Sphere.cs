namespace Surfaces
{
    using System;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Media3D;

    public sealed class Sphere : Surface
    {
        private static readonly PropertyHolder<double, Sphere> RadiusProperty =
            new PropertyHolder<double, Sphere>("Radius", 1.0, OnGeometryChanged);

        private static readonly PropertyHolder<Point3D, Sphere> PositionProperty =
            new PropertyHolder<Point3D, Sphere>("Position", new Point3D(0, 0, 0), OnGeometryChanged);

        private Point3D position;
        private double radius;

        public double Radius
        {
            get { return RadiusProperty.Get(this); }
            set { RadiusProperty.Set(this, value); }
        }

        public Point3D Position
        {
            get { return PositionProperty.Get(this); }
            set { PositionProperty.Set(this, value); }
        }

        protected override Geometry3D CreateMesh()
        {
            this.radius = this.Radius;
            this.position = this.Position;

            int angleSteps = 32;
            double minAngle = 0;
            double maxAngle = 2 * Math.PI;
            double angle = (maxAngle - minAngle) / angleSteps;

            int steps = 32;
            double minY = -1.0;
            double maxY = 1.0;
            double dy = (maxY - minY) / steps;

            var mesh = new MeshGeometry3D();

            for (var yi = 0; yi <= steps; yi++)
            {
                var y = minY + (yi * dy);

                for (var ai = 0; ai <= angleSteps; ai++)
                {
                    var ang = ai * angle;

                    mesh.Positions.Add(this.GetPosition(ang, y));
                    mesh.Normals.Add(this.GetNormal(ang, y));
                    mesh.TextureCoordinates.Add(this.GetTextureCoordinate(ang, y));
                }
            }

            for (var yi = 0; yi < steps; yi++)
            {
                for (var ai = 0; ai < angleSteps; ai++)
                {
                    var a1 = ai;
                    var a2 = ai + 1;
                    var y1 = yi * (angleSteps + 1);
                    var y2 = (yi + 1) * (angleSteps + 1);

                    mesh.TriangleIndices.Add(y1 + a1);
                    mesh.TriangleIndices.Add(y2 + a1);
                    mesh.TriangleIndices.Add(y1 + a2);

                    mesh.TriangleIndices.Add(y1 + a2);
                    mesh.TriangleIndices.Add(y2 + a1);
                    mesh.TriangleIndices.Add(y2 + a2);
                }
            }

            mesh.Freeze();
            return mesh;
        }

        private Point3D GetPosition(double angle, double y)
        {
            var r = this.radius * Math.Sqrt(1 - (y * y));
            var x = this.position.X + (r * Math.Cos(angle));
            var newY = this.position.Y + (this.radius * y);
            var z = this.position.Z + (r * Math.Sin(angle));

            return new Point3D(x, newY, z);
        }

        private Vector3D GetNormal(double angle, double y)
        {
            return (Vector3D)this.GetPosition(angle, y);
        }

        private Point GetTextureCoordinate(double angle, double y)
        {
            var map = new Matrix();
            map.Scale(1 / (2 * Math.PI), -0.5);

            var p = new Point(angle, y);
            p = p * map;

            return p;
        }
    }
}