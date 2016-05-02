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
    [XmlRootAttribute("Level")]
    public class Level
    {

        #region Fields

        private string _bgFilePath, _fgFilePath;
        private List<Platform> _platformBlocks;

        #endregion

        #region Properties
        [XmlElement("BackgroundImage")]
        public string BgImage
        {
            get { return _bgFilePath; }
            set { _bgFilePath = value; }
        }

        [XmlElement("ForegroundImage")]
        public string FgImage
        {
            get { return _fgFilePath;}
            set { _fgFilePath = value; }
        }

        [XmlArrayItem("Platform")]
        public List<Platform> Platforms
        {
            get { return _platformBlocks;}
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

        public void AddPlatformByCoordinates(double left, double top, double width, double height)
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
    }
}
