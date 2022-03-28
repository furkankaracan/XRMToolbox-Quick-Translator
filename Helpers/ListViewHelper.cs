using System.Windows.Forms;

namespace Quick_Translator
{
    internal class ListViewHelper
    {
        public static void AddColumn(System.Windows.Forms.ListView lv, string title, int width)
        {
            ColumnHeader column = new ColumnHeader();
            column.Text = title;
            column.Width = width;
            lv.Columns.Add(column);
        }
    }
}
