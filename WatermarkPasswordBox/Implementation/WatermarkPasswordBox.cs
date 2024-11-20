using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using RimeControls.TextBoxControls.WatermarkTextboxControl.Implementation;

namespace RimeControls.PasswordBoxes
{
    public class WatermarkPasswordBox : WatermarkTextBox
    {
        #region Members

        private int _newCaretIndex = -1;

        #endregion

        #region Properties

        #region Password

        public string Password
        {
            [SecuritySafeCritical]
            get
            {
                string passwordString;
                var valuePtr = Marshal.SecureStringToBSTR(SecurePassword);
                try
                {
                    passwordString = Marshal.PtrToStringUni(valuePtr);
                }
                finally
                {
                    Marshal.ZeroFreeBSTR(valuePtr);
                }
                return passwordString;
            }
            set
            {
                if (value == null)
                {
                    value = string.Empty;
                }
                SecurePassword = new SecureString();
                for (int i = 0; i < value.Length; ++i)
                {
                    SecurePassword.AppendChar(value[i]);
                }

                // Internal changes to Password property will have a _newCaretIndex > 0.
                SyncTextPassword(_newCaretIndex);

                RaiseEvent(new RoutedEventArgs(PasswordChangedEvent, this));
            }
        }

        #endregion

        #region PasswordChar

        public static readonly DependencyProperty PasswordCharProperty = DependencyProperty.Register("PasswordChar", typeof(char), typeof(WatermarkPasswordBox)
          , new UIPropertyMetadata('\u25CF', OnPasswordCharChanged)); //default is black bullet

        public char PasswordChar
        {
            get
            {
                return (char)GetValue(PasswordCharProperty);
            }

            set
            {
                SetValue(PasswordCharProperty, value);
            }
        }

        private static void OnPasswordCharChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var watermarkPasswordBox = o as WatermarkPasswordBox;
            if (watermarkPasswordBox != null)
            {
                watermarkPasswordBox.OnPasswordCharChanged((char)e.OldValue, (char)e.NewValue);
            }
        }

        protected virtual void OnPasswordCharChanged(char oldValue, char newValue)
        {
            SyncTextPassword(CaretIndex);
        }

        #endregion

        #region SecurePassword

        public SecureString SecurePassword
        {
            get;
            private set;
        }

        #endregion SecurePassword

        #endregion //Properties

        #region Constructors

        public WatermarkPasswordBox()
        {
            Password = string.Empty;
            IsUndoEnabled = false;
            UndoLimit = 0;

            CommandManager.AddPreviewCanExecuteHandler(this, OnPreviewCanExecuteCommand);
            DataObject.AddPastingHandler(this, OnPaste);
        }

        #endregion //Constructors

        #region Base Class Overrides

        [SecuritySafeCritical]
        protected override void OnPreviewTextInput(TextCompositionEventArgs e)
        {
            // Do not insert \r. When AcceptReturn is true, is it already added in OnPreviewKeyDown().
            if (e.Text != "\r")
            {
                PasswordInsert(e.Text, CaretIndex);
            }

            e.Handled = true; //Handle to prevent TextChanged when OnPreviewTextInput exist

            base.OnPreviewTextInput(e);
        }

        [SecuritySafeCritical]
        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            // Keys not detected by OnPreviewTextInput
            switch (e.Key)
            {
                case Key.Space:
                    PasswordInsert(" ", CaretIndex);
                    e.Handled = true;  //Handle to prevent TextChanged when OnPreviewKeyDown exist
                    break;
                case Key.Back:
                    // With a selection, delete from CaretIndex. Without a selection delete the character before the CaretIndex.
                    PasswordRemove(SelectedText.Length > 0 ? CaretIndex : CaretIndex - 1);
                    e.Handled = true;  //Handle to prevent TextChanged when OnPreviewKeyDown exists
                    break;
                case Key.Delete:
                    PasswordRemove(CaretIndex);
                    e.Handled = true;  //Handle to prevent TextChanged when OnPreviewKeyDown exist
                    break;
                case Key.V:
                    if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                    {
                        if (Clipboard.ContainsText())
                        {
                            PasswordInsert(Clipboard.GetText(), CaretIndex);
                            e.Handled = true; //Handle to prevent TextChanged when OnPreviewKeyDown exist
                        }
                    }
                    break;
                case Key.Enter:
                    if (AcceptsReturn)
                    {
                        // Add input because it's not added by default.
                        PasswordInsert("\r", CaretIndex);
                    }
                    break;
                case Key.Escape:
                    e.Handled = true;  //Handle to prevent TextChanged when OnPreviewKeyDown exist
                    break;
            }

            base.OnPreviewKeyDown(e);
        }

        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);

            if (Text.Length != Password.Length)
            {
                // When Clear() or Cut() methods are called, we need to update the Password property to empty.
                if (Text == "")
                {
                    SetPassword("", 0);
                }
                // When AppendText() method is called, we need to reset the Text property to prevent adding text.
                else
                {
                    SyncTextPassword(Password.Length);
                }
            }
        }




        #endregion //Base Class Overrides

        #region Event

        public static readonly RoutedEvent PasswordChangedEvent = EventManager.RegisterRoutedEvent("PasswordChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler)
          , typeof(WatermarkPasswordBox));
        public event RoutedEventHandler PasswordChanged
        {
            add
            {
                AddHandler(PasswordChangedEvent, value);
            }
            remove
            {
                RemoveHandler(PasswordChangedEvent, value);
            }
        }

        #endregion

        #region Event Handlers

        [SecuritySafeCritical]
        private void OnPaste(object sender, DataObjectPastingEventArgs e)
        {
            //Pasting something that is not text
            if (!e.SourceDataObject.GetDataPresent(DataFormats.UnicodeText, true))
                return;

            var text = e.SourceDataObject.GetData(DataFormats.UnicodeText) as string;
            if (text != null)
            {
                PasswordInsert(text, CaretIndex);
            }
            e.CancelCommand(); //Cancel to prevent TextChanged
        }

        private void OnPreviewCanExecuteCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            //Will not execute these actions
            if (e.Command == ApplicationCommands.Copy ||
                e.Command == ApplicationCommands.Cut ||
                e.Command == ApplicationCommands.Undo)
            {
                e.CanExecute = false;
                e.Handled = true;  //Handle to prevent actions
            }
        }

        #endregion

        #region Private Methods

        [SecurityCritical]
        private void PasswordInsert(string text, int index)
        {
            if (text == null)
                return;
            if (index < 0 || index > Password.Length)
                return;

            //If there is a selection, remove it first
            if (SelectedText.Length > 0)
            {
                PasswordRemove(index);
            }

            var newPassword = Password;
            for (int i = 0; i < text.Length; ++i)
            {
                // MaxLength == 0 is no limit
                if (MaxLength == 0 || newPassword.Length < MaxLength)
                {
                    newPassword = newPassword.Insert(index++, text[i].ToString());
                }
            }
            SetPassword(newPassword, index);
        }

        [SecurityCritical]
        private void PasswordRemove(int index)
        {
            if (index < 0 || index >= Password.Length)
                return;

            if (SelectedText.Length > 0)
            {
                var newPassword = Password;
                for (int i = 0; i < SelectedText.Length; ++i)
                {
                    newPassword = newPassword.Remove(index, 1);
                }
                SetPassword(newPassword, index);
            }
            else
            {
                var newPassword = Password.Remove(index, 1);
                SetPassword(newPassword, index);
            }
        }

        private void SetPassword(string password, int caretIndex)
        {
            _newCaretIndex = caretIndex;
            Password = password;
            _newCaretIndex = -1;
        }

        private void SyncTextPassword(int nextCarretIndex)
        {
            var sb = new StringBuilder();
            Text = sb.Append(Enumerable.Repeat(PasswordChar, Password.Length).ToArray()).ToString();
            //set CaretIndex after Text is changed
            CaretIndex = Math.Max(nextCarretIndex, 0);
        }

        #endregion
    }
}
