using System.Windows.Forms;

namespace Coursework
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            menuStrip1 = new MenuStrip();
            справочникиToolStripMenuItem = new ToolStripMenuItem();
            аудиторныйФондToolStripMenuItem = new ToolStripMenuItem();
            преподавателиToolStripMenuItem = new ToolStripMenuItem();
            факультетыToolStripMenuItem = new ToolStripMenuItem();
            кафедрыToolStripMenuItem = new ToolStripMenuItem();
            предметыToolStripMenuItem = new ToolStripMenuItem();
            scheduleToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { справочникиToolStripMenuItem, scheduleToolStripMenuItem, aboutToolStripMenuItem, exitToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(932, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // справочникиToolStripMenuItem
            // 
            справочникиToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { аудиторныйФондToolStripMenuItem, преподавателиToolStripMenuItem, факультетыToolStripMenuItem, кафедрыToolStripMenuItem, предметыToolStripMenuItem });
            справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            справочникиToolStripMenuItem.Size = new Size(117, 24);
            справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // аудиторныйФондToolStripMenuItem
            // 
            аудиторныйФондToolStripMenuItem.Name = "аудиторныйФондToolStripMenuItem";
            аудиторныйФондToolStripMenuItem.Size = new Size(224, 26);
            аудиторныйФондToolStripMenuItem.Text = "Аудиторный фонд";
            аудиторныйФондToolStripMenuItem.Click += аудиторныйФондToolStripMenuItem_Click;
            // 
            // преподавателиToolStripMenuItem
            // 
            преподавателиToolStripMenuItem.Name = "преподавателиToolStripMenuItem";
            преподавателиToolStripMenuItem.Size = new Size(224, 26);
            преподавателиToolStripMenuItem.Text = "Преподаватели";
            преподавателиToolStripMenuItem.Click += преподавателиToolStripMenuItem_Click;
            // 
            // факультетыToolStripMenuItem
            // 
            факультетыToolStripMenuItem.Name = "факультетыToolStripMenuItem";
            факультетыToolStripMenuItem.Size = new Size(224, 26);
            факультетыToolStripMenuItem.Text = "Факультеты";
            факультетыToolStripMenuItem.Click += факультетыToolStripMenuItem_Click;
            // 
            // кафедрыToolStripMenuItem
            // 
            кафедрыToolStripMenuItem.Name = "кафедрыToolStripMenuItem";
            кафедрыToolStripMenuItem.Size = new Size(224, 26);
            кафедрыToolStripMenuItem.Text = "Кафедры";
            кафедрыToolStripMenuItem.Click += кафедрыToolStripMenuItem_Click;
            // 
            // предметыToolStripMenuItem
            // 
            предметыToolStripMenuItem.Name = "предметыToolStripMenuItem";
            предметыToolStripMenuItem.Size = new Size(224, 26);
            предметыToolStripMenuItem.Text = "Предметы";
            предметыToolStripMenuItem.Click += предметыToolStripMenuItem_Click;
            // 
            // scheduleToolStripMenuItem
            // 
            scheduleToolStripMenuItem.Name = "scheduleToolStripMenuItem";
            scheduleToolStripMenuItem.Size = new Size(105, 24);
            scheduleToolStripMenuItem.Text = "Расписание";
            scheduleToolStripMenuItem.Click += scheduleToolStripMenuItem_Click;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(178, 24);
            aboutToolStripMenuItem.Text = "Справка о программе";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(67, 24);
            exitToolStripMenuItem.Text = "Выход";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(932, 503);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Главная программа";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem scheduleToolStripMenuItem;
        private ToolStripMenuItem справочникиToolStripMenuItem;
        private ToolStripMenuItem аудиторныйФондToolStripMenuItem;
        private ToolStripMenuItem преподавателиToolStripMenuItem;
        private ToolStripMenuItem факультетыToolStripMenuItem;
        private ToolStripMenuItem предметыToolStripMenuItem;
        private ToolStripMenuItem кафедрыToolStripMenuItem;
    }
}
