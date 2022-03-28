using System;
using System.Globalization;
using System.Windows.Forms;

namespace Hotel.Columns
{
    /// <summary>
    /// Зададим столбец календаря для элемента управления DataGridView.
    /// </summary>
    public class Calendar : DataGridViewColumn
    {
        public Calendar() : base(new CalendarCell())
        {
        }
        public override DataGridViewCell CellTemplate
        {
            get => base.CellTemplate;
            set
            {

                if (value != null && !(value.GetType().IsAssignableFrom(typeof(CalendarCell))))
                {
                    throw new InvalidCastException("Должен быть CalendarCell");
                }

                base.CellTemplate = value;
            }
        }
    }

    /// <summary>
    /// Зададим ячейку календаря для элемента управления DataGridView.
    /// </summary>
    public class CalendarCell : DataGridViewTextBoxCell
    {
        public CalendarCell()
        {
            Style.Format = "d";
            EmptyDate = DateTime.Now;
        }
        /// <summary>
        /// Устанавливаем дату по умолчанию
        /// </summary>
        public DateTime EmptyDate { get; set; }

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            var theControl = (CalendarEditingControl)DataGridView.EditingControl;

            if (Convert.IsDBNull(Value) || (Value == null))
            {
                theControl.Value = DateTime.Now;
            }
            else
            {
                theControl.Value = Convert.ToDateTime(Value);
            }

        }
        public override Type EditType => typeof(CalendarEditingControl);
        public override Type ValueType => typeof(DateTime);
        public override object DefaultNewRowValue => DateTime.Now;
    }

    /// <summary>
    /// Зададим всплывающее окно календаря в DataGridView.
    /// </summary>
    /// <remarks></remarks>
    internal class CalendarEditingControl : DateTimePicker, IDataGridViewEditingControl
    {
        private DataGridView _dataGridViewControl;
        private bool _valueChanged = false;
        private int _rowIndexNumber;

        public CalendarEditingControl()
        {
            Format = DateTimePickerFormat.Short;
        }

        public object EditingControlFormattedValue
        {
            get => Value.ToShortDateString();
            set
            {
                if (value is string)
                {
                    Value = DateTime.Parse(Convert.ToString(value));
                }
            }
        }
        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return Value.ToString(CultureInfo.InvariantCulture);
        }
        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            Font = dataGridViewCellStyle.Font;
            CalendarForeColor = dataGridViewCellStyle.ForeColor;
            CalendarMonthBackground = dataGridViewCellStyle.BackColor;
        }

        /// <summary>
        /// Унаследованные методы взаимодействия
        /// </summary>
        /// <remarks></remarks>
        public int EditingControlRowIndex
        {
            get => _rowIndexNumber;
            set => _rowIndexNumber = value;
        }
        public bool EditingControlWantsInputKey(Keys key, bool dataGridViewWantsInputKey)
        {
            if (((key & Keys.KeyCode) == Keys.Left) ||
                ((key & Keys.KeyCode) == Keys.Up) ||
                ((key & Keys.KeyCode) == Keys.Down) ||
                ((key & Keys.KeyCode) == Keys.Right) ||
                ((key & Keys.KeyCode) == Keys.Home) ||
                ((key & Keys.KeyCode) == Keys.End) ||
                ((key & Keys.KeyCode) == Keys.PageDown) ||
                ((key & Keys.KeyCode) == Keys.PageUp))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void PrepareEditingControlForEdit(bool selectAll)
        {
        }
        public bool RepositionEditingControlOnValueChange => false;

        public DataGridView EditingControlDataGridView
        {
            get => _dataGridViewControl;
            set => _dataGridViewControl = value;
        }
        public bool EditingControlValueChanged
        {
            get => _valueChanged;
            set => _valueChanged = value;
        }
        Cursor IDataGridViewEditingControl.EditingPanelCursor => EditingControlCursor;
        public Cursor EditingControlCursor => base.Cursor;
        protected override void OnValueChanged(EventArgs eventArgs)
        {
            _valueChanged = true;
            EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnValueChanged(eventArgs);
        }
    }
}
