using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MatrixActions;
namespace Пр12
{
    public partial class Form1 : Form
    {
        private double[,] matrix1 = new double[0, 0], matrix2 = new double[0, 0], result = new double[0, 0];
        private void FillArray(DataGridView dataGrid, ref double[,] data)
        {
            data = new double[dataGrid.RowCount, dataGrid.ColumnCount];
            for (int y = 0; y < dataGrid.RowCount; y++)
            {
                for (int x = 0; x < dataGrid.ColumnCount; x++)
                {
                    data[y, x] = Convert.ToDouble(dataGrid[x, y].Value);
                }
            }
        }

        private void FillGrid(DataGridView dataGrid, double[,] data)
        {
            dataGrid.RowCount = data.GetLength(0);
            dataGrid.ColumnCount = data.GetLength(1);
            for (int y = 0; y < data.GetLength(0); y++)
            {
                for (int x = 0; x < data.GetLength(1); x++)
                {
                    dataGrid[x, y].Value = data[y, x];
                }
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FillArray(MatrA, ref matrix1);
            FillArray(MatrB, ref matrix2);
            result = Matrix.SumMatrix(matrix1, matrix2);
            if (result == null)
            {
                MessageBox.Show("Матрицы должны быть с одинаковым количеством столбцов и строк", "Матричный калькулятор");
                return;
            }
            FillGrid(GResult, result);
            GResult.Text = "Результат вычисления - сложение";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FillArray(MatrA, ref matrix1);
            FillArray(MatrB, ref matrix2);
            result = Matrix.SubtractMatrix(matrix1, matrix2);
            if (result == null)
            {
                MessageBox.Show("Матрицы должны быть с одинаковым количеством столбцов и строк", "Матричный калькулятор");
                return;
            }
            FillGrid(GResult, result);
            GResult.Text = "Результат вычисления - вычитание";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MatrA.ColumnCount = (int)numc.Value;
            MatrA.RowCount = (int)numr.Value;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FillArray(MatrA, ref matrix1);
            result = Matrix.MultipMatrix(matrix1, matrix2);
            FillGrid(GResult, result);
            GResult.Text = "Результат вычисления - умножение матриц";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FillArray(MatrA, ref matrix1);
            result = Matrix.ReverseMatrix(matrix1);
            FillGrid(GResult, result);
            GResult.Text = "Результат вычисления - обратная матрица";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FillArray(MatrA, ref matrix1);
            result[0, 0] = (int)Matrix.RankMatrix(matrix1);
            FillGrid(GResult, result);
            GResult.Text = "Результат вычисления - ранг матриц ";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FillArray(MatrA, ref matrix1);
            result[0, 0] = (double)Matrix.Opred(matrix1);
            FillGrid(GResult, result);
            GResult.Text = "Результат вычисления - определитель";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            FillArray(MatrA, ref matrix1);
            result = Matrix.MinorsMatrix(matrix1);
            FillGrid(GResult, result);
            GResult.Text = "Результат вычисления - минор элемента";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            FillArray(MatrA, ref matrix1);
            result = Matrix.ByNumber(matrix1, 3);
            FillGrid(GResult, result);
            GResult.Text = "Результат вычисления - транспонирование";
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button12_Click(object sender, EventArgs e) => CopyDataGrid(MatrA, MatrB);
       

        private void button13_Click(object sender, EventArgs e) => CopyDataGrid(MatrB, MatrA);




        private void button2_Click(object sender, EventArgs e)
        {
            MatrB.ColumnCount = (int)numc.Value;
            MatrB.RowCount = (int)numr.Value;
        }

        private void button14_Click(object sender, EventArgs e) => CopyDataGrid(GResult, MatrB);
      

        private void button7_Click(object sender, EventArgs e)
        {
            FillArray(MatrA, ref matrix1);
            result = Matrix.TranspMatrix(matrix1);
            FillGrid(GResult, result);
            GResult.Text = "Результат вычисления - транспонирование";
        }


        private void CopyDataGrid(DataGridView source, DataGridView destination)
        {
            destination.ColumnCount = source.ColumnCount;
            destination.RowCount = source.RowCount;
            for (int y = 0; y < destination.RowCount; y++)
            {
                for (int x = 0; x < destination.ColumnCount; x++)
                {
                    destination[y, x].Value = source[y, x].Value;
                }
            }
        }
    }
}

