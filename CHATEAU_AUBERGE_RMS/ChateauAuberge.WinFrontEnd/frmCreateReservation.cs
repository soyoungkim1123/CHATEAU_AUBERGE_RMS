using ChateauAuberge.Model;
using ChateauAuberge.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChateauAuberge.WinFrontEnd
{
    public partial class frmCreateReservation : Form
    {
        public frmCreateReservation()
        {
            InitializeComponent();
        }

        private void frmCreateReservation_Load(object sender, EventArgs e)
        {
            LoadCountry();
            grpRoomSelection.Enabled = false;
            grpGuestInformation.Hide();
            ((MainForm)this.MdiParent).StatusLabel2.Text = "";
        }

        private void LoadCountry()
        {
            LookupsService service = new LookupsService();

            List<CountryLookupsDTO> countries = service.GetCountries();

            countries.Insert(0, new CountryLookupsDTO { CountryId = 0, CountryName = "-- Select a country --" });

            cmbCountry.DataSource = countries;
            cmbCountry.DisplayMember = "CountryName";
            cmbCountry.ValueMember = "CountryId";
            cmbCountry.SelectedIndex = 0;
        }

        private void cmbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbCountry.SelectedIndex > 0)
            {
                LoadState();
                cmbState.Enabled = true;
            }
            else
            {
                cmbState.DataSource = null;
                cmbState.Enabled = false;
            }
        }

        private void LoadState()
        {
            LookupsService service = new LookupsService();

            List<StateLookupsDTO> states = service.GetStates(Convert.ToInt32(cmbCountry.SelectedValue));

            states.Insert(0, new StateLookupsDTO { StateId = 0, StateName = "-- Select a state --" });

            cmbState.DataSource = states;
            cmbState.DisplayMember = "StateName";
            cmbState.ValueMember = "StateId";
            cmbState.SelectedIndex = 0;
        }

        private void btnSearchRoom_Click(object sender, EventArgs e)
        {
            try
            {
                RoomService service = new RoomService();

                List<RoomDTO> rooms = service.SearchAvailableRoomByDate(dtpStartDate.Value.Date, dtpEndDate.Value.Date);
                cmbRoomList.DataSource = null;

                if (rooms.Count() == 0)
                {
                    cmbRoomList.DataSource = null;
                    grpRoomSelection.Enabled = false;
                    MessageBox.Show("There is no available room", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    grpRoomSelection.Enabled = true;
                    rooms.Insert(0, new RoomDTO { RoomNumber = 0, RoomName = "-- Select a room --" });
                    cmbRoomList.DataSource = rooms;                   
                    cmbRoomList.DisplayMember = "RoomName";
                    cmbRoomList.ValueMember = "RoomNumber";
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbRoomList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbRoomList.SelectedIndex > 0)
                {
                    RoomService service = new RoomService();
                    RoomDTO room = service.GetRoomDetail(Convert.ToInt32(cmbRoomList.SelectedValue));

                    lbRoomNumber.Text = room.RoomNumber.ToString();
                    lbRoomName.Text = room.RoomName;
                    lbMaxOccupancy.Text = room.MaxOccupancy.ToString();
                    lbBaseRate.Text = room.BaseRate.ToString("C");
                    lbBedType.Text = room.BedType;
                    lbRoomType.Text = room.RoomType;
                    grpGuestInformation.Visible = true;
                }

                else
                {
                    lbRoomNumber.Text = "";
                    lbRoomName.Text = "";
                    lbMaxOccupancy.Text = "";
                    lbBaseRate.Text = "";
                    lbBedType.Text = "";
                    lbRoomType.Text = "";
                    grpGuestInformation.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCreateReservation_Click(object sender, EventArgs e)
        {
            try
            {                
                ReservationService service = new ReservationService();

                ReservationCreationEntity reservation = new ReservationCreationEntity
                {
                    Reservation = PopulateReservationObject()
                };

                if (service.AddReservation(reservation))
                {
                    MessageBox.Show(reservation.ConfirmMessage, "Reservation Creation Completed");
                    ClearGuestForm();
                    ClearForm();
                }
                else
                {
                    string errorMsg = "";

                    foreach(ValidationError error in reservation.Reservation.Errors)
                    {
                        errorMsg += error.Description + Environment.NewLine;
                    }
                   
                    MessageBox.Show(errorMsg, "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearGuestForm();
        }

        #region Private methods
        private void ClearGuestForm()
        {
            foreach (Control ctl in this.grpGuestInformation.Controls)
            {
                if (ctl is TextBox)
                {
                    ctl.ResetText();
                }
            }

            nudChildren.Value = 0;
            nudAdults.Value = 0;
            cmbCountry.SelectedIndex = 0;
            dtpDateOfBirth.Value = DateTime.Now;
        }

        private void ClearForm()
        {
            cmbRoomList.DataSource = null;
            grpRoomSelection.Enabled = false;
            grpGuestInformation.Visible = false;
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now;
        }

        private Reservation PopulateReservationObject()
        {
            return new Reservation()
            {
                ClerkId = ((MainForm)this.MdiParent).clerk.ClerkId,
                CheckInDate = dtpStartDate.Value.Date,
                CheckOutDate = dtpEndDate.Value.Date,
                NumOfAdults = Convert.ToInt32(nudAdults.Value),
                NumOfChildren = Convert.ToInt32(nudChildren.Value),
                RoomNumber = Convert.ToInt32(cmbRoomList.SelectedValue),
                Guest = PopulateGuestObject()
            };
        }

        private Guest PopulateGuestObject()
        {
            return new Guest()
            {
                FirstName = txtFirstName.Text.Trim(),
                MiddleName = txtMiddleName.Text.Trim() != string.Empty ? txtMiddleName.Text : null,
                LastName = txtLastName.Text.Trim(),
                Street = txtStreet.Text.Trim(),
                City = txtCity.Text.Trim(),
                StateId = Convert.ToInt32(cmbState.SelectedValue),
                CountryId = Convert.ToInt32(cmbCountry.SelectedValue),
                PostalCode = txtPostalCode.Text.Trim(),
                HomePhone = txtHomePhone.Text.Trim() != string.Empty ? txtHomePhone.Text : null,
                CellPhone = txtCellPhone.Text.Trim(),
                Email = txtEmail.Text.Trim() != string.Empty ? txtEmail.Text : null,
                DateOfBirth = dtpDateOfBirth.Value.Date
            };
        }

        #endregion

        private void frmCreateReservation_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((MainForm)this.MdiParent).RefreshParent();
        }
    }
}
