using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ShadeGameLevelEditor.Model
{
    public class Platform : IXmlSerializable
    {

        #region Fields

        private int _x, _y, _width, _height;

        #endregion

        #region Properties

        public Platform()
        {
            _x = 0;
            _y = 0;
            _width = 0;
            _height = 0;
        }

        public Platform(int x, int y, int width, int height)
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

        #region Constructors
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