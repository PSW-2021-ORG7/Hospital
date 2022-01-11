using System;
using System.Collections.Generic;
using HospitalClassLibrary.Shared.Models;

namespace HospitalClassLibrary.GraphicalEditor.Models
{
    public class RoomDimensions : ValueObject
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public double Width { get; private set; }
        public double Height { get; private set; }

        public RoomDimensions() { }

        public RoomDimensions(double x, double y, double width, double height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Validate();
        }

        private void Validate()
        {
            if (X < 0 || Y < 0 || Width <= 0 || Height <= 0)
            {
                throw new ArgumentException("Not valid");
            }
        }

        public bool AreHorizontallyAligned(RoomDimensions roomDimensions)
        {
            return Y.Equals(roomDimensions.Y);
        }

        public bool AreVerticallyAligned(RoomDimensions roomDimensions)
        {
            return X.Equals(roomDimensions.X);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return X;
            yield return Y;
            yield return Width;
            yield return Height;
        }
    }
}
