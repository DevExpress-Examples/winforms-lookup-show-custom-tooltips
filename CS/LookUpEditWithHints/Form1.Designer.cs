namespace LookUpEditWithHints
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
            this.lookUpEditHints1 = new LookUpEditWithHints.LookUpEditHints();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditHints1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lookUpEditHints1
            // 
            this.lookUpEditHints1.DescriptionField = "";
            this.lookUpEditHints1.Location = new System.Drawing.Point(47, 12);
            this.lookUpEditHints1.Name = "lookUpEditHints1";
            this.lookUpEditHints1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditHints1.Properties.DescriptionField = "";
            this.lookUpEditHints1.Size = new System.Drawing.Size(100, 20);
            this.lookUpEditHints1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 100);
            this.Controls.Add(this.lookUpEditHints1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditHints1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private LookUpEditHints lookUpEditHints1;

    }
}

