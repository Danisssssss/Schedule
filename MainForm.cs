namespace Coursework
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutProgram newAboutProgram = new AboutProgram();
            newAboutProgram.ShowDialog();
        }

        private void scheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Schedule newSchedule = new Schedule();
            newSchedule.Show();
        }
    }
}
