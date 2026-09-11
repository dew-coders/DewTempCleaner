namespace DewTempCleaner
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer? components = null;

        private Label lblTitle;
        private Label lblSubtitle;

        private GroupBox groupLocations;

        private CheckBox chkUserTemp;
        private CheckBox chkWindowsTemp;

        private Label lblUserTemp;
        private Label lblWindowsTemp;

        private Button btnClean;
        private Button btnCancel;

        private ProgressBar progressBar;

        private Label lblFilesTitle;
        private Label lblFiles;

        private Label lblSpaceTitle;
        private Label lblSpace;

        private Label lblSkippedTitle;
        private Label lblSkipped;

        private Label lblStatusTitle;
        private Label lblStatus;

        protected override void Dispose(
            bool disposing)
        {
            if (disposing &&
                components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components =
                new System.ComponentModel.Container();

            lblTitle = new Label();
            lblSubtitle = new Label();

            groupLocations = new GroupBox();

            chkUserTemp = new CheckBox();
            chkWindowsTemp = new CheckBox();

            lblUserTemp = new Label();
            lblWindowsTemp = new Label();

            btnClean = new Button();
            btnCancel = new Button();

            progressBar = new ProgressBar();

            lblFilesTitle = new Label();
            lblFiles = new Label();

            lblSpaceTitle = new Label();
            lblSpace = new Label();

            lblSkippedTitle = new Label();
            lblSkipped = new Label();

            lblStatusTitle = new Label();
            lblStatus = new Label();

            groupLocations.SuspendLayout();
            SuspendLayout();

            // FORM

            AutoScaleDimensions =
                new SizeF(7F, 15F);

            AutoScaleMode =
                AutoScaleMode.Font;

            BackColor =
                Color.FromArgb(
                    18,
                    18,
                    18);

            ClientSize =
                new Size(
                    720,
                    520);

            FormBorderStyle =
                FormBorderStyle.FixedSingle;

            MaximizeBox = false;

            StartPosition =
                FormStartPosition.CenterScreen;

            Text =
                "Dew Temp Cleaner";

            Font =
                new Font(
                    "Segoe UI",
                    10F);

            // TITLE

            lblTitle.AutoSize = true;

            lblTitle.Font =
                new Font(
                    "Segoe UI",
                    24F,
                    FontStyle.Bold);

            lblTitle.ForeColor =
                Color.White;

            lblTitle.Location =
                new Point(
                    35,
                    25);

            lblTitle.Text =
                "DEW TEMP CLEANER";

            // SUBTITLE

            lblSubtitle.AutoSize = true;

            lblSubtitle.ForeColor =
                Color.FromArgb(
                    170,
                    170,
                    170);

            lblSubtitle.Location =
                new Point(
                    39,
                    70);

            lblSubtitle.Text =
                "Windows 10 / 11 temporary file cleaner";

            // LOCATIONS

            groupLocations.ForeColor =
                Color.White;

            groupLocations.Location =
                new Point(
                    35,
                    110);

            groupLocations.Size =
                new Size(
                    650,
                    150);

            groupLocations.Text =
                "Cleaning Locations";

            // USER TEMP

            chkUserTemp.AutoSize = true;

            chkUserTemp.Checked = true;

            chkUserTemp.ForeColor =
                Color.White;

            chkUserTemp.Location =
                new Point(
                    20,
                    35);

            chkUserTemp.Text =
                "User Temp";

            lblUserTemp.AutoEllipsis = true;

            lblUserTemp.ForeColor =
                Color.FromArgb(
                    150,
                    150,
                    150);

            lblUserTemp.Location =
                new Point(
                    145,
                    35);

            lblUserTemp.Size =
                new Size(
                    480,
                    25);

            // WINDOWS TEMP

            chkWindowsTemp.AutoSize = true;

            chkWindowsTemp.Checked = true;

            chkWindowsTemp.ForeColor =
                Color.White;

            chkWindowsTemp.Location =
                new Point(
                    20,
                    85);

            chkWindowsTemp.Text =
                "Windows Temp";

            lblWindowsTemp.AutoEllipsis = true;

            lblWindowsTemp.ForeColor =
                Color.FromArgb(
                    150,
                    150,
                    150);

            lblWindowsTemp.Location =
                new Point(
                    145,
                    85);

            lblWindowsTemp.Size =
                new Size(
                    480,
                    25);

            groupLocations.Controls.Add(
                chkUserTemp);

            groupLocations.Controls.Add(
                lblUserTemp);

            groupLocations.Controls.Add(
                chkWindowsTemp);

            groupLocations.Controls.Add(
                lblWindowsTemp);

            // CLEAN BUTTON

            btnClean.BackColor =
                Color.FromArgb(
                    45,
                    45,
                    45);

            btnClean.FlatStyle =
                FlatStyle.Flat;

            btnClean.ForeColor =
                Color.White;

            btnClean.Font =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold);

            btnClean.Location =
                new Point(
                    35,
                    285);

            btnClean.Size =
                new Size(
                    200,
                    50);

            btnClean.Text =
                "CLEAN TEMP";

            btnClean.UseVisualStyleBackColor =
                false;

            btnClean.Click +=
                btnClean_Click;

            // CANCEL

            btnCancel.BackColor =
                Color.FromArgb(
                    35,
                    35,
                    35);

            btnCancel.FlatStyle =
                FlatStyle.Flat;

            btnCancel.ForeColor =
                Color.White;

            btnCancel.Location =
                new Point(
                    250,
                    285);

            btnCancel.Size =
                new Size(
                    120,
                    50);

            btnCancel.Text =
                "CANCEL";

            btnCancel.Enabled =
                false;

            btnCancel.Click +=
                btnCancel_Click;

            // PROGRESS

            progressBar.Location =
                new Point(
                    35,
                    355);

            progressBar.Size =
                new Size(
                    650,
                    25);

            progressBar.Minimum = 0;

            progressBar.Maximum = 100;

            progressBar.Value = 0;

            // FILES

            lblFilesTitle.AutoSize = true;

            lblFilesTitle.ForeColor =
                Color.FromArgb(
                    150,
                    150,
                    150);

            lblFilesTitle.Location =
                new Point(
                    35,
                    400);

            lblFilesTitle.Text =
                "Files Removed";

            lblFiles.AutoSize = true;

            lblFiles.Font =
                new Font(
                    "Segoe UI",
                    12F,
                    FontStyle.Bold);

            lblFiles.ForeColor =
                Color.White;

            lblFiles.Location =
                new Point(
                    35,
                    425);

            lblFiles.Text = "0";

            // SPACE

            lblSpaceTitle.AutoSize = true;

            lblSpaceTitle.ForeColor =
                Color.FromArgb(
                    150,
                    150,
                    150);

            lblSpaceTitle.Location =
                new Point(
                    180,
                    400);

            lblSpaceTitle.Text =
                "Space Freed";

            lblSpace.AutoSize = true;

            lblSpace.Font =
                new Font(
                    "Segoe UI",
                    12F,
                    FontStyle.Bold);

            lblSpace.ForeColor =
                Color.White;

            lblSpace.Location =
                new Point(
                    180,
                    425);

            lblSpace.Text =
                "0 MB";

            // SKIPPED

            lblSkippedTitle.AutoSize = true;

            lblSkippedTitle.ForeColor =
                Color.FromArgb(
                    150,
                    150,
                    150);

            lblSkippedTitle.Location =
                new Point(
                    340,
                    400);

            lblSkippedTitle.Text =
                "Skipped";

            lblSkipped.AutoSize = true;

            lblSkipped.Font =
                new Font(
                    "Segoe UI",
                    12F,
                    FontStyle.Bold);

            lblSkipped.ForeColor =
                Color.White;

            lblSkipped.Location =
                new Point(
                    340,
                    425);

            lblSkipped.Text =
                "0";

            // STATUS

            lblStatusTitle.AutoSize = true;

            lblStatusTitle.ForeColor =
                Color.FromArgb(
                    150,
                    150,
                    150);

            lblStatusTitle.Location =
                new Point(
                    475,
                    400);

            lblStatusTitle.Text =
                "Status";

            lblStatus.AutoSize = true;

            lblStatus.Font =
                new Font(
                    "Segoe UI",
                    12F,
                    FontStyle.Bold);

            lblStatus.ForeColor =
                Color.White;

            lblStatus.Location =
                new Point(
                    475,
                    425);

            lblStatus.Text =
                "Ready";

            // ADD CONTROLS

            Controls.Add(
                lblTitle);

            Controls.Add(
                lblSubtitle);

            Controls.Add(
                groupLocations);

            Controls.Add(
                btnClean);

            Controls.Add(
                btnCancel);

            Controls.Add(
                progressBar);

            Controls.Add(
                lblFilesTitle);

            Controls.Add(
                lblFiles);

            Controls.Add(
                lblSpaceTitle);

            Controls.Add(
                lblSpace);

            Controls.Add(
                lblSkippedTitle);

            Controls.Add(
                lblSkipped);

            Controls.Add(
                lblStatusTitle);

            Controls.Add(
                lblStatus);

            groupLocations.ResumeLayout(false);
            groupLocations.PerformLayout();

            ResumeLayout(false);
            PerformLayout();
        }
    }
}