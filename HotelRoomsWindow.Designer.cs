using Hotel.Columns;

namespace Hotel
{
    partial class HotelRoomsWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Высвобождение используемых ресурсов
        /// </summary>
        /// <param name="disposing">true - если используемые ресурсы должны быть высвобождены false - нет</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.AllButton = new System.Windows.Forms.Button();
            this.CurrentRowButton2 = new System.Windows.Forms.Button();
            this.CurrentRowButton1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.RoomIdentifierColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.AllButton);
            this.panel1.Controls.Add(this.CurrentRowButton2);
            this.panel1.Controls.Add(this.CurrentRowButton1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 125);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(414, 55);
            this.panel1.TabIndex = 0;
            // 
            // AllButton
            // 
            this.AllButton.Location = new System.Drawing.Point(219, 15);
            this.AllButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.AllButton.Name = "AllButton";
            this.AllButton.Size = new System.Drawing.Size(88, 27);
            this.AllButton.TabIndex = 4;
            this.AllButton.Text = "All";
            this.AllButton.UseVisualStyleBackColor = true;
            this.AllButton.Click += new System.EventHandler(this.AllButton_Click);
            // 
            // CurrentRowButton2
            // 
            this.CurrentRowButton2.Location = new System.Drawing.Point(125, 15);
            this.CurrentRowButton2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CurrentRowButton2.Name = "CurrentRowButton2";
            this.CurrentRowButton2.Size = new System.Drawing.Size(88, 27);
            this.CurrentRowButton2.TabIndex = 3;
            this.CurrentRowButton2.Text = "Current 2";
            this.CurrentRowButton2.UseVisualStyleBackColor = true;
            this.CurrentRowButton2.Click += new System.EventHandler(this.CurrentRowButton2_Click);
            // 
            // CurrentRowButton1
            // 
            this.CurrentRowButton1.Location = new System.Drawing.Point(14, 15);
            this.CurrentRowButton1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CurrentRowButton1.Name = "CurrentRowButton1";
            this.CurrentRowButton1.Size = new System.Drawing.Size(88, 27);
            this.CurrentRowButton1.TabIndex = 2;
            this.CurrentRowButton1.Text = "Current 1";
            this.CurrentRowButton1.UseVisualStyleBackColor = true;
            this.CurrentRowButton1.Click += new System.EventHandler(this.CurrentRowButton1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RoomIdentifierColumn});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(414, 125);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // RoomIdentifierColumn
            // 
            this.RoomIdentifierColumn.DataPropertyName = "Identifier";
            this.RoomIdentifierColumn.HeaderText = "Room";
            this.RoomIdentifierColumn.Name = "RoomIdentifierColumn";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Identifier";
            this.dataGridViewTextBoxColumn1.HeaderText = "Room";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // HotelRoomsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 180);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "HotelRoomsWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hotel rooms";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Button CurrentRowButton1;
        private System.Windows.Forms.Button CurrentRowButton2;
        private System.Windows.Forms.Button AllButton;
        private Calendar calendarColumn1;
        private Time timeColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomIdentifierColumn;
        private Calendar StartDateColumn;
        private Time StartTimeColumn;
    }
}