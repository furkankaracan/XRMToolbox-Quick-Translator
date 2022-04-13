using System.Windows.Forms;

namespace Quick_Translator
{
    public class DataGridViewHelper
    {
        public static void AddColumn(System.Windows.Forms.DataGridView dgv, string title, int width, string lcId)
        {
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
            column.HeaderText = title;
            column.Name = lcId;
            column.Width = width;
            dgv.Columns.Add(column);
        }
    }
}
