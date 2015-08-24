namespace Surfaces
{
    using System;
    using System.Windows.Media.Media3D;

    public sealed class Circle : Surface
    {
        private static readonly PropertyHolder<double, Circle> RadiusProperty =
            new PropertyHolder<double, Circle>("Radius", 1.0, OnGeometryChanged);

        private static readonly PropertyHolder<Point3D, Circle> PositionProperty =
            new PropertyHolder<Point3D, Circle>("Position", new Point3D(0, 0, 0), OnGeometryChanged);

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

            var mesh = new MeshGeometry3D();
            var prevPoint = this.PointForAngle(0);
            var normal = new Vector3D(0, 0, 1);

            int div = 180;

            for (var i = 1; i <= div; ++i)
            {
                var angle = 2 * Math.PI / div * i;
                var newPoint = this.PointForAngle(angle);
                mesh.Positions.Add(prevPoint);
                mesh.Positions.Add(this.position);
                mesh.Positions.Add(newPoint);
                mesh.Normals.Add(normal);
                mesh.Normals.Add(normal);
                mesh.Normals.Add(normal);
                prevPoint = newPoint;
            }

            mesh.Freeze();
            return mesh;
        }

        private Point3D PointForAngle(double angle)
        {
            double x = this.position.X + (this.radius * Math.Cos(angle));
            double y = this.position.Y + (this.radius * Math.Sin(angle));
            double z = this.position.Z;

            return new Point3D(x, y, z);
        }
    }
}