using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DewTempCleaner
{
    public partial class MainForm : Form
    {
        private CancellationTokenSource? cancellationTokenSource;

        private long filesDeleted;
        private long filesSkipped;
        private long bytesFreed;

        private readonly string userTemp =
            Path.GetTempPath();

        private readonly string windowsTemp =
            Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.Windows),
                "Temp");

        public MainForm()
        {
            InitializeComponent();

            lblUserTemp.Text = userTemp;
            lblWindowsTemp.Text = windowsTemp;

            ResetStatistics();
        }

        private void ResetStatistics()
        {
            filesDeleted = 0;
            filesSkipped = 0;
            bytesFreed = 0;

            lblFiles.Text = "0";
            lblSkipped.Text = "0";
            lblSpace.Text = "0 MB";
            lblStatus.Text = "Ready";

            progressBar.Value = 0;
        }

        private async void btnClean_Click(
            object? sender,
            EventArgs e)
        {
            if (cancellationTokenSource != null)
                return;

            if (!chkUserTemp.Checked &&
                !chkWindowsTemp.Checked)
            {
                MessageBox.Show(
                    "Please select at least one cleaning location.",
                    "Dew Temp Cleaner",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult result = MessageBox.Show(
                "Dew Temp Cleaner will attempt to remove " +
                "temporary files.\n\n" +

                "Locked files and protected files will be skipped.\n\n" +

                "Do you want to continue?",

                "Start Cleaning",

                MessageBoxButtons.YesNo,

                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            ResetStatistics();

            btnClean.Enabled = false;
            btnCancel.Enabled = true;

            cancellationTokenSource =
                new CancellationTokenSource();

            try
            {
                lblStatus.Text = "Cleaning...";

                List<string> locations = new();

                if (chkUserTemp.Checked)
                    locations.Add(userTemp);

                if (chkWindowsTemp.Checked)
                    locations.Add(windowsTemp);

                await CleanLocationsAsync(
                    locations,
                    cancellationTokenSource.Token);

                if (cancellationTokenSource.IsCancellationRequested)
                {
                    lblStatus.Text = "Cancelled";
                }
                else
                {
                    progressBar.Value = 100;

                    lblStatus.Text = "Completed";

                    MessageBox.Show(
                        "Cleaning completed!\n\n" +

                        $"Files removed: {filesDeleted:N0}\n" +

                        $"Space freed: " +
                        $"{FormatBytes(bytesFreed)}\n\n" +

                        $"Skipped files: " +
                        $"{filesSkipped:N0}",

                        "Dew Temp Cleaner",

                        MessageBoxButtons.OK,

                        MessageBoxIcon.Information);
                }
            }
            catch (OperationCanceledException)
            {
                lblStatus.Text = "Cancelled";
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error";

                MessageBox.Show(
                    "An unexpected error occurred.\n\n" +
                    ex.Message,

                    "Dew Temp Cleaner",

                    MessageBoxButtons.OK,

                    MessageBoxIcon.Error);
            }
            finally
            {
                cancellationTokenSource?.Dispose();

                cancellationTokenSource = null;

                btnClean.Enabled = true;
                btnCancel.Enabled = false;
            }
        }

        private async Task CleanLocationsAsync(
            List<string> locations,
            CancellationToken token)
        {
            await Task.Run(() =>
            {
                foreach (string location in locations)
                {
                    token.ThrowIfCancellationRequested();

                    if (!Directory.Exists(location))
                        continue;

                    CleanDirectory(
                        location,
                        token);
                }

            }, token);
        }

        private void CleanDirectory(
            string directory,
            CancellationToken token)
        {
            token.ThrowIfCancellationRequested();

            string[] files;

            try
            {
                files = Directory.GetFiles(
                    directory,
                    "*",
                    SearchOption.TopDirectoryOnly);
            }
            catch
            {
                Interlocked.Increment(
                    ref filesSkipped);

                UpdateStatistics();

                return;
            }

            int total = files.Length;

            for (int i = 0; i < total; i++)
            {
                token.ThrowIfCancellationRequested();

                TryDeleteFile(files[i]);

                int progress =
                    total == 0
                        ? 100
                        : (i + 1) * 100 / total;

                UpdateProgress(progress);
            }

            string[] directories;

            try
            {
                directories = Directory.GetDirectories(
                    directory,
                    "*",
                    SearchOption.TopDirectoryOnly);
            }
            catch
            {
                return;
            }

            foreach (string subDirectory in directories)
            {
                token.ThrowIfCancellationRequested();

                CleanDirectory(
                    subDirectory,
                    token);

                TryDeleteDirectory(
                    subDirectory);
            }
        }

        private void TryDeleteFile(string file)
        {
            try
            {
                if (!File.Exists(file))
                    return;

                long size = 0;

                try
                {
                    FileInfo info = new FileInfo(file);

                    size = info.Length;
                }
                catch
                {
                }

                try
                {
                    File.SetAttributes(
                        file,
                        FileAttributes.Normal);
                }
                catch
                {
                }

                File.Delete(file);

                Interlocked.Increment(
                    ref filesDeleted);

                Interlocked.Add(
                    ref bytesFreed,
                    size);
            }
            catch
            {
                Interlocked.Increment(
                    ref filesSkipped);
            }

            UpdateStatistics();
        }

        private void TryDeleteDirectory(
            string directory)
        {
            try
            {
                if (!Directory.Exists(directory))
                    return;

                Directory.Delete(
                    directory,
                    false);
            }
            catch
            {
                // Directory still contains
                // locked/protected files.
            }
        }

        private void UpdateStatistics()
        {
            if (InvokeRequired)
            {
                BeginInvoke(
                    new Action(
                        UpdateStatistics));

                return;
            }

            lblFiles.Text =
                filesDeleted.ToString("N0");

            lblSkipped.Text =
                filesSkipped.ToString("N0");

            lblSpace.Text =
                FormatBytes(bytesFreed);
        }

        private void UpdateProgress(
            int value)
        {
            if (InvokeRequired)
            {
                BeginInvoke(
                    new Action(() =>
                    {
                        progressBar.Value =
                            Math.Max(
                                0,
                                Math.Min(
                                    100,
                                    value));
                    }));

                return;
            }

            progressBar.Value =
                Math.Max(
                    0,
                    Math.Min(
                        100,
                        value));
        }

        private void btnCancel_Click(
            object? sender,
            EventArgs e)
        {
            cancellationTokenSource?.Cancel();

            lblStatus.Text =
                "Cancelling...";

            btnCancel.Enabled = false;
        }

        private static string FormatBytes(
            long bytes)
        {
            if (bytes < 1024)
                return $"{bytes} B";

            if (bytes < 1024 * 1024)
                return $"{bytes / 1024.0:F2} KB";

            if (bytes < 1024L * 1024L * 1024L)
                return
                    $"{bytes / 1024.0 / 1024.0:F2} MB";

            return
                $"{bytes / 1024.0 / 1024.0 / 1024.0:F2} GB";
        }
    }
}