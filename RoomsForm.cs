using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EscapeRoomBookingSystem
{
    public partial class RoomsForm : Form
    {
        public RoomsForm()
        {
            InitializeComponent();
        }

        private void RoomsForm_Load(object sender, EventArgs e)
        {
            this.Text = "Escape Room Booking System - Manage Rooms";
            this.StartPosition = FormStartPosition.CenterParent;
            RefreshRoomsList();
        }

        private void RefreshRoomsList()
        {
            try
            {
                List<Room> rooms = RoomManager.GetAllRooms();
                dgvRooms.DataSource = rooms;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading rooms: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddEditRoomDialog dialog = new AddEditRoomDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                RefreshRoomsList();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvRooms.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a room to edit", "Select Room", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Room room = (Room)dgvRooms.SelectedRows[0].DataBoundItem;
            AddEditRoomDialog dialog = new AddEditRoomDialog(room);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                RefreshRoomsList();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvRooms.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a room to delete", "Select Room", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this room?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    Room room = (Room)dgvRooms.SelectedRows[0].DataBoundItem;
                    RoomManager.DeleteRoom(room.RoomID);
                    MessageBox.Show("Room deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshRoomsList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting room: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnToggleAvailability_Click(object sender, EventArgs e)
        {
            if (dgvRooms.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a room", "Select Room", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                Room room = (Room)dgvRooms.SelectedRows[0].DataBoundItem;
                RoomManager.ToggleRoomAvailability(room.RoomID);
                RefreshRoomsList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error toggling availability: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeComponent()
        {
            this.dgvRooms = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnToggleAvailability = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRooms)).BeginInit();
            this.SuspendLayout();

            // dgvRooms
            this.dgvRooms.Location = new System.Drawing.Point(10, 10);
            this.dgvRooms.Name = "dgvRooms";
            this.dgvRooms.Size = new System.Drawing.Size(760, 300);
            this.dgvRooms.TabIndex = 0;

            // btnAdd
            this.btnAdd.Location = new System.Drawing.Point(10, 320);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 30);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add Room";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // btnEdit
            this.btnEdit.Location = new System.Drawing.Point(120, 320);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 30);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Edit Room";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            // btnDelete
            this.btnDelete.Location = new System.Drawing.Point(230, 320);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete Room";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // btnToggleAvailability
            this.btnToggleAvailability.Location = new System.Drawing.Point(340, 320);
            this.btnToggleAvailability.Name = "btnToggleAvailability";
            this.btnToggleAvailability.Size = new System.Drawing.Size(120, 30);
            this.btnToggleAvailability.TabIndex = 4;
            this.btnToggleAvailability.Text = "Toggle Availability";
            this.btnToggleAvailability.Click += new System.EventHandler(this.btnToggleAvailability_Click);

            // RoomsForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 370);
            this.Controls.Add(this.btnToggleAvailability);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvRooms);
            this.Name = "RoomsForm";
            this.Load += new System.EventHandler(this.RoomsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRooms)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dgvRooms;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnToggleAvailability;
    }
}
