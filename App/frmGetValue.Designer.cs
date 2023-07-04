namespace App
{
    partial class frmGetValue
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
            txtMessage = new System.Windows.Forms.Label();
            txtValue = new System.Windows.Forms.TextBox();
            button1 = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // txtMessage
            // 
            txtMessage.AutoSize = true;
            txtMessage.Location = new System.Drawing.Point(231, 44);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new System.Drawing.Size(38, 15);
            txtMessage.TabIndex = 0;
            txtMessage.Text = "label1";
            // 
            // txtValue
            // 
            txtValue.Location = new System.Drawing.Point(69, 62);
            txtValue.Name = "txtValue";
            txtValue.Size = new System.Drawing.Size(361, 23);
            txtValue.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(289, 91);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(206, 34);
            button1.TabIndex = 2;
            button1.Text = "Confirmar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // frmGetValue
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(507, 133);
            Controls.Add(button1);
            Controls.Add(txtValue);
            Controls.Add(txtMessage);
            Name = "frmGetValue";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "frmGetValue";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label txtMessage;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Button button1;
    }
}