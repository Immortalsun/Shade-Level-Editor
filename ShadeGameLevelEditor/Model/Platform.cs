using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ShadeGameLevelEditor.Model
{
    public class Platform : IXmlSerializable
    {

        #region Fields

        private double _x, _y, _width, _height;

        #endregion

        #region Properties

        public double X
        {
            get { return _x; }
            set { _x = value; }
        }

        public double Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public double Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public double Height
        {
            get { return _height; }
            set { _height = value; }
        }
        #endregion

        #region Constructors
        public Platform()
        {
            _x = 0;
            _y = 0;
            _width = 0;
            _height = 0;
        }

        public Platform(double x, double y, double width, double height)
        {
            _x = x;
            _y = y;
            _width = width;
            _height = height;
        }

        public Platform(Platform p)
        {
            _x = p._x;
            _y = p._y;
            _width = p._width;
            _height = p._height;
        }
        #endregion

        #region Methods
        #endregion

        #region Events
        #endregion

        public XmlSchema GetSchema()
        {
            throw new System.NotImplementedException();
        }

        public void ReadXml(XmlReader reader)
        {
            throw new System.NotImplementedException();
        }

        public void WriteXml(XmlWriter writer)
        {
            throw new System.NotImplementedException();
        }
    }
}