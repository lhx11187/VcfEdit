using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Globalization;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace VcfEdit
{
    public partial class FormMain : Form
    {
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);

        public DataTable myTable = new DataTable("phone");
        public DataSet dataSet = new DataSet();

        string filename;

        DataRow[] foundRows;
        DataTable dt = new DataTable();
        bool bCellDirty = false;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

            ExportVCFtoolStripButton.Enabled = false;
            ExportExceltoolStripButton.Enabled = false;
            toolStripSearch.Enabled = false;
        }

        public  string ConvertHexToString(string hexstring, Encoding encode)
        {
            try
            {
                if (hexstring == null || hexstring.Equals("")) return "";
                if (hexstring.StartsWith("=")) hexstring = hexstring.Substring(1);
                string[] aHex = hexstring.Split(new char[1] { '=' });
                byte[] abyte = new Byte[aHex.Length];

                for (int i = 0; i < abyte.Length; i++)
                {
                     abyte[i] = (byte)int.Parse(aHex[i], NumberStyles.HexNumber);
                }
                return encode.GetString(abyte);
            }
            catch
            {
                return hexstring;
            }
        }

        public string ConvertToUTF8String(string hexstring)
        {
            string mystring=null;
            foreach (byte mybyte in Encoding.UTF8.GetBytes(hexstring))
                mystring += "=" + mybyte.ToString("X2");

            return mystring;
        }
        private void 打开OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DataGridViewTextBoxColumn dgvColumn;

            //openFileDialog1.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog1.Filter = "Vcf files (*.vcf)|*.vcf|Excel files (*.xls)|*.xls|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                dataGridView1.DataSource = null;
                dataGridView1.Update();

                myTable = new DataTable();
                filename = openFileDialog1.FileName;

                #region "打开VCF文件"
                if (openFileDialog1.FilterIndex == 1)
                {
                    ExportExceltoolStripButton.Enabled = true;
                    ExportVCFtoolStripButton.Enabled = false;

                    System.IO.StreamReader sr = new System.IO.StreamReader(filename);

                    string name;
                    DataRow row;

                    string s = "";

                    row = myTable.NewRow();

                    int line = 0;
                    int IndexTel = 0;
                    int IndexTelWork = 0;

                    string longstring = null;

                    while ((s = sr.ReadLine()) != null)
                    {
                        // 判断最后一个字符是否为"="号
                        // 判读第一个字符是否为"="号
                        if (s.EndsWith("="))
                        {
                            if (longstring == null)
                            {
                                s = s.Substring(0, s.Length - 1);
                                longstring = s;
                            }
                            else
                            { 
                                s = s.Substring(0, s.Length - 1);
                                longstring = longstring + s;
                            }

                            continue;
                        }
                        if(longstring != null)
                        {
                            if (s.StartsWith("="))
                                s = longstring + s;
                            else
                                s = longstring;

                            longstring = null;
                        }

                        string[] split = s.Split(new char[] { ':' });

                        if (split.Length > 1)
                        {
                            if (split[0].Contains("BEGIN"))
                            {
                                line = 0;
                                //row = table.NewRow();
                            }
                            if (split[0].Contains("FN"))
                            {
                                if (split[0].Contains("FN;CHARSET=UTF-8"))
                                {
                                    if (split[0].Contains("ENCODING=QUOTED-PRINTABLE"))
                                        name = ConvertHexToString(split[1], Encoding.UTF8);
                                    else
                                        name = split[1];

                                    if (!myTable.Columns.Contains("姓名"))
                                        myTable.Columns.Add("姓名", typeof(string));

                                    row = myTable.NewRow();
                                    row["姓名"] = name;
                                }
                                else
                                {
                                    if (split[0].Contains("ENCODING=QUOTED-PRINTABLE"))
                                        name = ConvertHexToString(split[1], Encoding.UTF8);
                                    else
                                        name = split[1];

                                    if (!myTable.Columns.Contains("姓名"))
                                        myTable.Columns.Add("姓名", typeof(string));

                                    row = myTable.NewRow();
                                    row["姓名"] = name;
                                }
                            }

                            if (split[0].Contains("X-OPPO-GROUP;CHARSET=UTF-8"))
                            {
                                if (!myTable.Columns.Contains("群组"))
                                    myTable.Columns.Add("群组", typeof(string));

                                row["群组"] = ConvertHexToString(split[1], Encoding.UTF8);
                            }

                            if ((split[0] == "TEL;CELL;PREF") || (split[0] == "TEL;CELL"))
                            {
                                IndexTel++;

                                if (!myTable.Columns.Contains("手机" + IndexTel.ToString()))
                                    myTable.Columns.Add("手机" + IndexTel.ToString(), typeof(string));
                                row["手机" + IndexTel.ToString()] = split[1];
                            }

                            if ((split[0] == "TEL;WORK;VOICE") || (split[0] == "TEL;WORK"))
                            {
                                IndexTelWork++;

                                if (!myTable.Columns.Contains("办公电话" + IndexTelWork.ToString()))
                                    myTable.Columns.Add("办公电话" + IndexTelWork.ToString(), typeof(string));
                                row["办公电话" + IndexTelWork.ToString()] = split[1];
                            }
                            if ((split[0] == "TEL;HOME;VOICE") || (split[0] == "TEL;HOME"))
                            {
                                if (!myTable.Columns.Contains("住宅电话"))
                                    myTable.Columns.Add("住宅电话", typeof(string));
                                row["住宅电话"] = split[1];
                            }
                            if (split[0] == "EMAIL;WORK")
                            {
                                if (!myTable.Columns.Contains("工作邮箱"))
                                    myTable.Columns.Add("工作邮箱", typeof(string));
                                row["工作邮箱"] = split[1];
                            }
                            if (split[0] == "EMAIL;HOME")
                            {
                                if (!myTable.Columns.Contains("家庭邮箱"))
                                    myTable.Columns.Add("家庭邮箱", typeof(string));
                                row["家庭邮箱"] = split[1];
                            }
                            if (split[0] == "ADR;HOME;CHARSET=UTF-8;ENCODING=QUOTED-PRINTABLE")
                            {
                                string addr;

                                addr = split[1].Trim(';');
                                addr = ConvertHexToString(addr, Encoding.UTF8);

                                if (!myTable.Columns.Contains("家庭地址"))
                                    myTable.Columns.Add("家庭地址", typeof(string));
                                row["家庭地址"] = addr;
                            }
                            if (split[0] == "ADR;WORK;CHARSET=UTF-8;ENCODING=QUOTED-PRINTABLE")
                            {
                                string addr=null;

                                string[] addrs;

                                addrs = split[1].Split(new char[] { ';' });

                                for (int x = addrs.Length; x > 0; x--)
                                   addr += addrs[x-1] ;



                                //addr = split[1].Replace(";",""); 
                                addr = ConvertHexToString(addr, Encoding.UTF8);

                                if (!myTable.Columns.Contains("单位地址"))
                                    myTable.Columns.Add("单位地址", typeof(string));
                                row["单位地址"] = addr;
                            }
                            if (split[0] == "ORG;CHARSET=UTF-8;ENCODING=QUOTED-PRINTABLE")
                            {
                                string addr;
                                addr = split[1].Trim(';');
                                addr = ConvertHexToString(addr, Encoding.UTF8);

                                if (!myTable.Columns.Contains("公司"))
                                    myTable.Columns.Add("公司", typeof(string));
                                row["公司"] = addr;
                            }

                            if ((split[0] == "END")) // || (split[0] == "END:VCARD"))
                            {
                                line = 0;
                                IndexTel = 0;
                                IndexTelWork = 0;

                                myTable.Rows.Add(row);
                                myTable.AcceptChanges();
                            }
                        }

                        longstring = null;
                    } 

                    sr.Close();

                    toolStripSearch.Enabled = true;
                }
                #endregion
                #region "打开Excel文件"
                else if (openFileDialog1.FilterIndex == 2)
                {
                    ExportExceltoolStripButton.Enabled = false;
                    ExportVCFtoolStripButton.Enabled = true;

                    Excel.Application excel = new Excel.Application();
                    Excel.Workbook book = excel.Application.Workbooks.Add(filename);

                    foreach (Excel._Worksheet sheet in book.Sheets)
                    {
                        if (sheet.Name == "通讯录")
                        {
                            DataRow row;
                            //row = myTable.NewRow();

                            FormReading fr = new FormReading();
                            fr.Label1.Text = @"正在读取Excel文件";
                            fr.Owner = this;
                            Point point = this.Location;
                            fr.StartPosition = FormStartPosition.Manual;
                            fr.Size = new Size(300, 100);
                            fr.Location = new Point(point.X + (this.Size.Width - fr.Size.Width) / 2, point.Y + (this.Size.Height - fr.Size.Height) / 2);
                            fr.Show();

                            int ColIndex = 1;
                            int ColNum = 1; // 列数
                            int r = 2;

                            while (sheet.Cells[1, ColIndex].value != null)
                            {

                                if (!myTable.Columns.Contains(sheet.Cells[1, ColIndex].value))
                                    myTable.Columns.Add(sheet.Cells[1, ColIndex].value, typeof(string));

                                ColIndex++;
                            }
                            
                            ColNum = ColIndex - 1;

                            while(sheet.Cells[r,1].value != null)
                            {
                                row = myTable.NewRow();

                                for (ColIndex = 1; ColIndex <= ColNum; ColIndex++)
                                    row[sheet.Cells[1, ColIndex].value] = sheet.Cells[r, ColIndex].value;

                                myTable.Rows.Add(row);
                                r++;
                            }

                            StatusLabel1.Image = VcfEdit.Properties.Resources.export_vcard;
                            fr.Close();

                        }
                    }

                } 
                #endregion

                StatusLabel1.Text = myTable.Rows.Count  + "个联系人。";
                dataSet.Tables.Add(myTable);

                // Use the Select method to find all rows matching the filter.
                foundRows = myTable.Select();

                //foreach (DataRow row in foundRows)
                //    dt.ImportRow(row);

                int i=0;
                for(i=0;i<myTable.Columns.Count;i++)
                {
                    dgvColumn = new DataGridViewTextBoxColumn();
                    dgvColumn.DataPropertyName = myTable.Columns[i].ColumnName;
                    dgvColumn.HeaderText = myTable.Columns[i].ColumnName;
                    dgvColumn.Name = myTable.Columns[i].ColumnName;
                    dataGridView1.Columns.Add(dgvColumn);
                }
                dataGridView1.DataSource = myTable;
                dataGridView1.Update();
                dataGridView1.AllowUserToAddRows = false;

                toolStripSearch.Enabled = true;
                myTable.ColumnChanged += new DataColumnChangeEventHandler(OnColumnChanged);
            }

        }

        protected static void OnColumnChanged(Object sender, DataColumnChangeEventArgs args)
        {

        }

        private void 退出XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void CreateWorkbook(string filePath)
        {
            Excel.Application excelApp = null;
            Excel.Workbook wkbk;
            Excel.Worksheet sheet;

            try
            {
                // Start Excel and create a workbook and worksheet.
                excelApp = new Excel.Application();
                wkbk = excelApp.Workbooks.Add();
                sheet = wkbk.Sheets.Add() as Excel.Worksheet;
                sheet.Name = "通讯录";

                // Write a column of values.
                // In the For loop, both the row index and array index start at 1.
                // Therefore the value of 4 at array index 0 is not included.

                dt = (DataTable)dataGridView1.DataSource;
                DataRow[] drs = dt.Select();

                int i = 2;
                int numColumn = dt.Columns.Count; // 列数
                int iColumn = 0;

                for (iColumn = 1; iColumn <= numColumn;iColumn++ )
                {
                    sheet.Cells[1, iColumn] = dt.Columns[iColumn-1].ToString();
                }

                foreach (DataRow dr in drs)
                {
                    for (iColumn = 1; iColumn <= numColumn;iColumn++ )
                    {
                        sheet.Cells[i, iColumn] = dr[iColumn-1];
                    }

                    i++;
                }

                // Suppress any alerts and save the file. Create the directory 
                // if it does not exist. Overwrite the file if it exists.

                excelApp.DisplayAlerts = false;
                
                wkbk.SaveAs(filePath);
            }
            catch
            {

            }
            finally
            {
                sheet = null;
                wkbk = null;

                // Close Excel.
                Kill(excelApp);
            }
        }

        public static void Kill(Excel.Application excel)   
        {   
            IntPtr t = new IntPtr(excel.Hwnd);   //得到这个句柄，具体作用是得到这块内存入口    
  
            int k = 0;   
            GetWindowThreadProcessId(t, out k);   //得到本进程唯一标志k   
            Process p = System.Diagnostics.Process.GetProcessById(k);   //得到对进程k的引用   
            p.Kill();     //关闭进程k   
    
        }   

        public void CreateVcffile(string filePath)
        {
            using (System.IO.FileStream fs = System.IO.File.Create(filePath))
            {
                DataRow[] drs = myTable.Select();
                StreamWriter swFromFileStream = new StreamWriter(fs);

                foreach (DataRow dr in drs)
                {
                    swFromFileStream.WriteLine("BEGIN:VCARD");
                    swFromFileStream.WriteLine("VERSION:2.1");

                    for (int i = 0; i < myTable.Columns.Count; i++)
                    {
                        switch(myTable.Columns[i].ColumnName)
                        {
                            case "姓名":
                                swFromFileStream.WriteLine("N;CHARSET=UTF-8;ENCODING=QUOTED-PRINTABLE:;" + ConvertToUTF8String(dr[i].ToString()) + ";;;");
                                swFromFileStream.WriteLine("FN;CHARSET=UTF-8;ENCODING=QUOTED-PRINTABLE:" + ConvertToUTF8String(dr[i].ToString()));
                                break;
                            case "手机1":
                                if (dr[i].ToString() != "")
                                    swFromFileStream.WriteLine("TEL;CELL:" + dr[i]);
                                break;
                            case "手机2":
                                if (dr[i].ToString() != "")
                                    swFromFileStream.WriteLine("TEL;CELL:" + dr[i]);
                                break;
                            case "手机3":
                                if (dr[i].ToString() != "")
                                    swFromFileStream.WriteLine("TEL;CELL:" + dr[i]);
                                break;
                            case "住宅电话":
                                if (dr[i].ToString() != "")
                                    swFromFileStream.WriteLine("TEL;HOME:" + dr[i]);
                                break;
                            case "办公电话1":
                                if (dr[i].ToString() != "")swFromFileStream.WriteLine("TEL;WORK:" + dr[i]);
                                break;
                            case "群组":
                                if (dr[i].ToString() != "") swFromFileStream.WriteLine("X-OPPO-GROUP;CHARSET=UTF-8;ENCODING=QUOTED-PRINTABLE:" + ConvertToUTF8String(dr[i].ToString()));
                                break;
                            case "家庭邮箱":
                                if (dr[i].ToString() != "") swFromFileStream.WriteLine("EMAIL;HOME:" + dr[i]);
                                break;
                            case "工作邮箱":
                                if (dr[i].ToString() != "") swFromFileStream.WriteLine("EMAIL;WORK:" + dr[i]);
                                break;
                            case "家庭地址":
                                if (dr[i].ToString() != "") swFromFileStream.WriteLine("ADR;HOME;CHARSET=UTF-8;ENCODING=QUOTED-PRINTABLE:;;" +  ConvertToUTF8String(dr[i].ToString()));
                                break;
                            case "单位地址":
                                if (dr[i].ToString() != "") swFromFileStream.WriteLine("ADR;WORK;CHARSET=UTF-8;ENCODING=QUOTED-PRINTABLE:;;" + ConvertToUTF8String(dr[i].ToString()));
                                break;
                            case "公司":
                                if (dr[i].ToString() != "") swFromFileStream.WriteLine("ORG;CHARSET=UTF-8;ENCODING=QUOTED-PRINTABLE:" +  ConvertToUTF8String(dr[i].ToString()));
                                break;
                        }   
                    }
                    swFromFileStream.WriteLine("END:VCARD");
                }
                swFromFileStream.Flush();
                swFromFileStream.Close();
            }
        }

        private void ExportExceltoolStripButton_Click(object sender, EventArgs e)
        {
            if (myTable.Rows.Count != 0)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "Excel files (*.xls)|*.xls";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string filename;

                    FormReading fr = new FormReading();
                    fr.Label1.Text = @"正在导出数据,生成Excel文件";
                    fr.Owner = this;
                    Point point = this.Location;
                    fr.StartPosition = FormStartPosition.Manual;
                    fr.Size = new Size(300, 100);
                    fr.Location = new Point(point.X + (this.Size.Width - fr.Size.Width) / 2, point.Y + (this.Size.Height - fr.Size.Height) / 2);
                    fr.Show();

                    filename = saveFileDialog1.FileName;
                    CreateWorkbook(filename);

                    fr.Close();
                }
            }
        }

        private void ExportVCFtoolStripButton_Click(object sender, EventArgs e)
        {
            if (myTable.Rows.Count != 0)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "Vcf files (*.vcf)|*.vcf";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string filename;

                    filename = saveFileDialog1.FileName;
                    CreateVcffile(filename);
                }
            }
        }

        private void 关于VcfEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 abox = new AboutBox1();
            abox.ShowDialog();
        }

        private void toolStripSearch_TextChanged(object sender, EventArgs e)
        {
            string expression;

            expression = "姓名 like '%" + toolStripSearch.Text.Trim() + "%'";

            DataTable dt_temp = new DataTable();

            for(int i=0;i<myTable.Columns.Count;i++)
                if (!dt_temp.Columns.Contains(myTable.Columns[i].ColumnName))
                    dt_temp.Columns.Add(myTable.Columns[i].ColumnName, typeof(string));

            // Use the Select method to find all rows matching the filter.
            foundRows = myTable.Select(expression);

            foreach (DataRow row in foundRows)
                dt_temp.ImportRow(row);


            dataGridView1.DataSource = null;
            dataGridView1.Update();

            dt = dt_temp;

            dataGridView1.DataSource = dt;
            dataGridView1.AllowUserToAddRows = true;

            StatusLabel1.Text =dt.Rows.Count + "个联系人。";
        }

        private void SavetoolStripButton_Click(object sender, EventArgs e)
        {
            // 将更改写回当前文件
            // 即将当前myTable的内容写文件

            DataTableReader dtr = myTable.CreateDataReader();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // 更新dataSet
            DataGridViewRow  row = new DataGridViewRow();

            int i=0;
            i = dataGridView1.RowCount;
            row = dataGridView1.Rows[i - 2];
            dataSet.Tables[0].Rows.Add(row);
        }

        private void dataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {

        }

        private void dataGridView1_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            int i = 10;
            i = i + 10;
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int i = 10;
            i = i + 10;
        }

        private void dataGridView1_CurrentCellDirtyStateChanged_1(object sender, EventArgs e)
        {
            bCellDirty = true;
            SavetoolStripButton.Enabled = true;
        }
    }
}
