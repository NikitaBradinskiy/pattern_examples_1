using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace PracticeTime3
{

    public interface IFigure
    {
        IFigure Clone();
        void GetInfo();
    }
    [Serializable]
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    [Serializable]
    public class Circle : IFigure
    {
        int radius;
        public Point Point { get; set; }
        public Circle(int r, int x, int y)
        {
            radius = r;
            this.Point = new Point { X = x, Y = y };
        }

        public IFigure Clone()
        {
            return this.MemberwiseClone() as IFigure;
        }

        public object DeepCopy()
        {
            object figure = null;
            using (MemoryStream tempStream = new MemoryStream())
            {
                BinaryFormatter binFormatter = new BinaryFormatter(null,
                    new StreamingContext(StreamingContextStates.Clone));

                binFormatter.Serialize(tempStream, this);
                tempStream.Seek(0, SeekOrigin.Begin);

                figure = binFormatter.Deserialize(tempStream);
            }
            return figure;
        }
        public void GetInfo()
        {
            Console.WriteLine("Круг радиусом {0} и центром в точке ({1}, {2})", radius, Point.X, Point.Y);
        }
    }

}
