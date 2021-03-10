namespace W_GUI
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
            this.button = new System.Windows.Forms.Button();
            this.listBox = new System.Windows.Forms.ListBox();
            this.textBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Web.UI.WebControls.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button
            // 
            this.button.Location = new System.Drawing.Point(194, 49);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(80, 23);
            this.button.TabIndex = 0;
            this.button.Text = "Abschuss";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // listBox
            // 
            this.listBox.BackColor = System.Drawing.SystemColors.Info;
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(54, 49);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(124, 69);
            this.listBox.TabIndex = 2;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(54, 148);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(124, 20);
            this.textBox.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.ID = null;
            this.button1.Text = "button1";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(52, 174);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(125, 32);
            this.buttonDelete.TabIndex = 4;
            this.buttonDelete.Text = "Löschen";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 214);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.button);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Web.UI.WebControls.Button button1;
        private System.Windows.Forms.Button buttonDelete;

        private System.Windows.Forms.TextBox textBox;

        private System.Windows.Forms.Button button;
        private System.Windows.Forms.ListBox listBox;

        #endregion
    }
}