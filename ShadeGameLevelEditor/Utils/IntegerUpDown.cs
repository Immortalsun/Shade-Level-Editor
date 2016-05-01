using System;
using System.Windows;
using System.Windows.Controls;

namespace ShadeGameLevelEditor.Utils
{
    public class IntegerUpDown : Control
    {
        #region Fields
        public static readonly DependencyProperty ValueProperty = DependencyProperty.RegisterAttached("Value",
            typeof(double),typeof(IntegerUpDown),
            new FrameworkPropertyMetadata(0.0,FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.RegisterAttached("MaxValue",
            typeof(double), typeof(IntegerUpDown),
            new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public static readonly DependencyProperty IntegerUpCommandProperty =
            DependencyProperty.Register("IntegerUpCommand",
                typeof(RelayCommand), typeof(IntegerUpDown));

        public static readonly DependencyProperty IntegerDownCommandProperty =
           DependencyProperty.Register("IntegerDownCommand",
               typeof(RelayCommand), typeof(IntegerUpDown));
        #endregion

        #region Properties

        public double Value
        {
            get { return (double) GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value);}
        }

        public double MaxValue
        {
            get { return (double) GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value);}
        }

        public RelayCommand IntegerUp
        {
            get { return (RelayCommand) GetValue(IntegerUpCommandProperty); }
            set { SetValue(IntegerUpCommandProperty, value);}
        }

        public RelayCommand IntegerDown
        {
            get { return (RelayCommand)GetValue(IntegerDownCommandProperty); }
            set { SetValue(IntegerDownCommandProperty, value); }
        }

        #endregion

        #region Constructors

        public IntegerUpDown()
        {
            IntegerUp = new RelayCommand(IncrementValue);
            IntegerDown = new RelayCommand(DecrementValue);
        }

        #endregion

        #region Methods

        private void IncrementValue(object obj)
        {
            var num = Int32.Parse(Math.Floor(Value).ToString());
            if (num + 1 < MaxValue)
            {
                num++;
                Value = num;
            }
        }

        public void DecrementValue(object obj)
        {
            var num = Int32.Parse(Value.ToString());
            if (num - 1 > 0)
            {
                num--;
                Value = num;
            }
        }

        #endregion

        #region Events

        #endregion
    }
}