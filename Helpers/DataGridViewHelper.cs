using System.Windows.Forms;

namespace Quick_Translator
{
    public class DataGridViewHelper
    {
        public static void AddColumn(System.Windows.Forms.DataGridView dgv, string title, int width)
        {
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
            column.HeaderText = title;
            column.Width = width;
            dgv.Columns.Add(column);
        }
    }
}
