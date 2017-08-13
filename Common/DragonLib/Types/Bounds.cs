using System;
using System.Collections.Generic;
using System.Text;

namespace DragonLib.Types
{
    public class Bounds
    {
        public int MinX { get; protected set; }
        public int MaxX { get; protected set; }
        public int MinY { get; protected set; }
        public int MaxY { get; protected set; }
        public int MinLayer { get; protected set; }
        public int MaxLayer { get; protected set; }
        public bool IgnoreLayer { get; protected set; }

        /// <summary>
        /// Builds boudaries with the specified coordinates
        /// </summary>
        /// <param name="minX"></param>
        /// <param name="maxX"></param>
        /// <param name="minY"></param>
        /// <param name="maxY"></param>
        public Bounds(int minX, int maxX, int minY, int maxY)
        {
            this.MinX = minX;
            this.MaxX = maxX;
            this.MinY = minY;
            this.MaxY = maxY;
        }

        /// <summary>
        /// Builds boudaries fron 0,0 to the specified values
        /// </summary>
        /// <param name="maxX"></param>
        /// <param name="maxY"></param>
        public Bounds(int maxX, int maxY) : this(0, maxX, 0, maxY) { }

        /// <summary>
        /// Builds boudaries with the specified coordinates and layers
        /// </summary>
        /// <param name="minX"></param>
        /// <param name="maxX"></param>
        /// <param name="minY"></param>
        /// <param name="maxY"></param>
        /// <param name="minLayer"></param>
        /// <param name="maxLayer"></param>
        public Bounds(int minX, int maxX, int minY, int maxY, int minLayer, int maxLayer) : this(minX, maxX, minY, maxY)
        {
            this.MinLayer = minLayer;
            this.MaxLayer = maxLayer;
        }

        /// <summary>
        /// Sets the layer boudaries
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public void SetLayers(int min, int max)
        {
            MinLayer = min;
            MaxLayer = max;
        }

        /// <summary>
        /// Sets the boudaries for the x coordinates
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public void SetXBoudaries(int min, int max)
        {
            MinX = min;
            MaxX = max;
        }

        /// <summary>
        /// Sets the boudaries for the y coordinates
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public void SetYBoudaries(int min, int max)
        {
            MinY = min;
            MaxY = max;
        }

        /// <summary>
        /// Specify weather or not to conside the layer bounds
        /// </summary>
        /// <param name="value"></param>
        public void SetIgnoreLayer(bool value)
        {
            IgnoreLayer = value;
        }

        /// <summary>
        /// Verify if the position is inside the bounds
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool IsInsideBounds(Position position)
        {
            if (IgnoreLayer)
            {
                return IsInsideXBounds(position.PositionX) && IsInsideYBounds(position.PositionY);
            }
            else
            {
                return IsInsideXBounds(position.PositionX) && IsInsideYBounds(position.PositionY) && IsInsideLayerBounds(position.Layer);
            }
        }

        /// <summary>
        /// Verify is the value is inside the x bounds
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool IsInsideXBounds(int position)
        {
            return position >= MinX && position <= MaxX;
        }

        /// <summary>
        /// Verify is the value is inside the y bounds
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool IsInsideYBounds(int position)
        {
            return position >= MinY && position <= MaxY;
        }

        /// <summary>
        /// Verfiy is the value is between the layer bounds
        /// </summary>
        /// <param name="layer"></param>
        /// <returns></returns>
        public bool IsInsideLayerBounds(int layer)
        {
            return layer >= MinLayer && layer <= MaxLayer;
        }
    }
}
