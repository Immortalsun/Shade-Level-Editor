using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using ShadeGameLevelEditor.Model;

namespace ShadeGameLevelEditor.Models
{
    public class Level : IXmlSerializable
    {

        #region Fields

        private string _bgFilePath;
        private List<Platform> _platformBlocks;

        #endregion

        #region Properties

        public string BgImage
        {
            get { return _bgFilePath; }
            set { _bgFilePath = value; }
        }

        #endregion

        #region Constructor
        public Level()
        {
            _bgFilePath = String.Empty;
            _platformBlocks = new List<Platform>();
        }

        public Level(string levelFilePath)
        {

        }

        public Level(Level level)
        {
            _bgFilePath = level._bgFilePath;
            _platformBlocks = level._platformBlocks;
        }
        #endregion

        #region Methods

        private void LoadLevelFile(string levelFile)
        {

        }

        private void SaveLevel(string saveLoc)
        {

        }

        public void AddPlatformByCoordinates(int left, int top, int width, int height)
        {
            _platformBlocks.Add(new Platform(left,top,width,height));
        }

        public void AddPlatformByBlock(Platform block)
        {
            _platformBlocks.Add(block);
        }
        #endregion

        #region Events
        #endregion

        public XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }

        public void ReadXml(XmlReader reader)
        {
            throw new NotImplementedException();
        }

        public void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }
    }
}
