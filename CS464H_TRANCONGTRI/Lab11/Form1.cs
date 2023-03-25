﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Lab11
{
	public partial class Form1 : Form
	{
		Connection lopchung = new Connection();
		string duongdan = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Resources\";
		public Form1()
		{
			InitializeComponent();
		}

		public void LoadNV()
		{
			string sql = "Select * from KHACHHANG";
			DataTable table = lopchung.getData(sql);
			dataGridView1.DataSource = table;
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			OpenFileDialog open = new OpenFileDialog();
			open.Title = "Hãy chọn ảnh khách hàng";
			open.Filter = "JPEG|*.JPEG|PNG|*.PNG|JPG|*.JPG|BMP|*.bmp|Tất cả ảnh|*.*";
			if (open.ShowDialog() == DialogResult.OK)
			{
				pictureBox1.Image = Image.FromFile(open.FileName);
			}
		}

		private void btn_Them_Click(object sender, EventArgs e)
		{
			string sql = "Insert into KHACHHANG values(N'" + txt_MaKhachHang.Text + "',N'"
+ txt_HoVaTen.Text + "',N'" + txt_Tuoi.Text + "',N'" + txt_HinhAnh.Text + "')";
            int ketqua = lopchung.setData(sql);
            if (ketqua >= 1)
            {
                MessageBox.Show("Thêm thành công");
                pictureBox1.Image.Save(duongdan + txt_HinhAnh.Text);
            }
            else MessageBox.Show("Thêm thất bại");
            LoadNV();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			LoadNV();
		}

		private void btn_Xoa_Click(object sender, EventArgs e)
		{
			string sql = "Delete from KHACHHANG where MaKH = N'" + txt_MaKhachHang.Text + "'";
			int ketqua = lopchung.setData(sql);
			if (ketqua >= 1)
			{
				MessageBox.Show("Xóa thành công");
			}
			else MessageBox.Show("Xóa thất bại");
			LoadNV();
		}

		private void btn_Sua_Click(object sender, EventArgs e)
		{
			string sql = "Update KHACHHANG set HoTen = N'" + txt_HoVaTen.Text + "',Tuoi = N'" + txt_Tuoi.Text + "',HinhAnh = N'" + txt_HinhAnh.Text + "' where MaKH = N'" + txt_MaKhachHang.Text + "'";
			int ketqua = lopchung.setData(sql);
			if (ketqua >= 1)
			{
				MessageBox.Show("Sửa thành công");
				pictureBox1.Image.Save(duongdan + txt_HinhAnh.Text);
			}
			else MessageBox.Show("Sửa thất bại");
			LoadNV();
		}
	}
}
