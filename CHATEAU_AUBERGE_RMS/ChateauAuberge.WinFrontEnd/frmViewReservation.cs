using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChateauAuberge.Model;
using ChateauAuberge.Service;

namespace ChateauAuberge.WinFrontEnd
{
    public partial class frmViewReservation : Form
    {
        int totalCount;
        List<SummaryReservationDTO> summaryReservations = new List<SummaryReservationDTO>();

        public frmViewReservation()
        {
            InitializeComponent();
            LoadSearchCriteria();
        }

        private void frmViewReservations_Load(object sender, EventArgs e)
        {
            try
            {
                GenerateDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSearchCriteria()
        {
            cmbSearchCriteria.Items.Add("All");
            cmbSearchCriteria.Items.Add("Date");
            cmbSearchCriteria.Items.Add("Room Number");
            cmbSearchCriteria.Items.Add("Room Name");
            cmbSearchCriteria.Items.Add("Guest's Last Name");
            cmbSearchCriteria.Items.Add("Confirmation Number");
        }

        private void cmbSearchCriteria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbSearchCriteria.SelectedIndex == 0)
            {
                dtpDate.Enabled = false;
                dtpDate.Value = DateTime.Now.Date;
                txtSearch.Text = "";
                txtSearch.Enabled = false;
            }

            else if(cmbSearchCriteria.SelectedIndex == 1)
            {
                dtpDate.Enabled = true;
                dtpDate.Visible = true;
                txtSearch.Visible = false;
                txtSearch.Text = "";
            }
            else
            {
                txtSearch.Enabled = true;
                txtSearch.Visible = true;
                dtpDate.Visible = false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ReservationService service = new ReservationService();
            string error = "";
            string numberOfRecords = "";

            if (cmbSearchCriteria.SelectedIndex == -1)
            {
                error = "Please select search criteria";
            }

            else if (cmbSearchCriteria.SelectedIndex < 1) {
                summaryReservations = service.GetReservationList();
                numberOfRecords = $"Results: {summaryReservations.Count()}";
            }

            else if(cmbSearchCriteria.SelectedIndex == 1)
            {
                summaryReservations = service.GetReservationListByDate(dtpDate.Value.Date);
                numberOfRecords = $"Results: {summaryReservations.Count()} / {totalCount}";
            }
            
            else
            {
                if(txtSearch.Text != string.Empty)
                {
                    switch (cmbSearchCriteria.SelectedIndex)
                    {
                        case 2:
                            if (isNumeric(txtSearch.Text))
                            {
                                summaryReservations = service.GetReservationListByRoomNumber(Convert.ToInt32(txtSearch.Text.Trim()));
                                numberOfRecords = $"Results: {summaryReservations.Count()} / {totalCount}";
                            }
                            else
                            {
                                error = "Please enter a number";
                            }
                            break;
                        case 3:
                            summaryReservations = service.GetReservationListByRoomName(txtSearch.Text.Trim());
                            numberOfRecords = $"Results: {summaryReservations.Count()} / {totalCount}";
                            break;
                        case 4:
                            summaryReservations = service.GetReservationListByLastName(txtSearch.Text.Trim());
                            numberOfRecords = $"Results: {summaryReservations.Count()} / {totalCount}";
                            break;
                        case 5:
                            summaryReservations = service.GetReservationListByConfirmationNumber(txtSearch.Text.Trim());
                            numberOfRecords = $"Results: {summaryReservations.Count()} / {totalCount}";
                            break;
                    }
                }
                else
                {
                    error = "Please enter a keyword";
                }
            }
            

            if(error != string.Empty)
            {
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dgvReservation.DataSource = summaryReservations;
                ((MainForm)this.MdiParent).StatusLabel2.Text = numberOfRecords;
            }

        }

        private void dgvReservation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex > -1 && dgvReservation.Columns[e.ColumnIndex].Name == "btnDetail")
            {
                if(e.RowIndex >= 0)
                {
                    string confirmationNumber = dgvReservation.Rows[e.RowIndex].Cells[6].Value.ToString();
                    ReservationService service = new ReservationService();
                    DetailReservationDTO detailReservation = service.GetReservationDetail(confirmationNumber);

                    panel1.Visible = true;
                    string homePhone = detailReservation.HomePhone == string.Empty ? "" : $"/ {detailReservation.HomePhone}(Home Phone)";
                    string email = detailReservation.Email == string.Empty ? "Not provided" : detailReservation.Email;

                    lblGuestName.Text = detailReservation.GuestName;
                    lblGuestAddress.Text = detailReservation.Address;
                    lblPhone.Text = $"{detailReservation.CellPhone}(Cell Phone) {homePhone}";
                    lblEmail.Text = email;
                    lblCheckIn.Text = detailReservation.CheckInDate.ToShortDateString();
                    lblCheckOut.Text = detailReservation.CheckOutDate.ToShortDateString();
                    lblRoomNumber.Text = detailReservation.RoomNumber.ToString();
                    lblRoomName.Text = detailReservation.RoomName;
                    lblNumOfGuests.Text = $"{detailReservation.NumOfAdults} Adults, {detailReservation.NumOfChildren} Children";
                    lblBaseRate.Text = detailReservation.BaseRate.ToString("C");
                    lblDailyRate.Text = detailReservation.DailyRate.ToString("C");
                    lblTotalPrice.Text = detailReservation.TotalPrice.ToString("C");
                    lblConfirmationNumber.Text = confirmationNumber;

                    foreach (Control child in this.Controls)
                    {
                        if (child != panel1)
                        {
                            child.Enabled = false;
                        }
                    }
                }
            }
        }

        private void dgvReservation_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex > 0 && e.ColumnIndex < 7)
            {
                DataGridView grid = (DataGridView)sender;
                SortOrder sortOrder = SortOrder.None;

                if (grid.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None ||
                    grid.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Ascending)
                {
                    sortOrder = SortOrder.Descending;
                }
                else
                {
                    sortOrder = SortOrder.Ascending;
                }

                Sort(grid.Columns[e.ColumnIndex].Name, sortOrder);
                grid.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = sortOrder;
            }
        }

        private void btnDetailClose_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            foreach (Control child in this.Controls)
            {
                if (child != panel1)
                {
                    child.Enabled = true;
                }
            }
        }

        private void frmViewReservation_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((MainForm)this.MdiParent).RefreshParent();
        }

        #region Private Methods

        private void GenerateDataGridView()
        {
            ReservationService service = new ReservationService();
            summaryReservations = service.GetReservationList();

            dgvReservation.DataSource = summaryReservations;

            totalCount = summaryReservations.Count();
            ((MainForm)this.MdiParent).StatusLabel2.Text = $"Total Results: {totalCount}";

            dgvReservation.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvReservation.Columns[0].HeaderText = "Reservation Date";
            dgvReservation.Columns[1].HeaderText = "Check In Date";
            dgvReservation.Columns[2].HeaderText = "Check Out Date";
            dgvReservation.Columns[3].HeaderText = "Room Number";
            dgvReservation.Columns[4].HeaderText = "Guest's Last Name";
            dgvReservation.Columns[5].HeaderText = "Confirmation Number";
            dgvReservation.AutoResizeColumns();

            DataGridViewButtonColumn dgvBtnDetail = new DataGridViewButtonColumn();
            dgvReservation.Columns.Insert(dgvReservation.Columns.Count, dgvBtnDetail);
            dgvBtnDetail.HeaderText = "Detail";
            dgvBtnDetail.Text = "View";
            dgvBtnDetail.Name = "btnDetail";
            dgvBtnDetail.UseColumnTextForButtonValue = true;

        }
        private void Sort(string column, SortOrder sortOrder)
        {
            switch (column)
            {
                case "ReservationDate":
                    if (sortOrder == SortOrder.Ascending)
                    {
                        dgvReservation.DataSource = summaryReservations.OrderBy(r => r.ReservationDate).ToList();
                    }
                    else
                    {
                        dgvReservation.DataSource = summaryReservations.OrderByDescending(r => r.ReservationDate).ToList();
                    }
                    break;
                case "CheckInDate":
                    if (sortOrder == SortOrder.Ascending)
                    {
                        dgvReservation.DataSource = summaryReservations.OrderBy(r => r.CheckInDate).ToList();
                    }
                    else
                    {
                        dgvReservation.DataSource = summaryReservations.OrderByDescending(r => r.CheckInDate).ToList();
                    }
                    break;
                case "CheckOutDate":
                    if (sortOrder == SortOrder.Ascending)
                    {
                        dgvReservation.DataSource = summaryReservations.OrderBy(r => r.CheckOutDate).ToList();
                    }
                    else
                    {
                        dgvReservation.DataSource = summaryReservations.OrderByDescending(r => r.CheckOutDate).ToList();
                    }
                    break;
                case "RoomNumber":
                    if (sortOrder == SortOrder.Ascending)
                    {
                        dgvReservation.DataSource = summaryReservations.OrderBy(r => r.RoomNumber).ToList();
                    }
                    else
                    {
                        dgvReservation.DataSource = summaryReservations.OrderByDescending(r => r.RoomNumber).ToList();
                    }
                    break;
                case "GuestLastName":
                    if (sortOrder == SortOrder.Ascending)
                    {
                        dgvReservation.DataSource = summaryReservations.OrderBy(r => r.GuestLastName).ToList();
                    }
                    else
                    {
                        dgvReservation.DataSource = summaryReservations.OrderByDescending(r => r.GuestLastName).ToList();
                    }
                    break;
                case "ConfirmationNumber":
                    if (sortOrder == SortOrder.Ascending)
                    {
                        dgvReservation.DataSource = summaryReservations.OrderBy(r => r.ConfirmationNumber).ToList();
                    }
                    else
                    {
                        dgvReservation.DataSource = summaryReservations.OrderByDescending(r => r.ConfirmationNumber).ToList();
                    }
                    break;
            }
        }

        private bool isNumeric(string value)
        {
            return int.TryParse(value, out int number);
        }



        #endregion

    }
}
