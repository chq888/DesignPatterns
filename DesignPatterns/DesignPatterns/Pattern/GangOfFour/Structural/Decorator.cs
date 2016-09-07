using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace DesignPatterns.Pattern.GangOfFour.Structural
{
    public interface IPhoto
    {
        Bitmap GetPhoto();
    }

    public class Photo : IPhoto
    {
        public Bitmap GetPhoto()
        {
            return null;
        }
    }

    public abstract class DecoratorBase: IPhoto
    {
        private IPhoto _Photo;
        public DecoratorBase(IPhoto photo)
        {
            _Photo = photo;
        }

        public virtual Bitmap GetPhoto()
        {
            return _Photo.GetPhoto();
        }

    }

    public class WatermarkDecorator : DecoratorBase
    {
        public WatermarkDecorator(IPhoto photo) : base(photo)
        {
        }

        public override Bitmap GetPhoto()
        {
            return base.GetPhoto();
        }
    }
}