
namespace Aplicacion
{
    partial class FrmPrincipal
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
            this.btnNuevoCliente = new System.Windows.Forms.Button();
            this.btnAgregarProducto = new System.Windows.Forms.Button();
            this.btnBorrarTodo = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lstCarrito = new System.Windows.Forms.ListBox();
            this.btnCargarCliente = new System.Windows.Forms.Button();
            this.txtClienteActualNombre = new System.Windows.Forms.TextBox();
            this.txtClienteActualApellido = new System.Windows.Forms.TextBox();
            this.txtClienteActualDni = new System.Windows.Forms.TextBox();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.lblCarrito = new System.Windows.Forms.Label();
            this.btnFinalizarCompra = new System.Windows.Forms.Button();
            this.txtClienteActualPuntos = new System.Windows.Forms.TextBox();
            this.txtClienteActualTipo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTotalCarrito = new System.Windows.Forms.Label();
            this.lstHistorialCompras = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbOrdenarHistorial = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnGestionarCatalogo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNuevoCliente
            // 
            this.btnNuevoCliente.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNuevoCliente.Location = new System.Drawing.Point(13, 27);
            this.btnNuevoCliente.Name = "btnNuevoCliente";
            this.btnNuevoCliente.Size = new System.Drawing.Size(188, 50);
            this.btnNuevoCliente.TabIndex = 0;
            this.btnNuevoCliente.Text = "Nuevo Cliente";
            this.btnNuevoCliente.UseVisualStyleBackColor = true;
            this.btnNuevoCliente.Click += new System.EventHandler(this.btnNuevoCliente_Click);
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAgregarProducto.Location = new System.Drawing.Point(450, 27);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(308, 50);
            this.btnAgregarProducto.TabIndex = 2;
            this.btnAgregarProducto.Text = "Agregar Producto al Carrito";
            this.btnAgregarProducto.UseVisualStyleBackColor = true;
            this.btnAgregarProducto.Click += new System.EventHandler(this.btnAgregarProducto_Click);
            // 
            // btnBorrarTodo
            // 
            this.btnBorrarTodo.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBorrarTodo.Location = new System.Drawing.Point(231, 467);
            this.btnBorrarTodo.Name = "btnBorrarTodo";
            this.btnBorrarTodo.Size = new System.Drawing.Size(188, 45);
            this.btnBorrarTodo.TabIndex = 6;
            this.btnBorrarTodo.Text = "Borrar Todo";
            this.btnBorrarTodo.UseVisualStyleBackColor = true;
            this.btnBorrarTodo.Click += new System.EventHandler(this.btnBorrarTodo_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSalir.Location = new System.Drawing.Point(450, 467);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(188, 45);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lstCarrito
            // 
            this.lstCarrito.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstCarrito.FormattingEnabled = true;
            this.lstCarrito.ItemHeight = 25;
            this.lstCarrito.Location = new System.Drawing.Point(13, 195);
            this.lstCarrito.Name = "lstCarrito";
            this.lstCarrito.Size = new System.Drawing.Size(698, 229);
            this.lstCarrito.TabIndex = 4;
            // 
            // btnCargarCliente
            // 
            this.btnCargarCliente.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCargarCliente.Location = new System.Drawing.Point(231, 27);
            this.btnCargarCliente.Name = "btnCargarCliente";
            this.btnCargarCliente.Size = new System.Drawing.Size(188, 50);
            this.btnCargarCliente.TabIndex = 1;
            this.btnCargarCliente.Text = "Cargar Cliente";
            this.btnCargarCliente.UseVisualStyleBackColor = true;
            this.btnCargarCliente.Click += new System.EventHandler(this.btnCargarCliente_Click);
            // 
            // txtClienteActualNombre
            // 
            this.txtClienteActualNombre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtClienteActualNombre.Location = new System.Drawing.Point(13, 123);
            this.txtClienteActualNombre.Name = "txtClienteActualNombre";
            this.txtClienteActualNombre.PlaceholderText = "Nombre";
            this.txtClienteActualNombre.ReadOnly = true;
            this.txtClienteActualNombre.Size = new System.Drawing.Size(177, 29);
            this.txtClienteActualNombre.TabIndex = 10;
            this.txtClienteActualNombre.TabStop = false;
            this.txtClienteActualNombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtClienteActualApellido
            // 
            this.txtClienteActualApellido.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtClienteActualApellido.Location = new System.Drawing.Point(206, 123);
            this.txtClienteActualApellido.Name = "txtClienteActualApellido";
            this.txtClienteActualApellido.PlaceholderText = "Apellido";
            this.txtClienteActualApellido.ReadOnly = true;
            this.txtClienteActualApellido.Size = new System.Drawing.Size(177, 29);
            this.txtClienteActualApellido.TabIndex = 11;
            this.txtClienteActualApellido.TabStop = false;
            this.txtClienteActualApellido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtClienteActualDni
            // 
            this.txtClienteActualDni.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtClienteActualDni.Location = new System.Drawing.Point(398, 123);
            this.txtClienteActualDni.Name = "txtClienteActualDni";
            this.txtClienteActualDni.PlaceholderText = "DNI";
            this.txtClienteActualDni.ReadOnly = true;
            this.txtClienteActualDni.Size = new System.Drawing.Size(177, 29);
            this.txtClienteActualDni.TabIndex = 12;
            this.txtClienteActualDni.TabStop = false;
            this.txtClienteActualDni.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnBorrar
            // 
            this.btnBorrar.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBorrar.Location = new System.Drawing.Point(13, 467);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(188, 45);
            this.btnBorrar.TabIndex = 5;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // lblCarrito
            // 
            this.lblCarrito.AutoSize = true;
            this.lblCarrito.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCarrito.Location = new System.Drawing.Point(13, 167);
            this.lblCarrito.Name = "lblCarrito";
            this.lblCarrito.Size = new System.Drawing.Size(79, 25);
            this.lblCarrito.TabIndex = 14;
            this.lblCarrito.Text = "Carrito:";
            // 
            // btnFinalizarCompra
            // 
            this.btnFinalizarCompra.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnFinalizarCompra.Location = new System.Drawing.Point(1033, 467);
            this.btnFinalizarCompra.Name = "btnFinalizarCompra";
            this.btnFinalizarCompra.Size = new System.Drawing.Size(188, 45);
            this.btnFinalizarCompra.TabIndex = 8;
            this.btnFinalizarCompra.Text = "Finalizar Compra";
            this.btnFinalizarCompra.UseVisualStyleBackColor = true;
            this.btnFinalizarCompra.Click += new System.EventHandler(this.btnFinalizarCompra_Click);
            // 
            // txtClienteActualPuntos
            // 
            this.txtClienteActualPuntos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtClienteActualPuntos.Location = new System.Drawing.Point(786, 123);
            this.txtClienteActualPuntos.Name = "txtClienteActualPuntos";
            this.txtClienteActualPuntos.PlaceholderText = "Puntos";
            this.txtClienteActualPuntos.ReadOnly = true;
            this.txtClienteActualPuntos.Size = new System.Drawing.Size(177, 29);
            this.txtClienteActualPuntos.TabIndex = 16;
            this.txtClienteActualPuntos.TabStop = false;
            this.txtClienteActualPuntos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtClienteActualTipo
            // 
            this.txtClienteActualTipo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtClienteActualTipo.Location = new System.Drawing.Point(594, 123);
            this.txtClienteActualTipo.Name = "txtClienteActualTipo";
            this.txtClienteActualTipo.PlaceholderText = "Tipo";
            this.txtClienteActualTipo.ReadOnly = true;
            this.txtClienteActualTipo.Size = new System.Drawing.Size(177, 29);
            this.txtClienteActualTipo.TabIndex = 17;
            this.txtClienteActualTipo.TabStop = false;
            this.txtClienteActualTipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(13, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(206, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 19;
            this.label2.Text = "Apellido:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(398, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 17);
            this.label3.TabIndex = 20;
            this.label3.Text = "DNI:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(594, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 17);
            this.label4.TabIndex = 21;
            this.label4.Text = "Tipo de Cliente:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(786, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 17);
            this.label5.TabIndex = 22;
            this.label5.Text = "Puntos:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(13, 427);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 25);
            this.label6.TabIndex = 23;
            this.label6.Text = "TOTAL :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalCarrito
            // 
            this.lblTotalCarrito.AutoSize = true;
            this.lblTotalCarrito.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalCarrito.Location = new System.Drawing.Point(83, 427);
            this.lblTotalCarrito.Name = "lblTotalCarrito";
            this.lblTotalCarrito.Size = new System.Drawing.Size(39, 25);
            this.lblTotalCarrito.TabIndex = 24;
            this.lblTotalCarrito.Text = "$ 0";
            // 
            // lstHistorialCompras
            // 
            this.lstHistorialCompras.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstHistorialCompras.FormattingEnabled = true;
            this.lstHistorialCompras.ItemHeight = 17;
            this.lstHistorialCompras.Location = new System.Drawing.Point(727, 199);
            this.lstHistorialCompras.Name = "lstHistorialCompras";
            this.lstHistorialCompras.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstHistorialCompras.Size = new System.Drawing.Size(494, 225);
            this.lstHistorialCompras.TabIndex = 25;
            this.lstHistorialCompras.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(727, 171);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(197, 25);
            this.label7.TabIndex = 26;
            this.label7.Text = "Hitorial de compras: ";
            // 
            // cmbOrdenarHistorial
            // 
            this.cmbOrdenarHistorial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrdenarHistorial.FormattingEnabled = true;
            this.cmbOrdenarHistorial.Location = new System.Drawing.Point(1116, 173);
            this.cmbOrdenarHistorial.Name = "cmbOrdenarHistorial";
            this.cmbOrdenarHistorial.Size = new System.Drawing.Size(105, 23);
            this.cmbOrdenarHistorial.TabIndex = 9;
            this.cmbOrdenarHistorial.SelectedIndexChanged += new System.EventHandler(this.cmbOrdenarHistorial_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(1008, 173);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 23);
            this.label8.TabIndex = 28;
            this.label8.Text = "Ordenar Por :";
            // 
            // btnGestionarCatalogo
            // 
            this.btnGestionarCatalogo.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGestionarCatalogo.Location = new System.Drawing.Point(1022, 27);
            this.btnGestionarCatalogo.Name = "btnGestionarCatalogo";
            this.btnGestionarCatalogo.Size = new System.Drawing.Size(199, 50);
            this.btnGestionarCatalogo.TabIndex = 29;
            this.btnGestionarCatalogo.Text = "Gestionar Catalogo";
            this.btnGestionarCatalogo.UseVisualStyleBackColor = true;
            this.btnGestionarCatalogo.Click += new System.EventHandler(this.btnGestionarCatalogo_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1233, 524);
            this.Controls.Add(this.btnGestionarCatalogo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbOrdenarHistorial);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lstHistorialCompras);
            this.Controls.Add(this.lblTotalCarrito);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtClienteActualTipo);
            this.Controls.Add(this.txtClienteActualPuntos);
            this.Controls.Add(this.btnFinalizarCompra);
            this.Controls.Add(this.lblCarrito);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.txtClienteActualDni);
            this.Controls.Add(this.txtClienteActualApellido);
            this.Controls.Add(this.txtClienteActualNombre);
            this.Controls.Add(this.btnCargarCliente);
            this.Controls.Add(this.lstCarrito);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnBorrarTodo);
            this.Controls.Add(this.btnAgregarProducto);
            this.Controls.Add(this.btnNuevoCliente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "     ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPrincipal_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNuevoCliente;
        private System.Windows.Forms.Button btnAgregarProducto;
        private System.Windows.Forms.Button btnBorrarTodo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ListBox lstCarrito;
        private System.Windows.Forms.Button btnCargarCliente;
        private System.Windows.Forms.TextBox txtClienteActualNombre;
        private System.Windows.Forms.TextBox txtClienteActualApellido;
        private System.Windows.Forms.TextBox txtClienteActualDni;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Label lblCarrito;
        private System.Windows.Forms.Button btnFinalizarCompra;
        private System.Windows.Forms.TextBox txtClienteActualPuntos;
        private System.Windows.Forms.TextBox txtClienteActualTipo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTotalCarrito;
        private System.Windows.Forms.ListBox lstHistorialCompras;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbOrdenarHistorial;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnGestionarCatalogo;
    }
}

