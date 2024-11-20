using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace RimeControls.WatermarkComboBox.Implementation
{
    public class WatermarkComboBox : ComboBox
    {
        #region Properties

        #region Watermark

        public static readonly DependencyProperty WatermarkProperty = DependencyProperty.Register("Watermark", typeof(object), typeof(WatermarkComboBox), new UIPropertyMetadata(null));
        public object Watermark
        {
            get
            {
                return (object)GetValue(WatermarkProperty);
            }
            set
            {
                SetValue(WatermarkProperty, value);
            }
        }

        #endregion //Watermark

        #region WatermarkTemplate

        public static readonly DependencyProperty WatermarkTemplateProperty = DependencyProperty.Register("WatermarkTemplate", typeof(DataTemplate), typeof(WatermarkComboBox), new UIPropertyMetadata(null));
        public DataTemplate WatermarkTemplate
        {
            get
            {
                return (DataTemplate)GetValue(WatermarkTemplateProperty);
            }
            set
            {
                SetValue(WatermarkTemplateProperty, value);
            }
        }

        #endregion //WatermarkBackground

        #region WatermarkBackground

        public static readonly DependencyProperty WatermarkBackgroundProperty = DependencyProperty.RegisterAttached(
            "WatermarkBackground", typeof(Brush), typeof(WatermarkComboBox), new PropertyMetadata((Brush)null));

        public Brush WatermarkBackground
        {
            get
            {
                return (Brush)GetValue(WatermarkBackgroundProperty);
            }
            set
            {
                SetValue(WatermarkBackgroundProperty, value);
            }
        }

        #endregion //WatermarkBackground

        #endregion //Properties

        #region Constructors

        static WatermarkComboBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WatermarkComboBox), new FrameworkPropertyMetadata(typeof(WatermarkComboBox)));
        }

        public WatermarkComboBox()
        {
        }

        #endregion //Constructors

        #region Base Class Overrides




        #endregion
    }
}
