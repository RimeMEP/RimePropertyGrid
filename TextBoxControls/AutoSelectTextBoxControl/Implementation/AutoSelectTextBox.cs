﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using RimeControls.Core.Utilities;

namespace RimeControls.TextBoxControls.AutoSelectTextBoxControl.Implementation
{
    public class AutoSelectTextBox : TextBox
    {
        public AutoSelectTextBox()
        {
        }

        #region AutoSelectBehavior PROPERTY

        public AutoSelectBehavior AutoSelectBehavior
        {
            get
            {
                return (AutoSelectBehavior)GetValue(AutoSelectBehaviorProperty);
            }
            set
            {
                SetValue(AutoSelectBehaviorProperty, value);
            }
        }

        public static readonly DependencyProperty AutoSelectBehaviorProperty =
            DependencyProperty.Register("AutoSelectBehavior", typeof(AutoSelectBehavior), typeof(AutoSelectTextBox),
          new UIPropertyMetadata(AutoSelectBehavior.Never));

        #endregion AutoSelectBehavior PROPERTY

        #region AutoMoveFocus PROPERTY

        public bool AutoMoveFocus
        {
            get
            {
                return (bool)GetValue(AutoMoveFocusProperty);
            }
            set
            {
                SetValue(AutoMoveFocusProperty, value);
            }
        }

        public static readonly DependencyProperty AutoMoveFocusProperty =
            DependencyProperty.Register("AutoMoveFocus", typeof(bool), typeof(AutoSelectTextBox), new UIPropertyMetadata(false));

        #endregion AutoMoveFocus PROPERTY

        #region QueryMoveFocus EVENT

        public static readonly RoutedEvent QueryMoveFocusEvent = EventManager.RegisterRoutedEvent("QueryMoveFocus",
                                                                                                    RoutingStrategy.Bubble,
                                                                                                    typeof(QueryMoveFocusEventHandler),
                                                                                                    typeof(AutoSelectTextBox));
        #endregion QueryMoveFocus EVENT

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            if (!AutoMoveFocus)
            {
                base.OnPreviewKeyDown(e);
                return;
            }

            if (e.Key == Key.Left
              && (Keyboard.Modifiers == ModifierKeys.None
                || Keyboard.Modifiers == ModifierKeys.Control))
            {
                e.Handled = MoveFocusLeft();
            }

            if (e.Key == Key.Right
              && (Keyboard.Modifiers == ModifierKeys.None
                || Keyboard.Modifiers == ModifierKeys.Control))
            {
                e.Handled = MoveFocusRight();
            }

            if ((e.Key == Key.Up || e.Key == Key.PageUp)
              && (Keyboard.Modifiers == ModifierKeys.None
                || Keyboard.Modifiers == ModifierKeys.Control))
            {
                e.Handled = MoveFocusUp();
            }

            if ((e.Key == Key.Down || e.Key == Key.PageDown)
             && (Keyboard.Modifiers == ModifierKeys.None
               || Keyboard.Modifiers == ModifierKeys.Control))
            {
                e.Handled = MoveFocusDown();
            }

            base.OnPreviewKeyDown(e);
        }

        protected override void OnPreviewGotKeyboardFocus(KeyboardFocusChangedEventArgs e)
        {
            base.OnPreviewGotKeyboardFocus(e);

            if (AutoSelectBehavior == AutoSelectBehavior.OnFocus)
            {
                // If the focus was not in one of our child ( or popup ), we select all the text.
                if (!TreeHelper.IsDescendantOf(e.OldFocus as DependencyObject, this))
                {
                    SelectAll();
                }
            }
        }

        protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnPreviewMouseLeftButtonDown(e);

            if (AutoSelectBehavior == AutoSelectBehavior.Never)
                return;

            if (IsKeyboardFocusWithin == false)
            {
                Focus();
                e.Handled = true;  //prevent from removing the selection
            }
        }

        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);

            if (!AutoMoveFocus)
                return;

            if (Text.Length != 0
                && Text.Length == MaxLength
                && CaretIndex == MaxLength)
            {
                if (CanMoveFocus(FocusNavigationDirection.Right, true) == true)
                {
                    FocusNavigationDirection direction = FlowDirection == FlowDirection.LeftToRight
                      ? FocusNavigationDirection.Right
                      : FocusNavigationDirection.Left;

                    MoveFocus(new TraversalRequest(direction));
                }
            }
        }


        private bool CanMoveFocus(FocusNavigationDirection direction, bool reachedMax)
        {
            QueryMoveFocusEventArgs e = new QueryMoveFocusEventArgs(direction, reachedMax);
            RaiseEvent(e);
            return e.CanMoveFocus;
        }

        private bool MoveFocusLeft()
        {
            if (FlowDirection == FlowDirection.LeftToRight)
            {
                //occurs only if the cursor is at the beginning of the text
                if (CaretIndex == 0 && SelectionLength == 0)
                {
                    if (ComponentCommands.MoveFocusBack.CanExecute(null, this))
                    {
                        ComponentCommands.MoveFocusBack.Execute(null, this);
                        return true;
                    }
                    else if (CanMoveFocus(FocusNavigationDirection.Left, false))
                    {
                        MoveFocus(new TraversalRequest(FocusNavigationDirection.Left));
                        return true;
                    }
                }
            }
            else
            {
                //occurs only if the cursor is at the end of the text
                if (CaretIndex == Text.Length && SelectionLength == 0)
                {
                    if (ComponentCommands.MoveFocusBack.CanExecute(null, this))
                    {
                        ComponentCommands.MoveFocusBack.Execute(null, this);
                        return true;
                    }
                    else if (CanMoveFocus(FocusNavigationDirection.Left, false))
                    {
                        MoveFocus(new TraversalRequest(FocusNavigationDirection.Left));
                        return true;
                    }
                }
            }

            return false;
        }

        private bool MoveFocusRight()
        {
            if (FlowDirection == FlowDirection.LeftToRight)
            {
                //occurs only if the cursor is at the beginning of the text
                if (CaretIndex == Text.Length && SelectionLength == 0)
                {
                    if (ComponentCommands.MoveFocusForward.CanExecute(null, this))
                    {
                        ComponentCommands.MoveFocusForward.Execute(null, this);
                        return true;
                    }
                    else if (CanMoveFocus(FocusNavigationDirection.Right, false))
                    {
                        MoveFocus(new TraversalRequest(FocusNavigationDirection.Right));
                        return true;
                    }
                }
            }
            else
            {
                //occurs only if the cursor is at the end of the text
                if (CaretIndex == 0 && SelectionLength == 0)
                {
                    if (ComponentCommands.MoveFocusForward.CanExecute(null, this))
                    {
                        ComponentCommands.MoveFocusForward.Execute(null, this);
                        return true;
                    }
                    else if (CanMoveFocus(FocusNavigationDirection.Right, false))
                    {
                        MoveFocus(new TraversalRequest(FocusNavigationDirection.Right));
                        return true;
                    }
                }
            }

            return false;
        }

        private bool MoveFocusUp()
        {
            int lineNumber = GetLineIndexFromCharacterIndex(SelectionStart);

            //occurs only if the cursor is on the first line
            if (lineNumber == 0)
            {
                if (ComponentCommands.MoveFocusUp.CanExecute(null, this))
                {
                    ComponentCommands.MoveFocusUp.Execute(null, this);
                    return true;
                }
                else if (CanMoveFocus(FocusNavigationDirection.Up, false))
                {
                    MoveFocus(new TraversalRequest(FocusNavigationDirection.Up));
                    return true;
                }
            }

            return false;
        }

        private bool MoveFocusDown()
        {
            int lineNumber = GetLineIndexFromCharacterIndex(SelectionStart);

            //occurs only if the cursor is on the first line
            if (lineNumber == LineCount - 1)
            {
                if (ComponentCommands.MoveFocusDown.CanExecute(null, this))
                {
                    ComponentCommands.MoveFocusDown.Execute(null, this);
                    return true;
                }
                else if (CanMoveFocus(FocusNavigationDirection.Down, false))
                {
                    MoveFocus(new TraversalRequest(FocusNavigationDirection.Down));
                    return true;
                }
            }

            return false;
        }
    }
}
