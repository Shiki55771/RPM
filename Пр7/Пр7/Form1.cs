﻿using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Пр7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

         private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form2 AddRec = new Form2();

            AddRec.Owner = this;
            AddRec.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            listBox1.BeginUpdate();

            string[] Strings = richTextBox1.Text.Split(new char[] { '\n', '\t', ' ' },
            StringSplitOptions.RemoveEmptyEntries);

            foreach (string s in Strings)
            {
                string Str = s.Trim();

                if (Str == String.Empty) continue;
                if (radioButton1.Checked) listBox1.Items.Add(Str);
                if (radioButton2.Checked)
                {
                    if (Regex.IsMatch(Str, @"\d")) listBox1.Items.Add(Str);
                }
                if (radioButton3.Checked)
                {
                    if (Regex.IsMatch(Str, @"\w+@\w+\.\w+")) listBox1.Items.Add(Str);

                }
            }
            listBox1.EndUpdate();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenDlg = new OpenFileDialog();
            SaveFileDialog SaveDlg = new SaveFileDialog();
            {
                if (OpenDlg.ShowDialog() == DialogResult.OK)
                {
                    StreamReader Reader = new StreamReader(OpenDlg.FileName, Encoding.Default);
                    richTextBox1.Text = Reader.ReadToEnd();
                    Reader.Close();
                }
                OpenDlg.Dispose();
            }
               if (SaveDlg.ShowDialog() == DialogResult.OK)
                {
                  StreamWriter Writer = new StreamWriter(SaveDlg.FileName);
                  for (int i = 0; i < listBox2.Items.Count; i++)
                  {
                    Writer.WriteLine((string)listBox2.Items[i]);
                  }
                    Writer.Close();
               }
            SaveDlg.Dispose();
         } 

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();

            string Find = textBox1.Text;

            if (checkBox1.Checked)
            {
                foreach (string String in listBox1.Items)
                {
                    if (String.Contains(Find)) listBox3.Items.Add(String);
                }
            }
            if (checkBox2.Checked)
            {
                foreach (string String in listBox2.Items)
                {
                    if (String.Contains(Find)) listBox3.Items.Add(String);
                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.BeginUpdate();
            string biggest = "";
            List<string> sorted = new List<string>();
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    listBox1.Sorted = true;
                    listBox1.Sorted = false;
                    break;
                case 1:
                    foreach (string element in listBox1.Items) sorted.Add(element);
                    listBox1.Items.Clear();
                    sorted.Sort();
                    sorted.Reverse();
                    listBox1.Items.AddRange(sorted.ToArray());
                    sorted.Clear();
                    break;
                case 2:
                    for (int i = listBox1.Items.Count; i > 0; i--)
                    {
                        foreach (string element in listBox1.Items) if (element.Length > biggest.Length) biggest = element;
                        sorted.Add(biggest);
                        listBox1.Items.Remove(biggest);
                        biggest = "";
                    }
                    sorted.Reverse();
                    listBox1.Items.AddRange(sorted.ToArray());
                    sorted.Clear();
                    break;
                case 3:
                    for (int i = listBox1.Items.Count; i > 0; i--)
                    {
                        foreach (string element in listBox1.Items) if (element.Length > biggest.Length) biggest = element;
                        sorted.Add(biggest);
                        listBox1.Items.Remove(biggest);
                        biggest = "";
                    }
                    listBox1.Items.AddRange(sorted.ToArray());
                    sorted.Clear();
                    break;
            }
            listBox1.EndUpdate();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string Find = textBox1.Text;
            if (checkBox1.Checked) foreach (string String in listBox2.Items) if (String.Contains(Find)) listBox1.Items.Add(String);
            if (checkBox2.Checked) foreach (string String in listBox3.Items) if (String.Contains(Find)) listBox1.Items.Add(String);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listBox2.BeginUpdate();
            string[] Strings = richTextBox1.Text.Split(new char[] { '\n', '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in Strings)
            {
                string Str = s.Trim();
                if (Str == String.Empty) continue;
                if (radioButton1.Checked) listBox2.Items.Add(Str);
                if (radioButton2.Checked) if (Regex.IsMatch(Str, @"\d")) listBox2.Items.Add(Str);
                if (radioButton3.Checked) if (Regex.IsMatch(Str, @"\w+@\w+\.\w+")) listBox2.Items.Add(Str);
            }
            listBox2.EndUpdate();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            listBox2.BeginUpdate();
            string biggest = "";
            List<string> sorted = new List<string>();
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    listBox2.Sorted = true;
                    listBox2.Sorted = false;
                    break;
                case 1:
                    foreach (string element in listBox2.Items) sorted.Add(element);
                    listBox2.Items.Clear();
                    sorted.Sort();
                    sorted.Reverse();
                    listBox2.Items.AddRange(sorted.ToArray());
                    sorted.Clear();
                    break;
                case 2:
                    for (int i = listBox2.Items.Count; i > 0; i--)
                    {
                        foreach (string element in listBox2.Items) if (element.Length > biggest.Length) biggest = element;
                        sorted.Add(biggest);
                        listBox2.Items.Remove(biggest);
                        biggest = "";
                    }
                    sorted.Reverse();
                    listBox2.Items.AddRange(sorted.ToArray());
                    sorted.Clear();
                    break;
                case 3:
                    for (int i = listBox2.Items.Count; i > 0; i--)
                    {
                        foreach (string element in listBox2.Items) if (element.Length > biggest.Length) biggest = element;
                        sorted.Add(biggest);
                        listBox2.Items.Remove(biggest);
                        biggest = "";
                    }
                    listBox2.Items.AddRange(sorted.ToArray());
                    sorted.Clear();
                    break;
            }
            listBox2.EndUpdate();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
        }
        private void DeleteSelectedStrings(ListBox list)
        {
            for (int i = list.Items.Count - 1; i >= 0; i--) if (list.GetSelected(i)) list.Items.RemoveAt(i);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            for (int i = listBox1.Items.Count - 1; i >= 0; i--)
                if (listBox1.GetSelected(i))
                {
                    listBox2.Items.Add(listBox1.Items[i]);
                    listBox1.Items.RemoveAt(i);
                };
        }

        private void button12_Click(object sender, EventArgs e)
        {
            for (int i = listBox2.Items.Count - 1; i >= 0; i--)
                if (listBox2.GetSelected(i))
                {
                    listBox1.Items.Add(listBox2.Items[i]);
                    listBox2.Items.RemoveAt(i);
                };
        }

        private void button13_Click(object sender, EventArgs e)
        {
            listBox2.Items.AddRange(listBox1.Items);
            listBox1.Items.Clear();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            listBox1.Items.AddRange(listBox2.Items);
            listBox2.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        


  
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
