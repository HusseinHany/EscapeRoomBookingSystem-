using System;
using System.Windows.Forms;

namespace EscapeRoomBookingSystem
{
    public partial class AddEditRoomDialog : Form
    {
        private Room currentRoom;
        private bool isEdit;

        public AddEditRoomDialog(Room room = null)
        {
            InitializeComponent();
            if (room != null)
            {
                currentRoom = room;
                isEdit = true;
            }
            else
            {
                currentRoom = new Room();
                isEdit = false;
            }
        }

        private void AddEditRoomDialog_Load(object sender, EventArgs e)
        {
            this.Text = isEdit ? "Edit Room" : "Add New Room";
            this.StartPosition = FormStartPosition.CenterParent;

            if (isEdit)
            {
                txtRoomName.Text = currentRoom.RoomName;
                txtTheme.Text = currentRoom.Theme;
                nudDifficulty.Value = currentRoom.Difficulty;
                nudCapacity.Value = currentRoom.Capacity;
                nudPrice.Value = (decimal)currentRoom.Price;
                chkAvailable.Checked = currentRoom.IsAvailable;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(txtRoomName.Text))
            {
                MessageBox.Show("Please enter a room name", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTheme.Text))
            {
                MessageBox.Show("Please enter a theme", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nudCapacity.Value <= 0)
            {
                MessageBox.Show("Capacity must be greater than 0", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nudPrice.Value <= 0)
            {
                MessageBox.Show("Price must be greater than 0", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                currentRoom.RoomName = txtRoomName.Text;
                currentRoom.Theme = txtTheme.Text;
                currentRoom.Difficulty = (int)nudDifficulty.Value;
                currentRoom.Capacity = (int)nudCapacity.Value;
                currentRoom.Price = nudPrice.Value;
                currentRoom.IsAvailable = chkAvailable.Checked;

                if (isEdit)
                {
                    RoomManager.UpdateRoom(currentRoom);
                    MessageBox.Show("Room updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    RoomManager.AddRoom(currentRoom);
                    MessageBox.Show("Room added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving room: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void InitializeComponent()
        {
            this.lblRoomName = new System.Windows.Forms.Label();
            this.txtRoomName = new System.Windows.Forms.TextBox();
            this.lblTheme = new System.Windows.Forms.Label();
            this.txtTheme = new System.Windows.Forms.TextBox();
            this.lblDifficulty = new System.Windows.Forms.Label();
            this.nudDifficulty = new System.Windows.Forms.NumericUpDown();
            this.lblCapacity = new System.Windows.Forms.Label();
            this.nudCapacity = new System.Windows.Forms.NumericUpDown();
            this.lblPrice = new System.Windows.Forms.Label();
            this.nudPrice = new System.Windows.Forms.NumericUpDown();
            this.chkAvailable = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudDifficulty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCapacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).BeginInit();
            this.SuspendLayout();

            // lblRoomName
            this.lblRoomName.AutoSize = true;
            this.lblRoomName.Location = new System.Drawing.Point(20, 20);
            this.lblRoomName.Name = "lblRoomName";
            this.lblRoomName.Size = new System.Drawing.Size(68, 13);
            this.lblRoomName.TabIndex = 0;
            this.lblRoomName.Text = "Room Name:";

            // txtRoomName
            this.txtRoomName.Location = new System.Drawing.Point(120, 20);
            this.txtRoomName.Name = "txtRoomName";
            this.txtRoomName.Size = new System.Drawing.Size(200, 20);
            this.txtRoomName.TabIndex = 1;

            // lblTheme
            this.lblTheme.AutoSize = true;
            this.lblTheme.Location = new System.Drawing.Point(20, 50);
            this.lblTheme.Name = "lblTheme";
            this.lblTheme.Size = new System.Drawing.Size(43, 13);
            this.lblTheme.TabIndex = 2;
            this.lblTheme.Text = "Theme:";

            // txtTheme
            this.txtTheme.Location = new System.Drawing.Point(120, 50);
            this.txtTheme.Name = "txtTheme";
            this.txtTheme.Size = new System.Drawing.Size(200, 20);
            this.txtTheme.TabIndex = 3;

            // lblDifficulty
            this.lblDifficulty.AutoSize = true;
            this.lblDifficulty.Location = new System.Drawing.Point(20, 80);
            this.lblDifficulty.Name = "lblDifficulty";
            this.lblDifficulty.Size = new System.Drawing.Size(59, 13);
            this.lblDifficulty.TabIndex = 4;
            this.lblDifficulty.Text = "Difficulty:";

            // nudDifficulty
            this.nudDifficulty.Location = new System.Drawing.Point(120, 80);
            this.nudDifficulty.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            this.nudDifficulty.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudDifficulty.Name = "nudDifficulty";
            this.nudDifficulty.Size = new System.Drawing.Size(200, 20);
            this.nudDifficulty.TabIndex = 5;
            this.nudDifficulty.Value = new decimal(new int[] { 1, 0, 0, 0 });

            // lblCapacity
            this.lblCapacity.AutoSize = true;
            this.lblCapacity.Location = new System.Drawing.Point(20, 110);
            this.lblCapacity.Name = "lblCapacity";
            this.lblCapacity.Size = new System.Drawing.Size(51, 13);
            this.lblCapacity.TabIndex = 6;
            this.lblCapacity.Text = "Capacity:";

            // nudCapacity
            this.nudCapacity.Location = new System.Drawing.Point(120, 110);
            this.nudCapacity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudCapacity.Name = "nudCapacity";
            this.nudCapacity.Size = new System.Drawing.Size(200, 20);
            this.nudCapacity.TabIndex = 7;
            this.nudCapacity.Value = new decimal(new int[] { 1, 0, 0, 0 });

            // lblPrice
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(20, 140);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(37, 13);
            this.lblPrice.TabIndex = 8;
            this.lblPrice.Text = "Price:";

            // nudPrice
            this.nudPrice.Location = new System.Drawing.Point(120, 140);
            this.nudPrice.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudPrice.Name = "nudPrice";
            this.nudPrice.Size = new System.Drawing.Size(200, 20);
            this.nudPrice.TabIndex = 9;
            this.nudPrice.Value = new decimal(new int[] { 1, 0, 0, 0 });

            // chkAvailable
            this.chkAvailable.AutoSize = true;
            this.chkAvailable.Checked = true;
            this.chkAvailable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAvailable.Location = new System.Drawing.Point(120, 170);
            this.chkAvailable.Name = "chkAvailable";
            this.chkAvailable.Size = new System.Drawing.Size(71, 17);
            this.chkAvailable.TabIndex = 10;
            this.chkAvailable.Text = "Available";
            this.chkAvailable.UseVisualStyleBackColor = true;

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(120, 200);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(220, 200);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // AddEditRoomDialog
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 250);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkAvailable);
            this.Controls.Add(this.nudPrice);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.nudCapacity);
            this.Controls.Add(this.lblCapacity);
            this.Controls.Add(this.nudDifficulty);
            this.Controls.Add(this.lblDifficulty);
            this.Controls.Add(this.txtTheme);
            this.Controls.Add(this.lblTheme);
            this.Controls.Add(this.txtRoomName);
            this.Controls.Add(this.lblRoomName);
            this.Name = "AddEditRoomDialog";
            this.Load += new System.EventHandler(this.AddEditRoomDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudDifficulty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCapacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblRoomName;
        private System.Windows.Forms.TextBox txtRoomName;
        private System.Windows.Forms.Label lblTheme;
        private System.Windows.Forms.TextBox txtTheme;
        private System.Windows.Forms.Label lblDifficulty;
        private System.Windows.Forms.NumericUpDown nudDifficulty;
        private System.Windows.Forms.Label lblCapacity;
        private System.Windows.Forms.NumericUpDown nudCapacity;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.NumericUpDown nudPrice;
        private System.Windows.Forms.CheckBox chkAvailable;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
