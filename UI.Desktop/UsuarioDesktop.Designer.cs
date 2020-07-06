namespace UI.Desktop
{
    partial class UsuarioDesktop
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
            this.tlpUsuarioDesktop = new System.Windows.Forms.TableLayoutPanel();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.txtConfirmarClave = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.chkHabilitado = new System.Windows.Forms.CheckBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.labelID = new System.Windows.Forms.Label();
            this.labelNombre = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelClave = new System.Windows.Forms.Label();
            this.labelConfirmarClave = new System.Windows.Forms.Label();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.labelApellido = new System.Windows.Forms.Label();
            this.tlpUsuarioDesktop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpUsuarioDesktop
            // 
            this.tlpUsuarioDesktop.ColumnCount = 4;
            this.tlpUsuarioDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpUsuarioDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpUsuarioDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpUsuarioDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpUsuarioDesktop.Controls.Add(this.txtID, 1, 0);
            this.tlpUsuarioDesktop.Controls.Add(this.txtNombre, 1, 1);
            this.tlpUsuarioDesktop.Controls.Add(this.txtEmail, 1, 2);
            this.tlpUsuarioDesktop.Controls.Add(this.txtClave, 1, 3);
            this.tlpUsuarioDesktop.Controls.Add(this.txtConfirmarClave, 3, 3);
            this.tlpUsuarioDesktop.Controls.Add(this.txtUsuario, 3, 2);
            this.tlpUsuarioDesktop.Controls.Add(this.txtApellido, 3, 1);
            this.tlpUsuarioDesktop.Controls.Add(this.chkHabilitado, 2, 0);
            this.tlpUsuarioDesktop.Controls.Add(this.btnAceptar, 2, 4);
            this.tlpUsuarioDesktop.Controls.Add(this.btnCancelar, 3, 4);
            this.tlpUsuarioDesktop.Controls.Add(this.labelID, 0, 0);
            this.tlpUsuarioDesktop.Controls.Add(this.labelNombre, 0, 1);
            this.tlpUsuarioDesktop.Controls.Add(this.labelEmail, 0, 2);
            this.tlpUsuarioDesktop.Controls.Add(this.labelClave, 0, 3);
            this.tlpUsuarioDesktop.Controls.Add(this.labelConfirmarClave, 2, 3);
            this.tlpUsuarioDesktop.Controls.Add(this.labelUsuario, 2, 2);
            this.tlpUsuarioDesktop.Controls.Add(this.labelApellido, 2, 1);
            this.tlpUsuarioDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpUsuarioDesktop.Location = new System.Drawing.Point(0, 0);
            this.tlpUsuarioDesktop.Name = "tlpUsuarioDesktop";
            this.tlpUsuarioDesktop.RowCount = 5;
            this.tlpUsuarioDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpUsuarioDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpUsuarioDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpUsuarioDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpUsuarioDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpUsuarioDesktop.Size = new System.Drawing.Size(540, 144);
            this.tlpUsuarioDesktop.TabIndex = 0;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(53, 3);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(187, 20);
            this.txtID.TabIndex = 0;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(53, 29);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(187, 20);
            this.txtNombre.TabIndex = 2;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(53, 55);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(187, 20);
            this.txtEmail.TabIndex = 3;
            // 
            // txtClave
            // 
            this.txtClave.Location = new System.Drawing.Point(53, 81);
            this.txtClave.Name = "txtClave";
            this.txtClave.PasswordChar = '*';
            this.txtClave.Size = new System.Drawing.Size(187, 20);
            this.txtClave.TabIndex = 4;
            // 
            // txtConfirmarClave
            // 
            this.txtConfirmarClave.Location = new System.Drawing.Point(333, 81);
            this.txtConfirmarClave.Name = "txtConfirmarClave";
            this.txtConfirmarClave.PasswordChar = '*';
            this.txtConfirmarClave.Size = new System.Drawing.Size(187, 20);
            this.txtConfirmarClave.TabIndex = 5;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(333, 55);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(187, 20);
            this.txtUsuario.TabIndex = 6;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(333, 29);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(187, 20);
            this.txtApellido.TabIndex = 7;
            // 
            // chkHabilitado
            // 
            this.chkHabilitado.AutoSize = true;
            this.chkHabilitado.Location = new System.Drawing.Point(246, 3);
            this.chkHabilitado.Name = "chkHabilitado";
            this.chkHabilitado.Size = new System.Drawing.Size(73, 17);
            this.chkHabilitado.TabIndex = 8;
            this.chkHabilitado.Text = "Habilitado";
            this.chkHabilitado.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(246, 107);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 9;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(333, 107);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(3, 0);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(18, 13);
            this.labelID.TabIndex = 11;
            this.labelID.Text = "ID";
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Location = new System.Drawing.Point(3, 26);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(44, 13);
            this.labelNombre.TabIndex = 12;
            this.labelNombre.Text = "Nombre";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(3, 52);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(32, 13);
            this.labelEmail.TabIndex = 13;
            this.labelEmail.Text = "Email";
            // 
            // labelClave
            // 
            this.labelClave.AutoSize = true;
            this.labelClave.Location = new System.Drawing.Point(3, 78);
            this.labelClave.Name = "labelClave";
            this.labelClave.Size = new System.Drawing.Size(34, 13);
            this.labelClave.TabIndex = 14;
            this.labelClave.Text = "Clave";
            // 
            // labelConfirmarClave
            // 
            this.labelConfirmarClave.AutoSize = true;
            this.labelConfirmarClave.Location = new System.Drawing.Point(246, 78);
            this.labelConfirmarClave.Name = "labelConfirmarClave";
            this.labelConfirmarClave.Size = new System.Drawing.Size(81, 13);
            this.labelConfirmarClave.TabIndex = 15;
            this.labelConfirmarClave.Text = "Confirmar Clave";
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Location = new System.Drawing.Point(246, 52);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(43, 13);
            this.labelUsuario.TabIndex = 16;
            this.labelUsuario.Text = "Usuario";
            // 
            // labelApellido
            // 
            this.labelApellido.AutoSize = true;
            this.labelApellido.Location = new System.Drawing.Point(246, 26);
            this.labelApellido.Name = "labelApellido";
            this.labelApellido.Size = new System.Drawing.Size(44, 13);
            this.labelApellido.TabIndex = 17;
            this.labelApellido.Text = "Apellido";
            // 
            // UsuarioDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 144);
            this.Controls.Add(this.tlpUsuarioDesktop);
            this.Name = "UsuarioDesktop";
            this.Text = "Usuario";
            this.tlpUsuarioDesktop.ResumeLayout(false);
            this.tlpUsuarioDesktop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpUsuarioDesktop;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.TextBox txtConfirmarClave;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.CheckBox chkHabilitado;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelClave;
        private System.Windows.Forms.Label labelConfirmarClave;
        private System.Windows.Forms.Label labelUsuario;
        private System.Windows.Forms.Label labelApellido;
    }
}