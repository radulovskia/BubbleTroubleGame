namespace BubbleTroubleGame
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelPauseMenu = new System.Windows.Forms.Panel();
            this.btnLvlEditor = new System.Windows.Forms.Button();
            this.btnExitToDesktop = new System.Windows.Forms.Button();
            this.btnExitToMenu = new System.Windows.Forms.Button();
            this.btnResume = new System.Windows.Forms.Button();
            this.panelPauseMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panelPauseMenu
            // 
            this.panelPauseMenu.Controls.Add(this.btnLvlEditor);
            this.panelPauseMenu.Controls.Add(this.btnExitToDesktop);
            this.panelPauseMenu.Controls.Add(this.btnExitToMenu);
            this.panelPauseMenu.Controls.Add(this.btnResume);
            this.panelPauseMenu.Enabled = false;
            this.panelPauseMenu.Location = new System.Drawing.Point(180, 68);
            this.panelPauseMenu.Name = "panelPauseMenu";
            this.panelPauseMenu.Size = new System.Drawing.Size(235, 286);
            this.panelPauseMenu.TabIndex = 0;
            this.panelPauseMenu.Visible = false;
            // 
            // btnLvlEditor
            // 
            this.btnLvlEditor.BackColor = System.Drawing.Color.Firebrick;
            this.btnLvlEditor.Font = new System.Drawing.Font("Stencil", 12.25F);
            this.btnLvlEditor.ForeColor = System.Drawing.Color.White;
            this.btnLvlEditor.Location = new System.Drawing.Point(36, 190);
            this.btnLvlEditor.Name = "btnLvlEditor";
            this.btnLvlEditor.Size = new System.Drawing.Size(164, 52);
            this.btnLvlEditor.TabIndex = 0;
            this.btnLvlEditor.Text = "LEVEL EDITOR";
            this.btnLvlEditor.UseVisualStyleBackColor = false;
            this.btnLvlEditor.Click += new System.EventHandler(this.btnLvlEditor_Click);
            // 
            // btnExitToDesktop
            // 
            this.btnExitToDesktop.BackColor = System.Drawing.Color.Firebrick;
            this.btnExitToDesktop.Font = new System.Drawing.Font("Stencil", 12.25F);
            this.btnExitToDesktop.ForeColor = System.Drawing.Color.White;
            this.btnExitToDesktop.Location = new System.Drawing.Point(36, 137);
            this.btnExitToDesktop.Name = "btnExitToDesktop";
            this.btnExitToDesktop.Size = new System.Drawing.Size(164, 47);
            this.btnExitToDesktop.TabIndex = 0;
            this.btnExitToDesktop.Text = "EXIT TO DESKTOP";
            this.btnExitToDesktop.UseVisualStyleBackColor = false;
            this.btnExitToDesktop.Click += new System.EventHandler(this.btnExitToDesktop_Click);
            // 
            // btnExitToMenu
            // 
            this.btnExitToMenu.BackColor = System.Drawing.Color.Firebrick;
            this.btnExitToMenu.Font = new System.Drawing.Font("Stencil", 12.25F);
            this.btnExitToMenu.ForeColor = System.Drawing.Color.White;
            this.btnExitToMenu.Location = new System.Drawing.Point(36, 84);
            this.btnExitToMenu.Name = "btnExitToMenu";
            this.btnExitToMenu.Size = new System.Drawing.Size(164, 47);
            this.btnExitToMenu.TabIndex = 0;
            this.btnExitToMenu.Text = "EXIT TO MENU";
            this.btnExitToMenu.UseVisualStyleBackColor = false;
            this.btnExitToMenu.Click += new System.EventHandler(this.btnExitToMenu_Click);
            // 
            // btnResume
            // 
            this.btnResume.BackColor = System.Drawing.Color.Firebrick;
            this.btnResume.Font = new System.Drawing.Font("Stencil", 12.25F);
            this.btnResume.ForeColor = System.Drawing.Color.White;
            this.btnResume.Location = new System.Drawing.Point(36, 31);
            this.btnResume.Name = "btnResume";
            this.btnResume.Size = new System.Drawing.Size(164, 47);
            this.btnResume.TabIndex = 0;
            this.btnResume.Text = "RESUME";
            this.btnResume.UseVisualStyleBackColor = false;
            this.btnResume.Click += new System.EventHandler(this.btnResume_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BubbleTroubleGame.Properties.Resources.bg2;
            this.ClientSize = new System.Drawing.Size(584, 441);
            this.Controls.Add(this.panelPauseMenu);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.panelPauseMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panelPauseMenu;
        private System.Windows.Forms.Button btnLvlEditor;
        private System.Windows.Forms.Button btnExitToDesktop;
        private System.Windows.Forms.Button btnExitToMenu;
        private System.Windows.Forms.Button btnResume;
    }
}

