﻿using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ShadeGameLevelEditor.Model
{
    public class Platform
    {

        #region Fields

        private double _x, _y, _width, _height;
        private string _name;
        #endregion

        #region Properties
        [XmlAttribute]
        public double Height
        {
            get { return _height; }
            set { _height = value; }
        }

        [XmlAttribute]
        public double Width
        {
            get { return _width; }
            set { _width = value; }
        }

        [XmlAttribute]
        public double Y
        {
            get { return _y; }
            set { _y = value; }
        }

        [XmlAttribute]
        public double X
        {
            get { return _x; }
            set { _x = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        #endregion

        #region Constructors
        public Platform()
        {
            _x = 0;
            _y = 0;
            _width = 0;
            _height = 0;
            _name = String.Empty;
        }

        public Platform(double x, double y, double width, double height, string name)
        {
            _x = x;
            _y = y;
            _width = width;
            _height = height;
            _name = name;
        }

        public Platform(Platform p)
        {
            _x = p._x;
            _y = p._y;
            _width = p._width;
            _height = p._height;
            _name = p._name;
        }
        #endregion

        #region Methods
        #endregion

        #region Events
        #endregion

    }
}