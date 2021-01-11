namespace Keyboard__
{
    partial class SettingsForms
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
            this.btn_addBind = new System.Windows.Forms.Button();
            this.btn_deleteBind = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_keyboard = new System.Windows.Forms.ComboBox();
            this.btn_addKeyboard = new System.Windows.Forms.Button();
            this.btn_deleteKeyboard = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.modifierBindControl1 = new Keyboard__.ModifierBindControl();
            this.btn_other = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_addBind
            // 
            this.btn_addBind.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_addBind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addBind.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_addBind.Location = new System.Drawing.Point(67, 90);
            this.btn_addBind.Name = "btn_addBind";
            this.btn_addBind.Size = new System.Drawing.Size(25, 25);
            this.btn_addBind.TabIndex = 1;
            this.btn_addBind.Text = "+";
            this.btn_addBind.UseVisualStyleBackColor = false;
            this.btn_addBind.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_deleteBind
            // 
            this.btn_deleteBind.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_deleteBind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_deleteBind.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_deleteBind.Location = new System.Drawing.Point(98, 90);
            this.btn_deleteBind.Name = "btn_deleteBind";
            this.btn_deleteBind.Size = new System.Drawing.Size(25, 25);
            this.btn_deleteBind.TabIndex = 2;
            this.btn_deleteBind.Text = "-";
            this.btn_deleteBind.UseVisualStyleBackColor = false;
            this.btn_deleteBind.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_save.Location = new System.Drawing.Point(327, 91);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(88, 25);
            this.btn_save.TabIndex = 3;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(8, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Keyboard:";
            // 
            // cmb_keyboard
            // 
            this.cmb_keyboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmb_keyboard.FormattingEnabled = true;
            this.cmb_keyboard.Location = new System.Drawing.Point(114, 12);
            this.cmb_keyboard.Name = "cmb_keyboard";
            this.cmb_keyboard.Size = new System.Drawing.Size(120, 28);
            this.cmb_keyboard.TabIndex = 7;
            this.cmb_keyboard.Text = "1";
            this.cmb_keyboard.SelectedIndexChanged += new System.EventHandler(this.cmb_keyboard_SelectedIndexChanged);
            // 
            // btn_addKeyboard
            // 
            this.btn_addKeyboard.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_addKeyboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addKeyboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_addKeyboard.Location = new System.Drawing.Point(240, 14);
            this.btn_addKeyboard.Name = "btn_addKeyboard";
            this.btn_addKeyboard.Size = new System.Drawing.Size(25, 25);
            this.btn_addKeyboard.TabIndex = 9;
            this.btn_addKeyboard.Text = "+";
            this.btn_addKeyboard.UseVisualStyleBackColor = false;
            this.btn_addKeyboard.Click += new System.EventHandler(this.btn_addKeyboard_Click);
            // 
            // btn_deleteKeyboard
            // 
            this.btn_deleteKeyboard.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_deleteKeyboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_deleteKeyboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_deleteKeyboard.Location = new System.Drawing.Point(271, 14);
            this.btn_deleteKeyboard.Name = "btn_deleteKeyboard";
            this.btn_deleteKeyboard.Size = new System.Drawing.Size(25, 25);
            this.btn_deleteKeyboard.TabIndex = 10;
            this.btn_deleteKeyboard.Text = "-";
            this.btn_deleteKeyboard.UseVisualStyleBackColor = false;
            this.btn_deleteKeyboard.Click += new System.EventHandler(this.btn_deleteKeyboard_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(8, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Binds:";
            // 
            // modifierBindControl1
            // 
            this.modifierBindControl1.Location = new System.Drawing.Point(12, 52);
            this.modifierBindControl1.Name = "modifierBindControl1";
            this.modifierBindControl1.Size = new System.Drawing.Size(222, 26);
            this.modifierBindControl1.TabIndex = 4;
            // 
            // btn_other
            // 
            this.btn_other.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_other.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_other.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_other.Location = new System.Drawing.Point(327, 60);
            this.btn_other.Name = "btn_other";
            this.btn_other.Size = new System.Drawing.Size(88, 25);
            this.btn_other.TabIndex = 12;
            this.btn_other.Text = "Other";
            this.btn_other.UseVisualStyleBackColor = false;
            this.btn_other.Click += new System.EventHandler(this.btn_other_Click);
            // 
            // SettingsForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(427, 315);
            this.Controls.Add(this.btn_other);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_deleteKeyboard);
            this.Controls.Add(this.btn_addKeyboard);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmb_keyboard);
            this.Controls.Add(this.modifierBindControl1);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_deleteBind);
            this.Controls.Add(this.btn_addBind);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForms";
            this.Text = "Settings";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingsForms_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_addBind;
        private System.Windows.Forms.Button btn_deleteBind;
        private System.Windows.Forms.Button btn_save;
        private ModifierBindControl modifierBindControl1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_keyboard;
        private System.Windows.Forms.Button btn_addKeyboard;
        private System.Windows.Forms.Button btn_deleteKeyboard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_other;
    }
}