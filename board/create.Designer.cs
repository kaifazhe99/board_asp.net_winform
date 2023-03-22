namespace board
{
    partial class create
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
            this.site_kind = new System.Windows.Forms.TextBox();
            this.site_code = new System.Windows.Forms.TextBox();
            this.site_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.use_yn = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // site_kind
            // 
            this.site_kind.Location = new System.Drawing.Point(77, 32);
            this.site_kind.Name = "site_kind";
            this.site_kind.Size = new System.Drawing.Size(100, 21);
            this.site_kind.TabIndex = 0;
            // 
            // site_code
            // 
            this.site_code.Location = new System.Drawing.Point(77, 78);
            this.site_code.Name = "site_code";
            this.site_code.Size = new System.Drawing.Size(100, 21);
            this.site_code.TabIndex = 1;
            // 
            // site_name
            // 
            this.site_name.Location = new System.Drawing.Point(77, 118);
            this.site_name.Name = "site_name";
            this.site_name.Size = new System.Drawing.Size(100, 21);
            this.site_name.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "제품타입";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "제품코드";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "사이트명";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "사용여부";
            // 
            // use_yn
            // 
            this.use_yn.Location = new System.Drawing.Point(77, 154);
            this.use_yn.Name = "use_yn";
            this.use_yn.Size = new System.Drawing.Size(100, 21);
            this.use_yn.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(128, 247);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 28);
            this.button1.TabIndex = 10;
            this.button1.Text = "작성완료";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.postBtnClick);
            // 
            // create
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.use_yn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.site_name);
            this.Controls.Add(this.site_code);
            this.Controls.Add(this.site_kind);
            this.Name = "create";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox site_kind;
        private System.Windows.Forms.TextBox site_code;
        private System.Windows.Forms.TextBox site_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox use_yn;
        private System.Windows.Forms.Button button1;
    }
}