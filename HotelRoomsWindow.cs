using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Hotel.Data;
using Hotel.Extensions;
using Hotel.Columns;
using Hotel.Models;

namespace Hotel
{
    public partial class HotelRoomsWindow : Form
    {
        private BindingList<Models.Room> _bindingListRooms = new BindingList<Models.Room>();
        public HotelRoomsWindow()
        {
            InitializeComponent();

            CurrentRowButton1.Enabled = false;
            CurrentRowButton2.Enabled = false;

            dataGridView1.AutoGenerateColumns = false;

            Shown += HotelRooms_Shown;
            dataGridView1.EditingControlShowing += DataGridView1_EditingControlShowing;
            dataGridView1.CellEndEdit += DataGridView1_CellEndEdit;

        }

        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            if (dataGridView1.Columns[e.ColumnIndex].Name == "StartDateColumn")
            {
                var value = _bindingListRooms.StartDate(_currentIndex);
                Console.WriteLine($"          CellEndEdit {value:d}");
            }
        }

        /// <summary>
        /// Отслеживаем индекс строки DataGridView для события EditingControlShowing.
        /// </summary>
        private int _currentIndex = 0;

        /// <summary>
        /// Элементы управления при редактировании ячейки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                _currentIndex = dataGridView1.CurrentRow.Index;
            }

            if (e.Control is CalendarEditingControl calendar)
            {
                if (dataGridView1.CurrentCell.OwningColumn.Name == "StartDateColumn")
                {
                    if (dataGridView1.CurrentRow != null)
                    {
                        var value = _bindingListRooms.StartDate(_currentIndex);
                        Console.WriteLine($"EditingControlShowing {value:d}");
                    }
                }
            }

            if (e.Control is TimeEditingControl)
            {
                if (dataGridView1.CurrentRow != null)
                {
                    var value = _bindingListRooms.StartTime(_currentIndex);
                    Console.WriteLine($"{value:T}");
                }
            }

            if (e.Control is DataGridViewTextBoxEditingControl)
            {
                if (dataGridView1.CurrentCell.OwningColumn.Name == "RoomIdentifierColumn")
                {
                    e.Control.KeyPress -= RoomNumberNumericOnly_KeyPress;
                    if (e.Control is TextBox tb)
                    {
                        tb.KeyPress += RoomNumberNumericOnly_KeyPress;
                    }
                }
            }
        }

        /// <summary>
        /// Разрешаем ввод только значений типа int
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RoomNumberNumericOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private async void HotelRooms_Shown(object sender, EventArgs e)
        {
            var roomList = await Rooms.GetRooms();

            _bindingListRooms = new BindingList<Models.Room>(roomList);

            dataGridView1.DataSource = _bindingListRooms;

            CurrentRowButton1.Enabled = true;
            CurrentRowButton2.Enabled = true;
        }

        /// <summary>
        /// Получение текущей комнаты через BindingList
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentRowButton1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            var room = _bindingListRooms.Values(dataGridView1.CurrentRow.Index);

            MessageBox.Show(room);
        }

        /// <summary>
        /// Получение текущей комнаты через Room
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentRowButton2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            var room = ((Models.Room)dataGridView1.CurrentRow.DataBoundItem).Values();
            MessageBox.Show(room);

        }

        /// <summary>
        /// Получение всех комнат из DataGridView через DataBoundItem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AllButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            var allRooms = dataGridView1.Rows
                .Cast<DataGridViewRow>()
                .Select(row => row.DataBoundItem as Models.Room);

        }
    }
}
