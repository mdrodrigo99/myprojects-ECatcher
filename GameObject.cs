using System;
using System.Collections.Generic;
using System.Text;
using SplashKitSDK;

namespace ECatcher
{
    public abstract class GameObject
    {
        protected Point2D _position;
        protected Bitmap _image;
        protected int _value;
        protected Vector2D _velocity;

        public GameObject(double x, double y)
        {
            _position.X = x;
            _position.Y = y;
        }

        public virtual void Draw() 
        {
            SplashKit.DrawBitmap(_image, _position.X, _position.Y);
        }

        public abstract void Update();

        public Point2D Position 
        {
            get 
            {
                return _position;
            }
            set 
            {
                _position = value;
            }
        }

        public virtual bool IsAt(Bitmap img, Point2D pt) 
        {
            return SplashKit.BitmapCollision(_image, _position, img, pt);
        }

        public Bitmap Image
        {
            get
            {
                return _image;
            }
            set 
            {
                _image = value;
            }
        }

        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        public Vector2D Velocity
        {
            get 
            {
                return _velocity;
            }
            set 
            {
                _velocity = value;
            }
        }
    }
}